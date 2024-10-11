using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    [SerializeField] private BulletController bullet;
    [SerializeField] private Transform firePoint;
    [SerializeField] private float bulletSpeed;
    public static float timeBetweenShots = GameInfo.shootDelay;
    
    public bool isFiring;
    private float shotCounter;

    // Update is called once per frame
    void Update()
    {
        if (isFiring)
        {
            shotCounter -= Time.deltaTime;
            if (shotCounter <= 0)
            {
                shotCounter = timeBetweenShots;
                BulletController newBullet = Instantiate(bullet, firePoint.position, firePoint.rotation) as BulletController;
                PlayerController.numberBullets += 1;
                newBullet.speed = bulletSpeed;
            }
        }
        else
        {
            shotCounter = 0;
        }
    }
}
