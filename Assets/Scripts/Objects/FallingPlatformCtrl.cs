using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatformCtrl : MonoBehaviour
{

    [SerializeField] private Rigidbody2D rb2D;
    [SerializeField] private float timeToFall = 0.2f;
    [SerializeField] private float timeToDestroy = 0.2f;

    private float waitTrigger;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine("Fall");
        }
        
    }

    IEnumerator Fall()
    {
        yield return new WaitForSeconds(timeToFall);
        rb2D.bodyType = RigidbodyType2D.Dynamic;
        Destroy(gameObject, timeToDestroy);
    }

}
