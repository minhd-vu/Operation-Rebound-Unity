using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedPowerUp : PowerUp
{
    [SerializeField]
    private float multiplier;

    protected override IEnumerator PickUp(Collider2D player)
    {
        PlayerController playerController = player.GetComponent<PlayerController>();
        float previousSpeed = playerController.moveSpeed;
        playerController.moveSpeed *= multiplier;

        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<Collider2D>().enabled = false;
        yield return new WaitForSeconds(duration);

        playerController.moveSpeed = previousSpeed;

        Destroy(gameObject);
    }
}
