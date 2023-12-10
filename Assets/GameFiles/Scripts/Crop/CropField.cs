using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CropField : MonoBehaviour
{

    [Header("Events")]
    public static Action<CropField> FieldfullySown;
    [Header("Elements")]
    [SerializeField] private Transform tileParent;
    List<CropTile> cropTiles = new List<CropTile>();
    private TileFieldState state;
    [SerializeField] private CropData cropData;
    private int tileSown;
    // Start is called before the first frame update
    void Start()
    {
        StoreTiles();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void StoreTiles()
    {
        for(int i = 0; i < tileParent.childCount; i++)
        {
            cropTiles.Add(tileParent.GetChild(i).GetComponent<CropTile>());
        }
    }

    public void SeedCollidedCallBack(Vector3[] seedPos)
    {
        for(int i=0; i < seedPos.Length; i++)
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
}
