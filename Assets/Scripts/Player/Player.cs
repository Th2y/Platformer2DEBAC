using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Rigidbody2D playerRB;
    [SerializeField] private Vector2 friction = new Vector2(.1f, 0);
    [SerializeField] private float speedX;
    [SerializeField] private float speedRun;
    [SerializeField] private float forceJump;

    [SerializeField] private SettingsData settingsData;

    private KeyCode leftCode;
    private KeyCode rigthCode;
    private KeyCode jumpCode;
    private KeyCode runCode;

    private float speedY;
    private float currentSpeedX = 0;

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
        Jump();
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

        if(playerRB.velocity.x > 0)
        {
            playerRB.velocity -= friction;
        }
        else if(playerRB.velocity.x < 0)
        {
            playerRB.velocity += friction;
        }
    }

    private void Jump()
    {
        if (Input.GetKeyDown(jumpCode))
        {
            playerRB.velocity = Vector2.up * forceJump;
        }
    }
}
