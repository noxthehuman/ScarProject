using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;
using System.IO;

public class SpawnEnemyEditMap : MonoBehaviour
{
    public GameObject pot;
    public  GameObject pat;
    public GameObject put;
    public GameObject pit;
    public  GameObject boss1;
    public  GameObject boss2;
    public  GameObject boss3;
    public  GameObject boss4;
    public GameObject miniBoss;
    public GameObject spawnMonster;
    public GameObject fontaine;
    public Transform spawnpointFontaine;
    private static float xPos;
    private static float zPos;
    
    private int cptWave;
    private int monstreRecup;
    public int numBoss;
    public int numMiniBoss;
    
    public static int nbMonster;
    
    private GameObject door;
    private GameObject spawnPoint;

    private GameObject[] portes;

    private static Transform player;

    public bool hasEnded;
    public static bool open;
    private string chemin, jsonString;

    void Start()
    {
        hasEnded = false;
        player = GameObject.FindGameObjectWithTag("Player").transform;

        if (numMiniBoss > 0 || numBoss > 0) {
            cptWave = 1;
            monstreRecup = 0;
        } else {
            cptWave = 1;
            monstreRecup = 1;
        }
    }

    void Awake() {
        nbMonster = 0;
        cptWave = 1;
    }

    private void Update() {
        spawnPoint = spawnMonster;
        
        xPos = Random.Range(spawnPoint.transform.position.x - 15, spawnPoint.transform.position.x) + 15;
        zPos = Random.Range(spawnPoint.transform.position.z - 15, spawnPoint.transform.position.z + 15);
        if (nbMonster <= 0 && cptWave > 0) {
            chemin = Application.streamingAssetsPath + "/EditeurMap.json";
            jsonString = File.ReadAllText(chemin);
            InfosForMapEditor editionMap = JsonUtility.FromJson<InfosForMapEditor>(jsonString);
            switch(PlayerController.cpt) {
                case 0:
                    SpawnMonster(monstreRecup, editionMap.nb_pot_1, editionMap.nb_pat_1, editionMap.nb_put_1, editionMap.nb_pit_1);
                    cptWave -= 1;
                    break;
                case 1:
                    SpawnMonster(monstreRecup, editionMap.nb_pot_1, editionMap.nb_pat_1, editionMap.nb_put_1, editionMap.nb_pit_1);
                    cptWave -= 1;
                    break;
                case 2:
                    SpawnMonster(monstreRecup, editionMap.nb_pot_2, editionMap.nb_pat_2, editionMap.nb_put_2, editionMap.nb_pit_2);
                    cptWave -= 1;
                    break;
                case 3:
                    SpawnMonster(monstreRecup, editionMap.nb_pot_3, editionMap.nb_pat_3, editionMap.nb_put_3, editionMap.nb_pit_3);
                    cptWave -= 1;
                    break;
                case 4:
                    SpawnMonster(monstreRecup, editionMap.nb_pot_4, editionMap.nb_pat_4, editionMap.nb_put_4, editionMap.nb_pit_4);
                    cptWave -= 1;
                    break;
                case 5:
                    SpawnMonster(monstreRecup, editionMap.nb_pot_5, editionMap.nb_pat_5, editionMap.nb_put_5, editionMap.nb_pit_5);
                    cptWave -= 1;
                    break;
                case 6:
                    SpawnMonster(monstreRecup, editionMap.nb_pot_6, editionMap.nb_pat_6, editionMap.nb_put_6, editionMap.nb_pit_6);
                    cptWave -= 1;
                    break;
                case 7:
                    SpawnMonster(monstreRecup, editionMap.nb_pot_7, editionMap.nb_pat_7, editionMap.nb_put_7, editionMap.nb_pit_7);
                    cptWave -= 1;
                    break;
                case 8:
                    SpawnMonster(monstreRecup, editionMap.nb_pot_8, editionMap.nb_pat_8, editionMap.nb_put_8, editionMap.nb_pit_8);
                    break;
                case 9:
                    SpawnMonster(monstreRecup, editionMap.nb_pot_9, editionMap.nb_pat_9, editionMap.nb_put_9, editionMap.nb_pit_9);
                    cptWave -= 1;
                    break;
                case 10:
                    SpawnMonster(monstreRecup, editionMap.nb_pot_10, editionMap.nb_pat_10, editionMap.nb_put_10, editionMap.nb_pit_10);
                    cptWave -= 1;
                    break;
                case 11:
                    SpawnMonster(monstreRecup, editionMap.nb_pot_11, editionMap.nb_pat_11, editionMap.nb_put_11, editionMap.nb_pit_11);
                    cptWave -= 1;
                    break;
                case 12:
                    SpawnMonster(monstreRecup, editionMap.nb_pot_12, editionMap.nb_pat_12, editionMap.nb_put_12, editionMap.nb_pit_12);
                    cptWave -= 1;
                    break;
                case 13:
                    SpawnMonster(monstreRecup, editionMap.nb_pot_13, editionMap.nb_pat_13, editionMap.nb_put_13, editionMap.nb_pit_13);
                    cptWave -= 1;
                    break;
                case 14:
                    SpawnMonster(monstreRecup, editionMap.nb_pot_14, editionMap.nb_pat_14, editionMap.nb_put_14, editionMap.nb_pit_14);
                    cptWave -= 1;
                    break;
                case 15:
                    SpawnMonster(monstreRecup, editionMap.nb_pot_15, editionMap.nb_pat_15, editionMap.nb_put_15, editionMap.nb_pit_15);
                    cptWave -= 1;
                    break;
                default:
                    cptWave -= 1;
                    break;
            }
        }

        // Check si plus d'ennemi donc ouverture porte
        var enemies = GameObject.FindGameObjectsWithTag("Enemy");
        portes = GameObject.FindGameObjectsWithTag("BloquePorte");
        if (nbMonster <= 0 && cptWave <= 0) {
            if(enemies.Length <= 0 && cptWave <= 0 && hasEnded == false) {
                foreach (var gameobject in portes) {
                    gameobject.GetComponent<Animator>().Play("OuverturePorteDonjon", -1, 0f);
                }
                hasEnded = true;
            }
        }
    }

