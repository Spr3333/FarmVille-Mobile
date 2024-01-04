using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryItem
{
    public CropType CropType;
    public int amount;
    [TextArea(0, 25)]
    public string description;

    public InventoryItem(CropType cropType, int amount)
    {
        this.CropType = cropType;
        this.amount = amount;
    }
}
