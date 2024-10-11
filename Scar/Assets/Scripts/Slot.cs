using UnityEngine;
using System.Collections;
using System.Linq;
using UnityEngine.UI; 
using System.IO;


public class Slot : MonoBehaviour
{
    string chemin, jsonString;
    [SerializeField] private GameObject potion;
    [SerializeField] private GameObject description;
    [SerializeField] private GameObject itemDisplay;
    [SerializeField] private GameObject heal_potion;
    [SerializeField] private GameObject mana_potion;
    [SerializeField] private GameObject damage_potion;
    [SerializeField] private GameObject shield_potion;
    [SerializeField] private GameObject destruct_potion;
    private GameObject avertissment;
    private SlotsInventaire inventoryPart1;
    private SlotsInventaire hotbarPart;
    private GameObject inventory1;
    private GameObject hotbar;
    private GameObject amountBoard;
    private GameObject slotAmount;
    private GameObject slotsImage;
    private GameObject avertissement;
    private AmountBoard amounts;
    private Transform player;


    private void Awake() {
        SearchUtileGameObject();
    }
    

//***** PARTIE DROP DE POTION *****//

    //*** Permet de drop en fonction du type de fonction ***//
    public void DropPotion(GameObject type) {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        if(type.tag == "HealthPotionInventory") {
            if(amounts.GetAmountSlot1() == 1) {
                IsEmpty(0);
            } else {
                Process(0);
            }
        } else if(type.tag == "ManaPotionInventory") {
            if(amounts.GetAmountSlot2() == 1) {
                IsEmpty(1);
            } else {
                Process(1);
            }
        } else if(type.tag == "ShieldPotionInventory" || type.tag == "DamagePotionInventory" || type.tag == "DestructPotionInventory") {
            if(amounts.GetAmountSlot3() == 1) {
                IsEmpty(2);
            } else {
                Process(2);
            }
        } 
    }

    //*** Fonction appeler quand il ne reste qu'un seul item dans le slot afin de le reset ***//
    private void IsEmpty(int i) {
        Process(i);
        inventoryPart1.isFull[i] = false; 
        Destroy(inventoryPart1.slots[i].transform.GetChild(0).gameObject); 
        slotsImage = inventoryPart1.slots[i].transform.GetChild(inventoryPart1.slots[i].transform.childCount - 1).gameObject; 
        slotsImage.SetActive(false); 
    }

    //*** Fonction appeler afin de drop une potion en face du joueur  ***//
    private void Process(int i) {
        ChangeNumberOfPotion(i, inventoryPart1.slots[i].transform.childCount - 1);
        //Vector3 playerPos = new Vector3(player.position.x + 3, player.position.y + 2, player.position.z + 2);
        //Instantiate(potion, playerPos, Quaternion.identity);
    }

    //*** Change l'affichage du nombre de potion dans le slot de l'inventaire ***//
    private void ChangeNumberOfPotion(int x, int lastChildIndex) {
        var slotAmounts = inventoryPart1.slots[x].transform.GetChild(lastChildIndex).GetComponent<Text>();
        if(x == 0) {
            amounts.SetAmountSlot1(1);
            slotAmounts.text = amounts.GetAmountSlot1().ToString();
        } else if(x == 1) {
            amounts.SetAmountSlot2(1);
            slotAmounts.text = amounts.GetAmountSlot2().ToString();
        } else if(x == 2) {
            amounts.SetAmountSlot3(1);
            slotAmounts.text = amounts.GetAmountSlot3().ToString();
        }
    }

//***** *************** *****//

//***** PARTIE SWITCH IN HOTBAR *****//

