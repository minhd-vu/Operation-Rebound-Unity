using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePowerUp : PowerUp
{
    protected override IEnumerator PickUp(Collider2D player)
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
