using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PotBehaviour : MonoBehaviour
{
    private Transform player;
    private float speedMonster = 6;
    [SerializeField]
    private BulletController bullet;
    public Transform firePoint;
    private float bulletSpeed = 25;
    private  float timeBetweenShots = 1;
    
    void Awake()
    {
        StartCoroutine(EnemyShoot());
    }
    
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    private void Update()
    {
        Deplacement();
    }

    IEnumerator EnemyShoot()
    {
        while (isActiveAndEnabled)
        {
            BulletController newBullet = Instantiate(bullet, firePoint.position, firePoint.rotation) as BulletController;
            newBullet.speed = bulletSpeed;
            yield return new WaitForSeconds(timeBetweenShots);
        }
        
    }
    
    // Start is called before the first frame update
    private void Deplacement()
    {
        Quaternion targetRotation = Quaternion.LookRotation(new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z) - new Vector3(transform.position.x, transform.position.y, transform.position.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 3 * Time.deltaTime);
        float dist = Vector3.Distance(gameObject.transform.position, player.position);
        if (dist <= 20)
        {
            /*Quaternion targetRotation = Quaternion.LookRotation(new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z) - new Vector3(transform.position.x, transform.position.y, transform.position.z));
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 3 * Time.deltaTime);*/
            transform.position += -transform.forward * Time.deltaTime * speedMonster;
        }
        else
        {
            /*Quaternion targetRotation = Quaternion.LookRotation(new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z) - new Vector3(transform.position.x, transform.position.y, transform.position.z));
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 3 * Time.deltaTime);*/
            transform.position += transform.forward * Time.deltaTime * speedMonster;   
        }

        if (transform.position.y <= -2)
        {
            Destroy(gameObject);
            if(SceneManager.GetActiveScene().name != "DonjonEditMap") { 
                SpawnEnemy.nbMonster -= 1;
            } else if(SceneManager.GetActiveScene().name == "DonjonEditMap") {
                SpawnEnemyEditMap.nbMonster -= 1;
            };
            if (gameObject.CompareTag("boss"))
            {
                BossBehaviour.isAlive = 0;
            }
        }
    }
}
