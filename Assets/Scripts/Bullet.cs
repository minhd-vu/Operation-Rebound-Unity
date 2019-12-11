using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    public Rigidbody2D rb;
    public float range;
    private Vector3 initialPosition;
    private float damage;
    public HealthBar healthBar;
    public GameObject damageIndicator;
    public GameObject bulletParticles;

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed;
        initialPosition = transform.position;
        damage = 0.1f;
        AudioManager.instance.Play("Fire Bullet");
    }

    // Update is called once per frame
    void Update()
    {
        // Destroy the bullet if it goes beyond its maximum range.
        if (Vector3.Distance(initialPosition, transform.position) > range)
        {
            Destroy(gameObject);
        }
    }

    /**
     * Upon colliding with an enemy:
     * Damage the enemy,
     * Destroy the bullet,
     */
    void OnCollisionEnter2D(Collision2D collision)
    {
        ZombieController enemy;
        if ((enemy = collision.gameObject.GetComponent<ZombieController>()) != null)
        {
            // Damage the enemy.
            enemy.damage(damage);

            // Create damage numbers appear after an enemy being damaged.
            //Instantiate(damageIndicator, enemy.transform.position, Quaternion.Euler(Vector3.zero)).GetComponent<NumberIndicator>().number = (int)(damage * 100);
            Instantiate(bulletParticles, enemy.transform.position, Quaternion.Euler(Vector3.zero));
        }

        Destroy(gameObject);
    }
}