    //*** Permet de mettre le slot de potion choisi dans la hotbar ***//
    public void SwitchToHotBar(GameObject par) {
        if(par.tag == "HealthPotionInventory") { 
            ProcessForHotBar(0, itemDisplay, "HealthPotionHotbar");
        } else if(par.tag == "ManaPotionInventory") {
            ProcessForHotBar(1, itemDisplay, "ManaPotionHotbar");
        } else if(par.tag == "ShieldPotionInventory") {
            ProcessForHotBar(2, itemDisplay, "ShieldPotionHotbar");
        } else if(par.tag == "DestructPotionInventory") {
            ProcessForHotBar(2, itemDisplay, "DestructPotionHotbar");
        } else if(par.tag == "DamagePotionInventory") {
            ProcessForHotBar(2, itemDisplay, "DamagePotionHotbar");
        }
    }

    //*** Tout le processus pour switch une potion dans la hotbar ***//
    private void ProcessForHotBar(int i, GameObject itemDisplay, string tag) {
        chemin = Application.streamingAssetsPath + "/Settings.json";
        jsonString = File.ReadAllText(chemin);
        SettingsGame settings = JsonUtility.FromJson<SettingsGame>(jsonString);
        SearchUtileGameObject();
        if(hotbarPart.isFull[0] == false) { // SI LA HOTBAR EST VIDE
            Switch(i); // ON REMPLIE
        } else if(hotbarPart.isFull[0] == true) { // SI LA HOTBAR EST PLEINE
            if(hotbarPart.slots[0].transform.GetChild(0).gameObject.tag == tag) { // SI L'ITEM EST LE MEME QUE CELUI DEJA PRESENT DANS LA HOTBAR
                 SlotTypeSameInHotbar(i);
            } else { // SI L'ITEM N'EST PAS LE MEME QUE CELUI DE LA HOTBAR
                if(hotbarPart.slots[0].transform.GetChild(0).gameObject.tag == "HealthPotionHotbar") {
                    if(amounts.GetAmountSlot1() < 10) {
                        for(int j = amounts.GetAmountSlot1(); j < 10 || amounts.GetAmountHotBar() > 0; j = amounts.GetAmountSlot1()) {
                            amounts.SetHotBarMany(-1);
                            amounts.SetPotionSlot1(1, heal_potion, inventoryPart1);
                            if(amounts.GetAmountSlot1() == 10 || amounts.GetAmountHotBar() == 0) {
                                break;
                            }
                        }
                        if(amounts.GetAmountHotBar() == 0) {
                            Destroy(hotbarPart.slots[0].transform.GetChild(0).gameObject);
                            hotbarPart.isFull[0] = false;
                            Switch(i);
                        }
                        if(amounts.GetAmountSlot1() == 10) {
                            if(settings.language == "fr") {
                                AvertissmentFullHotbar("LE SLOT 1 EST PLEIN!");
                            } else if(settings.language == "en") {
                                AvertissmentFullHotbar("SLOT 1 IS FULL!");
                            }
                        }
                    } else if(amounts.GetAmountSlot1() == 10) {
                        if(settings.language == "fr") {
                            AvertissmentFullHotbar("LE SLOT 1 EST PLEIN!");
                        } else if(settings.language == "en") {
                            AvertissmentFullHotbar("SLOT 1 IS FULL!");
                        }
                    }
                    if(hotbarPart.slots[0].gameObject.transform.GetChild(2).gameObject.tag == tag) {
                        hotbarPart.slots[0].gameObject.transform.GetChild(2).gameObject.transform.SetSiblingIndex(0);
                    }
                } else if(hotbarPart.slots[0].transform.GetChild(0).gameObject.tag == "ManaPotionHotbar") {
                    if(amounts.GetAmountSlot2() < 10) {
                        for(int j = amounts.GetAmountSlot2(); j < 10 || amounts.GetAmountHotBar() > 0; j = amounts.GetAmountSlot2()) {
                            amounts.SetHotBarMany(-1);
                            amounts.SetPotionSlot2(1, mana_potion, inventoryPart1);
                            if(amounts.GetAmountSlot2() == 10 || amounts.GetAmountHotBar() == 0) {
                                break;
                            }
                        }
                        if(amounts.GetAmountHotBar() == 0) {
                            Destroy(hotbarPart.slots[0].transform.GetChild(0).gameObject);
                            hotbarPart.isFull[0] = false;
                            Switch(i);
                        }
                        if(amounts.GetAmountSlot2() == 10) {
                            if(settings.language == "fr") {
                                AvertissmentFullHotbar("LE SLOT 2 EST PLEIN!");
                            } else if(settings.language == "en") {
                                AvertissmentFullHotbar("SLOT 2 IS FULL!");
                            }
                        }
                    } else if(amounts.GetAmountSlot2() == 10) {
                        if(settings.language == "fr") {
                            AvertissmentFullHotbar("LE SLOT 2 EST PLEIN!");
                        } else if(settings.language == "en") {
                            AvertissmentFullHotbar("SLOT 2 IS FULL!");
                        }
                    }
                    if(hotbarPart.slots[0].gameObject.transform.GetChild(2).gameObject.tag == tag) {
                        hotbarPart.slots[0].gameObject.transform.GetChild(2).gameObject.transform.SetSiblingIndex(0);
                    }
                } else if(hotbarPart.slots[0].transform.GetChild(0).gameObject.tag == "ShieldPotionHotbar") {
                    if(tag == "DestructPotionHotbar") {
                        SlotTypeNotSameInHotBar(2, shield_potion, amounts.GetAmountSlot3());
                        if(hotbarPart.slots[0].gameObject.transform.GetChild(2).gameObject.tag == tag) {
                            hotbarPart.slots[0].gameObject.transform.GetChild(2).gameObject.transform.SetSiblingIndex(0);
                        }
                    } else if(tag == "DamagePotionHotbar") {
                        SlotTypeNotSameInHotBar(2, shield_potion, amounts.GetAmountSlot3());
                        if(hotbarPart.slots[0].gameObject.transform.GetChild(2).gameObject.tag == tag) {
                            hotbarPart.slots[0].gameObject.transform.GetChild(2).gameObject.transform.SetSiblingIndex(0);
                        }
                    } else if(tag == "ManaPotionHotbar" && inventoryPart1.isFull[2] == false) {
                        SlotTypeNotSameInHotBar(1, shield_potion, amounts.GetAmountSlot2());
                        if(hotbarPart.slots[0].gameObject.transform.GetChild(2).gameObject.tag == tag) {
                            hotbarPart.slots[0].gameObject.transform.GetChild(2).gameObject.transform.SetSiblingIndex(0);
                        }
                    } else if(tag == "HealthPotionHotbar" && inventoryPart1.isFull[2] == false) {
                        SlotTypeNotSameInHotBar(0, shield_potion, amounts.GetAmountSlot1());
                        if(hotbarPart.slots[0].gameObject.transform.GetChild(2).gameObject.tag == tag) {
                            hotbarPart.slots[0].gameObject.transform.GetChild(2).gameObject.transform.SetSiblingIndex(0);
                        }
                    } else {
                        if(settings.language == "fr") {
                            AvertissmentFullHotbar("LE SLOT 3 EST PRIS!");
                        } else if(settings.language == "en") {
                            AvertissmentFullHotbar("SLOT 3 IS TAKEN!");
                        }
                    }
                } else if(hotbarPart.slots[0].transform.GetChild(0).gameObject.tag == "DestructPotionHotbar") {
                    if(tag == "ShieldPotionHotbar") {
                        SlotTypeNotSameInHotBar(2, destruct_potion, amounts.GetAmountSlot3());
                        if(hotbarPart.slots[0].gameObject.transform.GetChild(2).gameObject.tag == tag) {
                            hotbarPart.slots[0].gameObject.transform.GetChild(2).gameObject.transform.SetSiblingIndex(0);
                        }
                    } else if(tag == "DamagePotionHotbar") {
                        SlotTypeNotSameInHotBar(2, destruct_potion, amounts.GetAmountSlot3());
                        if(hotbarPart.slots[0].gameObject.transform.GetChild(2).gameObject.tag == tag) {
                            hotbarPart.slots[0].gameObject.transform.GetChild(2).gameObject.transform.SetSiblingIndex(0);
                        }
                    } else if(tag == "ManaPotionHotbar" && inventoryPart1.isFull[2] == false) {
                        SlotTypeNotSameInHotBar(1, destruct_potion, amounts.GetAmountSlot2());
                        if(hotbarPart.slots[0].gameObject.transform.GetChild(2).gameObject.tag == tag) {
                            hotbarPart.slots[0].gameObject.transform.GetChild(2).gameObject.transform.SetSiblingIndex(0);
                        }
                    } else if(tag == "HealthPotionHotbar" && inventoryPart1.isFull[2] == false) {
                        SlotTypeNotSameInHotBar(0, destruct_potion, amounts.GetAmountSlot1());
                        if(hotbarPart.slots[0].gameObject.transform.GetChild(2).gameObject.tag == tag) {
                            hotbarPart.slots[0].gameObject.transform.GetChild(2).gameObject.transform.SetSiblingIndex(0);
                        }
                    } else {
                        if(settings.language == "fr") {
                            AvertissmentFullHotbar("LE SLOT 3 EST PRIS!");
                        } else if(settings.language == "en") {
                            AvertissmentFullHotbar("SLOT 3 IS TAKEN!");
                        }
                    }
                } else if(hotbarPart.slots[0].transform.GetChild(0).gameObject.tag == "DamagePotionHotbar") {
                    if(tag == "ShieldPotionHotbar") {
                        SlotTypeNotSameInHotBar(2, damage_potion, amounts.GetAmountSlot3());
                        if(hotbarPart.slots[0].gameObject.transform.GetChild(2).gameObject.tag == tag) {
                            hotbarPart.slots[0].gameObject.transform.GetChild(2).gameObject.transform.SetSiblingIndex(0);
                        }
                    } else if(tag == "DestructPotionHotbar") {
                        SlotTypeNotSameInHotBar(2, damage_potion, amounts.GetAmountSlot3());
                        if(hotbarPart.slots[0].gameObject.transform.GetChild(2).gameObject.tag == tag) {
                            hotbarPart.slots[0].gameObject.transform.GetChild(2).gameObject.transform.SetSiblingIndex(0);
                        }
                    } else if(tag == "ManaPotionHotbar" && inventoryPart1.isFull[2] == false) {
                        SlotTypeNotSameInHotBar(1, damage_potion, amounts.GetAmountSlot2());
                        if(hotbarPart.slots[0].gameObject.transform.GetChild(2).gameObject.tag == tag) {
                            hotbarPart.slots[0].gameObject.transform.GetChild(2).gameObject.transform.SetSiblingIndex(0);
                        }
                    } else if(tag == "HealthPotionHotbar" && inventoryPart1.isFull[2] == false) {
                        SlotTypeNotSameInHotBar(0, damage_potion, amounts.GetAmountSlot1());
                        if(hotbarPart.slots[0].gameObject.transform.GetChild(2).gameObject.tag == tag) {
                            hotbarPart.slots[0].gameObject.transform.GetChild(2).gameObject.transform.SetSiblingIndex(0);
                        }
                    } else {
                        if(settings.language == "fr") {
                            AvertissmentFullHotbar("LE SLOT 3 EST PRIS!");
                        } else if(settings.language == "en") {
                            AvertissmentFullHotbar("SLOT 3 IS TAKEN!");
                        }
                    }
                } else {
                    if(settings.language == "fr") {
                        AvertissmentFullHotbar("ERREUR!");
                    } else if(settings.language == "en") {
                        AvertissmentFullHotbar("ERROR!");
                    }
                }
            }
        }
    }

