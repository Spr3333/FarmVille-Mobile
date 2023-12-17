using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCropinteractor : MonoBehaviour
{

    [Header("Elements")]
    [SerializeField] private Material[] materials;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < materials.Length; i++)
        {
            materials[i].SetVector("_PlayerPos", transform.position);
        }
    }
}
