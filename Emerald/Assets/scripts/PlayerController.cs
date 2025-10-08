using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(AudioSource))]
public class PlayerController : MonoBehaviour
{
    // you can modify this value if it's necessary.
    public int health = 3;

    private AudioSource audioSource;
    private Animator animator;
    private Rigidbody2D rb;

    // pay attention, you have to fill out this field from inspector with approprite value.
    [SerializeField] private Vector2 moveVector;

    private bool isJumped;
    public bool isAttacked;
    public bool isShielded;
    private bool previousShielded;

    // pay attention, you have to fill out these fields from inspector with approprite values.
    [SerializeField] private AudioClip jumpClip;
    [SerializeField] private AudioClip attackClip;
    [SerializeField] private AudioClip shieldClip;
    [SerializeField] private AudioClip DieClip;
    [SerializeField] private float volumeSound;

    // the menu that appears when player is game over
    public GameObject endMenu;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
        if (endMenu != null)
            endMenu.SetActive(false);
    }

    void Update()
    {
        HandleInputs();
        HandleDie();

        if (isJumped)
        {
            HandleMovement();
            HandleAudios(jumpClip, volumeSound);
            HandleAnimations();
            isJumped = false;
        }
        else if (isAttacked)
        {
            HandleAudios(attackClip, volumeSound);
            HandleAnimations();
            isAttacked = false;
        }

        if (isShielded != previousShielded)
        {
            HandleAudios(shieldClip, volumeSound);
            HandleAnimations();
            previousShielded = isShielded;
        }
    }

    void HandleInputs()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //move to right
            isJumped = true;

        }
        else if (Input.GetMouseButtonDown(0))
        {
            //attack
            isAttacked = true;
        }

        if (Input.GetMouseButtonDown(1))
        {
            //get shield
            isShielded = true;
        }
        else if (Input.GetMouseButtonUp(1))
        {
            //leave shield
            isShielded = false;
        }
    }

    void HandleAnimations()
    {
        if (isJumped)
        {
            animator.SetTrigger("isJumped");
        }
        else if (isAttacked)
        {
            animator.SetTrigger("isAttacked");
        }
        else if (!isJumped && !isAttacked)
            animator.SetBool("isShielded", isShielded);
    }

    void HandleAudios(AudioClip soundEffect, float volume)
    {
        audioSource.PlayOneShot(soundEffect, volume);
    }

    void HandleMovement()
    {
        rb.AddForce(moveVector, ForceMode2D.Impulse);
    }

    void HandleDie()
    {
        if(health == 0)
        {
            HandleAudios(DieClip, volumeSound);
            if (endMenu != null)
                endMenu.SetActive(true);
            Time.timeScale = 0f;
        }
    }
}
