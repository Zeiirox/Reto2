using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{

    [SerializeField] private Animator animator;
    [SerializeField] private GameObject ballPrefab;
    [SerializeField] private Transform spawnPoint;

    [SerializeField] private float waitedToStart = 2;
    private float waitedTrigger;

    private void Start()
    {
        waitedTrigger = 0;
    }

    private void Update()
    {
        if (waitedTrigger <= 0)
        {
            animator.SetBool("Attack", true);
            Invoke("LaunchBall", 0.5f);
            waitedTrigger = waitedToStart;
        }
        else
        {
            waitedTrigger -= Time.deltaTime;
        } 
        
    }

    private void LaunchBall()
    {
        GameObject ball = Instantiate(ballPrefab, spawnPoint.position, spawnPoint.rotation);
        animator.SetBool("Attack", false);
    }
}
