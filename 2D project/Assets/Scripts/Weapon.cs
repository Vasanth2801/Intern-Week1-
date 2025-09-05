using UnityEngine;

public class Weapon : MonoBehaviour
{
    [Header("weaponData")]
    public Weapondata weapon;

    int currentMag;
    float nextTimeToFire;


    void Start()
    {
        currentMag = weapon.magazineSize;
        Debug.Log("Equipped weapon: " + weapon.weaponName);
    }

    
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Shoot();
        }


        void Shoot()
        {
            if(Time.time < nextTimeToFire)
            {
                return;
            }

            if(currentMag > 0)
            {
                Debug.Log(weapon.weaponName +  "Fired" + weapon.damage + " damage dealt.");
                currentMag--;
                nextTimeToFire = Time.time + 1f / weapon.fireRate;
            }
            else
            {
                Debug.Log("Out of ammo!");
            }
        }
    }
}
