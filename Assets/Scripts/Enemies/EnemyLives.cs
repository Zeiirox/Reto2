using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EnemyLives : MonoBehaviour
{
    [SerializeField] private Animator animator;

    [SerializeField] private int live = 2;
    [SerializeField] private float timeToDestroy = 2;

    public bool ReduceLives()
    {
        live--;
        animator.Play("Hit");
        if (live == 0)
        {
            animator.SetBool("Dead", true);
            Destroy(gameObject, timeToDestroy);
        }

        return true;
    }
}
