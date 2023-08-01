using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumperTrap : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private float jumperForce = 5;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<Rigidbody2D>().velocity = Vector2.up * jumperForce;
            collision.GetComponent<Animator>().SetInteger("State", 2);
            animator.SetBool("Jumper", true);

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            animator.SetBool("Jumper", false);
        }
    }
}
