using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationEvents : MonoBehaviour
{


    [Header("Elements")]
    [SerializeField] private ParticleSystem seedFX;
    [SerializeField] private ParticleSystem waterFx;
    
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
}
