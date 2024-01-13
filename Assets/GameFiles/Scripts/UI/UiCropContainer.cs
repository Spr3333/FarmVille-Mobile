using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UiCropContainer : MonoBehaviour
{

    [Header("Elements")]
    [SerializeField] private Image iconImage;
    [SerializeField] private TextMeshProUGUI cropAmount;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Configure(Sprite icon , int amount)
    {
        iconImage.sprite = icon;
        cropAmount.text = amount.ToString();
    }

    public void UpdateDisplay(int amount)
    {
        cropAmount.text = amount.ToString();
    }
}
