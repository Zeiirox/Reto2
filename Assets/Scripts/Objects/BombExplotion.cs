using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombExplotion : MonoBehaviour
{
    [SerializeField] private Animator animator;

    [SerializeField] private float explotionRadius = 2;
    [SerializeField, Range(0, 500)] private float explotionForce = 100;
    [SerializeField] private float waitTimeToExploit = 1.5f;
    [SerializeField] private int damage;

    private float lifeTime;

    private void Start()
    {
        //lifeTime = waitTimeToExploit + 1f;
        //Destroy(gameObject.transform.parent, lifeTime);
    }

    private void Update()
    {
        Invoke("InitiateExplotion", 1f);
    }


    public void InitiateExplotion()
    {
        animator.SetBool("On", true);
        Collider2D[] objects = Physics2D.OverlapCircleAll(transform.position, explotionRadius);
        foreach (Collider2D collider in objects)
        {
            Rigidbody2D rb2D = collider.GetComponent<Rigidbody2D>();
            if (rb2D != null)
            {
                Animator animCollider = collider.GetComponent<Animator>();
                StartCoroutine(WaveExplotion(collider, rb2D, animCollider));
            }
        }

    }

    IEnumerator WaveExplotion(Collider2D collider, Rigidbody2D rb2D, Animator animCollider)
    {
        yield return new WaitForSeconds(waitTimeToExploit);
        animator.SetBool("Explotion", true);
        Vector2 direction = collider.transform.position - transform.position;
        float distance = 1 + direction.magnitude;
        float finalForce = explotionForce / distance;
        rb2D.AddForce(direction * finalForce);
        if (collider.transform.CompareTag("Player"))
        {
            animCollider.SetBool("Hit", true);
        }
    }
}
