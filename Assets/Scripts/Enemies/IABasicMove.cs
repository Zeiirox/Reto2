using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IABasicMove : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Transform[] wayPoints;
    [SerializeField] private float speedMove = 0.5f;
    [SerializeField] private float startWaitTime = 2;
    [SerializeField] private bool left;

    private Vector2 actualPosition;

    private float waitedTrigger;
    private int i = 0;

    private void Start()
    {
        waitedTrigger = startWaitTime;
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, wayPoints[i].transform.position, speedMove * Time.deltaTime);

        if (Vector2.Distance(transform.position, wayPoints[i].transform.position) < 0.1f)
        {
            StartCoroutine(CheckTurnAround());
            if (waitedTrigger <= 0)
            {
                if (wayPoints[i] != wayPoints[wayPoints.Length - 1])
                {
                    i++;
                }
                else
                {
                    i = 0;
                }
                waitedTrigger = startWaitTime;
            }
            else
            {
                waitedTrigger -= Time.deltaTime;
            }
        }
    }

    IEnumerator CheckTurnAround()
    {
        actualPosition = transform.position;
        yield return new WaitForSeconds(0.5f);
        if (transform.position.x > actualPosition.x)
        {
            spriteRenderer.flipX = !left;
            animator.SetBool("Idle", false);
        }
        else if (transform.position.x < actualPosition.x)
        {
            spriteRenderer.flipX = left;
            animator.SetBool("Idle", false);
        }
        else if (transform.position.x == actualPosition.x)
        {
            animator.SetBool("Idle", true);
        }
    }
}
