using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Speed Setup")]
    [SerializeField] private Rigidbody2D playerRB;
    [SerializeField] private Vector2 friction = new Vector2(.1f, 0);
    [SerializeField] private float speedX;
    [SerializeField] private float speedRun;
    [SerializeField] private float forceJump;

    [Header("Animation Player")]
    [SerializeField] private Animator animator;
    [SerializeField] private string fallBoolAnim;
    [SerializeField] private string jumpBoolAnim;
    [SerializeField] private string runBoolAnim;
    [SerializeField] private string walkBoolAnim;
    [SerializeField] private float playerSwipDuration = .1f;

    [Header("Floor")]
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private float maxRayLength = 1;

    [Header("Scripts References")]
    [SerializeField] private SettingsData settingsData;

    private KeyCode leftCode;
    private KeyCode rigthCode;
    private KeyCode jumpCode;
    private KeyCode runCode;

    private float currentSpeedX = 0;
    private bool isJumping = false;

    private void Awake()
    {
        leftCode = settingsData.leftCode;
        rigthCode = settingsData.rigthCode;
        jumpCode = settingsData.jumpCode;
        runCode = settingsData.runCode;
    }

    private void Update()
    {
        Movement();
        HandleJump();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (isJumping && collision.gameObject.CompareTag("Floor"))
        {
            isJumping = false;
            animator.SetBool(jumpBoolAnim, false);
            animator.SetBool(fallBoolAnim, false);
        }
    }


    private void Movement()
    {
        bool isRunning = Input.GetKey(runCode);
        currentSpeedX = isRunning ? speedRun : speedX;

        if (Input.GetKey(rigthCode))
        {
            animator.SetBool(walkBoolAnim, true);
            animator.SetBool(runBoolAnim, isRunning);

            if(playerRB.transform.localScale.x != 1)
            {
                playerRB.transform.DOScaleX(1, playerSwipDuration);
            }
            playerRB.velocity = new Vector2(currentSpeedX, playerRB.velocity.y);
        }
        else if (Input.GetKey(leftCode))
        {
            animator.SetBool(walkBoolAnim, true);
            animator.SetBool(runBoolAnim, isRunning);

            if (playerRB.transform.localScale.x != -1)
            {
                playerRB.transform.DOScaleX(-1, playerSwipDuration);
            }
            playerRB.velocity = new Vector2(-currentSpeedX, playerRB.velocity.y);
        }
        else
        {
            animator.SetBool(walkBoolAnim, false);
            animator.SetBool(runBoolAnim, false);

            if (playerRB.velocity.x > 0)
            {
                playerRB.velocity -= friction;
            }
            else if (playerRB.velocity.x < 0)
            {
                playerRB.velocity += friction;
            }
        }
    }

    private void HandleJump()
    {
        if (!isJumping && Input.GetKeyDown(jumpCode))
        {
            isJumping = true;
            animator.SetBool(jumpBoolAnim, true);
            playerRB.velocity = Vector2.up * forceJump;
        }
        else if (playerRB.velocity.y <= -28)
        {
            RaycastHit2D hit = Physics2D.Raycast(
                new Vector3(transform.position.x, transform.position.y - .5f, transform.position.z), 
                Vector3.down, maxRayLength, groundLayer.value);

            if (hit.collider != null && hit.collider.CompareTag("Floor"))
            {
                animator.SetBool(fallBoolAnim, true);
                animator.SetBool(jumpBoolAnim, false);
            }
        }

        if (playerRB.velocity.y <= -28)
        {
            animator.SetBool(fallBoolAnim, true);
        }
        else if(playerRB.velocity.y < Vector2.up.y * forceJump)
        {
            animator.SetBool(jumpBoolAnim, false);
        }
    }
}
