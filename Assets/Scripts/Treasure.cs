using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Treasure : MonoBehaviour
{
    public GameObject victoryPanel;
    public float delayBeforeVictoryPanel = 2.0f; 

    private bool hasCollided = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Invoke("ShowVictoryPanel", delayBeforeVictoryPanel);
        }
    }

    private void ShowVictoryPanel()
    {
    
        if (victoryPanel != null)
        {
            victoryPanel.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void GoToMainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
        
    }
}
