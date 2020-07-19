using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Consumable Item", menuName = "Inventory/Items/Consumable Item")]
public class ConsumableItem : Item
{
    public enum EffectType
    {
        Magical,
        Physical,
        Mental,
        CUNT
    }
    public EffectType effect_type;
    public int healing;
    [Range(1, 6)]
    public int damage_over_time;

    private void Awake()
    {
        type = ItemType.Consumable;
    }
}
