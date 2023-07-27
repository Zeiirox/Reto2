using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour
{
    [SerializeField] private Transform[] wayPoints;
    [SerializeField] private float speedMove;
    [SerializeField] private float waitedPerPoint;

    private PlatformEffector2D effector2D;

    private float waitedTrigger = 0;
    private int i = 0;
    // Start is called before the first frame update
    void Start()
    {
        waitedTrigger = waitedPerPoint;
        effector2D = GetComponent<PlatformEffector2D>();

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyUp(KeyCode.DownArrow) || Input.GetKeyUp("s"))
        {
            waitedTrigger = waitedPerPoint;
        }


        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey("s"))
        {
            if (waitedTrigger <= 0)
            {
                effector2D.rotationalOffset = 180f;
                waitedTrigger = waitedPerPoint;
            }
            else
            {
                waitedTrigger -= Time.deltaTime;
            }
        }

        if (Input.GetButton("Jump"))
        {
            effector2D.rotationalOffset = 0;
        }

        transform.position = Vector2.MoveTowards(transform.position, wayPoints[i].transform.position, speedMove * Time.deltaTime);

        if (Vector2.Distance(transform.position, wayPoints[i].transform.position) < 0.1f)
        {
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
                waitedTrigger = waitedPerPoint;
            } else
            {
                waitedTrigger -= Time.deltaTime;
            }
        }


    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.parent.transform.SetParent(gameObject.transform);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.parent.transform.SetParent(null);
        }
    }
}
