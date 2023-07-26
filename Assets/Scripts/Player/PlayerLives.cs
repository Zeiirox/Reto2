using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerLives : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private GameObject[] lives;


    private int live = 3;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bomb") || collision.gameObject.CompareTag("Enemy"))
        {
            live--;

            if (live >= 0 && live <= lives.Length - 1)
            {
                Animator liveAnimator = lives[live].GetComponent<Animator>();
                liveAnimator.SetBool("LessLive", true);
                if (live == 0)
                {
                    animator.SetBool("Dead", true);
                    Destroy(gameObject, 1f);
                    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                }

                Invoke("hide", 1);

            }
            
        }
    }

    private void hide()
    {
        lives[live].SetActive(false);
    }
}
