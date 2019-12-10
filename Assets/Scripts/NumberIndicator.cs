using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NumberIndicator : MonoBehaviour
{
    public float moveSpeed;
    public int number;
    public Text displayNumber;
    public float duration;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        displayNumber.text = "" + number;
        transform.position = new Vector3(transform.position.x, transform.position.y + moveSpeed * Time.deltaTime);

        if ((duration -= Time.deltaTime) <= 0)
        {
            Destroy(gameObject);
        }
    }
}
