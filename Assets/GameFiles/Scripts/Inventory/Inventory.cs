using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory
{
    [SerializeField]private List<InventoryItem> items = new List<InventoryItem>();

    public void CropHarvestedCallBack(CropType croptype)
    {
        bool cropFound = false;

        for(int i = 0; i< items.Count; i++)
        {
            if(croptype == items[i].CropType)
            {
                cropFound = true;
                items[i].amount += 1;
            }
        }

        //DebugInventory();
        if (cropFound)
            return;

        items.Add(new InventoryItem(croptype, 1));
    }

    public InventoryItem[] GetItems()
    {
        return items.ToArray();
    }

    public void DebugInventory()
    {
        foreach(InventoryItem item in items)
        {
            Debug.Log("We Have " + item.amount + " in" +  item.CropType + " List");
        }
    }

    public void Clearinventory()
    {
        items.Clear();
    }
}
