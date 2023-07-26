using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class DoorController : MonoBehaviour
{
    [SerializeField] private Animator doorAnim;
    [SerializeField] private string sceneName;

    public bool enableDoor = false;

    private Animator playerAnim;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && enableDoor)
        {
            doorAnim.SetBool("Opening", true);
            playerAnim = collision.gameObject.GetComponent<Animator>();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && enableDoor)
        {
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
