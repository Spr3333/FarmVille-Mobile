using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerAnimationEvents : MonoBehaviour
{


    [Header("Elements")]
    [SerializeField] private ParticleSystem seedFX;
    [SerializeField] private ParticleSystem waterFx;


    [Header("UnityEvents")]
    [SerializeField] private UnityEvent StartHarvestEvent;
    [SerializeField] private UnityEvent StopHarvestEvent;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void PlaySeedParticle()
    {
        seedFX.Play();
    }

    private void PlayWaterParticle()
    { 
        waterFx.Play();
    }

    private void StartHarvestCallBack()
    {
        StartHarvestEvent?.Invoke();
    }

    private void StopHarvestCallBack()
    {
        StopHarvestEvent?.Invoke();
    }
}
