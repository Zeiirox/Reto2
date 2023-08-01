using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DobleJump : MonoBehaviour
{
    [SerializeField] SpriteRenderer spriteRenderer;

    [SerializeField] private float timePowerUp = 2;
    [SerializeField] private float doubleJumpForce = 2; 

    private float actualDoubleJumpForce;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            spriteRenderer.enabled = false;
            collision.gameObject.GetComponent<PlayerController>().EnableDobleJump = true;
            actualDoubleJumpForce = collision.gameObject.GetComponent<PlayerController>().DoubleJumpForce;
            collision.gameObject.GetComponent<PlayerController>().DoubleJumpForce = doubleJumpForce;
            StartCoroutine(QuitPowerUp(collision)); ;
        }
    }

    IEnumerator QuitPowerUp(Collider2D collision)
    {
        yield return new WaitForSeconds(timePowerUp);
        spriteRenderer.enabled = true;
        collision.gameObject.GetComponent<PlayerController>().EnableDobleJump = false;
        collision.gameObject.GetComponent<PlayerController>().DoubleJumpForce = actualDoubleJumpForce;
    }
}
