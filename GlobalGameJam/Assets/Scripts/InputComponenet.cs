using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputComponenet : MonoBehaviour
{
    float xInput;
    float yInput;
    bool running;
    Vector3 mouseMovement;

    void Update()
    {
        xInput = Input.GetAxisRaw("Horizontal");
        yInput = Input.GetAxisRaw("Vertical");
        running = Input.GetKey(KeyCode.LeftShift);
        mouseMovement = Input.mousePosition;
    }
    public float getXinput()
    {
        return xInput;
    }
    public float getYinput()
    {
        return yInput;
    }
    public Vector3 getMouse()
    {
        return mouseMovement;
    } 
}