    //*** Fonction appeler pour switch les potions dans la hotbar ***//
    private void Switch(int i) {
        if(i == 0) {
            if(amounts.GetAmountSlot1() <= 5) {
                amounts.SetHotBarMany(amounts.GetAmountSlot1(), itemDisplay);
                amounts.SetPotionSlot1(-1*amounts.GetAmountSlot1(), itemDisplay, inventoryPart1);
            } else {
                amounts.SetHotBarMany(5, itemDisplay);
                amounts.SetPotionSlot1(-5, itemDisplay, inventoryPart1);
            }
        } else if(i == 1) {
            if(amounts.GetAmountSlot2() <= 5) {
                amounts.SetHotBarMany(amounts.GetAmountSlot2(), itemDisplay);
                amounts.SetPotionSlot2(-1*amounts.GetAmountSlot2(), itemDisplay, inventoryPart1);
            } else {
                amounts.SetHotBarMany(5, itemDisplay);
                amounts.SetPotionSlot2(-5, itemDisplay, inventoryPart1);
            }
        } else if(i == 2) {
            amounts.SetHotBarMany(amounts.GetAmountSlot3(), itemDisplay);
            amounts.SetPotionSlot3(-1*amounts.GetAmountSlot3(), itemDisplay, inventoryPart1);
        }
        hotbarPart.isFull[0] = true;
        Instantiate(itemDisplay, hotbarPart.slots[0].transform, false);
        DestroyOnProcess(i);
    }

