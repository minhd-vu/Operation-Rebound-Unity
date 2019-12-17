using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfinityPowerUp : PowerUp
{
    [SerializeField]
    private float multiplier;
    protected override IEnumerator PickUp(Collider2D collider)
    {
        Weapon weapon = collider.GetComponent<Weapon>();
        float previousBulletsPerSecond = weapon.bulletsPerSecond;
        int previousMaxBullets = weapon.maxBullets;
        weapon.bulletsPerSecond *= multiplier;
        weapon.maxBullets = (int)(weapon.bulletsPerSecond * duration);
        weapon.bullets = weapon.maxBullets;

        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<Collider2D>().enabled = false;
        yield return new WaitForSeconds(duration);

        weapon.bulletsPerSecond = previousBulletsPerSecond;
        weapon.maxBullets = previousMaxBullets;
        weapon.bullets = weapon.maxBullets;

        Destroy(gameObject);
    }
}
