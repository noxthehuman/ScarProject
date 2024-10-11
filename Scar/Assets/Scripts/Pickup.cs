using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI; 
using UnityEngine.SceneManagement;

public class Pickup : MonoBehaviour
{
    private SlotsInventaire inventoryPart1;
    private SlotsInventaire inventoryPart5;
    private GameObject inventory1;
    private GameObject inventory5;

    private GameObject amountBoard;
    private AmountBoard amounts;

    public GameObject itemButton;
    public GameObject itemDisplay;
    private SpawnEnemy spawnEnemy;
    private GameObject porte;
    private static Transform player;
    private Scene scene;

    void Awake() {
        scene = SceneManager.GetActiveScene();
        player = GameObject.FindGameObjectWithTag("Player").transform;

        amountBoard = GameObject.FindWithTag("AmountBoard");
        amounts = amountBoard.GetComponent<AmountBoard>();

        var objects = Resources.FindObjectsOfTypeAll<GameObject>().Where(obj => obj.name == "First Part");
        foreach(var item in objects) {
            inventory1 = item;
        }
        inventoryPart1 = inventory1.GetComponent<SlotsInventaire>();

        objects = Resources.FindObjectsOfTypeAll<GameObject>().Where(obj => obj.name == "Fifth Part");
        foreach(var item in objects) {
            inventory5 = item;
        }
        inventoryPart5 = inventory5.GetComponent<SlotsInventaire>();
    }

    private void Start()
    {
        //*** Détruit l'objet au bout de 60 secondes si non ramassé ***//
        Destroy(gameObject, 60);
    }

    private void Update()
    {   
        //*** Détruit l'objet si il est en dessous de -5 ***//
        if (gameObject.transform.position.y <= -5)
        {
            Destroy(gameObject);
        }

        //*** Si l'objet n'est pas dans le village ET qu'il n'y a pas d'ennemi, il se tp au joueur ***//
        if(!scene.name.Contains("Village")) {
            var enemy = GameObject.FindGameObjectsWithTag("Enemy");
            if(enemy.Length <= 0 && gameObject.tag == "piece" || enemy.Length <= 0 && gameObject.tag == "rubis") {
                transform.position = Vector3.MoveTowards(transform.position, player.position, 40.0f * Time.deltaTime);
            }
        }
    }

    //*** Check quel item entre en collision avec le joueur ***//
    private void OnTriggerEnter(Collider col) {
        if(col.CompareTag("Player")) {
            if(itemButton.tag == "piece" || itemButton.tag == "rubis") {
                isCoinOrRubis(itemButton.tag);
            } else {
                isPotion(itemButton.tag);
            }
        }
    }

    //*** Ajoute la potion au bon slot ***//
    private void isPotion(string type) {
        if(type == "health_potion") {
            if(inventoryPart1.isFull[0] == false) {
                amounts.SetSlot1Type("health_potion");
                amounts.SetPotionSlot1(1, itemDisplay, inventoryPart1);
                inventoryPart1.isFull[0] = true;
                Destroy(gameObject);
            } else if(inventoryPart1.isFull[0] == true) {
                if(amounts.GetAmountSlot1() < 10) {
                    amounts.SetSlot1Type("health_potion");
                    amounts.SetPotionSlot1(1, itemDisplay, inventoryPart1);
                    Destroy(gameObject);
                }
            } 
        } else if(type == "mana_potion") { 
            if(inventoryPart1.isFull[1] == false) {
                amounts.SetSlot2Type("mana_potion");
                amounts.SetPotionSlot2(1, itemDisplay, inventoryPart1);
                inventoryPart1.isFull[1] = true;
                Destroy(gameObject);
            } else if(inventoryPart1.isFull[1] == true) {
                if(amounts.GetAmountSlot2() < 10) {
                    amounts.SetSlot2Type("mana_potion");
                    amounts.SetPotionSlot2(1, itemDisplay, inventoryPart1);
                    Destroy(gameObject);
                }
            } 
        } else if(type == "damage_potion") {
            ProcessForSlot3(type, "DamagePotionInventory");
        } else if(type == "shield_potion") {
            ProcessForSlot3(type, "ShieldPotionInventory");
        } else if(type == "destruct_potion") {
            ProcessForSlot3(type, "DestructPotionInventory");
        } 
    }

    //*** Processur appeler pour une potion du slot 3 ***//
    private void ProcessForSlot3(string type, string tag) {
        if(inventoryPart1.isFull[2] == false) {
            amounts.SetSlot3Type(type);
            amounts.SetPotionSlot3(1, itemDisplay, inventoryPart1);
            inventoryPart1.isFull[2] = true;
            Destroy(gameObject);
        } else if(inventoryPart1.isFull[2] == true && inventoryPart1.slots[2].transform.GetChild(0).gameObject.tag == tag) {
            if(amounts.GetAmountSlot3() < 5) {
                amounts.SetSlot3Type(type);
                amounts.SetPotionSlot3(1, itemDisplay, inventoryPart1);
                Destroy(gameObject);
            }
        }
    }

    //*** Ajoute la pièce ou le rubis au bon slot ***//
    private void isCoinOrRubis(string items) {
        if(items == "piece") {
            if(inventoryPart5.isFull[0] == false) {
                amounts.SetPiece(1, itemDisplay, inventoryPart5);
                inventoryPart5.isFull[0] = true;
                Destroy(gameObject);
            } else if(inventoryPart5.isFull[0] == true) {
                amounts.SetPiece(1, itemDisplay, inventoryPart5);
                Destroy(gameObject);
            }
        } else if(items == "rubis") {
            if(inventoryPart5.isFull[2] == false) {
                amounts.SetRubis(1, itemDisplay, inventoryPart5);
                inventoryPart5.isFull[2] = true;
                Destroy(gameObject);
            } else if(inventoryPart5.isFull[2] == true) {
                amounts.SetRubis(1, itemDisplay, inventoryPart5);
                Destroy(gameObject);
            }
        }
    }
}
