using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rb2D;
    private AudioSource audioSource;


    [SerializeField] private AudioClip jumpClip;
    [SerializeField] private AudioClip runingClip;
    [SerializeField] private GameObject runParticleLeft;
    [SerializeField] private GameObject runParticleRight;
    [SerializeField] private GameObject jumpParticle;
    [SerializeField] private GameObject fallParticle;

    [SerializeField] private float speedRun = 3;
    [SerializeField] private float jumpForce = 3;
    [SerializeField] private float doubleJumpForce = 2.5f;

    private bool canDoubleJump;

    private enum moveStates  { Idle, Run, Jump, Falling, Ground};
    private bool grondedPlay = false;
    private float hDirection = 0f;
    private float vDirection = 0f;

    void Start()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb2D = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
    }

    
    void Update()
    {

        hDirection = Input.GetAxis("Horizontal");
        vDirection = Input.GetAxis("Vertical");

        rb2D.velocity = new Vector2(hDirection * speedRun, rb2D.velocity.y);
        if (Input.GetButton("Jump"))
        {
            if (CheckIsGrounded.isGrounded)
            {
                jumpParticle.SetActive(true);
                audioSource.PlayOneShot(jumpClip);
                rb2D.velocity = new Vector2(rb2D.velocity.x, jumpForce);
                grondedPlay = true;
                canDoubleJump = true;
            }
            else
            {
                if (Input.GetButtonDown("Jump"))
                {
                    if (canDoubleJump)
                    {
                        audioSource.PlayOneShot(jumpClip);
                        rb2D.velocity = new Vector2(rb2D.velocity.x, doubleJumpForce);
                        canDoubleJump = false;
                    }
                }
            }
        }

        //if (Input.GetMouseButtonDown(0))
        //{
        //    gameObject.GetComponent<DropBombs>().DropBomb(spriteRenderer.flipX);
        //}

        UpdateAnimation();

    }

    private void UpdateAnimation()
    {
        moveStates state;
        if (hDirection > 0f)
        {
            spriteRenderer.flipX = false;
            state = moveStates.Run;
            ShowRunParticle(true, false);
        }
        else if (hDirection < 0f)
        {
            spriteRenderer.flipX = true;
            state = moveStates.Run;
            ShowRunParticle(false, true);
        }
        else
        {
            state = moveStates.Idle;
            ShowRunParticle(false, false);
        }

        if (rb2D.velocity.y > 0.1f)
        {
            //audioSource.clip = clipJump;
            state = moveStates.Jump;
        }
        else if (rb2D.velocity.y < -0.1f)
        {
            state = moveStates.Falling;
            jumpParticle.SetActive(false);
        }
        else if (rb2D.velocity.y == 0f && CheckIsGrounded.isGrounded && grondedPlay)
        {
            state = moveStates.Ground;
            fallParticle.SetActive(true);
            StartCoroutine(HiddenParticleFall());
            grondedPlay = false;
        }

        animator.SetInteger("State", ((int)state));
    }

    private void ShowRunParticle(bool left, bool right)
    {
        if (CheckIsGrounded.isGrounded)
        {
            runParticleLeft.SetActive(left);
            runParticleRight.SetActive(right);
        }
    }

    IEnumerator HiddenParticleFall()
    {
        yield return new WaitForSeconds(0.5f);
        fallParticle.SetActive(false);
    }
}
