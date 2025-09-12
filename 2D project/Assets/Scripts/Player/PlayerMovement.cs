using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement Settings")]
    public float speed = 5f;    //speed of the Player
    public float sprintSpeed = 8f; //sprint multiplier for the player speed

    [Header("Dash Settings")]
    public float dashForce = 12f;  //Force of the dash
    public float dashCooldown = 1f; //Cooldown time for the dash
    public float dashDuration = 0.2f; //Duration of the dash

    [Header("References")]
    Rigidbody2D rb;            //Rigidbody component
    Vector2 horizontalMovement;   //horizontal movement Vector
    PlayerController inputMovements;   //Reference to the PlayerController script

    [Header("Bool Settings")]
    bool isSprinting;  //Boolean to check if the player is sprinting
    bool isDashing;    //Boolean to check if the player is dashing
    float lastDash;   //Boolean to check if the player has dashed
    float  dashTimer; //Boolean to check if the dash timer is running
    bool  dashPressed; //Boolean to check if the dash button is pressed


    //Calls the Function before the Game starts
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();   //Getting the reference to the Rigidbody component
        inputMovements = new PlayerController();  //Creating a new instance of PlayerController

        MovementCalling();  //Calling the Movementcalling function

        SprintCheck();   //Calling the SprintCheck function

        DashCheck();   //Calling the DashCheck function
    }

    //Enabling the input system when the button is enabled 
    void MovementCalling()
    {
        inputMovements.Player.Move.performed += ctx => horizontalMovement.x = ctx.ReadValue<Vector2>().x;  //Reading the horizontal movement input
        inputMovements.Player.Move.canceled += ctx => horizontalMovement.x = Vector2.zero.x; //Resetting the horizontal movement input
    }

    //Function to check if the player is sprinting
    void SprintCheck()
    {
        inputMovements.Player.Sprint.performed += ctx => isSprinting = true; //setting the bool to true when the sprint button is pressed
        inputMovements.Player.Sprint.canceled += ctx => isSprinting = false; //setting the bool to false when the sprint button is released
    }

    //Function to check if the player is dashing
    void DashCheck()
    {
        inputMovements.Player.Dash.performed += ctx => dashPressed = true; //setting the bool to true when the dash button is pressed
    }

    //Enabling the input system
    private void OnEnable()
    {
        inputMovements.Player.Enable();  //Enabling the input system
    }

    //Disabling the input system
    private void OnDisable()
    {
        inputMovements.Player.Disable();  //Disabling the input system
    }

    //Called at a fixed interval and better for physics calculations
    private void FixedUpdate()
    {
        if(isDashing)
        {
            HandleDash();   //Function to handle the dash of the player
        }
        else
        {
            HandleMovement();   //Function to handle the movement of the player

            if(dashPressed && Time.time >= (lastDash + dashCooldown)) //Checking if the dash button is pressed and if the cooldown time has passed
            {
                StartDash();  //Calling the StartDash function
            }
        }

        dashPressed = false; //Resetting the dash button press
    }

    //Handles the player movement
    void HandleMovement()
    {
        float currentSpeed = speed;  //Storing the current speed of the player
        if (isSprinting)  //Checking if the player is sprinting
        {
            speed = sprintSpeed;     //Boosting the speed of the player
        }

        if(!isSprinting)   //Checking if the player is not sprinting
        {
            speed = 5f;          //Resetting the speed of the player
        }


        rb.MovePosition(rb.position + horizontalMovement * speed * Time.fixedDeltaTime);  //Moving the player based on the input
    }

    void StartDash()
    {
        isDashing = true;  //Setting the isDashing bool to true
        dashTimer = dashDuration; //Setting the dash timer to the dash duration
        lastDash = Time.time; //Setting the last dash time to the current time

        rb.linearVelocity = horizontalMovement.normalized*dashForce; //Applying the dash force to the player
       // AudioManager.Instance.PlayDashSound(); //Playing the dash sound
    }

    void HandleDash()
    {
        dashTimer -= Time.fixedDeltaTime; //Reducing the dash timer
        if(dashTimer <= 0) //Checking if the dash timer has run out
        {
            isDashing = false; //Setting the isDashing bool to false
            rb.linearVelocity = Vector2.zero; //Resetting the velocity of the player
        }
    }
}