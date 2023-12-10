using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
[RequireComponent (typeof(PlayerAnimator))]
public class PlayerController : MonoBehaviour
{

    [Header("Elements")]
    [SerializeField] private MobileJoytick joystick;
    [SerializeField] private float moveFactor;


    [Header("Settings")]
    private CharacterController cc;
    private PlayerAnimator playerAnimator;

    // Start is called before the first frame update
    void Start()
    {
        cc = GetComponent<CharacterController>();    
        playerAnimator = GetComponent<PlayerAnimator>();
    }

    // Update is called once per frame
    void Update()
    {
        Managemovement();
    }

    #region movement
    private void Managemovement()
    {
        Vector3 moveTarget = joystick.GetMoveVector() * moveFactor * Time.deltaTime/Screen.width;
        moveTarget.z = moveTarget.y;
        moveTarget.y = 0;
        cc.Move(moveTarget);
        playerAnimator.ManageAnimation(moveTarget);
    }
    #endregion
}
