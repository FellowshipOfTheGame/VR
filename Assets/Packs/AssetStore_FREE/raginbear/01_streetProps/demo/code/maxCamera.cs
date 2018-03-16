using UnityEngine;
using System.Collections;


[AddComponentMenu("Camera-Control/3dsMax Camera Style")]
public class maxCamera : MonoBehaviour
{
    public bool useFovLerp;
    public Transform target;
    public Vector3 targetOffset;
    public float distance = 5.0f;
    public float maxDistance = 20;
    public float minDistance = .6f;
    public float xSpeed = 200.0f;
    public float ySpeed = 200.0f;
    public int yMinLimit = -80;
    public int yMaxLimit = 80;
    public int zoomRate = 40;
    public float panSpeed = 0.3f;
    public float zoomDampening = 5.0f;
    public float zoomMultiplier = 5.0f;
    public float XYmin = 15f;
    public float XYmax = 150f;
    public float PanMin = 1f;
    public float PanMax = 5f;
    public bool AllowColorChange;
    public float minFov;
    public float maxFov;
    public Camera mainCam;

    private float xDeg = 0.0f;
    private float yDeg = 0.0f;
    public float currentDistance;
    private float desiredDistance;
    private Quaternion currentRotation;
    private Quaternion desiredRotation;
    private Quaternion rotation;
    private Vector3 position;
    public float invLerp;
    float lerp;
    bool firstLaunch = true;
    private Vector3 tempVec3;
    float storedDistance;

    void Start() { Init(); }
    void OnEnable() { Init(); }



    public void Init()
    {

        mainCam = this.transform.GetComponent<Camera>();

        //If there is no target, create a temporary target at 'distance' from the cameras current viewpoint
        if (!target)
        {
            GameObject go = new GameObject("Cam Target");
            go.transform.position = transform.position + (transform.forward * distance);
            target = go.transform;
        }

        distance = Vector3.Distance(transform.position, target.position);
        currentDistance = distance;
        desiredDistance = distance;

        //be sure to grab the current rotations as starting points.
        position = transform.position;
        rotation = transform.rotation;
        currentRotation = transform.rotation;
        desiredRotation = transform.rotation;

        xDeg = Vector3.Angle(Vector3.right, transform.right);
        yDeg = Vector3.Angle(Vector3.up, transform.up);
    }

    /*
     * Camera logic on LateUpdate to only update after all character movement logic has been handled. 
     */
    void LateUpdate()
    {
        // If Control and Alt and Middle button? ZOOM!
        UpdatePanSpeedWithDistance();
        if (Input.GetMouseButton(1) )
        {
            desiredDistance -= Input.GetAxis("Mouse Y") * Time.deltaTime * zoomRate * 0.125f * Mathf.Abs(desiredDistance);
        }
        // If middle mouse and left alt are selected? ORBIT
        //else if (Input.GetMouseButton(0) && Input.GetKey(KeyCode.LeftAlt))
        else if (Input.GetMouseButton(0))
        {
            xDeg += Input.GetAxis("Mouse X") * xSpeed * 0.02f;
            yDeg -= Input.GetAxis("Mouse Y") * ySpeed * 0.02f;

            ////////OrbitAngle

            //Clamp the vertical axis for the orbit
            yDeg = ClampAngle(yDeg, yMinLimit, yMaxLimit);
            // set camera rotation 
            desiredRotation = Quaternion.Euler(yDeg, xDeg, 0);
            currentRotation = transform.rotation;

            rotation = Quaternion.Lerp(currentRotation, desiredRotation, Time.deltaTime * zoomDampening);
            transform.rotation = rotation;
        }
        // otherwise if middle mouse is selected, we pan by way of transforming the target in screenspace
        else if (Input.GetMouseButton(2))
        {
            //grab the rotation of the camera so we can move in a psuedo local XY space
            target.rotation = transform.rotation;
            tempVec3 = Vector3.right * -Input.GetAxis("Mouse X") * panSpeed;
            tempVec3.y = 0;
            target.Translate(tempVec3);
            tempVec3 = transform.up * -Input.GetAxis("Mouse Y") * panSpeed;
            tempVec3.y = 0;
            target.Translate(tempVec3, Space.World);
        }

        ////////Orbit Position

        // affect the desired Zoom distance if we roll the scrollwheel
        desiredDistance -= Input.GetAxis("Mouse ScrollWheel") * Time.deltaTime * zoomRate * Mathf.Abs(desiredDistance);
        //clamp the zoom min/max
        desiredDistance = Mathf.Clamp(desiredDistance, minDistance, maxDistance);
        // For smoothing of the zoom, lerp distance
        currentDistance = Mathf.Lerp(currentDistance, desiredDistance, Time.deltaTime * zoomMultiplier );

        // calculate position based on the new currentDistance 
        position = target.position - (rotation * Vector3.forward * currentDistance + targetOffset);
        transform.position = position;


        //check if distance changed last frame
        CheckChange();
        //change fov by distance
        ModifyFov();
    }

    private static float ClampAngle(float angle, float min, float max)
    {
        if (angle < -360)
            angle += 360;
        if (angle > 360)
            angle -= 360;
        return Mathf.Clamp(angle, min, max);
    }

    void UpdatePanSpeedWithDistance()
    {
        invLerp = Mathf.InverseLerp(minDistance, maxDistance, currentDistance);
        lerp = Mathf.Lerp(XYmin, XYmax, invLerp);
        xSpeed = lerp;
        ySpeed = lerp;
        
        lerp = Mathf.Lerp(PanMin, PanMax, invLerp);
        panSpeed = lerp;
    }

    void CheckChange()
    {
        if ( firstLaunch)
        {
            storedDistance = currentDistance;
            firstLaunch = false;
        }

        else
        {
            if (storedDistance == currentDistance)
            {
                AllowColorChange = false;
            }
            else
            {
                AllowColorChange = true;
            }
            storedDistance = currentDistance;
        }
    }

    void ModifyFov()
    {
        if (useFovLerp)
        {
            mainCam.fieldOfView = Mathf.Lerp(minFov, maxFov, invLerp);
        }
    }
}