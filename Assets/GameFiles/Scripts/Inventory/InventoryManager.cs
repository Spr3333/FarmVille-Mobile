using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{

    private Inventory inventory;

    void Start()
    {
        inventory = new Inventory();
        CropTile.OnCropHarvested += CropHarvestedCallBack;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void CropHarvestedCallBack(CropType croptype)
    {
        inventory.CropHarvestedCallBack(croptype);
    }
}
