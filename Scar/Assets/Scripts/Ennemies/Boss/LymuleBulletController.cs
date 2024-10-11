using System;
using System.Collections;
using UnityEngine;

public class LymuleBulletController : MonoBehaviour
{
    private float speed = 10;
    private int numBullets = 10;
    [SerializeField] private BulletController bullet;
    [SerializeField] private Transform firePoint;
    private float radius = 1;
    private float hitCounter;

    private void Start()
    {
        StartCoroutine(CircleShoot());
    }

    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        Destroy(gameObject, 10);
    }

    IEnumerator CircleShoot()
    {
        while (true)
        {
            // spawn les balles en cercle autour du boss
            for (int i = 0; i < numBullets; i++)
            {
                // Determine la position de spawn des balles
                BulletController newBullet = Instantiate(bullet, firePoint.position + Vector3.up * radius,new Quaternion(0,0,0,0)) as BulletController;
                newBullet.speed = speed * 5;
                // Modifie la manière de spawn des balles (ici en cercle)
                newBullet.transform.RotateAround(firePoint.transform.position, Vector3.up, 360/(float)numBullets*i);
            }
            yield return new WaitForSeconds(2);   
        }
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
