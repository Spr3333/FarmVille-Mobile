using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerAnimator))]
public class PlayerSowingAbility : MonoBehaviour
{

    [Header("Elements")]
    private PlayerAnimator anim;
    private CropField currentCropField;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<PlayerAnimator>();
        SeedCollision.SeedCollidedEvent += OnSeedCollidedCallBack;
        CropField.FieldfullySown += FullySownCallBack;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

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



    #region TriggerEvents
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("CropField") && other.GetComponent<CropField>().IsEmpty())
        {
            anim.PlaySowAnimation();
            currentCropField = other.GetComponent<CropField>();
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
}
