using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main : MonoBehaviour
{
    [SerializeField] private GameObject doorIn;
    [SerializeField] private float timeToDisableMessage;

    [Header("Message current level")]
    [SerializeField] private GameObject panelMessage;

    [Header("To next level")]
    [SerializeField] private int numberOfObjects = 0;
    public static bool allObjectsCompleted = false;

    private void Start()
    {
        switch (SceneManager.GetActiveScene().name)
        {
            case "Level1":
                Time.timeScale = 0;
                panelMessage.SetActive(true);
                break;
            case "Level2":
                Time.timeScale = 0;
                panelMessage.SetActive(true);
                break;
            default:
                break;
        }
    }

    private void Update()
    {
        Debug.Log(ObjectInteractionController.numberOfObjects);
        if (ObjectInteractionController.numberOfObjects == numberOfObjects)
        {
            allObjectsCompleted = true;
        }
        else
        {
            allObjectsCompleted = false;
        }

        if (allObjectsCompleted && EnemiesManager.allEnemiesDead)
        {
            doorIn.GetComponent<DoorIn>().EnableDoor = true;
        }
    }



}
