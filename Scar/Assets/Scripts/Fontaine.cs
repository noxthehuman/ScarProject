using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class Fontaine : MonoBehaviour
{
    [SerializeField] private Transform respawn;
    [SerializeField] private Transform[] spawnpointLoots;
    
    [SerializeField] private GameObject coin;
    [SerializeField] private GameObject rubis;
    [SerializeField] private GameObject health_potion;
    [SerializeField] private GameObject mana_potion;
    [SerializeField] private GameObject damage_potion;
    [SerializeField] private GameObject shield_potion;
    [SerializeField] private GameObject destruct_potion;
    
    private Boolean firstSpawn;
    private Boolean lootSpawned;
    private int numberLoots;
    private int randomLoots;
    
    // Start is called before the first frame update
    void Start()
    {
        firstSpawn = true;
        lootSpawned = false;
        foreach (var spawnpoint in spawnpointLoots)
        {
            numberLoots = Random.Range(1, 5);
            Instantiate(coin, spawnpoint.position, Quaternion.identity);
            var xPos = 0f;
            var yPos = 0f;
            if (numberLoots <= 4)
            {
                xPos  = spawnpoint.position.x + Random.Range(-5, 5);
                yPos  = spawnpoint.position.y + Random.Range(-5, 5);
                Instantiate(rubis, new Vector3(xPos, yPos, spawnpoint.position.z), Quaternion.identity);
            }
            if (numberLoots <= 3)
            {
                xPos  = spawnpoint.position.x + Random.Range(-5, 5);
                yPos  = spawnpoint.position.y + Random.Range(-5, 5);
                Instantiate(health_potion, new Vector3(xPos, yPos, spawnpoint.position.z), Quaternion.identity);   
                Instantiate(mana_potion, new Vector3(xPos, yPos, spawnpoint.position.z), Quaternion.identity);
            }
            if (numberLoots <= 2)
            {
                xPos  = spawnpoint.position.x + Random.Range(-5, 5);
                yPos  = spawnpoint.position.y + Random.Range(-5, 5);
                Instantiate(damage_potion, new Vector3(xPos, yPos, spawnpoint.position.z), Quaternion.identity);   
                Instantiate(shield_potion, new Vector3(xPos, yPos, spawnpoint.position.z), Quaternion.identity);   
            }
            if (numberLoots == 1)
            {
                xPos  = spawnpoint.position.x + Random.Range(-5, 5);
                yPos  = spawnpoint.position.y + Random.Range(-5, 5);
                Instantiate(destruct_potion, new Vector3(xPos, yPos, spawnpoint.position.z), Quaternion.identity);   
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!lootSpawned)
        {
            lootSpawned = true;
            
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (firstSpawn)
        {
            if (other.CompareTag("Player"))
            {
                Debug.Log("oe");
                other.GetComponent<Transform>().position = respawn.position;
                firstSpawn = false;
            }
        }
    }
}
