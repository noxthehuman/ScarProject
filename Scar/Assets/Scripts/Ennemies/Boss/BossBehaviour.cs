using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

public class BossBehaviour : MonoBehaviour
{
    // Param principaux
    [SerializeField] private GameObject Boss;
    [SerializeField] private BossHealth BossHealth;
    [SerializeField] private BulletController bullet;
    [SerializeField] private int numBullets;
    public Transform firepoint;
    private Transform playerPos;
    
    // Derniere Chance
    //[SerializeField] private GameObject pat;
    [SerializeField] private GameObject pot;
    [SerializeField] private GameObject pit;
    private bool premiereChance = true;
    private bool derniereChance = true;
    public bool enervax = true;
    
    public float bulletSpeed;
    private float radius = -3;
    public static int isAlive = 1;
    [SerializeField] private float defaultSpeedMonster;
    private float speed;

    private bool firstSpawn = true; 
    
    // Start is called before the first frame update
    void Start()
    {
        playerPos = GameObject.FindGameObjectWithTag("Player").transform;
        speed = defaultSpeedMonster;
        StartCoroutine(SpawnBoss());
    }

    private void Update()
    {
        Deplacement();
    }

    // Script principal du boss, ses actions se trouve dans cette méthode
    IEnumerator SpawnBoss()
    {
        if (firstSpawn)
        {
            firstSpawn = false;
            speed = 0;
            yield return new WaitForSeconds(7);
            speed = defaultSpeedMonster;
        }
        // Tant que le boss est en vie on le fait agir
        while(Boss != null)
        {
            SimpleShoot();
            // Condition actions du boss 75% de vie = spawn petit groupe de monstre 
            if (BossHealth.currentHealth <= BossHealth.maxHealth * 0.75 && premiereChance)
            {
                SpawnEnemy.Spawn(3, pit);
                SpawnEnemy.Spawn(5, pot);
                premiereChance = false;
                enervax = false;
            }
            // Enervax quand 25% >= BossHealth.currentHealth >= 75%
            if (enervax)
            {
                CircleShoot();
            }
            // 25% de vie = spawn groupe de monstre medium réactive enervax
            if (BossHealth.currentHealth <= BossHealth.maxHealth * 0.25 && derniereChance)
            {
                enervax = true;
                SpawnEnemy.Spawn(5, pit);
                SpawnEnemy.Spawn(8, pot);
                derniereChance = false;
            }
            yield return new WaitForSeconds(2);
        }
    }

   void SimpleShoot()
    {
        // Vise le player depuis le firepoint
        // Tire sur le player
        Quaternion targetRotation = Quaternion.LookRotation(playerPos.transform.position - firepoint.position);
        firepoint.rotation = Quaternion.Slerp(firepoint.rotation, targetRotation, 1 * Time.deltaTime);
        BulletController newBullet = Instantiate(bullet, firepoint.position , firepoint.rotation);
        newBullet.speed = bulletSpeed;
    }

    void CircleShoot()
    {
        // spawn les balles en cercle autour du boss
        for (int i = 0; i < numBullets; i++)
        {
            // Determine la position de spawn des balles
            BulletController newBullet = Instantiate(bullet, Boss.transform.position + Vector3.up * radius,new Quaternion(0,0,0,0)) as BulletController;
            newBullet.speed = bulletSpeed;
            // Modifie la manière de spawn des balles (ici en cercle)
            newBullet.transform.RotateAround(Boss.transform.position, Vector3.up, 360/(float)numBullets*i);
        }
    }
    
    private void Deplacement()
    {
        Quaternion targetRotation = Quaternion.LookRotation(new Vector3(playerPos.transform.position.x, transform.position.y, playerPos.transform.position.z) - new Vector3(transform.position.x, transform.position.y, transform.position.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 3 * Time.deltaTime);
        transform.position += transform.forward * Time.deltaTime * speed;
        
        if (transform.position.y <= -2)
        {
            Destroy(gameObject);
            if (gameObject.CompareTag("boss"))
            {
                isAlive = 0;
            }
            SpawnEnemy.nbMonster -= 1;
        }
    }
}
