using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementComponent : MonoBehaviour
{
    Rigidbody rb;
    InputComponenet input;
    public float speed;
    public float maxVelocity;
    [Range(0,1)] public float smoothVelocityGainSpeed;
    private Vector3 currentVel;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        input = gameObject.GetComponent<InputComponenet>();
    }

    void FixedUpdate()
    {
        MovePlayer();
    }

    void MovePlayer()
    {
        Vector3 movementVector = new Vector3(input.getXinput(), 0 , input.getYinput());
        currentVel = Vector3.Lerp(currentVel, movementVector.normalized*speed, Time.deltaTime*smoothVelocityGainSpeed*10);
        rb.velocity = currentVel + rb.velocity.y*Vector3.up;
    }

}
