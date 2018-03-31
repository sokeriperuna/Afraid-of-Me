using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    private Vector3 velocity;

    public Transform target;
    public float cameraSmoothing;

    void Track(Transform targetTransform, float trackingSmoothing)
    {
        transform.position = Vector3.SmoothDamp(transform.position, new Vector3(targetTransform.position.x, targetTransform.position.y, transform.position.z), ref velocity, trackingSmoothing);
    }

    private void Update()
    {
        if (target != null)
            Track(target, cameraSmoothing);
    }
}
