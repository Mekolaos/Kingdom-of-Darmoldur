using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon", menuName ="Inventory/Items/Weapon")]
public class WeaponObject : Item
{
    public enum WeaponType
    {
        Sword,
        Mace,
        Axe,
        Dagger,
        Bow,
        Staff
    }
    public WeaponType weapontype;
    [Range(1, 30)]
    public int damage;
    private void Awake()
    {
        type = ItemType.Weapon;
    }


}
