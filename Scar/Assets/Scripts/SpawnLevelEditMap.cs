using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using UnityEditor;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;
using System.IO;

public class SpawnLevelEditMap : MonoBehaviour
{
    public GameObject[] rooms;
    public LevelDecor[] roomDecor;
    public GameObject spawnPoint;
    private int firstPart;
    private int secondPart;
    [SerializeField] private GameObject LymuleRoom;
    [SerializeField] private GameObject KorinhRoom;
    [SerializeField] private GameObject BobbRoom;
    [SerializeField] private GameObject FlueRoom;
    [SerializeField] private GameObject miniBossRoom;
    [SerializeField] private GameObject porte;
    [SerializeField] private GameObject room;
    private bool hasSpawn;
    private bool endFirstPart;
    private string chemin, jsonString;

    private int typeRoom;

    private void Awake() { 
        chemin = Application.streamingAssetsPath + "/EditeurMap.json";
        jsonString = File.ReadAllText(chemin);
        InfosForMapEditor editionMap = JsonUtility.FromJson<InfosForMapEditor>(jsonString);
    }

    private void Start()
    {
        hasSpawn = false;
    }

    void OnTriggerEnter(Collider other)
    {   
        if (other.CompareTag("Player") && hasSpawn == false)
        {
            chemin = Application.streamingAssetsPath + "/EditeurMap.json";
            jsonString = File.ReadAllText(chemin);
            InfosForMapEditor editionMap = JsonUtility.FromJson<InfosForMapEditor>(jsonString);
            if (PlayerController.cpt == Mathf.Round(editionMap.nb_salles/2) && endFirstPart != true)
            {
                Instantiate(miniBossRoom, spawnPoint.transform.position, spawnPoint.transform.rotation);
                PlayerController.cpt++;
                hasSpawn = true;
                endFirstPart = true;
            }
            else if( PlayerController.cpt >= editionMap.nb_salles)
            {   
                if(editionMap.type_boss == "null" || editionMap.type_boss == "lymul") {
                    Instantiate(LymuleRoom, spawnPoint.transform.position, spawnPoint.transform.rotation);
                } else if(editionMap.type_boss == "korinh") {
                    Instantiate(KorinhRoom, spawnPoint.transform.position, spawnPoint.transform.rotation);
                } else if(editionMap.type_boss == "bob") {
                    Instantiate(BobbRoom, spawnPoint.transform.position, spawnPoint.transform.rotation);
                } else if(editionMap.type_boss == "flue") {
                    Instantiate(FlueRoom, spawnPoint.transform.position, spawnPoint.transform.rotation);
                }
                hasSpawn = true;   
            }
            else
            {   
                if(PlayerController.cpt <= 1) {
                    if(editionMap.type_salle_1 == "null" || editionMap.type_salle_1 == "salle1") {
                        typeRoom = 0;
                    } else if(editionMap.type_salle_1 == "salle2") {
                        typeRoom = 1;
                    } else if(editionMap.type_salle_1 == "salle3") {
                        typeRoom = 2;
                    }
                    if(editionMap.type_habillage_1 == "null" || editionMap.type_habillage_1 == "habillage1") {
                        roomDecor[typeRoom].marecage.SetActive(true);
                        roomDecor[typeRoom].arene.SetActive(false);
                        roomDecor[typeRoom].cimetiere.SetActive(false);
                    } else if(editionMap.type_habillage_1 == "habillage2") {
                        roomDecor[typeRoom].marecage.SetActive(false);
                        roomDecor[typeRoom].arene.SetActive(false);
                        roomDecor[typeRoom].cimetiere.SetActive(true);
                    } else if(editionMap.type_habillage_1 == "habillage3") {
                        roomDecor[typeRoom].marecage.SetActive(false);
                        roomDecor[typeRoom].arene.SetActive(true);
                        roomDecor[typeRoom].cimetiere.SetActive(false);
                    }
                } else if(PlayerController.cpt == 2) {
                    if(editionMap.type_salle_2 == "null" || editionMap.type_salle_2 == "salle1") {
                        typeRoom = 0;
                    } else if(editionMap.type_salle_2 == "salle2") {
                        typeRoom = 1;
                    } else if(editionMap.type_salle_2 == "salle3") {
                        typeRoom = 2;
                    }
                    if(editionMap.type_habillage_2 == "null" || editionMap.type_habillage_2 == "habillage1") {
                        roomDecor[typeRoom].marecage.SetActive(true);
                        roomDecor[typeRoom].arene.SetActive(false);
                        roomDecor[typeRoom].cimetiere.SetActive(false);
                    } else if(editionMap.type_habillage_2 == "habillage2") {
                        roomDecor[typeRoom].marecage.SetActive(false);
                        roomDecor[typeRoom].arene.SetActive(false);
                        roomDecor[typeRoom].cimetiere.SetActive(true);
                    } else if(editionMap.type_habillage_2 == "habillage3") {
                        roomDecor[typeRoom].marecage.SetActive(false);
                        roomDecor[typeRoom].arene.SetActive(true);
                        roomDecor[typeRoom].cimetiere.SetActive(false);
                    }
                } else if(PlayerController.cpt == 3) {
                    if(editionMap.type_salle_3 == "null" || editionMap.type_salle_3 == "salle1") {
                        typeRoom = 0;
                    } else if(editionMap.type_salle_3 == "salle2") {
                        typeRoom = 1;
                    } else if(editionMap.type_salle_3 == "salle3") {
                        typeRoom = 2;
                    }
                    if(editionMap.type_habillage_3 == "null" || editionMap.type_habillage_3 == "habillage1") {
                        roomDecor[typeRoom].marecage.SetActive(true);
                        roomDecor[typeRoom].arene.SetActive(false);
                        roomDecor[typeRoom].cimetiere.SetActive(false);
                    } else if(editionMap.type_habillage_3 == "habillage2") {
                        roomDecor[typeRoom].marecage.SetActive(false);
                        roomDecor[typeRoom].arene.SetActive(false);
                        roomDecor[typeRoom].cimetiere.SetActive(true);
                    } else if(editionMap.type_habillage_3 == "habillage3") {
                        roomDecor[typeRoom].marecage.SetActive(false);
                        roomDecor[typeRoom].arene.SetActive(true);
                        roomDecor[typeRoom].cimetiere.SetActive(false);
                    }
                } else if(PlayerController.cpt == 4) {
                    if(editionMap.type_salle_4 == "null" || editionMap.type_salle_4 == "salle1") {
                        typeRoom = 0;
                    } else if(editionMap.type_salle_4 == "salle2") {
                        typeRoom = 1;
                    } else if(editionMap.type_salle_4 == "salle3") {
                        typeRoom = 2;
                    }
                    if(editionMap.type_habillage_4 == "null" || editionMap.type_habillage_4 == "habillage1") {
                        roomDecor[typeRoom].marecage.SetActive(true);
                        roomDecor[typeRoom].arene.SetActive(false);
                        roomDecor[typeRoom].cimetiere.SetActive(false);
                    } else if(editionMap.type_habillage_4 == "habillage2") {
                        roomDecor[typeRoom].marecage.SetActive(false);
                        roomDecor[typeRoom].arene.SetActive(false);
                        roomDecor[typeRoom].cimetiere.SetActive(true);
                    } else if(editionMap.type_habillage_4 == "habillage3") {
                        roomDecor[typeRoom].marecage.SetActive(false);
                        roomDecor[typeRoom].arene.SetActive(true);
                        roomDecor[typeRoom].cimetiere.SetActive(false);
                    }
                } else if(PlayerController.cpt == 5) {
                    if(editionMap.type_salle_5 == "null" || editionMap.type_salle_5 == "salle1") {
                        typeRoom = 0;
                    } else if(editionMap.type_salle_5 == "salle2") {
                        typeRoom = 1;
                    } else if(editionMap.type_salle_5 == "salle3") {
                        typeRoom = 2;
                    }
                    if(editionMap.type_habillage_5 == "null" || editionMap.type_habillage_5 == "habillage1") {
                        roomDecor[typeRoom].marecage.SetActive(true);
                        roomDecor[typeRoom].arene.SetActive(false);
                        roomDecor[typeRoom].cimetiere.SetActive(false);
                    } else if(editionMap.type_habillage_5 == "habillage2") {
                        roomDecor[typeRoom].marecage.SetActive(false);
                        roomDecor[typeRoom].arene.SetActive(false);
                        roomDecor[typeRoom].cimetiere.SetActive(true);
                    } else if(editionMap.type_habillage_5 == "habillage3") {
                        roomDecor[typeRoom].marecage.SetActive(false);
                        roomDecor[typeRoom].arene.SetActive(true);
                        roomDecor[typeRoom].cimetiere.SetActive(false);
                    }
                } else if(PlayerController.cpt == 6) {
                    if(editionMap.type_salle_6 == "null" || editionMap.type_salle_6 == "salle1") {
                        typeRoom = 0;
                    } else if(editionMap.type_salle_6 == "salle2") {
                        typeRoom = 1;
                    } else if(editionMap.type_salle_6 == "salle3") {
                        typeRoom = 2;
                    }
                    if(editionMap.type_habillage_6 == "null" || editionMap.type_habillage_6 == "habillage1") {
                        roomDecor[typeRoom].marecage.SetActive(true);
                        roomDecor[typeRoom].arene.SetActive(false);
                        roomDecor[typeRoom].cimetiere.SetActive(false);
                    } else if(editionMap.type_habillage_6 == "habillage2") {
                        roomDecor[typeRoom].marecage.SetActive(false);
                        roomDecor[typeRoom].arene.SetActive(false);
                        roomDecor[typeRoom].cimetiere.SetActive(true);
                    } else if(editionMap.type_habillage_6 == "habillage3") {
                        roomDecor[typeRoom].marecage.SetActive(false);
                        roomDecor[typeRoom].arene.SetActive(true);
                        roomDecor[typeRoom].cimetiere.SetActive(false);
                    }
                } else if(PlayerController.cpt == 7) {
                    if(editionMap.type_salle_7 == "null" || editionMap.type_salle_7 == "salle1") {
                        typeRoom = 0;
                    } else if(editionMap.type_salle_7 == "salle2") {
                        typeRoom = 1;
                    } else if(editionMap.type_salle_7 == "salle3") {
                        typeRoom = 2;
                    }
                    if(editionMap.type_habillage_7 == "null" || editionMap.type_habillage_7 == "habillage1") {
                        roomDecor[typeRoom].marecage.SetActive(true);
                        roomDecor[typeRoom].arene.SetActive(false);
                        roomDecor[typeRoom].cimetiere.SetActive(false);
                    } else if(editionMap.type_habillage_7 == "habillage2") {
                        roomDecor[typeRoom].marecage.SetActive(false);
                        roomDecor[typeRoom].arene.SetActive(false);
                        roomDecor[typeRoom].cimetiere.SetActive(true);
                    } else if(editionMap.type_habillage_7 == "habillage3") {
                        roomDecor[typeRoom].marecage.SetActive(false);
                        roomDecor[typeRoom].arene.SetActive(true);
                        roomDecor[typeRoom].cimetiere.SetActive(false);
                    }
                } else if(PlayerController.cpt == 8) {
                    if(editionMap.type_salle_8 == "null" || editionMap.type_salle_8 == "salle1") {
                        typeRoom = 0;
                    } else if(editionMap.type_salle_8 == "salle2") {
                        typeRoom = 1;
                    } else if(editionMap.type_salle_8 == "salle3") {
                        typeRoom = 2;
                    }
                    if(editionMap.type_habillage_8 == "null" || editionMap.type_habillage_8 == "habillage1") {
                        roomDecor[typeRoom].marecage.SetActive(true);
                        roomDecor[typeRoom].arene.SetActive(false);
                        roomDecor[typeRoom].cimetiere.SetActive(false);
                    } else if(editionMap.type_habillage_8 == "habillage2") {
                        roomDecor[typeRoom].marecage.SetActive(false);
                        roomDecor[typeRoom].arene.SetActive(false);
                        roomDecor[typeRoom].cimetiere.SetActive(true);
                    } else if(editionMap.type_habillage_8 == "habillage3") {
                        roomDecor[typeRoom].marecage.SetActive(false);
                        roomDecor[typeRoom].arene.SetActive(true);
                        roomDecor[typeRoom].cimetiere.SetActive(false);
                    }
                } else if(PlayerController.cpt == 9) {
                    if(editionMap.type_salle_9 == "null" || editionMap.type_salle_9 == "salle1") {
                        typeRoom = 0;
                    } else if(editionMap.type_salle_9 == "salle2") {
                        typeRoom = 1;
                    } else if(editionMap.type_salle_9 == "salle3") {
                        typeRoom = 2;
                    }
                    if(editionMap.type_habillage_9 == "null" || editionMap.type_habillage_9 == "habillage1") {
                        roomDecor[typeRoom].marecage.SetActive(true);
                        roomDecor[typeRoom].arene.SetActive(false);
                        roomDecor[typeRoom].cimetiere.SetActive(false);
                    } else if(editionMap.type_habillage_9 == "habillage2") {
                        roomDecor[typeRoom].marecage.SetActive(false);
                        roomDecor[typeRoom].arene.SetActive(false);
                        roomDecor[typeRoom].cimetiere.SetActive(true);
                    } else if(editionMap.type_habillage_9 == "habillage3") {
                        roomDecor[typeRoom].marecage.SetActive(false);
                        roomDecor[typeRoom].arene.SetActive(true);
                        roomDecor[typeRoom].cimetiere.SetActive(false);
                    }
                } else if(PlayerController.cpt == 10) {
                    if(editionMap.type_salle_10 == "null" || editionMap.type_salle_10 == "salle1") {
                        typeRoom = 0;
                    } else if(editionMap.type_salle_10 == "salle2") {
                        typeRoom = 1;
                    } else if(editionMap.type_salle_10 == "salle3") {
                        typeRoom = 2;
                    }
                    if(editionMap.type_habillage_10 == "null" || editionMap.type_habillage_10 == "habillage1") {
                        roomDecor[typeRoom].marecage.SetActive(true);
                        roomDecor[typeRoom].arene.SetActive(false);
                        roomDecor[typeRoom].cimetiere.SetActive(false);
                    } else if(editionMap.type_habillage_10 == "habillage2") {
                        roomDecor[typeRoom].marecage.SetActive(false);
                        roomDecor[typeRoom].arene.SetActive(false);
                        roomDecor[typeRoom].cimetiere.SetActive(true);
                    } else if(editionMap.type_habillage_10 == "habillage3") {
                        roomDecor[typeRoom].marecage.SetActive(false);
                        roomDecor[typeRoom].arene.SetActive(true);
                        roomDecor[typeRoom].cimetiere.SetActive(false);
                    }
                } else if(PlayerController.cpt == 11) {
                    if(editionMap.type_salle_11 == "null" || editionMap.type_salle_11 == "salle1") {
                        typeRoom = 0;
                    } else if(editionMap.type_salle_11 == "salle2") {
                        typeRoom = 1;
                    } else if(editionMap.type_salle_11 == "salle3") {
                        typeRoom = 2;
                    }
                    if(editionMap.type_habillage_11 == "null" || editionMap.type_habillage_11 == "habillage1") {
                        roomDecor[typeRoom].marecage.SetActive(true);
                        roomDecor[typeRoom].arene.SetActive(false);
                        roomDecor[typeRoom].cimetiere.SetActive(false);
                    } else if(editionMap.type_habillage_11 == "habillage2") {
                        roomDecor[typeRoom].marecage.SetActive(false);
                        roomDecor[typeRoom].arene.SetActive(false);
                        roomDecor[typeRoom].cimetiere.SetActive(true);
                    } else if(editionMap.type_habillage_11 == "habillage3") {
                        roomDecor[typeRoom].marecage.SetActive(false);
                        roomDecor[typeRoom].arene.SetActive(true);
                        roomDecor[typeRoom].cimetiere.SetActive(false);
                    }
                } else if(PlayerController.cpt == 12) {
                    if(editionMap.type_salle_12 == "null" || editionMap.type_salle_12 == "salle1") {
                        typeRoom = 0;
                    } else if(editionMap.type_salle_12 == "salle2") {
                        typeRoom = 1;
                    } else if(editionMap.type_salle_12 == "salle3") {
                        typeRoom = 2;
                    }
                    if(editionMap.type_habillage_12 == "null" || editionMap.type_habillage_12 == "habillage1") {
                        roomDecor[typeRoom].marecage.SetActive(true);
                        roomDecor[typeRoom].arene.SetActive(false);
                        roomDecor[typeRoom].cimetiere.SetActive(false);
                    } else if(editionMap.type_habillage_12 == "habillage2") {
                        roomDecor[typeRoom].marecage.SetActive(false);
                        roomDecor[typeRoom].arene.SetActive(false);
                        roomDecor[typeRoom].cimetiere.SetActive(true);
                    } else if(editionMap.type_habillage_12 == "habillage3") {
                        roomDecor[typeRoom].marecage.SetActive(false);
                        roomDecor[typeRoom].arene.SetActive(true);
                        roomDecor[typeRoom].cimetiere.SetActive(false);
                    }
                } else if(PlayerController.cpt == 13) {
                    if(editionMap.type_salle_13 == "null" || editionMap.type_salle_13 == "salle1") {
                        typeRoom = 0;
                    } else if(editionMap.type_salle_13 == "salle2") {
                        typeRoom = 1;
                    } else if(editionMap.type_salle_13 == "salle3") {
                        typeRoom = 2;
                    }
                    if(editionMap.type_habillage_13 == "null" || editionMap.type_habillage_13 == "habillage1") {
                        roomDecor[typeRoom].marecage.SetActive(true);
                        roomDecor[typeRoom].arene.SetActive(false);
                        roomDecor[typeRoom].cimetiere.SetActive(false);
                    } else if(editionMap.type_habillage_13 == "habillage2") {
                        roomDecor[typeRoom].marecage.SetActive(false);
                        roomDecor[typeRoom].arene.SetActive(false);
                        roomDecor[typeRoom].cimetiere.SetActive(true);
                    } else if(editionMap.type_habillage_13 == "habillage3") {
                        roomDecor[typeRoom].marecage.SetActive(false);
                        roomDecor[typeRoom].arene.SetActive(true);
                        roomDecor[typeRoom].cimetiere.SetActive(false);
                    }
                } else if(PlayerController.cpt == 14) {
                    if(editionMap.type_salle_14 == "null" || editionMap.type_salle_14 == "salle1") {
                        typeRoom = 0;
                    } else if(editionMap.type_salle_14 == "salle2") {
                        typeRoom = 1;
                    } else if(editionMap.type_salle_14 == "salle3") {
                        typeRoom = 2;
                    }
                    if(editionMap.type_habillage_14 == "null" || editionMap.type_habillage_14 == "habillage1") {
                        roomDecor[typeRoom].marecage.SetActive(true);
                        roomDecor[typeRoom].arene.SetActive(false);
                        roomDecor[typeRoom].cimetiere.SetActive(false);
                    } else if(editionMap.type_habillage_14 == "habillage2") {
                        roomDecor[typeRoom].marecage.SetActive(false);
                        roomDecor[typeRoom].arene.SetActive(false);
                        roomDecor[typeRoom].cimetiere.SetActive(true);
                    } else if(editionMap.type_habillage_14 == "habillage3") {
                        roomDecor[typeRoom].marecage.SetActive(false);
                        roomDecor[typeRoom].arene.SetActive(true);
                        roomDecor[typeRoom].cimetiere.SetActive(false);
                    }
                }
                GameObject newRoom = Instantiate(rooms[typeRoom], spawnPoint.transform.position, spawnPoint.transform.rotation);
                PlayerController.cpt++;
                hasSpawn = true;
            }
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.CompareTag("Player"))
        {
            Destroy(room, 1);
        }
    }
}
