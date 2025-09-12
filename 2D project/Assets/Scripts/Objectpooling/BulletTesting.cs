using UnityEngine;

public class BulletTesting : MonoBehaviour
{
    public GameObject bulletPrefab;  //prefab of the bullet
    public Transform firePoint;      //the point from where the bullet will be fired
    public float bulletSpeed = 15f;  //speed of the bullet

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))  //if space key is pressed
        {
            Shoot();  //call the shoot function
        }
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation); //instantiate the bullet
        
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();  //get the rigidbody component of the bullet
        rb.linearVelocity = firePoint.right * bulletSpeed;  //set the velocity of the bullet

        Destroy(bullet, 5f);  //destroy the bullet after 5 seconds
    }
}
