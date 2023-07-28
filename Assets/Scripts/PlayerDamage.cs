using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamage : MonoBehaviour
{
    [SerializeField] private float pushingForce = 2;

    private bool readyExecute = false;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Animator animator = collision.gameObject.GetComponent<Animator>();
            animator.Play("Hit");
            Rigidbody2D rb2D = collision.gameObject.GetComponent<Rigidbody2D>();
            Vector2 direction = collision.transform.position - transform.position;
            float distance = 1 + direction.magnitude;
            float finalForce = pushingForce / distance;
            collision.transform.Translate(Vector3.forward * finalForce * Time.deltaTime);
            if (!readyExecute)
            {
                readyExecute = collision.transform.parent.GetComponent<PlayerLives>().ReduceLives();
            }
        }
    }
}
