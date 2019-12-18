using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPowerUp : PowerUp
{
    [SerializeField]
    private float healthPerSecond;
    protected override IEnumerator PickUp(Collider2D collider)
    {
        Player player = collider.GetComponent<Player>();
        player.healthPerSecondBonus = healthPerSecond;
        player.health = player.maxHealth;


        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<Collider2D>().enabled = false;
        yield return new WaitForSeconds(duration);
        

        player.healthPerSecondBonus = 0f;

        Destroy(gameObject);
    }
}
