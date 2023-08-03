using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOut : MonoBehaviour
{
    [SerializeField] private Animator doorAnim;
    private Animator playerAnim;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            doorAnim.SetBool("Opening", true);
            playerAnim = collision.gameObject.GetComponent<Animator>();
        }
    }

    public void PlayAnimationOut()
    {
        playerAnim.Play("DoorOut");
    }
}
