using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField] private Animator animator;

    [SerializeField] private float timeToDestroy = 1;
    [SerializeField] private float jumpForce = 2.5f;
    [SerializeField] private int lifes = 2;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Rigidbody2D>().velocity = (Vector2.up * jumpForce);
            LosseLifeAndHit();
            CheckLife();
        }
    }

    private void LosseLifeAndHit()
    {
        lifes--;
        animator.Play("Hit");
    }

    private void CheckLife()
    {
        if (lifes == 0)
        {
            animator.SetBool("Dead", true);
            Invoke("EnemyDie", timeToDestroy);
        }
    }

    private void EnemyDie()
    {
        Destroy(gameObject);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        animator.SetBool("Idle", false);
    }
}
