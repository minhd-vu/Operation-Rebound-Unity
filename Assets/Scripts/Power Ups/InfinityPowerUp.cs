using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfinityPowerUp : PowerUp
{
    [SerializeField]
    private float bulletsPerSecond;
    [SerializeField]
    private int extraBullets;

    protected override IEnumerator PickUp(Collider2D collider)
    {
        Weapon weapon = collider.GetComponent<Weapon>();
        weapon.bulletsPerSecondBonus = bulletsPerSecond;
        weapon.bullets = weapon.maxBullets + extraBullets;

        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<Collider2D>().enabled = false;
        yield return new WaitForSeconds(duration);

        weapon.bulletsPerSecondBonus = 0f;

        if (weapon.bullets > weapon.maxBullets)
        {
            weapon.bullets = weapon.maxBullets;
        }

        Destroy(gameObject);
    }
}
