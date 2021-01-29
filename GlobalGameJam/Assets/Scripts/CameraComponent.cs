using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraComponent : MonoBehaviour
{
    public GameObject followTarget;
    public float height;
    private Vector3 position;
    [Range(0,1)]  public float speed;
    // Update is called once per frame
    void FixedUpdate()
    {
        if(followTarget)
        {
            position = Vector3.Lerp(transform.position, followTarget.transform.position+height*Vector3.up, speed*Time.deltaTime*10);
            transform.position = position;
        }
    }
}
