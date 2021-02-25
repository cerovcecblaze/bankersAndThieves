using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public Transform target;

    public float smoothTime = 0.3f;

    public float cameraHeight = -30;

    private Vector3 velocity = Vector3.zero;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (target == null) {
            return;
        }
        Vector3 targetPosition = target.TransformPoint(new Vector3(0, 0, cameraHeight));
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
    }

}
