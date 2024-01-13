using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CropTile : MonoBehaviour
{


    [Header("Events")]
    public static Action<CropType> OnCropHarvested;

    [Header("Elements")]
    private TileFieldState state;
    private Crop crop;
    [SerializeField] private Transform cropParent;
    [SerializeField] private MeshRenderer rend;
     private CropData cropdata;
    // Start is called before the first frame update
    void Start()
    {
        state = TileFieldState.Empty;
    }

    // Update is called once per frame
    void Update()
    {

    }

    #region Planting Process

    public void Sow(CropData cropData)
    {
        state = TileFieldState.Sown;
        crop = Instantiate(cropData.cropPrefab, this.transform.position, Quaternion.identity, cropParent);
        this.cropdata = cropData;
    }

    public void Water()
    {
        state = TileFieldState.Watered;
        rend.gameObject.LeanColor(Color.white * 0.3f, 2);
        crop.ScaleUp();
    }

    public void Harvest()
    {
        rend.gameObject.LeanColor(Color.white, 2);
        state = TileFieldState.Empty;
        crop.ScaleDown();
        OnCropHarvested?.Invoke(cropdata.cropType);
    }
    #endregion
    public bool IsEmpty()
    {
        return state == TileFieldState.Empty;        
    }

    public bool IsSown()
    {
        return state == TileFieldState.Sown;
    }
}
