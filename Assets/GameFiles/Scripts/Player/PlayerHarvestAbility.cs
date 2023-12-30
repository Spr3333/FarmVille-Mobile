using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerToolSelector))]
[RequireComponent(typeof(PlayerAnimator))]
public class PlayerHarvestAbility : MonoBehaviour
{
    PlayerToolSelector toolSelector;
    PlayerAnimator anim;
    private CropField currentCropField;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<PlayerAnimator>();
        toolSelector = GetComponent<PlayerToolSelector>();
        toolSelector.SelectedTool += ToolSelectedCallBack;
        CropField.FieldFullyHarvested += FullyWateredCallbAck;
    }

    private void OnDestroy()
    {
        toolSelector.SelectedTool -= ToolSelectedCallBack;
        CropField.FieldFullyHarvested -= FullyWateredCallbAck;
    }

    // Update is called once per frame
    void Update()
    {

    }

    #region CallBacks
    private void ToolSelectedCallBack(PlayerToolSelector.Tool tool)
    {
        if (!toolSelector.CanHarvest())
        {
            anim.StopHarvestAnimation();
        }
    }

    private void FullyWateredCallbAck(CropField cropField)
    {
        if (cropField == currentCropField)
        {
            anim.StopHarvestAnimation();
        }
    }
    #endregion

    #region TriggerEvents
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("CropField") && other.GetComponent<CropField>().IsWatered())
        {
            currentCropField = other.GetComponent<CropField>();
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
            anim.StopHarvestAnimation();
            currentCropField = null;
        }
    }
    #endregion

    private void EnteredCropField(CropField cropField)
    {
        if (toolSelector.CanHarvest() && cropField.IsWatered())
        {
            if (currentCropField == null)
                currentCropField = cropField;
            anim.PlayHarvestAnimation();
        }
    }
}
