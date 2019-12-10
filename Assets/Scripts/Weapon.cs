using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bullet;

    private int bullets;
    public int maxBullets = 10;

    // Start is called before the first frame update
    void Start()
    {
        bullets = maxBullets;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    /**
     * Create and fire the bullet.
     */
    void Shoot()
    {
        Instantiate(bullet, firePoint.position, firePoint.rotation);
        --bullets;
    }
}
