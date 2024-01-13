using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryDisplay : MonoBehaviour
{

    [Header("Elemensts")]
    [SerializeField] private UiCropContainer cropContainerPrefab;
    [SerializeField] private Transform cropContainerParent;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Configure(Inventory inventory)
    {
        InventoryItem[] items = inventory.GetItems();

        for (int i = 0; i < items.Length; i++)
        {
            UiCropContainer cropContainer = Instantiate(cropContainerPrefab, cropContainerParent);
            Sprite cropIcon = DataManager.instance.GetCropIcon(items[i].CropType);

            cropContainer.Configure(cropIcon, items[i].amount);
        }
    }

    public void UpdateDisplay(Inventory inventory)
    {
        InventoryItem[] items = inventory.GetItems();
        for (int i = 0; i < items.Length; i++)
        {
            if (i < cropContainerParent.childCount)
            {
                UiCropContainer cropContainerInstance = cropContainerParent.GetChild(i).GetComponent<UiCropContainer>();
                cropContainerInstance.gameObject.SetActive(true);

                Sprite cropIcon = DataManager.instance.GetCropIcon(items[i].CropType);
                cropContainerInstance.Configure(cropIcon, items[i].amount);
            }
            else
            {
                UiCropContainer cropContainerInstace = Instantiate(cropContainerPrefab, cropContainerParent);
                Sprite cropIcon = DataManager.instance.GetCropIcon(items[i].CropType);
                cropContainerInstace.Configure(cropIcon, items[i].amount);
            }
        }

        int remainingContainer = cropContainerParent.childCount - items.Length;

        if (remainingContainer <= 0)
            return;

        for (int i = 0; i < remainingContainer; i++)
        {
            cropContainerParent.GetChild(items.Length + i).gameObject.SetActive(false);
        }
    }

    //public void UpdateDisplay(Inventory inventory)
    //{
    //    InventoryItem[] items = inventory.GetItems();

    //    while(cropContainerParent.childCount > 0)
    //    {
    //        Transform containers = cropContainerParent.GetChild(0);
    //        containers.SetParent(null);
    //        Destroy(containers.gameObject);
    //    }

    //    Configure(inventory);
    //}
}
