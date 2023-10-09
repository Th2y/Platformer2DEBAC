using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Rigidbody2D playerRB;
    [SerializeField] private float speedX;
    [SerializeField] private float speedY;

    [SerializeField] private SettingsData settingsData;

    private KeyCode leftCode;
    private KeyCode rigthCode;
    private KeyCode jumpCode;

    private void Awake()
    {
        //Remover depois (quando implementar o pulo)
        speedY = playerRB.velocity.y;

        leftCode = settingsData.leftCode;
        rigthCode = settingsData.rigthCode;
        jumpCode = settingsData.jumpCode;
    }

    private void Update()
    {
        Movement();
    }

    private void Movement()
    {
        if (Input.GetKey(jumpCode))
        {
            Debug.Log("j");
        }
        else if (Input.GetKey(rigthCode))
        {
            playerRB.velocity = new Vector2 (speedX, speedY);
        }
        else if (Input.GetKey(leftCode))
        {
            playerRB.velocity = new Vector2(-speedX, speedY);
        }
    }
}
