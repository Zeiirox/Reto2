using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropBombs : MonoBehaviour
{
    [SerializeField] private GameObject bombSpawLeft;
    [SerializeField] private GameObject bombSpawRight;
    [SerializeField] private GameObject bombPrefab;
    [SerializeField] private float timeToDestroyBomb = 2f;
    [SerializeField] private float waitTime = 0;

    private float timeTrigger = 0;

    void Update()
    {
        timeTrigger -= Time.deltaTime;
    }

    public void DropBomb(bool flipX)
    {
        if (timeTrigger < 0)
        {
            GameObject bombSpaw = flipX ? bombSpawLeft : bombSpawRight;
            GameObject bomb = Instantiate(bombPrefab, bombSpaw.transform.position, bombSpaw.transform.rotation);
            timeTrigger = waitTime;
            Destroy(bomb, timeToDestroyBomb);
        }
    }
}
