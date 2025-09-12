using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletSpeed = 15f;  //speed of the bullet
    public float lifeTime = 5f;      //life time of the bullet
    float lifeTimer;                 //timer to track the life time

    Rigidbody2D rb;                  //Rigibody component


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();  //reference to rigidbody
    }

    private void OnEnable()   //called when the object is activated
    {
         

        lifeTimer = lifeTime;   //reseting the timer

        if (rb != null)  //checking if the rigidbody is not null
        {
            rb.linearVelocity = transform.right * bulletSpeed;  //setting the velocity of the bullet
        }
    }

    private void Update()
    {
        lifeTimer -= Time.deltaTime;  //decreasing the Timer
        if(lifeTimer <= 0f)  //checking for the timer
        {
            gameObject.SetActive(false);  //deactivating the bullet after its life time is over
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        gameObject.SetActive(false);  //deactivating the bullet on collision
    }
}
