using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombExplotion : MonoBehaviour
{
    [SerializeField] private Animator animator;

    [SerializeField] private float explotionRadius = 2;
    [SerializeField, Range(500, 1500)] private float explotionForce = 500;
    [SerializeField] private float waitTimeToExploit = 0;
    [SerializeField] private int damage;


    private float timeTrigger;

    private void Start()
    {
        timeTrigger = waitTimeToExploit;
    }

    private void Update()
    {
        timeTrigger -= Time.deltaTime;
    }
    public void InitiateExplotion()
    {
        //if (timeTrigger <= 0)
        //{
            animator.Play("BombOn");
            Collider2D[] objects = Physics2D.OverlapCircleAll(transform.position, explotionRadius);
            Debug.Log("Cuidado!!");
            foreach (Collider2D collider in objects)
            {
                Debug.Log(collider.tag);
                Rigidbody2D rb2d = collider.GetComponent<Rigidbody2D>();
                if (rb2d != null)
                {
                    Vector2 direction = collider.transform.position - transform.position;
                    float distance = 1 + direction.magnitude;
                    float finalForce = explotionForce / distance;
                    rb2d.AddForce(direction * finalForce);
                }
            }
            Destroy(gameObject);
            timeTrigger = waitTimeToExploit;
        //} 

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explotionRadius);
    }
}
