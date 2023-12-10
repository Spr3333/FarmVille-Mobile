using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TileFieldState
{
    Empty,
    Sown,
    Watered
}
public class CropTile : MonoBehaviour
{

    [Header("Elements")]
    private TileFieldState state;
    private Crop crop;
    [SerializeField] private Transform cropParent;
    // Start is called before the first frame update
    void Start()
    {
        state = TileFieldState.Empty;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Sow(CropData cropData)
    {
        state = TileFieldState.Sown;
        crop = Instantiate(cropData.cropPrefab, this.transform.position, Quaternion.identity, cropParent);
    }

    public bool IsEmpty()
    {
        return state == TileFieldState.Empty;
    }

    public bool IsSown()
    {
        return state == TileFieldState.Sown;
    }
}
