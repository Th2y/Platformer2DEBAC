using DG.Tweening;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Speed Setup")]
    [SerializeField] private Rigidbody2D myRB;
    [SerializeField] private SoValuesMovement valuesMovement;

    [Header("Animation Player")]
    [SerializeField] private Animator animator;
    [SerializeField] private SOStringAnimations stringAnimations;
    [SerializeField] private float playerSwipDuration = .1f;

    [Header("Floor")]
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private float maxRayLength = 1;

    [Header("Scripts References")]
    [SerializeField] private HealthPlayer health;
    [SerializeField] private SettingsData settingsData;

    private KeyCode leftCode;
    private KeyCode rigthCode;
    private KeyCode jumpCode;
    private KeyCode runCode;

    private float _currentSpeedX = 0;
    private bool _isJumping = false;

    private Vector2 friction;
    private float speedX;
    private float speedRun;
    private float forceJump;

    private void Awake()
    {
        leftCode = settingsData.leftCode;
        rigthCode = settingsData.rigthCode;
        jumpCode = settingsData.jumpCode;
        runCode = settingsData.runCode;

        friction = valuesMovement.friction;
        speedX = valuesMovement.speedX;
        speedRun = valuesMovement.speedRun;
        forceJump = valuesMovement.forceJump;

        health.OnKill += OnKill;
    }

    private void Update()
    {
        Movement();
        HandleJump();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (_isJumping && collision.gameObject.CompareTag("Floor"))
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

    private void HandleJump()
    {
        if (!_isJumping && Input.GetKeyDown(jumpCode))
        {
            _isJumping = true;
            animator.SetBool(stringAnimations.Jump, true);
            myRB.velocity = Vector2.up * forceJump;
        }
        else if (myRB.velocity.y <= -28)
        {
            RaycastHit2D hit = Physics2D.Raycast(
                new Vector3(transform.position.x, transform.position.y - .5f, transform.position.z), 
                Vector3.down, maxRayLength, groundLayer.value);

            if (hit.collider != null && hit.collider.CompareTag("Floor"))
            {
                animator.SetBool(stringAnimations.Fall, true);
                animator.SetBool(stringAnimations.Jump, false);
            }
        }

        if (myRB.velocity.y <= -28)
        {
            animator.SetBool(stringAnimations.Fall, true);
        }
        else if(myRB.velocity.y < Vector2.up.y * forceJump)
        {
            animator.SetBool(stringAnimations.Jump, false);
        }
    }

    private void OnKill()
    {
        health.OnKill -= OnKill;
    }
}
