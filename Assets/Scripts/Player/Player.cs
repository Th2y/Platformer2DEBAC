using DG.Tweening;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Speed Setup")]
    [SerializeField] private Rigidbody2D myRB;

    [Header("Jump Setup")]
    [SerializeField] private Collider2D myCollider;
    [SerializeField] private float spaceToGround = .1f;
    [SerializeField] private ParticleSystem jumpVFX;

    [Header("Animation Player")]
    [SerializeField] private Animator animator;
    [SerializeField] private SOStringAnimations stringAnimations;

    [Header("Floor")]
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private float maxRayLength = 1;

    [Header("Setup")]
    [SerializeField] private SOPlayerValues playerValues;
    [SerializeField] private HealthPlayer health;
    [SerializeField] private SOSettings settings;

    private KeyCode leftCode;
    private KeyCode rigthCode;
    private KeyCode jumpCode;
    private KeyCode runCode;

    private Vector2 friction;
    private float speedX;
    private float speedRun;
    private float forceJump;
    private float distToGround;
    private float _currentSpeedX = 0;
    private bool _isJumping = false;

    private float playerSwipDuration;

    private void Awake()
    {
        leftCode = settings.leftCode;
        rigthCode = settings.rigthCode;
        jumpCode = settings.jumpCode;
        runCode = settings.runCode;

        friction = playerValues.friction;
        speedX = playerValues.speedX;
        speedRun = playerValues.speedRun;
        forceJump = playerValues.forceJump;
        playerSwipDuration = playerValues.playerSwipDuration;

        if(myCollider != null) distToGround = myCollider.bounds.extents.y;

        health.OnKill += OnKill;
    }

    private void Update()
    {
        Movement();
        HandleJump();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (_isJumping && IsGrounded())
        {
            _isJumping = false;
            animator.SetBool(stringAnimations.Jump, false);
            animator.SetBool(stringAnimations.Fall, false);
        }
    }

    private void Movement()
    {
        bool isRunning = Input.GetKey(runCode);
        _currentSpeedX = isRunning ? speedRun : speedX;

        if (Input.GetKey(rigthCode))
        {
            animator.SetBool(stringAnimations.Walk, true);
            animator.SetBool(stringAnimations.Run, isRunning);

            if(myRB.transform.localScale.x != 1)
            {
                myRB.transform.DOScaleX(1, playerSwipDuration);
            }
            myRB.velocity = new Vector2(_currentSpeedX, myRB.velocity.y);
        }
        else if (Input.GetKey(leftCode))
        {
            animator.SetBool(stringAnimations.Walk, true);
            animator.SetBool(stringAnimations.Run, isRunning);

            if (myRB.transform.localScale.x != -1)
            {
                myRB.transform.DOScaleX(-1, playerSwipDuration);
            }
            myRB.velocity = new Vector2(-_currentSpeedX, myRB.velocity.y);
        }
        else
        {
            animator.SetBool(stringAnimations.Walk, false);
            animator.SetBool(stringAnimations.Run, false);

            if (myRB.velocity.x > 0)
            {
                myRB.velocity -= friction;
            }
            else if (myRB.velocity.x < 0)
            {
                myRB.velocity += friction;
            }
        }
    }

    private bool IsGrounded()
    {
        //Debug.DrawRay(transform.position, -Vector2.up, Color.white, distToGround + spaceToGround);
        return Physics2D.Raycast(transform.position, -Vector2.up, distToGround + spaceToGround, groundLayer);
    }

    private void HandleJump()
    {
        if (!_isJumping)
        {
            if(Input.GetKeyDown(jumpCode) && IsGrounded())
            {
                _isJumping = true;
                animator.SetBool(stringAnimations.Jump, true);
                myRB.velocity = Vector2.up * forceJump;
                OnJump();
            }
        }
        else if (myRB.velocity.y <= -28)
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, -Vector2.up, maxRayLength, groundLayer);

            if (hit.collider != null && hit.collider.CompareTag("Floor"))
            {
                animator.SetBool(stringAnimations.Fall, true);
                animator.SetBool(stringAnimations.Jump, false);
            }
        }
        else if(myRB.velocity.y < Vector2.up.y * forceJump)
        {
            animator.SetBool(stringAnimations.Jump, false);
        }
    }

    private void OnJump()
    {
        if (jumpVFX != null) jumpVFX.Play();
    }

    private void OnKill()
    {
        health.OnKill -= OnKill;
    }
}
