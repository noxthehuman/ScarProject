using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBoss : MonoBehaviour
{
    public  GameObject lymule;
    public  GameObject korinh;
    public  GameObject bobb;
    public  GameObject flue;
    public Transform spawnPointMonster;
    //public GameObject fontaine;
    //public Transform spawnpointFontaine;

    private GameObject door;
    private GameObject[] portes;

    private bool hasEnded;
    
    void Start()
    {
        hasEnded = false; 
        ControlSpawnBoss();
    }

    private void Update()
    {
        CheckMonstersAlive();
    }

    private void ControlSpawnBoss()
    {
        switch (PlayerController.BossRushroomCounter)
        {
            case 0:
                SpawnEnemy.Spawn(1,lymule, true);
                break;
            case 1:
                SpawnEnemy.Spawn(1,korinh, true);
                break;
            case 2:
                SpawnEnemy.Spawn(1,bobb, true);
                break;
            case 3:
                SpawnEnemy.Spawn(1,flue, true);
                break;
        }
    }
    
    private void CheckMonstersAlive()
    {
        var enemies = GameObject.FindGameObjectsWithTag("boss");
        portes = GameObject.FindGameObjectsWithTag("BloquePorte");
        if (SpawnEnemy.nbMonster <= 0 && hasEnded == false)
        {
            PlayerController.BossRushroomCounter += 1;
            foreach (var gameobject in portes)
            {
                gameobject.GetComponent<Animator>().Play("OuverturePorteDonjon", -1, 0f);
                /*if (fontaine != null)
                {
                    //Instantiate(fontaine, spawnpointFontaine.position, Quaternion.identity);   
                }*/
            }
            hasEnded = true;
        }
    }
}
