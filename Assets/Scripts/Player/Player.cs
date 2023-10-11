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

    [Header("Animation Setup")]
    [SerializeField] private float jumpScaleY = 1.5f;
    [SerializeField] private float jumpScaleX = .7f;
    [SerializeField] private float dropScaleY = .9f;
    [SerializeField] private float dropScaleX = 1.5f;
    [SerializeField] private float animationDuration = .3f;
    [SerializeField] private Ease ease = Ease.OutBack;

    [Header("Scripts References")]
    [SerializeField] private SettingsData settingsData;

    private KeyCode leftCode;
    private KeyCode rigthCode;
    private KeyCode jumpCode;
    private KeyCode runCode;

    private float speedY;
    private float currentSpeedX = 0;
    private bool isJumping = false;

    private void Awake()
    {
        //Remover depois (quando implementar o pulo)
        speedY = playerRB.velocity.y;

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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Floor") && isJumping)
        {
            isJumping = false;
            StopScale();
            StartDropScale();
        }
    }

    private void Movement()
    {
        currentSpeedX = Input.GetKey(runCode) ? speedRun : speedX;

        if (Input.GetKey(rigthCode))
        {
            playerRB.velocity = new Vector2(currentSpeedX, speedY);
        }
        else if (Input.GetKey(leftCode))
        {
            playerRB.velocity = new Vector2(-currentSpeedX, speedY);
        }
        else
        {
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
        if (Input.GetKeyDown(jumpCode) && !isJumping)
        {
            isJumping = true;
            playerRB.velocity = Vector2.up * forceJump;
            StopScale();
            StartJumpScale();
        }
    }

    private void StopScale()
    {
        playerRB.transform.localScale = Vector2.one;
        DOTween.Kill(playerRB.transform);
    }

    private void StartJumpScale()
    {
        playerRB.transform.DOScaleY(jumpScaleY, animationDuration).SetLoops(2, LoopType.Yoyo).SetEase(ease);
        playerRB.transform.DOScaleX(jumpScaleX, animationDuration).SetLoops(2, LoopType.Yoyo).SetEase(ease);
    }

    private void StartDropScale()
    {
        playerRB.transform.DOScaleY(dropScaleY, animationDuration).SetLoops(2, LoopType.Yoyo).SetEase(ease);
        playerRB.transform.DOScaleX(dropScaleX, animationDuration).SetLoops(2, LoopType.Yoyo).SetEase(ease);
    }
}
