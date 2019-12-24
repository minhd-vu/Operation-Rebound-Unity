using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [HideInInspector] public float moveSpeedBonus;
    //[SerializeField]
    //private float rotateSpeed;
    private Rigidbody2D rb;
    private Vector2 input;
    private Vector2 mousePosition;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        moveSpeedBonus = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        // Get input from player
        input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(Dash(dashDuration));
        }
    }

    public IEnumerator Dash(float duration)
    {
        Vector3 dashVector = rb.transform.position + (Vector3)input * dashForce;
        rb.DOMove(dashVector, duration);
        Physics2D.IgnoreLayerCollision(10, 11, isDashing = true);
        yield return new WaitForSeconds(duration);
        Physics2D.IgnoreLayerCollision(10, 11, isDashing = false);
    }

    public bool isDashing = false;
    [SerializeField] private float dashForce = 3f;
    [SerializeField] private float dashDuration = 0.3f;

    private void FixedUpdate()
    {
        // Move the player based on the input.
        float speed = moveSpeed + moveSpeedBonus;

        if (!isDashing)
        rb.velocity = new Vector2(input.x * speed, input.y * speed);

        // Rotate the player
        Vector2 direction = mousePosition - rb.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        //transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.AngleAxis(angle, Vector3.forward), dir.normalized.magnitude * rotationSpeed * Time.deltaTime);
        rb.rotation = angle;
    }
}
