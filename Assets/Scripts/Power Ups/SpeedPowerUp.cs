using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedPowerUp : PowerUp
{
    [SerializeField]
    private float moveSpeed;

    protected override IEnumerator PickUp(Collider2D player)
    {
        PlayerController playerController = player.GetComponent<PlayerController>();
        playerController.moveSpeedBonus = moveSpeed;

        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<Collider2D>().enabled = false;
        yield return new WaitForSeconds(duration);

        playerController.moveSpeedBonus = 0f;

        Destroy(gameObject);
    }
}
