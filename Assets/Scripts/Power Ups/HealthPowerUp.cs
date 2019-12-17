using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPowerUp : PowerUp
{
    [SerializeField]
    private float multiplier;
    protected override IEnumerator PickUp(Collider2D collider)
    {
        Player player = collider.GetComponent<Player>();
        float previousHealthPerSecond = player.healthPerSecond;
        player.healthPerSecond *= multiplier;
        player.health = player.maxHealth;


        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<Collider2D>().enabled = false;
        yield return new WaitForSeconds(duration);

        player.healthPerSecond = previousHealthPerSecond;

        Destroy(gameObject);
    }
}
