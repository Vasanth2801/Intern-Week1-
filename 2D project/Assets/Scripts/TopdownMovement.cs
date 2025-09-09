using UnityEngine;
using UnityEngine.InputSystem;

public class TopdownMovement : MonoBehaviour
{
    [Header("Movement Settings")]
    public float speed = 5f; // speed of the player
    Rigidbody2D rb;          //Rigidbody component
    private Vector2 movement; // movement vector

    TopDownController controls;  //Refrence to the TopDownController input action

    //Calls the function before the game starts
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>(); //Getting the reference to the Rigidbody component

        controls = new TopDownController(); //Creating a new instance of TopDownController

        MovementCalling();      //Calling the Movementcalling function
    }

    //making the movement enabled when the button is enabled
    void MovementCalling()
    {
        controls.TopDownPlayer.Move.performed += ctx => movement = ctx.ReadValue<Vector2>(); //Reading the movement input
        controls.TopDownPlayer.Move.canceled += ctx => movement = Vector2.zero; //Resetting the movement input
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
        HandleMovement();   //Function to handle the movemnt of the player 
    }

    //Function to handle the movement of the player
    void HandleMovement()
    {
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime); //Moving the player based on the input
    }
}

