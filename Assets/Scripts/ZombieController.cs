using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ZombieController : MonoBehaviour
{
    public Transform player;
    private float moveSpeed;
    public float rotationOffset;
    private Rigidbody2D rb;

    /*
    private bool moving;
    private Vector3 direction;

    private float movingTime;
    private float movingTimer;

    private float waitingTime;
    private float waitingTimer;
    */

    public float attackDamage;
    private float health;

    public GameObject healthBar;
    private float healthBarTime;
    private float healthBarTimer;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

        moveSpeed = Random.Range(1f, 3f);

        /*
        moving = false;
        movingTime = Random.Range(1f, 2f);
        movingTimer = 0;
        waitingTime = Random.Range(1f, 2f);
        waitingTimer = Random.Range(0f, 2f);
        */

        healthBar = Instantiate(healthBar);
        healthBar.GetComponent<HealthBar>().target = transform;
        healthBar.SetActive(false);

        healthBarTime = 5f;
        healthBarTimer = 0f;

        health = 1f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Move the zombie towards the player.
        rb.velocity = (player.transform.position - rb.transform.position).normalized * moveSpeed;

        // Rotate the zombie towards the player.
        Quaternion targetr = Quaternion.AngleAxis(Mathf.Atan2(rb.velocity.y, rb.velocity.x) * Mathf.Rad2Deg + rotationOffset, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetr, rb.velocity.magnitude * moveSpeed * Time.fixedDeltaTime);

        // AI movement.
        /*
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
            // Enemy pauses for a moment.
            rb.velocity = Vector3.zero;
            waitingTimer += Time.deltaTime;
            if (waitingTimer > waitingTime)
            {
                waitingTimer = 0;
                moving = true;
                direction = new Vector3(Random.Range(-1f, 1f) * moveSpeed, Random.Range(-1f, 1f) * moveSpeed, 0);
            }
        }
        */
        // End AI movement.

        // Update the health bar.
        if (healthBar.activeSelf)
        {
            // Update the visual values.
            healthBar.GetComponent<HealthBar>().image.fillAmount = health;

            // Make the healthbar disappear after a period of inactivity.
            healthBarTimer += Time.fixedDeltaTime;
            if (healthBarTimer > healthBarTime)
            {
                healthBar.SetActive(false);
            }
        }
    }

    /**
     * If the enemy collides with the player, damage the player.
     */
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.Equals("Player"))
        {
            PlayerController player = collision.gameObject.GetComponent<PlayerController>();
            player.damage(attackDamage);
            AudioManager.instance.Play("Enemy Attack");
        }
    }

    /**
     * Damage the enemy. If the enemy dies, delete the enemy and the healthbar.
     */
    public void damage(float damage)
    {
        health -= damage;
        healthBar.SetActive(true);
        healthBarTimer = 0f;

        if (health <= 0)
        {
            AudioManager.instance.Play("Enemy Death");
            Destroy(gameObject);
            Destroy(healthBar);
        }
    }
}
