using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item : ScriptableObject
{
    public enum ItemType
    {
        Armor,
        MagicItem,
        Weapon,
        Consumable
    }

    public string item_name;
    [HideInInspector]
    public ItemType type;
    [TextArea(10, 20)]
    public string description;
    public Sprite icon;


 

}
