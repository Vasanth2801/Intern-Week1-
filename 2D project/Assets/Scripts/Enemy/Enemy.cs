using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 3f;          //speed of the enemy

    void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);  //moving the enemy to the left
    }
}