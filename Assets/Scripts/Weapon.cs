using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;

public class Weapon : MonoBehaviour
{
    [SerializeField]
    private Transform firePoint;
    [SerializeField]
    private GameObject bullet;
    [SerializeField]
    private GameObject muzzleFlash;

    [HideInInspector]
    public int bullets;
    public int maxBullets;

    private float bulletTimer;
    [SerializeField]
    private float bulletsPerSecond;
    [HideInInspector]
    public float bulletsPerSecondBonus;

    [SerializeField]
    private float reloadTime;
    private float reloadTimer;
    private bool reloading;

    [SerializeField]
    public float damage;
    [HideInInspector]
    public float damageBonus;

    [SerializeField]
    private float shakeMagnitude;
    [SerializeField]
    private float shakeRoughness;

    [SerializeField]
    private string audio;

    public bool isOneHanded;

    // Start is called before the first frame update
    void Start()
    {
        bullets = maxBullets;
        reloadTimer = 0f;
        bulletTimer = 0f;
        reloading = false;
        damageBonus = 0f;
        bulletsPerSecondBonus = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        // Only allow firing or reloading if they are not reloading.
        if (!reloading)
        {
            // Allows firing when button is held down (for user experience).
            if (Input.GetButton("Fire1") && (bulletTimer += Time.deltaTime) >= 1f / bulletsPerSecond)
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
    }

    /**
     * Create and fire the bullet.
     * Reload if the weapon runs out of bullets.
     */
    void Shoot()
    {
        Instantiate(bullet, firePoint.position, firePoint.rotation).GetComponent<Bullet>().damage = damage + damageBonus;
        Instantiate(muzzleFlash, firePoint.position, firePoint.rotation);
        AudioManager.instance.Play(audio);
        CameraShaker.Instance.ShakeOnce(shakeMagnitude, shakeRoughness, 0.1f, 0.2f);
        bulletTimer = 0f;

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
}
