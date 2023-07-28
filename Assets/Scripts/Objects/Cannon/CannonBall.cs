using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBall : MonoBehaviour
{
    [SerializeField] private bool launghToRight = true;
    [SerializeField] private float timeToDestroy = 2;
    [SerializeField] private float moveSpeed = 2;

    void Start()
    {
        Destroy(gameObject, timeToDestroy);
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 direction = launghToRight ? Vector2.right : Vector2.left;
        transform.Translate(direction * moveSpeed * Time.deltaTime);
    }
}
