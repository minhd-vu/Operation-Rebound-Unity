using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPowerUp : PowerUp
{
    [SerializeField]
    private float healthRegenMultiplier;
    protected override IEnumerator PickUp(Collider2D player)
    {
        PlayerController playerController = player.GetComponent<PlayerController>();
        float previousHealthRegenMultiplier = 0.0f;
        playerController.healthBar;

        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<Collider2D>().enabled = false;
        yield return new WaitForSeconds(duration);

        Destroy(gameObject);
    }
}
