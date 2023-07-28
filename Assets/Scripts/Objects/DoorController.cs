using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class DoorController : MonoBehaviour
{
    [SerializeField] private Animator doorAnim;
    [SerializeField] private string sceneName;

    private Animator playerAnim;

    private bool enableDoor;
    public bool EnableDoor 
    {
        get { return enableDoor; }
        set { enableDoor = value; }
    }

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

    public void PlayAnimationOut()
    {
        if (enableDoor)
        {
            playerAnim.Play("DoorOut");
        }
    }


}
