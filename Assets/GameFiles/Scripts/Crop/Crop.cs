using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crop : MonoBehaviour
{

    [Header("Elements")]
    [SerializeField] private Transform cropRenderer;
    [SerializeField] private ParticleSystem cornParticle;
    public void ScaleUp()
    {
        cropRenderer.gameObject.LeanScale(Vector3.one, 5).setEase(LeanTweenType.easeOutBack);
    }

    public void ScaleDown()
    {
        cropRenderer.gameObject.LeanScale(Vector3.zero, 2).setEase(LeanTweenType.easeOutBack).setOnComplete(() => Destroy(gameObject));
        cornParticle.gameObject.SetActive(true);
        cornParticle.transform.parent = null;
        cornParticle.Play();
    }
}
