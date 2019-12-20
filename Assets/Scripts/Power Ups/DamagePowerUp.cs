using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePowerUp : PowerUp
{
    [SerializeField]
    private float damage;
    protected override IEnumerator PickUp(Collider2D collider)
    {
        Weapon weapon = collider.GetComponentInChildren<Weapon>();
        weapon.damageBonus = damage;

        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<Collider2D>().enabled = false;
        yield return new WaitForSeconds(duration);

        weapon.damageBonus = 0f;

        Destroy(gameObject);
    }
}
