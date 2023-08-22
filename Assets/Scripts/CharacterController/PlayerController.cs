using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public CharacterController player;
    public Camera mainCamera;

    private float horizontalMove;
    private float verticalMove;
    private float gravity = -9.8f;
    private float fallVelocity;
    private Vector3 playerInput;
    
    public float playerSpeed;
    public float mass;

    private Vector3 camForward;
    private Vector3 camRigth;
    private Vector3 movePlayerCam; //Movimiento del player segun la camara.


    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        MoveController();

        SetGravity();

        player.Move(movePlayerCam * Time.deltaTime);
    }


    void MoveController()
    {
        horizontalMove = Input.GetAxis("Horizontal");
        verticalMove = Input.GetAxis("Vertical");

        playerInput = new Vector3(horizontalMove, 0, verticalMove);
        playerInput = Vector3.ClampMagnitude(playerInput, 1); //De esta forma mantendra la misma velocidad incluso si el jugador se mueve en diagonal.
        Debug.Log(player.velocity.magnitude);

        CamDirection();

        movePlayerCam = (playerInput.x * camRigth + playerInput.z * camForward) * playerSpeed; // De esta forma, se movera con respecto a la camara. Lo multiplicamos por player speed para que no afecte a la velocidad en y.
        player.transform.LookAt(player.transform.position + movePlayerCam); //Rota al player en la dirección que se mueve.
    }

    private void CamDirection()
    {
        camForward = mainCamera.transform.forward; //Guardamos la dirección hacia delante de la camara.
        camRigth = mainCamera.transform.right;

        camForward.y = 0;
        camRigth.y = 0;

        camForward = camForward.normalized; //Los valores van de cero a uno.
        camRigth = camRigth.normalized;
    }

    private void SetGravity()
    { 
        if (player.isGrounded)
        {
            fallVelocity = gravity * mass * Time.deltaTime; //Al tener dos Time.deltaTime, genera una aceleración
            movePlayerCam.y = fallVelocity;
        }
        else
        {
            fallVelocity += gravity * mass * Time.deltaTime;
            movePlayerCam.y = fallVelocity;
        }
    }

}
