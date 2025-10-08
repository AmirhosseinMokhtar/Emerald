using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int healthEnemy = 1;
    [SerializeField] private int damage = 1;
    [SerializeField] private float waitToDamageAgain = 1f;
    private PlayerController player;
    private bool isDamaging = false;

    void Start()
    {
        player = GameObject.FindObjectOfType<PlayerController>();
    }

    IEnumerator DamageToPlayer()
    {
        isDamaging = true;
        while (player != null && !player.isShielded)
        {
            player.health -= damage;
            yield return new WaitForSeconds(waitToDamageAgain);
        }
        isDamaging = false;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>() != null)
        {
            if (!player.isShielded && !isDamaging)
            {
                StartCoroutine(DamageToPlayer());
            }

            if (player.isAttacked)
            {
                if (healthEnemy > 1)
                    healthEnemy -= damage;
                else
                    Destroy(gameObject);
            }
        }
    }
}
