using DG.Tweening;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Speed Setup")]
    [SerializeField] private Rigidbody2D myRB;

    [Header("Jump Setup")]
    [SerializeField] private ParticleSystem jumpVFX;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private float maxRayLength = 1;

    [Header("Animation Player")]
    [SerializeField] private Animator animator;
    [SerializeField] private SOStringAnimations stringAnimations;

    [Header("Setup")]
    [SerializeField] private SOPlayerValues playerValues;
    [SerializeField] private HealthPlayer health;

    private Vector2 friction;
    private float speedX;
    private float speedRun;
    private float forceJump;
    private float _currentSpeedX = 0;
    private float playerSwipDuration;

    private float _isMoving = 0f;
    private bool _isJumping = false;
    private bool _isRunning = false;

    private void Awake()
    {
        friction = playerValues.friction;
        speedX = playerValues.speedX;
        speedRun = playerValues.speedRun;
        forceJump = playerValues.forceJump;
        playerSwipDuration = playerValues.playerSwipDuration;

        health.OnKill += OnKill;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (_isJumping && IsGrounded())
        {
            _isJumping = false;
            animator.SetBool(stringAnimations.Jump, false);
            animator.SetBool(stringAnimations.Fall, false);
            AudioController.Instance.PlaySFXByName(SFXNames.Fall);
        }
    }

    private void Update()
    {
        Movement();
        HandleJump();
    }

    public void Move(float isMoving)
    {
        _isMoving = isMoving;

        if (isMoving == 0)
        {
            _isRunning = false;

            animator.SetBool(stringAnimations.Walk, false);
            animator.SetBool(stringAnimations.Run, false);
        }
        else
        {
            animator.SetBool(stringAnimations.Walk, true);

            _currentSpeedX = _isRunning ? speedRun : speedX;

            if (isMoving > 0)
            {
                if (myRB.transform.localScale.x != 1)
                {
                    myRB.transform.DOScaleX(1, playerSwipDuration);
                }
            }
            else
            {
                if (myRB.transform.localScale.x != -1)
                {
                    myRB.transform.DOScaleX(-1, playerSwipDuration);
                }
            }
        }
    }

    private void Movement()
    {
        if (_isMoving == 0)
        {
            if (myRB.velocity.x > 0)
            {
                myRB.velocity -= friction;
            }
            else if (myRB.velocity.x < 0)
            {
                myRB.velocity += friction;
            }
        }
        else if(_isMoving > 0)
        {
            myRB.velocity = new Vector2(_currentSpeedX, myRB.velocity.y);
        }
        else
        {
            myRB.velocity = new Vector2(-_currentSpeedX, myRB.velocity.y);
        }
    }

    public void Run()
    {
        _isRunning = !_isRunning;
        animator.SetBool(stringAnimations.Run, _isRunning);
    }

    private bool IsGrounded()
    {
        /*Ray ray = new Ray(new Vector3(transform.position.x, transform.position.y + .5f), Vector2.down);
        Debug.DrawRay(ray.origin, ray.direction, Color.white, 100);

        return Physics2D.Raycast(ray.origin, Vector2.down, 1, groundLayer);*/
        return Physics2D.
            Raycast(new Vector3(transform.position.x, transform.position.y + .5f), Vector2.down, 1, groundLayer);
    }

    public void Jump()
    {
        if (IsGrounded())
        {
            _isJumping = true;
            animator.SetBool(stringAnimations.Jump, true);
            myRB.velocity = Vector2.up * forceJump;
            AudioController.Instance.PlaySFXByName(SFXNames.Jump);
            OnJump();
        }
    }

    private void HandleJump()
    {
        if (_isJumping)
        {
            if (Physics2D.Raycast(transform.position, Vector2.down, maxRayLength, groundLayer))
            {
                animator.SetBool(stringAnimations.Fall, true);
                animator.SetBool(stringAnimations.Jump, false);
            }
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
