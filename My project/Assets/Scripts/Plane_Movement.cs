using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//public class Plane_Movement : MonoBehaviour
//{
//    public float speed = 0.55f;
//    public Vector3 curr;
//    public Vector2 mov;
//    public Vector3 movPosX = new Vector3(7f, 0, 0);
//    public Vector3 movPosZ = new Vector3(0, 0, 7f);
//    public bool directionChosen;
//    Touch _touch;
//    public float angle;
//    private Vector2 pos_a;
//    private Vector2 pos_b;
//    private int maxC = 5;
//    private int c = 5;

//    private Rigidbody rb;

//    void Start()
//    {
//        rb = gameObject.GetComponent<Rigidbody>();
//    }

//    void Update()
//    {
//        if(Input.touchCount > 0)
//        {
//            curr = rb.position;
//            _touch = Input.GetTouch(0);
//            switch (_touch.phase)
//            {
//                case TouchPhase.Began:
//                    print("Touched.");
//                    break;
//                case TouchPhase.Moved:
//                    if (c == maxC) { pos_a = _touch.position; c--; }
//                    else if (c > 0) { c--; }
//                    if(!directionChosen && c == 0)
//                    {
//                        pos_b = _touch.position;
//                        Vector2 swipe = pos_b - pos_a;
//                        angle = Vector2.Angle(Vector2.right, swipe);
//                        print(angle.ToString());
//                        rb.MovePosition(curr+movPosZ);
//                        directionChosen = true;
//                        c = maxC;
//                    }
//                    break;
//                case TouchPhase.Ended:
//                    directionChosen = false;
//                    c = maxC;
//                    break;
//            }
//        }
        


//    }

//    void ApplyMovement(Vector2 deltaPosition)
//    {
        
//    }
//    using UnityEngine;

public class Plane_Movement : MonoBehaviour
{
    public float stepMagnitude = 1.0f; // The magnitude of each step
    public float swipeThreshold = 50.0f; // The minimum swipe distance required to trigger movement
    public Camera mainCamera; // The main camera
    private Vector2 startPosition; // The start position of the swipe gesture

    void Update()
    {
        // Check if the user has touched the screen
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            // Check if the touch began
            if (touch.phase == TouchPhase.Began)
            {
                startPosition = touch.position;
            }
            // Check if the touch ended
            else if (touch.phase == TouchPhase.Ended)
            {
                // Calculate the swipe direction and distance
                Vector2 endPosition = touch.position;
                Vector2 swipeDirection = endPosition - startPosition;
                float swipeDistance = swipeDirection.magnitude;

                // Check if the swipe distance exceeds the threshold
                if (swipeDistance > swipeThreshold)
                {
                    // Calculate the normalized direction of the swipe
                    Vector2 swipeNormalized = swipeDirection.normalized;

                    // Calculate the movement direction based on the swipe direction
                    Vector3 movementDirection = new Vector3();
                    if (swipeNormalized.x < 0 && swipeNormalized.y > 0)
                    {
                        movementDirection = mainCamera.transform.forward + mainCamera.transform.right;
                    }
                    else if (swipeNormalized.x > 0 && swipeNormalized.y > 0)
                    {
                        movementDirection = mainCamera.transform.forward - mainCamera.transform.right;
                    }
                    else if (swipeNormalized.x < 0 && swipeNormalized.y < 0)
                    {
                        movementDirection = -mainCamera.transform.right;
                    }
                    else if (swipeNormalized.x > 0 && swipeNormalized.y < 0)
                    {
                        movementDirection = mainCamera.transform.right;
                    }

                    // Move the object by the specified step magnitude in the calculated direction
                    transform.position += movementDirection.normalized * stepMagnitude;
                }
            }
        }
    }
}
 
//}