using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerToolSelector : MonoBehaviour
{
    public enum Tool
    {
        None,
        Sow,
        Water,
        Harvest
    }

    [Header("Elements")]
    private Tool toolState;
    [SerializeField] private Image[] toolsImage;
    [SerializeField] private Color selectedColor;
    // Start is called before the first frame update
    void Start()
    {
        SelectTool(0);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SelectTool(int toolIndex)
    {
        toolState = (Tool)toolIndex;
        for (int i = 0; i < toolsImage.Length; i++)
        {
            toolsImage[i].color = i == toolIndex ? selectedColor : Color.white;
        }
    }

    public bool CanSow()
    {
        return toolState == Tool.Sow;
    }

    public bool CanWater()
    {
        return toolState == Tool.Water;
    }

    public bool CanHarvest()
    {
        return toolState == Tool.Harvest;
    }
}
