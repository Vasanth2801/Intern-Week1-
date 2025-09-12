using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public ObjectPoolManager poolManager;  //Reference to the objectpoolmanager 
    public float spawnInterval = 4f;       //interval between spawns
    private float timer;                   //timer to track the spawn interval

    public Transform spawnPoint;  //Spawn point for the enemy


    void Update()
    {
        timer -= Time.deltaTime;  //decreasing the timer

        if(timer <= 0) //checking for the timer
        {
            SpawnEnemy();   //Method to call the spawn enemy function
            timer = spawnInterval;  //resetting the timer
        }
    }

    void SpawnEnemy()
    {
        poolManager.SpawnObjects("Enemy", spawnPoint.position, spawnPoint.rotation); //spawning the enemy from objrct pool
    }
}