    //*** Fonction appeler quand il faut détruire un objet dans un slot de l'inventaire lors du processus ***//
    private void DestroyOnProcess(int i) {
        if(i == 0) {
            if(amounts.GetAmountSlot1() == 0) {
                inventoryPart1.isFull[i] = false;
                Destroy(inventoryPart1.slots[i].transform.GetChild(0).gameObject);
                slotsImage = inventoryPart1.slots[i].transform.GetChild(inventoryPart1.slots[i].transform.childCount - 1).gameObject;
                slotsImage.SetActive(false);
            }
        } else if(i == 1) {
            if(amounts.GetAmountSlot2() == 0) {
                inventoryPart1.isFull[i] = false;
                Destroy(inventoryPart1.slots[i].transform.GetChild(0).gameObject);
                slotsImage = inventoryPart1.slots[i].transform.GetChild(inventoryPart1.slots[i].transform.childCount - 1).gameObject;
                slotsImage.SetActive(false);
            }
        } else if(i == 2) {
            if(amounts.GetAmountSlot3() == 0) {
                inventoryPart1.isFull[i] = false;
                Destroy(inventoryPart1.slots[i].transform.GetChild(0).gameObject);
                slotsImage = inventoryPart1.slots[i].transform.GetChild(inventoryPart1.slots[i].transform.childCount - 1).gameObject;
                slotsImage.SetActive(false);
            }
        }   
    }

