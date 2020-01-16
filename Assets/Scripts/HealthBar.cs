using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializedField] private Transform target;
    [SerializedField] private Vector3 offset;
    [SerializedField] private Image image;

    // Update is called once per frame
    void Update()
    {
        transform.position = target.position + offset;
    }
}
