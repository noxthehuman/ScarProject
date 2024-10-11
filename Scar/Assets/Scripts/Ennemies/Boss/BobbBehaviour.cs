using System.Collections;
using System.Xml;
using UnityEngine;

public class BobbBehaviour : MonoBehaviour
{
    // Param principaux
    [SerializeField] private GameObject Boss;
    [SerializeField] private BossHealth BossHealth;
    private Transform player;
    
    // Derniere Chance
    [SerializeField] private GameObject pat;
    [SerializeField] private GameObject put;
    private bool premiereChance = true;
    private bool derniereChance = true;
    
    public static int isAlive = 1;
    
    //Cooldown attaques basiques
    private float hitCounter; 
    /*[SerializeField] private Transform[] hitPoints;
    [SerializeField] private Transform BasePoint;*/
    
    //Deplacement du boss pour la charge
    [SerializeField] private float defaultSpeedMonster;
    private float speed;

    //Attaques
    [SerializeField] private AttackTentacule TentaculeDeMort;
    [SerializeField] private AttackRotate TentaculeDeMortHorizontal;
    private float speedRotation = 50.0f;

    //Attaque Ulti
    [SerializeField] private Transform[] attackPoints;
    private bool hasUlti;

    private bool firstSpawn = true;
    
    // Start is called before the first frame update
    void Start()
    {
        speed = defaultSpeedMonster;
        hasUlti = false;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        StartCoroutine(BossBehaviour());
    }

    private void Update()
    {
        Deplacement();
    }
    
    
    // Script principal du boss, ses actions se trouve dans cette méthode
    IEnumerator BossBehaviour()
    {
        // Tant que le boss est en vie on le fait agir
        if (firstSpawn)
        {
            firstSpawn = false;
            speed = 0;
            yield return new WaitForSeconds(7);
            speed = defaultSpeedMonster;
        }
        while (Boss != null)
        {
            // Attaque en cas de distance élevé avec le joueur
            Ratatatata();
            UltiEnervax();
            hitCounter -= Time.deltaTime;
            if (hitCounter <= 0)
            {
                // Attaque avec delai de base
                CoupDeTentacule();
                hitCounter = Random.Range(5, 20);
            }
            else
            {
                hitCounter = 0;
            }

            // Condition actions du boss 75% de vie = spawn petit groupe de monstre 
            if (BossHealth.currentHealth <= BossHealth.maxHealth * 0.75 && premiereChance)
            {
                SpawnEnemy.Spawn(3, put);
                SpawnEnemy.Spawn(5, pat);
                premiereChance = false;
            }

            // 25% de vie = spawn groupe de monstre medium
            if (BossHealth.currentHealth <= BossHealth.maxHealth * 0.25 && derniereChance)
            {
                SpawnEnemy.Spawn(5, put);
                SpawnEnemy.Spawn(8, pat);
                derniereChance = false;
            }

            yield return new WaitForSeconds(2);
        }
    }

    private void CoupDeTentacule()
    {
        float dist = Vector3.Distance(gameObject.transform.position, player.position);
        if (dist <= 15)
        {
            AttackRotate newTentacule = Instantiate(TentaculeDeMortHorizontal, transform.position,
                transform.rotation);
            newTentacule.transform.Rotate(90, 0, 0);
        }
    }

    private void UltiEnervax()
    {
        if (BossHealth.currentHealth <= BossHealth.maxHealth * 0.1 && hasUlti == false)
        {
            foreach (var point in attackPoints)
            {
                var cpt = Random.Range(10, 30);
                for (int i = 0; i < cpt; i++)
                {
                    var xPos = point.transform.position.x + Random.Range(-10, 10);
                    var zPos = point.transform.position.z + Random.Range(-10, 10);
                    AttackTentacule newTentacule = Instantiate(TentaculeDeMort,
                        new Vector3(xPos, point.transform.position.y, zPos), point.transform.rotation);
                }
            }
            hasUlti = true;
        }
    }

    private void Ratatatata()
    {
        float dist = Vector3.Distance(gameObject.transform.position, player.position);
        if (dist >= 30)
        {
            var nbTentacule = Random.Range(10, 20);
            for (int i = 0; i < nbTentacule; i++)
            {
                var xPos = player.position.x + Random.Range(-20, 20);
                var zPos = player.position.z + Random.Range(-20, 20);
                
                AttackTentacule newTentacule = Instantiate(TentaculeDeMort,
                    new Vector3(xPos, player.position.y + 20, zPos),
                    player.rotation) as AttackTentacule;
            }
        }
    }

    private void Deplacement()
    {
        Quaternion targetRotation = Quaternion.LookRotation(new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z) - new Vector3(transform.position.x, transform.position.y, transform.position.z));
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