    //*** Fonction appeler quand la potion dans la hotbar est la meme que celle qu'on veut mettre ***//
    private void SlotTypeSameInHotbar(int i) {
        for(int j = amounts.GetAmountHotBar(); j < 5; j = amounts.GetAmountHotBar()) {
            amounts.SetHotBarMany(1);
            if(i == 0) {
                amounts.SetPotionSlot1(-1, itemDisplay, inventoryPart1);
                if(amounts.GetAmountSlot1() == 0) {
                    DestroyOnProcess(i);
                    break;
                }
            } else if(i == 1) {
                amounts.SetPotionSlot2(-1, itemDisplay, inventoryPart1);
                if(amounts.GetAmountSlot2() == 0) {
                    DestroyOnProcess(i);
                    break;
                }
            } else if(i == 2) {
                amounts.SetPotionSlot3(-1, itemDisplay, inventoryPart1);
                    if(amounts.GetAmountSlot3() == 0) {
                    DestroyOnProcess(i);
                    break;
                }
            }
        }
        if(amounts.GetAmountHotBar() >= 5) {
            chemin = Application.streamingAssetsPath + "/Settings.json";
            jsonString = File.ReadAllText(chemin);
            SettingsGame settings = JsonUtility.FromJson<SettingsGame>(jsonString);
            if(settings.language == "fr") {
                AvertissmentFullHotbar("LA HOTBAR EST PLEINE!");
            } else if(settings.language == "en") {
                AvertissmentFullHotbar("HOTBAR IS FULL!");
            }
        }
    }

