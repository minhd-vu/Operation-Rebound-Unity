using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MutipleCameraFollow : MonoBehaviour
{
    public List<Transform> targets;
    public Vector3 offset;
    public float smoothTime;
    private Vector3 velocity;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (targets.Count == 0)
        {
            return;
        }

        transform.position = Vector3.SmoothDamp(transform.position, GetCenter() + offset, ref velocity, smoothTime);
    }

    Vector3 GetCenter()
    {
        if (targets.Count == 1)
        {
            return targets[0].position;
        }

        var bounds = new Bounds(targets[0].position, Vector3.zero);

        foreach (Transform target in targets)
        {
            bounds.Encapsulate(target.position);
        }

        return bounds.center;
    }
}
