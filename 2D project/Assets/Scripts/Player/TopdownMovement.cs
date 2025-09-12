using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using TMPro;

public class TopdownMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;   // Movement speed of the player
    public Transform firePoint;                      // Point from where bullets are fired
    public ObjectPoolManager poolManager;                        // Reference to the bullet pooling script
    // public  ScoreManager scoreManager;                      // Reference to the score manager script
    Rigidbody2D rb;               // Reference to the Rigidbody2D component
    Vector2 movement;            // Movement input vector
    public GameManager gameManager;    // Reference to the GameManager script



    Playertopdown inputActions;                  // Input actions for player movement and shooting


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();          // Getting the Rigidbody2D component
        inputActions = new Playertopdown();        // Initializing input actions

        MovementCalling();
    }


    void MovementCalling()
    {
        inputActions.Player.Move.performed += ctx =>movement= ctx.ReadValue<Vector2>(); // Log movement input
        inputActions.Player.Move.canceled += ctx =>movement= Vector2.zero;   // Log when movement input is canceled
        inputActions.Player.Shoot.performed += ctx => Shoot(); // Call Shoot method when shoot input is performed
    }
    private void OnEnable()
    {
        inputActions.Enable();                     // Enabling input actions
    }

    private void OnDisable()
    {
        inputActions.Disable();                    // Disabling input actions
    }

       
    
    void FixedUpdate()
    {
        HandleMovement();                          // Handle player movement
    }

    void HandleMovement()
    {
       
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime); // Move the player using Rigidbody2D
    }


    void Shoot()
    {
        poolManager.SpawnObjects("Bullet", firePoint.position, firePoint.rotation); // Get a bullet from the pool and set its position and rotation
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
             gameManager.Restart(); // Call the Restart method from GameManager
        }
        //bulletPooling.Instance.ReturnBullet(gameObject);                               //deactivating the bullet on collision
    }
}
