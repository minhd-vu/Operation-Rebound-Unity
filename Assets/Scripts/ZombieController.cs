using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ZombieController : MonoBehaviour
{
    //public Transform target;
    public float moveSpeed;
    public float rotationOffset;
    private Rigidbody2D rb;
    private bool moving;
    private Vector3 direction;

    private float movingTime;
    private float movingTimer;

    private float waitingTime;
    private float waitingTimer;

    public float attackDamage;
    private float health;

    public GameObject healthBar;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        moving = false;
        //target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

        movingTime = Random.Range(1f, 2f);
        movingTimer = 0;
        waitingTime = Random.Range(1f, 2f);
        waitingTimer = Random.Range(0f, 2f);

        healthBar = Instantiate(healthBar);
        healthBar.GetComponent<HealthBar>().target = transform;

        health = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        //rb.velocity = Vector2.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);

        if (moving)
        {
            rb.velocity = direction;

            // Rotate the object smoothly in the direction of the velocity.
            Quaternion target = Quaternion.AngleAxis(Mathf.Atan2(rb.velocity.y, rb.velocity.x) * Mathf.Rad2Deg + rotationOffset, Vector3.forward);
            transform.rotation = Quaternion.Slerp(transform.rotation, target, rb.velocity.magnitude * moveSpeed * Time.deltaTime);

            movingTimer += Time.deltaTime;
            if (movingTimer > movingTime)
            {
                movingTimer = 0;
                moving = false;
            }
        }
        else
        {
            rb.velocity = Vector3.zero;
            waitingTimer += Time.deltaTime;
            if (waitingTimer > waitingTime)
            {
                waitingTimer = 0;
                moving = true;
                direction = new Vector3(Random.Range(-1f, 1f) * moveSpeed, Random.Range(-1f, 1f) * moveSpeed, 0);
            }
        }

        healthBar.GetComponent<HealthBar>().image.fillAmount = health;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.Equals("Player"))
        {
            PlayerController player = collision.gameObject.GetComponent<PlayerController>();
            player.damage(attackDamage);
        }
    }

    public void damage(float damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Destroy(gameObject);
            Destroy(healthBar);
        }
    }
}
