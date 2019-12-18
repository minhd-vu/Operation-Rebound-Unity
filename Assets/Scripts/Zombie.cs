using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Zombie : MonoBehaviour
{
    [SerializeField]
    private float attackDamage;

    private float health;
    [SerializeField]
    private GameObject healthBar;
    private float healthBarTime;
    private float healthBarTimer;

    // Start is called before the first frame update
    void Start()
    {
        healthBar = Instantiate(healthBar);
        healthBar.GetComponent<HealthBar>().target = transform;
        healthBar.SetActive(false);

        healthBarTime = 5f;
        healthBarTimer = 0f;

        health = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        // Update the health bar.
        if (healthBar.activeSelf)
        {
            // Update the visual values.
            healthBar.GetComponent<HealthBar>().image.fillAmount = health;

            // Make the healthbar disappear after a period of inactivity.
            healthBarTimer += Time.fixedDeltaTime;
            if (healthBarTimer > healthBarTime)
            {
                healthBar.SetActive(false);
            }
        }
    }

    /**
     * If the enemy collides with the player, damage the player.
     */
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.Equals("Player"))
        {
            Player player = collision.gameObject.GetComponent<Player>();
            player.damage(attackDamage);
            AudioManager.instance.Play("Enemy Attack");
        }
    }

    /**
     * Damage the enemy. If the enemy dies, delete the enemy and the healthbar.
     */
    public void damage(float damage)
    {
        health -= damage;
        healthBar.SetActive(true);
        healthBarTimer = 0f;

        if (health <= 0)
        {
            AudioManager.instance.Play("Enemy Death");
            GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().score++;
            Destroy(gameObject);
            Destroy(healthBar);
        }
    }
}
