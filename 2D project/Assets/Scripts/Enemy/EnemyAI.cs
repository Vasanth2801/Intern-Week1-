using UnityEngine;
using TMPro;

public class EnemyAI : MonoBehaviour
{
    public float speed = 2f;            // Speed of the enemy
    public Transform target;         // Target for the enemy to follow (player)
    

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;     // Finding the player by tag and setting it as the target
    }

    // Update is called once per frame
    void Update()
    {
        if(target != null)            // Check if the target is not null
        {
            Vector2 direction = (target.position - transform.position).normalized;    // Calculate the direction towards the target
            transform.Translate(direction * speed * Time.deltaTime, Space.World);    // Move the enemy towards the target
        }
    }

   
}
