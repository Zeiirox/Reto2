using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesManager : MonoBehaviour
{

    [SerializeField] private GameObject doorEnable;

    private void Start()
    {
        doorEnable.GetComponent<DoorController>().EnableDoor = false;
    }

    void Update()
    {
        int count = gameObject.transform.childCount;
        if (count == 0)
        {
            doorEnable.GetComponent<DoorController>().EnableDoor = true;
        }
    }
}
