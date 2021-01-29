using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtMouse : MonoBehaviour
{
    [Range(0,1)] public float smoothRotation;
    Camera cam;
    Vector3 mousePoint;
    InputComponenet input;
    void Start()
    {
        cam = Camera.main;
        input = GetComponent<InputComponenet>();
    }
    void FixedUpdate()
    {
        setMousePoint();
        Quaternion rotation;
        rotation =  Quaternion.LookRotation((mousePoint-transform.position), Vector3.up);
        rotation.eulerAngles = new Vector3(0, rotation.eulerAngles.y, 0);
        transform.rotation = Quaternion.Lerp(transform.rotation, rotation, Time.deltaTime*10*smoothRotation);
    }
    void setMousePoint()
    {
        Ray ray = cam.ScreenPointToRay(input.getMouse());
        RaycastHit hit;
        if(Physics.Raycast(ray, out hit))        
            mousePoint = hit.point;     
    }
}
