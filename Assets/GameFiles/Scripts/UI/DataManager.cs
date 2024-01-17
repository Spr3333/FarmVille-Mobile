using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static DataManager instance;

    [Header("Elements")]
    [SerializeField] private CropData[] cropData;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Sprite GetCropIcon(CropType cropType)
    {
        for(int i = 0; i < cropData.Length; i++)
        {
            if (cropData[i].cropType == cropType)
            {
                return cropData[i].icon;
            }
        }

        Debug.Log("Crop Icon Could Not Be Found");
        return null;
    }

    public int GetCropPrice(CropType cropType)
    {
        for (int i = 0; i < cropData.Length; i++)
        {
            if (cropData[i].cropType == cropType)
                return cropData[i].SellPrice;
        }

        Debug.Log("No Crop Found In Your Possesion. Go Grow Some Crops!!");
        return 0;
    }
}
