using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerAnimator))]
[RequireComponent (typeof(PlayerToolSelector))]
public class PlayerSowingAbility : MonoBehaviour
{

    [Header("Elements")]
    private PlayerAnimator anim;
    private CropField currentCropField;
    private PlayerToolSelector toolSelector;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<PlayerAnimator>();
        toolSelector = GetComponent<PlayerToolSelector>();
        SeedCollision.SeedCollidedEvent += OnSeedCollidedCallBack;
        CropField.FieldfullySown += FullySownCallBack;
        toolSelector.SelectedTool += SelectedToolCallBack;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
 


    #region Event CallBacks
    private void OnSeedCollidedCallBack(Vector3[] seedPos)
    {
        if (currentCropField != null)
            currentCropField.SeedCollidedCallBack(seedPos);
    }

    private void FullySownCallBack(CropField cropField)
    {
        if(currentCropField == cropField)
        {
            anim.StopSowAniamtion();
        }
    }

    private void SelectedToolCallBack(PlayerToolSelector.Tool tool)
    {
        if(!toolSelector.CanSow())
        {
            anim.StopSowAniamtion();
        }
    }
    #endregion


    #region TriggerEvents
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("CropField") && other.GetComponent<CropField>().IsEmpty())
        {
            currentCropField = other.GetComponent<CropField>();
            EnteredCropField(currentCropField);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("CropField"))
        {
            EnteredCropField(other.GetComponent<CropField>());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("CropField"))
        {
            anim.StopSowAniamtion();
            currentCropField = null;
        }
    }
    #endregion

    private void EnteredCropField(CropField cropField)
    {
        if(toolSelector.CanSow() && cropField.IsEmpty())
        {
            if (currentCropField == null)
                currentCropField = cropField;
            anim.PlaySowAnimation();
        }
    }
}
