using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputComponenet : MonoBehaviour
{
    float xInput;
    float yInput;
    bool running;
    float mouseMovement;

    void Update()
    {
        xInput = Input.GetAxis("Horizontal");
        yInput = Input.GetAxis("Vertical");
        running = Input.GetKey(KeyCode.LeftShift);
    }
    public float getXinput()
    {
        return xInput;
    }
    public float getYinput()
    {
        return yInput;
    }
}
