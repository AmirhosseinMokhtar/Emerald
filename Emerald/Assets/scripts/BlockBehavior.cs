using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockBehavior : MonoBehaviour
{
    public float moveDistance = 1f;         // هر بار چند واحد بره چپ
    public float moveDuration = 0.25f;      // مدت زمان حرکت (نرمی)

    [Header("Player ground check")]
    public Transform player;                // در Inspector درگ کن (یا تگ Player بگذار)
    public float groundCheckDistance = 0.12f;
    public LayerMask groundLayer;           // لایه‌ای که زمین/پلتفرم‌ها روش هستن

    bool isMoving = false;
    GameController controller;

    void Start()
    {
        // اگر player تنظیم نشده، سعی کن آبجکت با تگ "Player" رو پیدا کنی
        if (player == null)
        {
            GameObject p = GameObject.FindGameObjectWithTag("Player");
            if (p != null) player = p.transform;
        }

        controller = FindObjectOfType<GameController>();
    }

    void Update()
    {
        if (!controller.canJump)
            return;

        if (Input.GetKeyDown(KeyCode.Space) && !isMoving)
        {
            // اگر پلیر پیدا نشده، حرکت انجام نشه (امنیت)
            if (player == null) return;

            // بررسی اینکه پلیر روی زمین هست یا نه با Raycast از موقعیت پلیر به پایین
            bool playerIsGrounded = Physics2D.Raycast(player.position, Vector2.down, groundCheckDistance, groundLayer);

            if (playerIsGrounded)
            {
                Vector3 targetPos = transform.position + Vector3.left * moveDistance;
                StartCoroutine(MoveSmooth(targetPos, moveDuration));
            }
            // اگر خواستی می‌تونی اینجا صدایی بزنی یا افکت بزاری برای وقتی که حرکت مجاز نیست
        }
    }

    IEnumerator MoveSmooth(Vector3 destination, float duration)
    {
        isMoving = true;
        Vector3 start = transform.position;
        float elapsed = 0f;

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            float t = Mathf.Clamp01(elapsed / duration);
            transform.position = Vector3.Lerp(start, destination, Mathf.SmoothStep(0f, 1f, t));
            yield return null;
        }

        transform.position = destination;
        isMoving = false;
    }

    // فقط برای debug: نمایش ریکست پلیر در Scene view
    void OnDrawGizmosSelected()
    {
        if (player != null)
        {
            Gizmos.color = Color.cyan;
            Gizmos.DrawLine(player.position, player.position + Vector3.down * groundCheckDistance);
        }
    }

    public void BeingDestroyed()
    {
        Destroy(gameObject);
    }
}
