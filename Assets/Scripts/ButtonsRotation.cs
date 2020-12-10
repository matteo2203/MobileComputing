using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonsRotation : MonoBehaviour
{
    // Start is called before the first frame update
    public float rotateSpeed = 180f;
    private bool UpIsPressed;
    private bool DownIsPressed;

    public void TogglePressedUp(bool value)
    {
        UpIsPressed = value;
    }
    public void TogglePressedDown(bool value)
    {
        DownIsPressed = value;
    }

    // Use this for initialization
    void Start()
    {

    }

    void Update()
    {
        if (UpIsPressed)
        {
            OnClickLeft(); //or just move the rotation code here
        }
        if (DownIsPressed)
        {
            OnClickRight();
        }
    }

    public void OnClickLeft()
    {

        transform.Rotate(Vector3.forward * rotateSpeed * Time.deltaTime);

    }
    public void OnClickRight()
    {

        transform.Rotate(Vector3.forward * -rotateSpeed * Time.deltaTime);

    }
}
