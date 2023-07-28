using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombExplotion : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private AudioSource explotion;

    [SerializeField] private float explotionRadius = 2;
    [SerializeField, Range(0, 500)] private float explotionForce = 100;

    private bool readyExecute;
    private bool exploded;

    private void Start()
    {
        readyExecute = false;
        exploded = false;
    }

    private void Update()
    {
        Invoke("InitiateExplotion", 1.5f);
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
        yield return new WaitForSeconds(0.5f);
        animator.SetBool("Explotion", true);
        Vector2 direction = collider.transform.position - transform.position;
        float distance = 1 + direction.magnitude;
        float finalForce = explotionForce / distance;
        rb2D.AddForce(direction * finalForce);

        if (!readyExecute)
        {
            if (collider.CompareTag("Player"))
            {
                readyExecute = collider.transform.parent.GetComponent<PlayerLives>().ReduceLives();
            }
            else if (collider.CompareTag("Enemy"))
            {
                readyExecute = collider.transform.parent.GetComponent<EnemyLives>().ReduceLives();
            }

        }
        if (!exploded)
        {
            explotion.Play();
            exploded = true;
        }
        Destroy(gameObject, 1.5f);
    }
}
