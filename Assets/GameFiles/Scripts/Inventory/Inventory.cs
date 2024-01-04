using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory
{
    private List<InventoryItem> items = new List<InventoryItem>();

    public void CropHarvestedCallBack(CropType croptype)
    {
        Debug.Log("Crop Harvested");
    }
}
