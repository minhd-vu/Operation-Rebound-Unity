using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePowerUp : MonoBehaviour
{
    [SerializeField]
    private float duration;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /**
     * If the player collides with the power up, give the player a damage boost.
     */
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.Equals("Player"))
        {
            Debug.Log("PowerUpCollision");
            StartCoroutine(PlayerDamagePowerUp(collision.gameObject.GetComponent<Weapon>(), duration));
            Destroy(gameObject);
        }
    }

    IEnumerator PlayerDamagePowerUp(Weapon weapon, float time)
    {
        float damage = weapon.damage;
        weapon.damage = 1f;
        yield return new WaitForSeconds(time);
        weapon.damage = 0.1f;
        Debug.Log(weapon.damage + "before");
    }
}
