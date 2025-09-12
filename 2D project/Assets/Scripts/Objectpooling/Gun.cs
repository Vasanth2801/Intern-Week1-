using UnityEngine;

public class Gun : MonoBehaviour
{
    public ObjectPoolManager poolManager;   //Reference to the objectpoolmanager script
    public Transform firePoint;             //The point where the bullet will be fired 

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))   //if space key is pressed
        {
            Shoot();   //shoot function is called 
        }
    }

    void Shoot()
    {
        poolManager.SpawnObjects("Bullet", firePoint.position, firePoint.rotation); //spawn bullets from object pool
    }
}
