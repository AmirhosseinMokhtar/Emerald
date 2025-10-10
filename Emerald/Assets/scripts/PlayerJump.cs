using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    private GameController controller;
    private BlockSpawner spawner;
    public float jumpForce = 6f;           // قدرت پرش
    public float groundCheckDistance = 0.1f; // طول ریکست به سمت پایین
    public LayerMask groundLayer;          // لایه زمین

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        controller = FindObjectOfType<GameController>();
        spawner = FindObjectOfType<BlockSpawner>();
    }

    void Update()
    {
        bool isGrounded = Physics2D.Raycast(transform.position, Vector2.down, groundCheckDistance, groundLayer);
        controller.canJump = isGrounded;
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, 0f); // صفر کردن y برای پرش یکنواخت
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            SpawnRandom();
        }
    }

    void SpawnRandom()
    {
        if (spawner.prefabs.Length == 0) return; // اگر لیست خالی باشه هیچی نسازه

        // انتخاب رندوم یک پریفب از لیست
        int index = Random.Range(0, spawner.prefabs.Length);
        GameObject prefabToSpawn = spawner.prefabs[index];

        // مشخص کردن نقطه ساخت
        Vector3 position = spawner.spawnPoint != null ? spawner.spawnPoint.position : transform.position;

        // ساخت پریفب در صحنه
        Instantiate(prefabToSpawn, position, Quaternion.identity);
    }

    // برای دیدن ریکست در Scene
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawLine(transform.position, transform.position + Vector3.down * groundCheckDistance);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Cracked"))
        {
            collision.gameObject.GetComponent<Animator>().enabled = true;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            //controller.gameOver = true;
            //controller.state = GameController.GameState.gameOver;
            Debug.Log("GAME OVER");
        }
    }
}
