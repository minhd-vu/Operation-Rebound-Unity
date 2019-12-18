using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    private float speed;
    [SerializeField]
    private float range;

    private Vector3 initialPosition;
    [HideInInspector]
    public float damage;

    //public GameObject damageIndicator;
    [SerializeField]
    private GameObject muzzleFlashLight;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = transform.right * speed;
        initialPosition = transform.position;
        Instantiate(muzzleFlashLight, initialPosition, transform.rotation);
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
     * Display the blood splatter
     */
    void OnCollisionEnter2D(Collision2D collision)
    {
        Zombie enemy;
        if ((enemy = collision.gameObject.GetComponent<Zombie>()) != null)
        {
            // Damage the enemy.
            enemy.damage(damage);

            // Create damage numbers appear after an enemy being damaged.
            //Instantiate(damageIndicator, enemy.transform.position, Quaternion.Euler(Vector3.zero)).GetComponent<NumberIndicator>().number = (int)(damage * 100);
        }

        Destroy(gameObject);
    }
}
