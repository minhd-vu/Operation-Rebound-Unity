using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestoryAnimation : MonoBehaviour
{
    [SerializeField]
    private float delay = 0f;

    // Use this for initialization
    void Start()
    {
        Destroy(gameObject, GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length + delay);
    }
}
