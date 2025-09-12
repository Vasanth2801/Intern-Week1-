using UnityEngine;
using TMPro;

public class Bullet : MonoBehaviour
{
    public float bulletSpeed = 15f;  //speed of the bullet
    public float lifeTime = 2f;      //life time of the bullet
    float lifeTimer;  //timer to track the life time
    //private BulletPooling  bulletPooling;                   //reference to the bullet pooling script
    //private ScoreManager ScoreManager;               // Reference to the score manager script
    Rigidbody2D rb;  //reference to the rigidbody2D component
    // public TextMeshProUGUI scoreText; // Reference to the score display UI
     int score = 0; // Player's score
    [SerializeField] private ParticleSystem hitEffect; // Particle effect on hit



    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();  //getting the rigidbody2D component
        //bulletPooling = BulletPooling.Instance;               //getting the instance of the bullet pooling script
        //ScoreManager = ScoreManager.Instance;               //getting the instance of the score manager script
    }

    private void Start()
    {
        // scoreText.text = "Score: 0"; // Initialize score display
    }

    private void OnEnable()   //called when the object is activated
    {
         

        lifeTimer = lifeTime;   //reseting the timer

        rb.linearVelocity = Vector2.up* bulletSpeed;  //setting the velocity of the bullet
    }

    private void Update()
    {
        lifeTimer -= Time.deltaTime;  //decreasing the Timer
        if(lifeTimer <= 0f)  //checking for the timer
        {
            gameObject.SetActive(false);  //deactivating the bullet after its life time is over
            //bulletPooling.Instance.ReturnBullet(gameObject);                  //returning the bullet to the pool   
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Enemy"))  //checking for collision with enemy
        {
             score += 10; // Increase score by 10
            // scoreText.text = "Score: " + score.ToString(); // Update score display
            //ScoreManager.AddScore(10);  //adding score on enemy hit
            collision.gameObject.SetActive(false);  //deactivating the enemy on hit
            gameObject.SetActive(false);  //deactivating the bullet on hit
            Debug.Log("Enemy hit! Score increased." + score);
            hitEffect.Play(); // Play hit particle effect
            //bulletPooling.Instance.ReturnBullet(gameObject);                  //returning the bullet to the pool   
        }
    }

}