using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementComponent : MonoBehaviour
{
    Rigidbody rb;
    InputComponenet input;
    public float speed;
    public float maxVelocity;
    public float smoothVelocityGainSpeed;
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
        Vector3 velocityVector = Vector3.Lerp(rb.velocity, movementVector.normalized*speed, Time.deltaTime*smoothVelocityGainSpeed*10);
        velocityVector = Vector3.ClampMagnitude(velocityVector, maxVelocity);
        velocityVector.y = rb.velocity.y;
        rb.velocity = velocityVector;
    }

}
