using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bullet;

    private int bullets;
    public int maxBullets = 10;

    private float bulletTimer;
    public float bulletsPerSecond;

    public float reloadTime;
    private float reloadTimer;
    private bool reloading = false;

    public float damage;

    // Start is called before the first frame update
    void Start()
    {
        bullets = maxBullets;
        reloadTimer = 0f;
        bulletTimer = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        // Only allow firing or reloading if they are not reloading.
        if (!reloading)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                Shoot();
            }

            // Reload the weapon if it is able.
            if (Input.GetKeyDown(KeyCode.R) && bullets < maxBullets)
            {
                Reload();
            }
        }

        // Otherwise check if the reload is finished.
        else if ((reloadTimer += Time.deltaTime) >= reloadTime)
        {
            AudioManager.instance.Play("Finish Reload");
            bullets = maxBullets;
            reloadTimer = 0f;
            reloading = false;
        }

        
        if (Input.GetButton("Fire2") && (bulletTimer += Time.deltaTime) >= 1 / bulletsPerSecond)
        {
            Shoot();
            bullets = maxBullets;
            bulletTimer = 0f;
        }
    }

    /**
     * Create and fire the bullet.
     * Reload if the weapon runs out of bullets.
     */
    void Shoot()
    {
        Instantiate(bullet, firePoint.position, firePoint.rotation).GetComponent<Bullet>().damage = damage;

        // Reload the weapon if the ammo is too low.
        if (--bullets <= 0)
        {
            Reload();
        }
    }

    /**
     * Reload the weapon.
     */
    void Reload()
    {
        AudioManager.instance.Play("Start Reload");
        reloading = true;
    }

    public IEnumerator PowerUp(float time)
    {
        float previousDamage = damage;
        damage = 1f;
        yield return new WaitForSeconds(time);
        damage = previousDamage;
        Debug.Log(damage + " Damage");
    }
}
