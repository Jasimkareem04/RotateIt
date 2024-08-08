using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMovement : MonoBehaviour
{
    public float maxSpeed = 10f;
    private float screenCenterX;
    
    private Vector3 fp;   //First touch position
    private Vector3 lp;   //Last touch position
    private float dragDistance;  //minimum distance for a swipe to be registered

    public float initialSpeed = 1f; // Initial forward speed
    public float acceleration = 0.1f; // Acceleration over time
    public float laneDistance = 2f; // Distance between lanes
    public float lerpSpeed = 20f; // Speed of left and right movement
    public float rotationSpeed = 15f; // Speed of rotation
    private int desiredLane = 1;//0:left, 1:middle, 2:right

    private float currentSpeed; // Current forward speed
    private Vector3 targetPosition; // Target position for Lerp
    private Rigidbody rb; // Rigidbody component

    public float rotationStep = 22.5f; // Rotation step in degrees
    private float targetZRotation; // Target Z-axis rotation


    // Start is called before the first frame update
    void Start()
    {
        screenCenterX = Screen.width * 0.5f;
        dragDistance = Screen.height * 5 / 100;

        rb = GetComponent<Rigidbody>();
        currentSpeed = initialSpeed;
        targetPosition = transform.position;
        targetZRotation = transform.rotation.eulerAngles.z;
    }
    private void FixedUpdate()
    {
        // Apply continuous forward movement
        rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, currentSpeed);
        currentSpeed = Mathf.Clamp(currentSpeed + acceleration * Time.deltaTime, initialSpeed, maxSpeed);

        // Lerp to the target position for smooth left and right movement
        transform.position = Vector3.Lerp(transform.position, new Vector3(targetPosition.x, transform.position.y, transform.position.z), Time.fixedDeltaTime * lerpSpeed);

        // Lerp to the target rotation for smooth rotation
        Quaternion targetRotation = Quaternion.Euler(0, 0, targetZRotation);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.fixedDeltaTime * rotationSpeed);
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if(desiredLane == 0 ||desiredLane == 1){
                rightMove();
                desiredLane++;
                if (desiredLane == 3)
                    desiredLane = 2;
            }
        } 
        if(Input.GetKeyDown(KeyCode.DownArrow))
        {
            if(desiredLane == 1 || desiredLane == 2){
                leftMove();
                desiredLane--;
                if (desiredLane == -1)
                    desiredLane = 0;
            }
        } 
        if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            targetZRotation += rotationStep;
            targetZRotation = Mathf.Round(targetZRotation / rotationStep) * rotationStep; // Snap to nearest multiple of 22.5
        }
        if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            targetZRotation -= rotationStep;
            targetZRotation = Mathf.Round(targetZRotation / rotationStep) * rotationStep;
        }

      
        if (Input.touchCount == 1) // user is touching the screen with a single touch
        {
            Touch touch = Input.GetTouch(0); // get the touch
            if (touch.phase == TouchPhase.Began) //check for the first touch
            {
                fp = touch.position;
                lp = touch.position;
            }
            else if (touch.phase == TouchPhase.Moved) // update the last position based on where they moved
            {
                lp = touch.position;
            }
            else if (touch.phase == TouchPhase.Ended) //check if the finger is removed from the screen
            {
                lp = touch.position;  //last touch position. Ommitted if you use list
 
                //Check if drag distance is greater than 20% of the screen height
                if (Mathf.Abs(lp.x - fp.x) > dragDistance || Mathf.Abs(lp.y - fp.y) > dragDistance)
                {//It's a drag
                 //check if the drag is vertical or horizontal
                    if (Mathf.Abs(lp.x - fp.x) > Mathf.Abs(lp.y - fp.y))
                    {   //If the horizontal movement is greater than the vertical movement...
                        if (lp.x > fp.x)  //If the movement was to the right)
                        {   //Right swipe
                           if(desiredLane == 0 || desiredLane == 1)
                            {
                             rightMove();
                                desiredLane++;
                                if (desiredLane == 3)
                                    desiredLane = 2;
                            }
                            Debug.Log("Right Swipe");
                        }
                        else
                        {   //Left swipe
                             if(desiredLane == 1 || desiredLane == 2)
                             {
                                leftMove();
                                desiredLane--;
                                if (desiredLane == -1)
                                    desiredLane = 0;
                            }
                            Debug.Log("Left Swipe");
                        }
                    }
                    else
                    {   //the vertical movement is greater than the horizontal movement
                        if (lp.y > fp.y)  //If the movement was up
                        {   //Up swipe
                            Debug.Log("Up Swipe");
                        }
                        else
                        {   //Down swipe
                            Debug.Log("Down Swipe");
                        }
                    }
                }
                else
                {   //It's a tap as the drag distance is less than 20% of the screen height
                  if(touch.position.x > screenCenterX)
                  {
                        targetZRotation -= rotationStep;
                        targetZRotation = Mathf.Round(targetZRotation / rotationStep) * rotationStep;
                    }
                  else if(touch.position.x < screenCenterX)
                  {
                        targetZRotation += rotationStep;
                        targetZRotation = Mathf.Round(targetZRotation / rotationStep) * rotationStep; // Snap to nearest multiple of 22.5
                    }
                    Debug.Log("Tap");
                }
            }
        }
    }

    void rightMove()
    {
        if (desiredLane == 1)
        {
            targetPosition = new Vector3(2, transform.position.y, transform.position.z);
        }
        else if (desiredLane == 0)
        {
            targetPosition = new Vector3(0, transform.position.y, transform.position.z);
        }
    }
    void leftMove()
    {
        if (desiredLane == 1)
        {
            targetPosition = new Vector3(-2, transform.position.y, transform.position.z);
        }
        else if (desiredLane == 2)
        {
            targetPosition = new Vector3(0, transform.position.y, transform.position.z);
        }
    }
}
