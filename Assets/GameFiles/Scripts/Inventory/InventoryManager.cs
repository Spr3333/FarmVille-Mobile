using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

[RequireComponent(typeof(InventoryDisplay))]
public class InventoryManager : MonoBehaviour
{

    private Inventory inventory;
    private InventoryDisplay inventoryDisplay;

    void Start()
    {
        LoadInventory();
        inventoryDisplay = GetComponent<InventoryDisplay>();
        inventoryDisplay.Configure(inventory);

        CropTile.OnCropHarvested += CropHarvestedCallBack;
    }

    private void OnDestroy()
    {
        CropTile.OnCropHarvested -= CropHarvestedCallBack;

    }
    private void CropHarvestedCallBack(CropType croptype)
    {
        inventory.CropHarvestedCallBack(croptype);
        inventoryDisplay.UpdateDisplay(inventory);
        SaveInventory();
    }

    private void LoadInventory()
    {

        string dataPath = Application.dataPath + "/inventory.txt";
        string data = "";

        if (File.Exists(dataPath))
        {
             data = File.ReadAllText(dataPath);
            inventory = JsonUtility.FromJson<Inventory>(data);

            if(inventory == null)
                inventory = new Inventory();

        }
        else
        {
            File.Create(dataPath);
            inventory = new Inventory();
        }
    }

    private void SaveInventory()
    {
        string data = JsonUtility.ToJson(inventory, true);
        File.WriteAllText(Application.dataPath + "/inventory.txt", data);
    }
}
