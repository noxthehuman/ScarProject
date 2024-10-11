using System.Collections;
using System.Diagnostics;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class FlueBehaviour : MonoBehaviour
{
    // Param principaux
    [SerializeField] private GameObject Boss;
    [SerializeField] private BossHealth BossHealth;
    private Transform player;
    
    // Derniere Chance
    [SerializeField] private GameObject pat;
    [SerializeField] private GameObject put;
    
    public static int isAlive = 1;
    
    //Cooldown attaques basiques
    private float hitCounter; 
    /*[SerializeField] private Transform[] hitPoints;
    [SerializeField] private Transform BasePoint;*/
    
    //Deplacement du boss pour la charge
    [SerializeField] private float defaultSpeedMonster;
    private float speed;

    //Attaques Bobb
    [SerializeField] private AttackTentacule TentaculeDeMort;
    
    //Attaque Lymule
    [SerializeField] private BulletController bullet;
    private int numBullets = 30;
    private float radius = -3;
    private float bulletSpeed = 25;
    
    //Attaque K'orinh
    [SerializeField] private Transform[] hitPoints;
    [SerializeField] private AttackZoneController bossLongAttack;
    
    //Attaque Flue
    //Spawn Infini
    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] private GameObject[] monsters;
    private int WaveCounter;
    private int EnemyCounter = 0;
    
    //Ulti
    [SerializeField] private Transform[] ultiPoints;
    [SerializeField] private LymuleBulletController lymuleBullet;
    private bool ultiUsed;
    private bool lastChanceUsed;

    private bool firstSpawn = true; 

    // Start is called before the first frame update
    void Start()
    {
        ultiUsed = false;
        lastChanceUsed = false;
        WaveCounter = Random.Range(30, 50);
        speed = defaultSpeedMonster;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        StartCoroutine(BossBehaviour());
    }

    private void Update()
    {
        Deplacement();
        if (BossHealth.currentHealth <= BossHealth.maxHealth * 0.1 && lastChanceUsed == false)
        {
            for (int i = 0; i < 10; i++)
            {
                Ratatatata();   
            }
            lastChanceUsed = true;
        }
    }

    // Script principal du boss, ses actions se trouve dans cette méthode
    IEnumerator BossBehaviour()
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
            // Attaque en cas de distance élevé avec le joueur
            UltiOfDoomTheApocalypse();
            CircleShoot();
            float dist = Vector3.Distance(gameObject.transform.position, player.position);
            if (dist >= 30)
            {
                Ratatatata();
            }
            BigAssAttackOfDoom();
            SpawnInfini();
            yield return new WaitForSeconds(1);
        }
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
    
    private void BigAssAttackOfDoom()
    {
        int nbAttack = Random.Range(1, 3);
        if (nbAttack == 1)
        {
            foreach (var point in hitPoints)
            {
                AttackZoneController newZone = Instantiate(bossLongAttack, point.position, point.rotation) as AttackZoneController;
            }   
        }
        else if (nbAttack == 2)
        {
            for (int i = 1; i <= 2; i++)
            {
                AttackZoneController newZone = Instantiate(bossLongAttack, hitPoints[i].position, hitPoints[i].rotation) as AttackZoneController;
            }
        }
        else
        {
            AttackZoneController newZone = Instantiate(bossLongAttack, hitPoints[0].position, hitPoints[0].rotation) as AttackZoneController;
        }
    }

    private void Ratatatata()
    {
        var nbTentacule = Random.Range(7, 15);
        for (int i = 0; i < nbTentacule; i++)
        {
            var xPos = player.position.x + Random.Range(-20, 20);
            var zPos = player.position.z + Random.Range(-20, 20);
            
            AttackTentacule newTentacule = Instantiate(TentaculeDeMort,
                new Vector3(xPos, player.position.y + 20, zPos),
                player.rotation) as AttackTentacule;
        }
    }

    private void SpawnInfini()
    {
        if (WaveCounter >= 0 && SpawnEnemy.nbMonster <= 1)
        {
            foreach (var monster in monsters)
            {
                foreach (var spawnPoint in spawnPoints)
                {
                    var xPos = spawnPoint.position.x + Random.Range(-10, 10);
                    var zPos = spawnPoint.position.z + Random.Range(-10, 10);
                    Instantiate(monster, new Vector3(xPos, spawnPoint.transform.position.y, zPos), spawnPoint.rotation);
                    SpawnEnemy.nbMonster++;
                }
                WaveCounter--;
            }
        }
    }

    private void UltiOfDoomTheApocalypse()
    {
        if (BossHealth.currentHealth <= BossHealth.maxHealth * 0.2 && ultiUsed == false)
        {
            foreach (var point in ultiPoints)
            {
                LymuleBulletController newLymuleBulletController = Instantiate(lymuleBullet, point.position, point.rotation);
            }

            ultiUsed = true;
        }
    }

    private void Deplacement()
    {
        float dist = Vector3.Distance(player.transform.position, gameObject.transform.position);
        Quaternion targetRotation = Quaternion.LookRotation(new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z) - new Vector3(transform.position.x, transform.position.y, transform.position.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 3 * Time.deltaTime);
        if (dist <= 20)
        {
            /*Quaternion targetRotation = Quaternion.LookRotation(new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z) - new Vector3(transform.position.x, transform.position.y, transform.position.z));
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 3 * Time.deltaTime);*/
            transform.position += -transform.forward * Time.deltaTime * speed; 
        }
        else
        {
            /*Quaternion targetRotation = Quaternion.LookRotation(new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z) - new Vector3(transform.position.x, transform.position.y, transform.position.z));
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 3 * Time.deltaTime);*/
            transform.position += transform.forward * Time.deltaTime * speed;   
        }

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
