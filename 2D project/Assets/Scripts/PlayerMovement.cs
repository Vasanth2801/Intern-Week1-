using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement Settings")]
    public float speed = 5f;    //speed of the Player
    Rigidbody2D rb;            //Rigidbody component
    Vector2 horizontalMovement;   //horizontal movement Vector

    private PlayerController inputMovements;   //Reference to the PlayerController script

    //Calls the Function before the Game starts
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();   //Getting the reference to the Rigidbody component
        inputMovements = new PlayerController();  //Creating a new instance of PlayerController

        MovementCalling();  //Calling the Movementcalling function
    }

    //Enabling the input system when the button is enabled 
    void MovementCalling()
    {
        inputMovements.Player.Move.performed += ctx => horizontalMovement.x = ctx.ReadValue<Vector2>().x;  //Reading the horizontal movement input
        inputMovements.Player.Move.canceled += ctx => horizontalMovement.x = Vector2.zero.x; //Resetting the horizontal movement input
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
        HandleMovement();   //Function to handle the movement of the player
    }

    //Handles the player movement
    void HandleMovement()
    {
        rb.MovePosition(rb.position + horizontalMovement * speed * Time.fixedDeltaTime);  //Moving the player based on the input
    }
}

