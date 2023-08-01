using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeTrapController : MonoBehaviour
{
    [SerializeField] private Animator animator;

    [SerializeField] private float pushingForce;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Rigidbody2D rb2D = collision.gameObject.GetComponent<Rigidbody2D>();
            animator.SetBool("Attack", true);
            collision.gameObject.transform.parent.GetComponent<PlayerLives>().ReduceLives();
            rb2D.velocity = (Vector2.up * pushingForce);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            animator.SetBool("Attack", false);
        }
    }
}
