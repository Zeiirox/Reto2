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


    private float timeTrigger;
    
    // Start is called before the first frame update
    void Start()
    {
        timeTrigger = waitTime;
    }

    // Update is called once per frame
    void Update()
    {
        timeTrigger -= Time.deltaTime;
    }

    public void DropBomb(bool flipX)
    {
        if (timeTrigger < 0)
        {
            GameObject bombSpaw = flipX ? bombSpawRight : bombSpawLeft;
            GameObject bomb = Instantiate(bombPrefab, bombSpaw.transform.position, bombSpaw.transform.rotation);
            Destroy(bomb, timeToDestroyBomb);
            timeTrigger = waitTime;
        }

    }
}
