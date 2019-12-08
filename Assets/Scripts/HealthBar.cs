using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;
    public Image image;

    // Update is called once per frame
    void Update()
    {
        transform.position = target.position + offset;
    }
}
