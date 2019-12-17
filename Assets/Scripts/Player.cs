using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private float health;
    [SerializeField]
    private Image healthBar;
    [SerializeField]
    private GameObject damageParticles;

    // Start is called before the first frame update
    void Start()
    {
        health = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        // Update the health bar.
        healthBar.fillAmount = health;
    }

    /**
     * Deal damage to the player
     */
    public void damage(float damage)
    {
        health -= damage;
        Instantiate(damageParticles, transform);
    }
}
