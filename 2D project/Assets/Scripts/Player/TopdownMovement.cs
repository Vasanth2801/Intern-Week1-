using UnityEngine;
using UnityEngine.InputSystem;
public class TopdownMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    public Transform firePoint;
    ObjectPoolManager Bullet;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        GameObject bullet = Bullet.SpawnObjects("Bullet", firePoint.position, firePoint.rotation);
    }

    void FixedUpdate()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");
        Vector2 moveDir = new Vector2(moveX, moveY).normalized;
        transform.Translate(moveDir * moveSpeed * Time.fixedDeltaTime, Space.World);
    }
}
