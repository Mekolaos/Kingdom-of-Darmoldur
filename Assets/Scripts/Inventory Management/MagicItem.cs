using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Magic Item", menuName = "Inventory/Items/Magic Item")]
public class MagicItem : Item
{
    // Not sure what kind of attributes to add yet
    public string magical_attribute;
    private void Awake()
    {
        type = ItemType.MagicItem;
    }
}
