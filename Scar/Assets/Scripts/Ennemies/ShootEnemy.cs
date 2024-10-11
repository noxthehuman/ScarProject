using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootEnemy : MonoBehaviour
{
    [SerializeField]
    private BulletController bullet;
    public Transform firePoint;
    public float bulletSpeed;
    public float timeBetweenShots;
    void Awake()
    {
        StartCoroutine(EnemyShoot());
    }

    IEnumerator EnemyShoot()
    {
        while (this.isActiveAndEnabled)
        {
            BulletController newBullet = Instantiate(bullet, firePoint.position, firePoint.rotation) as BulletController;
            newBullet.speed = bulletSpeed;
            yield return new WaitForSeconds(timeBetweenShots);
        }
        
    }

}
