using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBuyerInteractor : MonoBehaviour
{

    [Header("Elements")]
    [SerializeField] private InventoryManager inventoryManager;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Buyer"))
        {
            SellCrops();
        }
    }

    private void SellCrops()
    {
        Inventory inventory = inventoryManager.GetInventory();
        InventoryItem[] items = inventory.GetItems();
        int coinsEarned = 0;

        for (int i = 0; i < items.Length; i++)
        {
            int itemPrice = DataManager.instance.GetCropPrice(items[i].CropType);
            coinsEarned += itemPrice * items[i].amount;
        }

        CashManager.instance.AddCoins(coinsEarned);

        inventoryManager.ClearInventory();
    }
}
