using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    public float speed = 10f;
    private Rigidbody rb;
    private CharacterController controller;

    public float forwardspeed = 10.0f;
    public float dragSpeed = 5.0f;
    public Vector3 moveVector;
    void Start()
    {
        //rb = GetComponent<Rigidbody>();
        controller = GetComponent<CharacterController>();
    }

    void Update()
    { 

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            moveVector = new Vector3(0, 0, forwardspeed);

            if(touch.phase == TouchPhase.Moved)
            {
                Vector2 touchDeltaPosition = Input.GetTouch(0).deltaPosition;
                ApplyMovement(touchDeltaPosition);

            }

            controller.Move(moveVector * Time.deltaTime);
        }
    }

    void ApplyMovement(Vector2 deltaPosition)
    {
        float x = deltaPosition.x * dragSpeed;
        //   float y = deltaPosition.y * speed * Time.deltaTime;
        //   float z = 1.0f; // Set the Z direction force value here

        //   Vector3 movement = new Vector3(x, y, z);

        //  rb.AddForce(movement);

        moveVector = new Vector3(x, 0, 0);
    }
}
