using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PitBehaviour : MonoBehaviour
{
    [SerializeField] private HealthEnemy healthPit;
    [SerializeField] private GameObject pit;
    private int speedMonster = 8;
    [SerializeField] private BulletController bullet;
    private Transform player;
    private bool HasSpawn = false;
    private int numBullets = 10;
    private float radius = 1;
    private float bulletSpeed = 25;
    private float cooldown;


    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    void Update()
    {
        Deplacement();
        if (healthPit.currentHealth <= 40 && HasSpawn == false)
        {   
            if(SceneManager.GetActiveScene().name != "DonjonEditMap") { 
                if (healthPit.maxHealth == 300)
                {
                    SpawnEnemy.Spawn(2, pit);
                    HasSpawn = true;
                }
            
                if(healthPit.maxHealth == 150)
                {
                    SpawnEnemy.Spawn(4, pit);
                    HasSpawn = true;
                }   
            } else if(SceneManager.GetActiveScene().name == "DonjonEditMap") {
                if (healthPit.maxHealth == 300)
                {
                    SpawnEnemyEditMap.Spawn(2, pit);
                    HasSpawn = true;
                }
            
                if(healthPit.maxHealth == 150)
                {
                    SpawnEnemyEditMap.Spawn(4, pit);
                    HasSpawn = true;
                }  
            } 
        }
    }

    private void Deplacement()
    {
        float dist = Vector3.Distance(player.transform.position, transform.position);
        if (dist >= 20)
        {
            cooldown -= 1 * Time.deltaTime;
            if (cooldown <= 0)
            {
                CircleShoot();
                cooldown = 5;
            }
        }
        else
        {
            Quaternion targetRotation = Quaternion.LookRotation(new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z) - new Vector3(transform.position.x, transform.position.y, transform.position.z));
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 3 * Time.deltaTime);
            transform.position += transform.forward * Time.deltaTime * speedMonster;   
        }

        if (transform.position.y <= -2)
        {
            Destroy(gameObject);
            if(SceneManager.GetActiveScene().name != "DonjonEditMap") { 
                SpawnEnemy.nbMonster--;
            } else if (SceneManager.GetActiveScene().name == "DonjonEditMap") {
                SpawnEnemyEditMap.nbMonster--;
            }
            if (gameObject.CompareTag("boss"))
            {
                BossBehaviour.isAlive = 0;
            }
        }
    }
    
    private void CircleShoot()
    {
        // spawn les balles en cercle autour du boss
        for (int i = 0; i < numBullets; i++)
        {
            // Determine la position de spawn des balles
            BulletController newBullet = Instantiate(bullet, transform.position + Vector3.up * radius,new Quaternion(0,0,0,0)) as BulletController;
            newBullet.speed = bulletSpeed;
            // Modifie la manière de spawn des balles (ici en cercle)
            newBullet.transform.RotateAround(transform.position, Vector3.up, 360/(float)numBullets*i);
        }
    }
}
