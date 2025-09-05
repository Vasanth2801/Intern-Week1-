using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Weapon : MonoBehaviour
{
    [Header("weaponData")]
    public Weapondata[] weapon;
    int currentWeaponIndex = 0;
    Weapondata currentWeapon;
    int currentMag;
    float nextTimeToFire;

    [Header("UI")]
    public TextMeshProUGUI weaponNameText;

    void Start()
    {
        EquipWeapon(0);
    }


    void Update()
    {
        // Shoot Button Pressed (Left Mouse Button)
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
        // For Changing weapons(1,2,3 keys)
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            EquipWeapon(0);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            EquipWeapon(1);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            EquipWeapon(2);
        }
    }

        void EquipWeapon(int index)
        {
            if ((index < 0 || index >= weapon.Length))
            {
                return;
            }

            currentWeaponIndex = index;
            currentWeapon = weapon[index];
            currentMag = currentWeapon.magazineSize;

            Debug.Log("Equipped" + currentWeapon.weaponName);
            
           UpdateUI(); // Update the UI with current weapon

        }
    

        void Shoot()
        {
            if(Time.time < nextTimeToFire)
            {
                return;
            }

            if(currentMag > 0)
            {
                Debug.Log(currentWeapon.weaponName +  "Fired" + currentWeapon.damage + " damage dealt.");
                currentMag--;
                nextTimeToFire = Time.time + 1f / currentWeapon.fireRate;
            }
            else
            {
                Debug.Log("Out of ammo!");
            }
        }

    //Update the UI with current weapon information
    void UpdateUI()
    {
        if(weaponNameText != null)
        {
            weaponNameText.text = $"weapon: {currentWeapon.weaponName} \n" +
                                  $"Damage: {currentWeapon.damage} \n" +
                                  $"Ammo: {currentMag}/{currentWeapon.magazineSize}";
        }
    }
}