    public static void Spawn(int numSpawn, GameObject typeMonster) {
        for (int i = 0; i < numSpawn; i++) {
            xPos = Random.Range(xPos - 10, xPos + 10);
            zPos = Random.Range(zPos - 10, zPos + 10);
            Instantiate(typeMonster, new Vector3(xPos, player.transform.position.y + 2, zPos), Quaternion.identity);
            nbMonster += 1;
        }
    }

    private void SpawnMonster(int sizeGroup, int numPot, int numPat, int numPut, int numPit) {
         chemin = Application.streamingAssetsPath + "/EditeurMap.json";
        jsonString = File.ReadAllText(chemin);
        InfosForMapEditor editionMap = JsonUtility.FromJson<InfosForMapEditor>(jsonString);
        if (sizeGroup > 0 && nbMonster <= 1) {
            Spawn(numPot, pot); // spawn pot 
            Spawn(numPat, pat); // spawn pat 
            Spawn(numPut, put); // spawn put 
            Spawn(numPit, pit); // spawn pit 
            sizeGroup -= 1;
        }

        if (sizeGroup == 0) {
            if (numBoss > 0) {
                if(editionMap.type_boss == "null" || editionMap.type_boss == "lymul") {
                    Spawn(numBoss, boss1);
                } else if(editionMap.type_boss == "korinh") {
                    Spawn(numBoss, boss2);
                } else if(editionMap.type_boss == "bob") {
                    Spawn(numBoss, boss3);
                } else if(editionMap.type_boss == "flue") {
                    Spawn(numBoss, boss4);
                }
                numBoss -= 1;
            }

            if (numMiniBoss > 0) {
                Spawn(numMiniBoss, miniBoss);
                numMiniBoss -= 1;
            }
        }
    }
}
