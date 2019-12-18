using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed;
    [HideInInspector]
    public float moveSpeedBonus;
    //[SerializeField]
    //private float rotateSpeed;
    private Rigidbody2D rb;
    private Vector2 input;
    private Vector3 direction;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        moveSpeedBonus = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        direction = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
    }

    private void FixedUpdate()
    {
        // Move the player based on the input.
        float speed = moveSpeed + moveSpeedBonus;

        // Move the player slower when they are moving diagonally to maintain the same magnitude.
        if (Math.Abs(input.x) > 0 && Math.Abs(input.y) > 0)
        {
            speed /= Mathf.Sqrt(2);
        }

        //transform.Translate(Input.GetAxisRaw("Horizontal") * speed * Time.deltaTime, Input.GetAxisRaw("Vertical") * speed * Time.deltaTime, 0, Space.World);
        //rb.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * speed * Time.deltaTime, Input.GetAxisRaw("Vertical") * speed * Time.deltaTime);
        rb.velocity = new Vector2(input.x * speed, input.y * speed);
        //rb.AddForce(new Vector2(Input.GetAxisRaw("Horizontal") * speed, Input.GetAxisRaw("Vertical") * speed));

        /**
         * Rotate the player towards the mouse cursor.
         * Find the direction vector.
         * Find the angle and convert it into degrees.
         * Slerp the value for a smooth rotation (removed).
         **/
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        //transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.AngleAxis(angle, Vector3.forward), dir.normalized.magnitude * rotationSpeed * Time.deltaTime);
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
}
