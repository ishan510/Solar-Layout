using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControler : MonoBehaviour
{
    Transform rotationTarget; // parent of this obj 
    Transform target; // parent of the parent of this obj 
    Vector3 lastPosition;

    //Zooming variables 
    float zoomDistance;
    float scrollSensitivity = 3;

    public float minDistance = 3f;
    public float maxDistance = 10f;

    //Panning variables 
    float panSensitivity = 0.005f;

    //Orbit variables 
    float rotationSensitivity = 0.05f;

    void Awake() // https://docs.unity3d.com/ScriptReference/MonoBehaviour.Awake.html
    {
        rotationTarget = transform.parent; // rotation target 
        target = rotationTarget.transform.parent; // camera rig 
        zoomDistance = Vector3.Distance(target.position, transform.position);
    }
    void Update()
    {
        transform.LookAt(target); // makes sure our forward vector points are pointing at the camera rig 

        if (Input.GetMouseButtonDown(1))
        {
            lastPosition = Input.mousePosition; // to help with panning and rotating 
        }
        if (Input.GetMouseButtonDown(2))
        {
            lastPosition = Input.mousePosition;
        }

        Zoom();
        Pan();
        Orbit();
    }
    void Zoom()
    {
        float num = Input.GetAxis("Mouse ScrollWheel"); // getting axis of where the scroll wheel is 

        zoomDistance -= num * scrollSensitivity;

        zoomDistance = Mathf.Clamp(zoomDistance, minDistance, maxDistance); // clamp sets range for camera to move in and out 

        Vector3 pos = target.position; // posistion of the target obj aka the camera rig 

        pos -= transform.forward * zoomDistance;

        // interpolation of the distance bewteen the camera and the camera rig at a rate of scrollSensitivity
        // the transform is attached to the obj that we attached the script to, aka the camera that is why we don't declare the camera in the script 
        transform.position = Vector3.Lerp(transform.position, pos, scrollSensitivity); 
    }
    void Pan()
    {
        if (Input.GetMouseButton(2)) // middle mouse click 
        {

            Vector3 delta = Input.mousePosition - lastPosition; // finds the mouse position on screen 
            target.Translate(delta.x * panSensitivity, 0, delta.y * panSensitivity); // manipulates the x and z axis not the y axis 
            lastPosition = Input.mousePosition; // update last position 
        }
    }
    void Orbit()
    {
        if (Input.GetMouseButton(1))
        {
            Vector3 delta = Input.mousePosition - lastPosition; 
            float angleY = -delta.y * rotationSensitivity; // this the change in angle in the y direction 
            float angleX = delta.x * rotationSensitivity; // this the change in angle in the x direction 

            //X axis
            Vector3 angles = rotationTarget.transform.eulerAngles;

            angles.x += angleY;
            //TODO: Experiment with these angles so that navigation of the obj is more comfortable!
            angles.x = Mathf.Clamp(angles.x, 10f, 80f); // another clamp so that we dont go beneath the objects 

            rotationTarget.transform.eulerAngles = angles; // rotationTarget rotates first then we manipulate the camera to follow suit 

            target.transform.RotateAround(target.position, Vector3.up, angleX); // since we have the camera looking at the camera rig then it will follow the rotation

            lastPosition = Input.mousePosition; 
        }  
    }
}
