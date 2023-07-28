using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField] private Animator animator;

    [SerializeField] private float jumpForce = 2.5f;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Rigidbody2D>().velocity = (Vector2.up * jumpForce);
            gameObject.transform.parent.GetComponent<EnemyLives>().ReduceLives();
        }
    }


    private void OnCollisionExit2D(Collision2D collision)
    {
        animator.SetBool("Idle", false);
    }
}
