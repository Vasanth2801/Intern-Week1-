using UnityEngine;
using UnityEngine.InputSystem;

public class TopdownMovement : MonoBehaviour
{
    [Header("Movement Settings")]
    public float speed = 5f; // speed of the player
    public float sprintSpeed = 12f;   // boost speed of the player

    [Header("Dash Settings")]
    public float dashForce = 12f;  //Force of the dash
    public float dashCooldown = 1f; //Cooldown time for the dash
    public float dashDuration = 0.2f; //Duration of the dash

    [Header("References Settings")]
    Rigidbody2D rb;          //Rigidbody component
    private Vector2 movement; // movement vector
    TopDownController controls;  //Refrence to the TopDownController input action

    [Header("Bool Settings")]
    bool isSprinting;  //Boolean to check if the player is sprinting
    bool isDashing;    //Boolean to check if the player is dashing
    float lastDash;   //Boolean to check if the player has dashed
    float dashTimer; //Boolean to check if the dash timer is running
    bool dashPressed; //Boolean to check if the dash button is pressed

    //Calls the function before the game starts
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>(); //Getting the reference to the Rigidbody component

        controls = new TopDownController(); //Creating a new instance of TopDownController

        MovementCalling();      //Calling the Movementcalling function

        CheckSprint();     //Calling the CheckSprint function

        CheckDash();  //Calling the CheckDash function
    }

    //making the movement enabled when the button is enabled
    void MovementCalling()
    {
        controls.TopDownPlayer.Move.performed += ctx => movement = ctx.ReadValue<Vector2>(); //Reading the movement input
        controls.TopDownPlayer.Move.canceled += ctx => movement = Vector2.zero; //Resetting the movement input
    }

    void CheckSprint()
    {
        controls.TopDownPlayer.Sprint.performed += ctx => isSprinting = true; //Setting the isSprinting to true when the sprint button is pressed
        controls.TopDownPlayer.Sprint.canceled += ctx => isSprinting = false; //Setting the isSprinting to false when the sprint button is released
    }

    void CheckDash()
    {
        controls.TopDownPlayer.Dash.performed += ctx => dashPressed = true; //Setting the dashPressed to true when the dash button is pressed
    }

    //Enabling the input system when the button is enabled
    private void OnEnable()
    {
        controls.TopDownPlayer.Enable();  //Enabling the input System
    }

    //Disabling the input system when the button is disabled
    private void OnDisable()
    {
        controls.TopDownPlayer.Disable(); //Disabling the input System
    }

    //Called at a fixed interval and better for physics calculations
    private void FixedUpdate()
    {
        if(isDashing)
        {
            HandleDash();      //Function to handle the dash of the player
        }
        else
        {
            HandleMovement();   //Function to handle the movemnt of the player 

            if (dashPressed && Time.time >= (lastDash + dashCooldown)) //Checking if the dash button is pressed and if the cooldown time has passed
            {
                StartDash();   //Calling the StartDash function
            }
        }
    }

    //Function to handle the movement of the player
    void HandleMovement()
    {
        float currentSpeed = speed; //Storing the current speed of the player
        if (isSprinting) //Checking if the player is sprinting
        {
            speed = sprintSpeed; //Setting the speed to sprintSpeed
        }
        if(!isSprinting) //Checking if the player is not sprinting
        {
            speed = 5f; //Setting the speed to normal speed
        }
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime); //Moving the player based on the input
    }

    //Function to start the dash
    void StartDash()
    {
        isDashing = true; //Setting the isDashing to true
        dashTimer = dashDuration; //Setting the dashTimer to dashDuration
        lastDash = Time.time; //Setting the lastDash to the current time
        dashPressed = false; //Setting the dashPressed to false

        rb.linearVelocity = movement.normalized * dashForce; //Applying the dash force to the player
    }

    //Function to handle the dash of the player
    void HandleDash()
    {
        dashTimer -= Time.fixedDeltaTime; //Reducing the dash timer
        if (dashTimer <= 0) //Checking if the dash timer has run out
        {
            isDashing = false; //Setting the isDashing bool to false
            rb.linearVelocity = Vector2.zero; //Resetting the velocity of the player
        }
    }
}

