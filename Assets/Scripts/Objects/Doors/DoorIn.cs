using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class DoorIn : MonoBehaviour
{

    [SerializeField] private Animator doorAnim;
    [SerializeField] private GameObject messagePanel = null;
    [SerializeField] private TextMeshProUGUI textMessage;
    [SerializeField] private string sceneName;

    private Animator playerAnim;
    public bool hasMessage = false;
    public bool enableDoor = false;
    public bool EnableDoor
    {
        set { enableDoor = value; }
        get { return enableDoor; }
    }

    private void Start()
    {
        if (hasMessage)
            messagePanel.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (hasMessage)
            {
                if (!Main.allObjectsCompleted && !EnemiesManager.allEnemiesDead)
                {
                    messagePanel.SetActive(true);
                    textMessage.text = "Ups! te faltan cosas por hacer (solucionar los problemas de contaminación o acabar con algun enemigo)...";
                }
                else if (!Main.allObjectsCompleted && EnemiesManager.allEnemiesDead)
                {
                    messagePanel.SetActive(true);
                    textMessage.text = "Ups! te faltan solucionar algunos problemas de contaminación.";
                }
                else if (Main.allObjectsCompleted && !EnemiesManager.allEnemiesDead)
                {
                    messagePanel.SetActive(true);
                    textMessage.text = "Ups! Tienes que acabar con todos lo enemigos.";
                }
            }

            if ((Main.allObjectsCompleted && EnemiesManager.allEnemiesDead && enableDoor) || !hasMessage)
            {
                doorAnim.SetBool("Opening", true);
                playerAnim = collision.gameObject.GetComponent<Animator>();
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (hasMessage) 
                messagePanel.SetActive(false);
            doorAnim.SetBool("Opening", false);
        }
    }

    public void SceneToEnter()
    {
        if (enableDoor)
        {
            SceneManager.LoadScene(sceneName);
        }
    }

    public void PlayAnimationIn()
    {
        if (enableDoor)
        {
            playerAnim.Play("DoorIn");
        }
    }
}
