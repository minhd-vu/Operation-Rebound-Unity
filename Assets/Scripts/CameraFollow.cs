using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * A simple camera script that statically follows around a transform.
 */
public class CameraFollow : MonoBehaviour
{
    public Transform target;

    public float smoothTime;
    public float maxSpeed;

    public Vector3 offset;
    private Vector3 velocity = Vector3.zero;

    // Update is called once per frame
    void LateUpdate()
    {
        // Smooth camera follows the target
        transform.position = Vector3.SmoothDamp(transform.position, target.position + offset, ref velocity, smoothTime, maxSpeed);
        velocity.z = 0;
    }
}
