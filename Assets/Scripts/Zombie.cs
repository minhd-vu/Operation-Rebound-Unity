﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Pathfinding;

public class Zombie : MonoBehaviour
{
    [SerializeField]
    private float attackDamage;

    public float moveSpeed;

    public float maxHealth;
    private float health;
    [SerializeField]
    private GameObject healthBar;
    private float healthBarTime;
    private float healthBarTimer;

    [SerializeField]
    private GameObject damageParticles;

    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        //GetComponent<AIPath>().maxSpeed = moveSpeed;
        healthBar = Instantiate(healthBar);
        healthBar.GetComponent<HealthBar>().target = transform;
        healthBar.SetActive(false);

        healthBarTime = 5f;
        healthBarTimer = 0f;

        health = maxHealth;

        animator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // Update the health bar.
        if (healthBar.activeSelf)
        {
            // Update the visual values.
            healthBar.GetComponent<HealthBar>().image.fillAmount = health / maxHealth;

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
            animator.SetBool("IsAttacking", true);
            StartCoroutine(Attack(animator.GetCurrentAnimatorStateInfo(0).length));
            Player player = collision.gameObject.GetComponent<Player>();
            player.damage(attackDamage);
            AudioManager.instance.Play("Enemy Attack");
        }
    }

    IEnumerator Attack(float duration)
    {
        yield return new WaitForSeconds(duration);
        animator.SetBool("IsAttacking", false);
    }

    /**
     * Damage the enemy. If the enemy dies, delete the enemy and the healthbar.
     */
    public void damage(float damage)
    {
        Instantiate(damageParticles, transform.position, Quaternion.Euler(Vector3.zero));
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
