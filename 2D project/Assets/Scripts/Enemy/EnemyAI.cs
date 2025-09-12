using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public float speed = 2f;
    public Transform target;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        if(target != null)
        {
            Vector2 direction = (target.position - transform.position).normalized;  
            transform.Translate(direction * speed * Time.deltaTime, Space.World);
        }
    }
}
