using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{

    [Header("Elements")]
    private Animator anim;
    [SerializeField] private float moveFactor;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    #region Animation
    public void ManageAnimation(Vector3 moveVector)
    {
        if(moveVector.magnitude > 0)
        {
            anim.SetFloat("moveFactor", moveVector.magnitude * moveFactor);
            PlayRunAnimation();
            anim.transform.forward = moveVector.normalized;
        }
        else
            PlayIdleAnimation();
    }
    #endregion

    #region Controlling Animation Sates
    private void PlayRunAnimation()
    {
        anim.Play("Run");
    }

    private void PlayIdleAnimation()
    {
        anim.Play("Idle");
    }
    #endregion
}