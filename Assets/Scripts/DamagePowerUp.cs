using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePowerUp : MonoBehaviour
{
    [SerializeField]
    private float duration;

    /**
     * If the player collides with the power up, give the player a damage boost.
     
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.Equals("Player"))
        {
            Debug.Log("PowerUpCollision" + duration);
            Weapon weapon = collision.gameObject.GetComponent<Weapon>();
            collision.gameObject.GetComponent<Weapon>().StartCoroutine(PowerUp(duration));
            Destroy(gameObject);
        }
    }
    */

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("PowerUp Picked Up");
        }
    }
}
