using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CropField : MonoBehaviour
{

    [Header("Events")]
    public static Action<CropField> FieldfullySown;
    public static Action<CropField> FieldfullyWatered;
    public static Action<CropField> FieldFullyHarvested;

    [Header("Elements")]
    [SerializeField] private Transform tileParent;
    [SerializeField] private CropData cropData;

    [Header("Settings")]
    List<CropTile> cropTiles = new List<CropTile>();
    private TileFieldState state;
    private int tileSown;
    private int tileWatered;
    private int tileHarvested;

    // Start is called before the first frame update
    void Start()
    {
        StoreTiles();
    }

    // Update is called once per frame
    void Update()
    {

    }

    #region DeveloperMode
    [NaughtyAttributes.Button]
    private void InstantlySowTiles()
    {
        for (int i = 0; i < cropTiles.Count; i++)
        {
            Sow(cropTiles[i]);
        }
    }

    [NaughtyAttributes.Button]
    private void InstantlyWatertiles()
    {
        for (int i = 0; i < cropTiles.Count; i++)
        {
            Water(cropTiles[i]);
        }
    }

    #endregion

    private void StoreTiles()
    {
        for (int i = 0; i < tileParent.childCount; i++)
        {
            cropTiles.Add(tileParent.GetChild(i).GetComponent<CropTile>());
        }
    }

    #region Sowing Process
    public void SeedCollidedCallBack(Vector3[] seedPos)
    {
        for (int i = 0; i < seedPos.Length; i++)
        {
            CropTile closestCropTile = GetClosestTile(seedPos[i]);

            if (closestCropTile == null)
                continue;

            if (!closestCropTile.IsEmpty())
                continue;
            Sow(closestCropTile);
        }
    }

    private void Sow(CropTile cropTile)
    {
        cropTile.Sow(cropData);
        tileSown++;

        if (tileSown == cropTiles.Count)
            FieldFullySown();
    }

    private void FieldFullySown()
    {
        state = TileFieldState.Sown;
        FieldfullySown?.Invoke(this);
    }
    #endregion

    #region Watering Process
    public void WaterCollidedCallBack(Vector3[] waterPos)
    {
        for (int i = 0; i < waterPos.Length; i++)
        {
            CropTile closestCropTile = GetClosestTile(waterPos[i]);

            if (closestCropTile == null)
                continue;
            if (!closestCropTile.IsSown())
                continue;

            Water(closestCropTile);
        }
    }

    private void Water(CropTile cropTile)
    {
        tileWatered++;
        cropTile.Water();
        if (tileWatered == cropTiles.Count)
        {
            FieldFullyWatered();
        }
    }

    private void FieldFullyWatered()
    {
        state = TileFieldState.Watered;
        FieldfullyWatered?.Invoke(this);
    }
    #endregion

    #region Harvest Process
    public void Harvest(Transform harvestSphere)
    {
        float harvestRad = harvestSphere.localScale.x;

        for (int i = 0; i < cropTiles.Count; i++)
        {
            if (cropTiles[i].IsEmpty())
                continue;

            float distance = Vector3.Distance(cropTiles[i].transform.position , harvestSphere.transform.position);

            if(distance <= harvestRad)
                HarvestTile(cropTiles[i]);
        }

    }

    private void HarvestTile(CropTile cropTile)
    {
        cropTile.Harvest();

        tileHarvested++;

        if(tileHarvested == cropTiles.Count)
        {
            FieldfullyHarvested();
        }
    }

    private void FieldfullyHarvested()
    {
        tileSown = 0;
        tileWatered = 0;
        tileHarvested = 0;
        state = TileFieldState.Empty;
        FieldFullyHarvested?.Invoke(this);
    }
    #endregion

    private CropTile GetClosestTile(Vector3 seedPos)
    {
        float minDistance = 5000f;
        int closestTileindex = -1;
        for (int i = 0; i < cropTiles.Count; i++)
        {
            float distance = Vector3.Distance(cropTiles[i].transform.position, seedPos);
            if (distance < minDistance)
            {
                minDistance = distance;
                closestTileindex = i;
            }

        }

        if (closestTileindex == -1)
            return null;

        return cropTiles[closestTileindex];
    }

    public bool IsEmpty()
    {
        return state == TileFieldState.Empty;
    }

    public bool IsSown()
    {
        return state == TileFieldState.Sown;
    }

    public bool IsWatered()
    {
        return state == TileFieldState.Watered;
    }
}
