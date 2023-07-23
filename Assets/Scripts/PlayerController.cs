using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rigidbody2D;
    private AudioSource audioSource;


    [SerializeField] private AudioClip jumpClip;
    [SerializeField] private AudioClip runingClip;
    [SerializeField] private float speedRun = 3f;
    [SerializeField] private float jumpForce = 3f;
    [SerializeField] private GameObject runParticleLeft;
    [SerializeField] private GameObject runParticleRight;
    [SerializeField] private GameObject jumpParticle;
    [SerializeField] private GameObject fallParticle;

    private object[] paramCorutine = new object[1];

    private enum moveStates  { Idle, Run, Jump, Falling, Ground};
    private bool isGrounded;
    private bool grondedPlay = false;
    private bool alreadyPlayed = false;
    private float hDirection = 0f;
    private float vDirection = 0f;

    private int jumpsCount = 1;

    void Start()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        rigidbody2D = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
    }

    
    void Update()
    {

        hDirection = Input.GetAxis("Horizontal");
        vDirection = Input.GetAxis("Vertical");

        rigidbody2D.velocity = new Vector2(hDirection * speedRun, rigidbody2D.velocity.y);

        if (Input.GetButtonDown("Jump") && (isGrounded || jumpsCount <= 2))
        {
            jumpParticle.SetActive(true);
            audioSource.PlayOneShot(jumpClip);
            rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, jumpForce);
            jumpsCount++;
            grondedPlay = true;
        }


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

        if (rigidbody2D.velocity.y > 0.1f)
        {
            //audioSource.clip = clipJump;
            state = moveStates.Jump;
        }
        else if (rigidbody2D.velocity.y < -0.1f)
        {
            state = moveStates.Falling;
            jumpParticle.SetActive(false);
        }
        else if (rigidbody2D.velocity.y == 0f && grondedPlay)
        {
            state = moveStates.Ground;
            grondedPlay = false;
            fallParticle.SetActive(true);
            StartCoroutine(HiddenParticleFall());
        }

        animator.SetInteger("State", ((int)state));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Floors"))
        {
            isGrounded = true;
            jumpsCount = 1;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Floors"))
        {
            isGrounded = false;
        }
    }

    private void ShowRunParticle(bool left, bool right)
    {
        if (isGrounded)
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
