using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesManager : MonoBehaviour
{

    [SerializeField] private GameObject doorEnable;
    public static bool allEnemiesDead = false;

    void Update()
    {
        EnemiesManager.allEnemiesDead = false;
        int count = gameObject.transform.childCount;
        if (count == 0)
        {
            EnemiesManager.allEnemiesDead = true;
        }
    }
}
