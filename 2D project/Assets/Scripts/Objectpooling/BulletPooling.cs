using UnityEngine;
using System.Collections.Generic;

public class BulletPooling : MonoBehaviour
{
    public static BulletPooling Instance;     // Singleton instance
    public  GameObject bulletPrefab;           // Bullet prefab to be pooled
    public int poolSize = 10;                  // Initial size of the pool

    Queue<GameObject> bulletPool = new Queue<GameObject>();          // Queue to hold the pooled bullets

    // Singleton pattern implementation
    void Awake()
    {
        if (Instance == null)          // If no instance exists
        {
            Instance = this;                 // Set this as the instance
            DontDestroyOnLoad(gameObject); 
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Initialize the bullet pool
    void Start()
    {
        for (int i = 0; i< poolSize; i++)   // Loop to create initial pool size
        {
            GameObject bullet = Instantiate(bulletPrefab);    // Instantiate bullet prefab
            bullet.SetActive(false);                  // Deactivate the bullet
            bulletPool.Enqueue(bullet);                // Add bullet to the pool
        }
    }

    // Get a bullet from the pool
    public GameObject GetBullet(Vector2 position, Quaternion rotation)       // Method to get a bullet from the pool
    {
        if (bulletPool.Count > 0)                                           // Check if there are available bullets in the pool
        {
            GameObject bullet = bulletPool.Dequeue();                       // Get a bullet from the pool
            bullet.transform.position = position;                            // Set bullet position
            bullet.transform.rotation = rotation;                          // Set bullet rotation
            bullet.SetActive(true);                                          // Activate the bullet
            return bullet;
        }
        else
        {
            GameObject bullet = Instantiate(bulletPrefab, position, rotation);         // If pool is empty, instantiate a new bullet
            return bullet;
        }
    }

    // Return a bullet to the pool
    public void ReturnBullet(GameObject bullet)
    {
        bullet.SetActive(false);                 // Deactivate the bullet
        bulletPool.Enqueue(bullet);            // Add bullet back to the pool
    } 
}
