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
        lifeTime = waitTimeToExploit + 1f;
        Destroy(gameObject, lifeTime);
    }

    private void Update()
    {
        InitiateExplotion();
    }


    public void InitiateExplotion()
    {
        animator.Play("BombOn");
        Collider2D[] objects = Physics2D.OverlapCircleAll(transform.position, explotionRadius);
        foreach (Collider2D collider in objects)
        {
            Rigidbody2D rb2D = collider.GetComponent<Rigidbody2D>();
            if (rb2D != null)
            {
                StartCoroutine(WaveExplotion(collider, rb2D));
            }
        }

    }

    IEnumerator WaveExplotion(Collider2D collider, Rigidbody2D rb2D)
    {
        yield return new WaitForSeconds(waitTimeToExploit);
        Vector2 direction = collider.transform.position - transform.position;
        float distance = 1 + direction.magnitude;
        float finalForce = explotionForce;
        rb2D.AddForce(direction * finalForce);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explotionRadius);
    }
}
