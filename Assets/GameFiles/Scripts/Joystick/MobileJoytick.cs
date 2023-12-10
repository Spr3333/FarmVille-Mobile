using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobileJoytick : MonoBehaviour
{

    [Header("Elements")]
    [SerializeField] private RectTransform joyStick_outline;
    [SerializeField] private RectTransform joyStick_Knob;


    [Header("Settings")]
    private Vector3 clickedMousePos;
    private bool canControl;
    [SerializeField] private float movefactor = 10;
    private Vector3 move;
    // Start is cal led before the first frame update
    void Start()
    {
        HideJoyStick();
    }

    // Update is called once per frame
    void Update()
    {
        if (canControl)
            MoveJoyStick();
    }

    public void OnClickedCallBackEvent()
    {
        clickedMousePos = Input.mousePosition;
        joyStick_outline.position = clickedMousePos;
        ShowJoyStick();
    }

    private void ShowJoyStick()
    {
        joyStick_outline.gameObject.SetActive(true);
        canControl = true;
    }

    private void HideJoyStick()
    {
        joyStick_outline.gameObject.SetActive(false);
        canControl = false;
        move = Vector3.zero;
    }

    private void MoveJoyStick()
    {
        Vector3 currentMousePos = Input.mousePosition;

        Vector3 distance = currentMousePos - clickedMousePos;

        float moveMagnitude = distance.magnitude * movefactor / Screen.width;
        moveMagnitude = Mathf.Min(moveMagnitude, joyStick_outline.rect.width / 2);

        move = distance.normalized * moveMagnitude;
        joyStick_Knob.position = clickedMousePos + move;

        if(Input.GetMouseButtonUp(0))
        {
            HideJoyStick();
        }
    }

    public Vector3 GetMoveVector()
    {
        return move;
    }
}
