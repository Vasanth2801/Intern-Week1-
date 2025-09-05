using UnityEngine;


[CreateAssetMenu(fileName = "NewWeaponData",menuName = "Weapondata")]
public class Weapondata : ScriptableObject
{
    //Weapon Properties
    public string weaponName;
    public int damage;
    public float fireRate;
    public int magazineSize;
}
