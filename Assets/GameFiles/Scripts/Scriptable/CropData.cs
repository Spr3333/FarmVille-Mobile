using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Crop Data", menuName = "Scriptable/ Crop Data")]
public class CropData : ScriptableObject
{
    [SerializeField]
    public Crop cropPrefab;
    public CropType cropType;
    public Sprite icon;
    public int SellPrice;
}
