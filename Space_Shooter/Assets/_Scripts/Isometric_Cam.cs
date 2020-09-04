using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Isometric_Cam : MonoBehaviour
{

    public Transform target;
    public float Height = 10f;
    public float Distance = 20f;
    public float Angle = 45f;
    public float smoothSpeed = .5f;
    Vector3 refVelocity;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        HandleCam();
    }

    void HandleCam()
    {
        if (!target)
        {
            return;
        }

        //Set height of Camera
        Vector3 worldPosition = (Vector3.forward * -Distance) + (Vector3.up * Height);
        //Set rotaion of Camera
        Vector3 rotatedVector = Quaternion.AngleAxis(Angle, Vector3.up) * worldPosition;
        //Move Camera
        Vector3 flatTargetPosition = target.position;
        flatTargetPosition.y = 0;
        Vector3 finalPosition = flatTargetPosition + rotatedVector;
        transform.position = finalPosition;

        transform.position = Vector3.SmoothDamp(transform.position, finalPosition, ref refVelocity, smoothSpeed);
        //Look at Target
        transform.LookAt(flatTargetPosition);
    }
}
