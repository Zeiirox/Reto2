using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatformCtrl : MonoBehaviour
{

    [SerializeField] private Rigidbody2D rb2D;
    [SerializeField] private SpriteRenderer spriteRenderer;

    [SerializeField] private float timeToFall = 0.2f;
    [SerializeField] private float timeToDestroy = 0.2f;

    private Vector2 initialPosition;

    private void Start()
    {
        initialPosition = gameObject.transform.position;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine("Fall");
            Invoke("ReloadFallingPlatform", timeToDestroy);
        }
        
    }

    IEnumerator Fall()
    {
        yield return new WaitForSeconds(timeToFall);
        rb2D.bodyType = RigidbodyType2D.Dynamic;
        //Invoke("DisableFallingPlatform", timeToDestroy);
        //spriteRenderer.enabled = false;
    }

    private void ReloadFallingPlatform()
    {
        gameObject.transform.position = initialPosition;
        rb2D.bodyType = RigidbodyType2D.Kinematic;
        //spriteRenderer.enabled = true;
    }

    private void DisableFallingPlatform()
    {
        spriteRenderer.enabled = false;
    }
}
