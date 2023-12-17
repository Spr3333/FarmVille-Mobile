using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerToolSelector))]
[RequireComponent(typeof(PlayerAnimator))]
public class PlayerWaterAbility : MonoBehaviour
{

    [Header("Elements")]
    private PlayerToolSelector toolSelector;
    private PlayerAnimator anim;
    private CropField currentCropField;
    // Start is called before the first frame update
    void Start()
    {
        toolSelector = GetComponent<PlayerToolSelector>();
        anim = GetComponent<PlayerAnimator>();
        WaterCollison.OnWaterCollided += WaterCollidedCallBack;
        toolSelector.SelectedTool += ToolSelectedCallBack;
        CropField.FieldfullyWatered += FullyWateredCallBack;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnDestroy()
    {
        WaterCollison.OnWaterCollided -= WaterCollidedCallBack;
        toolSelector.SelectedTool -= ToolSelectedCallBack;
        CropField.FieldfullyWatered -= FullyWateredCallBack;
    }

    #region CallBacks
    private void WaterCollidedCallBack(Vector3[] waterPos)
    {
        if (currentCropField != null)
            currentCropField.WaterCollidedCallBack(waterPos);
    }

    private void ToolSelectedCallBack(PlayerToolSelector.Tool tool)
    {
        if (!toolSelector.CanWater())
        {
            anim.StopWaterAnimation();
        }
    }

    private void FullyWateredCallBack(CropField cropfield)
    {
        if (currentCropField == cropfield)
        {
            anim.StopWaterAnimation();
        }
    }
    #endregion


    #region Trigger Events
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("CropField") && other.GetComponent<CropField>().IsSown())
        {
            currentCropField = other.GetComponent<CropField>();
            EnteredCropField(currentCropField);
        }
    }

    private void EnteredCropField(CropField cropField)
    {
        if (toolSelector.CanWater() && cropField.IsSown())
        {
            anim.PlayWaterAnimation();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("CropField"))
        {
            EnteredCropField(other.GetComponent<CropField>());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("CropField"))
        {
            anim.StopWaterAnimation();
            currentCropField = null;
        }
    }
    #endregion
}
