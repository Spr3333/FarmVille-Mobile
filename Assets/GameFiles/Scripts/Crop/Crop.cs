using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crop : MonoBehaviour
{

    [Header("Elements")]
    [SerializeField] private Transform cropRenderer;
    public void ScaleUp()
    {
        cropRenderer.gameObject.LeanScale(Vector3.one, 5).setEase(LeanTweenType.easeOutBack);
    }
}
