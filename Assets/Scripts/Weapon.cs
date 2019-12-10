using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bullet;

    private int bullets;
    public int maxBullets = 10;

    public float reloadTime;
    private float reloadTimer;
    private bool reloading = false;

    // Start is called before the first frame update
    void Start()
    {
        bullets = maxBullets;
        reloadTimer = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (!reloading)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                Shoot();
            }

            if (Input.GetKeyDown(KeyCode.R))
            {
                Reload();
            }
        }

        else if ((reloadTimer += Time.deltaTime) >= reloadTime)
        {
            AudioManager.instance.Play("Finish Reload");
            bullets = maxBullets;
            reloadTimer = 0f;
            reloading = false;
        }
    }

    /**
     * Create and fire the bullet.
     * Reload if the weapon runs out of bullets.
     */
    void Shoot()
    {
        Instantiate(bullet, firePoint.position, firePoint.rotation);

        if (--bullets <= 0)
        {
            Reload();
        }
    }

    void Reload()
    {
        AudioManager.instance.Play("Start Reload");
        reloading = true;
    }
}
