using System;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;
using Random = UnityEngine.Random;

public class BigBoiiBehaviour : MonoBehaviour
{
    private Transform player;
    private int speed = 20;
    private float rotationDelay;
    private int direction;
    private int distance;
    
    private float bulletSpeed = 25;
    private int numBullets = 15;
    private float radius = -3;
    [SerializeField] private BulletController bullet;
    private float shootDelayDelay = 3;
    private float timeBetweenShots = 1;

    private void Awake()
    {
        StartCoroutine(CircleShoot());
    }

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        direction = Random.Range(0, 1);
    }

    // Update is called once per frame
    void Update()
    {
        shootDelayDelay -= Time.deltaTime;
        if (shootDelayDelay <= 0)
        {
            timeBetweenShots = Random.Range(1, 3);
        }
        Deplacement();
    }
    
    IEnumerator CircleShoot()
    {
        while (isActiveAndEnabled)
        {
            // spawn les balles en cercle autour du boss
            for (int i = 0; i < numBullets; i++)
            {
                // Determine la position de spawn des balles
                BulletController newBullet = Instantiate(bullet, new Vector3(transform.position.x, transform.position.y + 2, transform.position.z) + Vector3.up * radius,new Quaternion(0,0,0,0)) as BulletController;
                newBullet.speed = bulletSpeed;
                // Modifie la manière de spawn des balles (ici en cercle)
                newBullet.transform.RotateAround(transform.position, Vector3.up, 360/(float)numBullets*i);
            }
            yield return new WaitForSeconds(timeBetweenShots);   
        }
    }
    
    private void Deplacement()
    {
        Quaternion targetRotation = Quaternion.LookRotation(new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z) - new Vector3(transform.position.x, transform.position.y, transform.position.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 3 * Time.deltaTime);
        rotationDelay -= Time.deltaTime;
        if (rotationDelay <= 0)
        {
            rotationDelay = 3;
            distance = Random.Range(5, 10);
            direction = Random.Range(0, 2);
        }
        float dist = Vector3.Distance(player.transform.position, gameObject.transform.position);
        if (dist <= distance)
        {
            if (direction == 1)
            {
                transform.RotateAround(player.position, Vector3.up, 20 * Time.deltaTime * speed);   
            }
            else
            {
                transform.RotateAround(player.position, Vector3.up, -20 * Time.deltaTime * speed);
            }
            transform.position += -transform.forward * Time.deltaTime * speed;

        }
        else
        {
            transform.position += transform.forward * Time.deltaTime * speed;
        }

        if (transform.position.y <= -2)
        {
            Destroy(gameObject);
            if (gameObject.CompareTag("boss"))
            {
                BossBehaviour.isAlive = 0;
            }
            if(SceneManager.GetActiveScene().name != "DonjonEditMap") { 
                SpawnEnemy.nbMonster -= 1;
            } else if(SceneManager.GetActiveScene().name == "DonjonEditMap") {
                SpawnEnemyEditMap.nbMonster -= 1;
            }
        }
    }
}
