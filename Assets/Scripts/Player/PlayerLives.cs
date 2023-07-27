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

    public bool ReduceLives()
    {
        live--;

        if (live >= 0 && live <= lives.Length - 1)
        {
            Animator liveAnimator = lives[live].GetComponent<Animator>();
            liveAnimator.SetBool("LessLive", true);
            animator.Play("Hit");
            if (live == 0)
            {
                animator.SetBool("Dead", true);
                Invoke("ReloadEscene", 2);
            }

            Invoke("hide", 1);

        }

        return true;
    }

    private void hide()
    {
        lives[live].SetActive(false);
    }

    private void ReloadEscene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