    private void SlotTypeNotSameInHotBar(int i, GameObject potion, int slotAmount) {
        int temp = amounts.GetAmountHotBar();
        amounts.SetHotBarMany(-1*(amounts.GetAmountHotBar()));
        Destroy(hotbarPart.slots[0].transform.GetChild(0).gameObject);
        hotbarPart.isFull[0] = false;
        /*amounts.SetHotBarMany(slotAmount);
        Instantiate(itemDisplay, hotbarPart.slots[0].transform, false);
        hotbarPart.isFull[0] = true;
        if(i == 0) {
            amounts.SetAmountSlot1(slotAmount);
        } else if(i == 1) {
            amounts.SetAmountSlot2(slotAmount);
        } else if(i == 2) {
            amounts.SetAmountSlot3(slotAmount);
        }*/
        Switch(i);
        if(i == 0) {
            if(amounts.GetAmountSlot1() == 0) {
                inventoryPart1.isFull[i] = false; 
                Destroy(inventoryPart1.slots[i].transform.GetChild(0).gameObject); 
                slotsImage = inventoryPart1.slots[i].transform.GetChild(inventoryPart1.slots[i].transform.childCount - 1).gameObject; 
                slotsImage.SetActive(false);
            }
        } else if(i == 1) {
            if(amounts.GetAmountSlot2() == 0) {
                inventoryPart1.isFull[i] = false; 
                Destroy(inventoryPart1.slots[i].transform.GetChild(0).gameObject); 
                slotsImage = inventoryPart1.slots[i].transform.GetChild(inventoryPart1.slots[i].transform.childCount - 1).gameObject; 
                slotsImage.SetActive(false);
            }
        } else if(i == 2) {
            if(amounts.GetAmountSlot3() == 0) {
                inventoryPart1.isFull[i] = false; 
                Destroy(inventoryPart1.slots[i].transform.GetChild(0).gameObject); 
                slotsImage = inventoryPart1.slots[i].transform.GetChild(inventoryPart1.slots[i].transform.childCount - 1).gameObject; 
                slotsImage.SetActive(false);
            }
        }
        amounts.SetPotionSlot3(temp, potion, inventoryPart1);
    }

    //*** Fonction appeler X secondes après grâce à Invoke ***//
    private void DesactivateAvertissment() {
        avertissment.SetActive(false);
    }

    //*** Fonction appeler afin d'avertir que la hotbar est pleine ***//
    private void AvertissmentFullHotbar(string description) {
        var texts = avertissment.GetComponent<Text>();
        texts.text = description; // LANGUAGE
        avertissment.SetActive(true);
        Invoke("DesactivateAvertissment", 5.0f);
    }

//*****  ***************************  *****//


//***** FONCTION PAS TRES IMPORTANTE *****//

    //*** Détecte si la souris est au dessus ***//
    public void OnMouseOver() {
        if(description != null) {
            description.SetActive(true);
        }
    }

    //*** Détecte si la souris quitte la zone ***//
    public void OnMouseExit() {
        if(description != null) {
            description.SetActive(false);
        }
    }

    //*** Fonction appeler afin de rechercher les GameObject à utiliser ***//
    private void SearchUtileGameObject() {
        var objects = Resources.FindObjectsOfTypeAll<GameObject>().Where(obj => obj.name == "First Part");
        foreach(var item in objects) {
            inventory1 = item;
        }
        inventoryPart1 = inventory1.GetComponent<SlotsInventaire>();

        objects = Resources.FindObjectsOfTypeAll<GameObject>().Where(obj => obj.name == "Fourth Part HotBar");
        foreach(var item in objects) {
            hotbar = item;
        }
        hotbarPart = hotbar.GetComponent<SlotsInventaire>();

        objects = Resources.FindObjectsOfTypeAll<GameObject>().Where(obj => obj.name == "Avertissement");
         foreach(var item in objects) {
            avertissment = item;
        }

        amountBoard = GameObject.FindWithTag("AmountBoard");
        amounts = amountBoard.GetComponent<AmountBoard>();
    }
}