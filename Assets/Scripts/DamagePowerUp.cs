using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePowerUp : MonoBehaviour
{
    [SerializeField]
    private float duration;

    // public GameObject pickupEffect;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            StartCoroutine(PickUp(collision));
        }
    }

    /**
     * Allow the player to be able to instantly defeat enemies for a period of time.
     */
    IEnumerator PickUp(Collider2D player)
    {
        Weapon weapon = player.GetComponent<Weapon>();
        float previousDamage = weapon.damage;
        weapon.damage = 1.0f;

        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<Collider2D>().enabled = false;

        yield return new WaitForSeconds(duration);

        weapon.damage = previousDamage;

        Destroy(gameObject);
    }
}
