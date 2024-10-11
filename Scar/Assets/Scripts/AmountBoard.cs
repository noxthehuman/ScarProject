using UnityEngine;
using UnityEngine.UI; 
using System.IO;
using UnityEngine.SceneManagement;

public class AmountBoard : MonoBehaviour {

    public int amount_piece = 0;
    public int amount_rubis = 0;
    public int amount_slot_1 = 0;
    public int amount_slot_2 = 0;
    public int amount_slot_3 = 0;
    public int amount_slot_card = 0;
    public int amount_slot_hotbar = 0;
    public string hotbar_type = "null";
    public string slot1_type = "null";
    public string slot2_type = "null";
    public string slot3_type = "null";
    public string slotcard_type = "null";

    public GameObject amount_piece_object;
    public GameObject amount_rubis_object;
    public GameObject amount_slot_object_1;
    public GameObject amount_slot_object_2;
    public GameObject amount_slot_object_3;
    public GameObject amount_slot_hotbar_hotbar;
    public GameObject first_part_inventory;
    public GameObject fifth_part_inventory;
    public GameObject fourth_part_hotbar;

    public SlotsInventaire slotsPiece;
    public SlotsInventaire slotsPotion;
    public SlotsInventaire slotsHotbar;
    public GameObject itemPiece;
    public GameObject itemRubis;
    public GameObject itemPotion1;
    public GameObject itemPotion2;
    public GameObject itemPotion3Shield;
    public GameObject itemPotion3Destruct;
    public GameObject itemPotion3Damage;
    public GameObject itemPotion1Hotbar;
    public GameObject itemPotion2Hotbar;
    public GameObject itemPotion3Hotbar;
    public GameObject itemPotion4Hotbar;
    public GameObject itemPotion5Hotbar;
    private string chemin, jsonString;

    /*private string hotbar_type;
    private string slot3_type; 
    private string slot2_type;
    private string slot1_type; */

    void Start() {
        if(SceneManager.GetActiveScene().name != "DonjonEditMap") {
            chemin = Application.streamingAssetsPath + "/inventory.json";
            jsonString = File.ReadAllText(chemin);
            VariableForJSON inventaire = JsonUtility.FromJson<VariableForJSON>(jsonString);
            amount_piece = inventaire.amount_piece;
            amount_rubis = inventaire.amount_rubis;
            amount_slot_1 = inventaire.amount_slot_1;
            amount_slot_2 = inventaire.amount_slot_2;
            amount_slot_3 = inventaire.amount_slot_3;
            amount_slot_card = inventaire.amount_slot_card;
            amount_slot_hotbar = inventaire.amount_slot_hotbar;
            hotbar_type = inventaire.hotbar_type;
            slot1_type = inventaire.slot1_type;
            slot2_type = inventaire.slot2_type;
            slot3_type = inventaire.slot3_type;
            slotcard_type = inventaire.slotcard_type;
        }
        if(amount_slot_1 >= 10) {
            amount_slot_1 = 10;
        } 
        if(amount_slot_2 >= 10) {
            amount_slot_2 = 10;
        } 
        if(amount_slot_3 >= 5) {
            amount_slot_3 = 5;
        }
        if(amount_slot_hotbar >= 5) {
            amount_slot_hotbar = 5;
        }

        slotsPiece = fifth_part_inventory.GetComponent<SlotsInventaire>();
        slotsPotion = first_part_inventory.GetComponent<SlotsInventaire>();
        slotsHotbar = fourth_part_hotbar.GetComponent<SlotsInventaire>();
        CheckInventory();
    }

    void Awake() {
        if(amount_slot_1 >= 10) {
            amount_slot_1 = 10;
        } 
        if(amount_slot_2 >= 10) {
            amount_slot_2 = 10;
        } 
        if(amount_slot_3 >= 5) {
            amount_slot_3 = 5;
        }
        if(amount_slot_hotbar >= 5) {
            amount_slot_hotbar = 5;
        }
        chemin = Application.streamingAssetsPath + "/inventory.json";
        jsonString = File.ReadAllText(chemin);
        VariableForJSON inventaire = JsonUtility.FromJson<VariableForJSON>(jsonString);
        hotbar_type = inventaire.hotbar_type;
        slot1_type = inventaire.slot1_type;
        slot2_type = inventaire.slot2_type;
        slot3_type = inventaire.slot3_type;
        slotcard_type = inventaire.slotcard_type;

        slotsPiece = fifth_part_inventory.GetComponent<SlotsInventaire>();
        slotsPotion = first_part_inventory.GetComponent<SlotsInventaire>();
        slotsHotbar = fourth_part_hotbar.GetComponent<SlotsInventaire>();
        CheckInventory();
        /*slotsPiece = null;
        slotsPotion = null;
        slotsHotbar = null;
        */
    }

    private void CheckInventory() {
        if(slotsPiece.isFull[0] == false && amount_piece > 0) {
            Instantiate(itemPiece, slotsPiece.slots[0].transform, false);
            slotsPiece.isFull[0] = true;
            var p = amount_piece_object.GetComponent<Text>();
            p.text = amount_piece.ToString();
            amount_piece_object.SetActive(true);
        }

        if(slotsPiece.isFull[2] == false && amount_rubis > 0) {
            Instantiate(itemRubis, slotsPiece.slots[2].transform, false);
            slotsPiece.isFull[2] = true;
            var p = amount_rubis_object.GetComponent<Text>();
            p.text = amount_rubis.ToString();
            amount_rubis_object.SetActive(true);
        }

        if(slotsPotion.isFull[0] == false && amount_slot_1 > 0) {
            Instantiate(itemPotion1, slotsPotion.slots[0].transform, false);
            slotsPotion.isFull[0] = true;
            var p = amount_slot_object_1.GetComponent<Text>();
            p.text = amount_slot_1.ToString();
            amount_slot_object_1.SetActive(true);
        }

        if(slotsPotion.isFull[1] == false && amount_slot_2 > 0) {
            Instantiate(itemPotion2, slotsPotion.slots[1].transform, false);
            slotsPotion.isFull[1] = true;
            var p = amount_slot_object_2.GetComponent<Text>();
            p.text = amount_slot_2.ToString();
            amount_slot_object_2.SetActive(true);
        }

        if(slotsPotion.isFull[2] == false && amount_slot_3 > 0) {
            if(slot3_type == "damage_potion") {
                Instantiate(itemPotion3Damage, slotsPotion.slots[2].transform, false);
            } else if(slot3_type == "destruct_potion") {
                Instantiate(itemPotion3Destruct, slotsPotion.slots[2].transform, false);
            } else if(slot3_type == "shield_potion") {
                Instantiate(itemPotion3Shield, slotsPotion.slots[2].transform, false);
            }
            slotsPotion.isFull[2] = true;
            var p = amount_slot_object_3.GetComponent<Text>();
            p.text = amount_slot_3.ToString();
            amount_slot_object_3.SetActive(true);
        }

        if(slotsHotbar.isFull[0] == false && amount_slot_hotbar > 0) {
            chemin = Application.streamingAssetsPath + "/inventory.json";
            jsonString = File.ReadAllText(chemin);
            VariableForJSON inventaire = JsonUtility.FromJson<VariableForJSON>(jsonString);
            if(inventaire.hotbar_type == "heal_potion") {
                Instantiate(itemPotion1Hotbar, slotsHotbar.slots[0].transform, false);
            } else if(inventaire.hotbar_type == "mana_potion") {
                Instantiate(itemPotion2Hotbar, slotsHotbar.slots[0].transform, false);
            } else if(inventaire.hotbar_type == "shield_potion") {
                Instantiate(itemPotion3Hotbar, slotsHotbar.slots[0].transform, false);
            } else if(inventaire.hotbar_type == "destruct_potion") {
                Instantiate(itemPotion4Hotbar, slotsHotbar.slots[0].transform, false);
            } else if(inventaire.hotbar_type == "damage_potion") {
                Instantiate(itemPotion5Hotbar, slotsHotbar.slots[0].transform, false);
            }
            slotsHotbar.isFull[0] = true;
            var p = amount_slot_hotbar_hotbar.GetComponent<Text>();
            p.text = amount_slot_hotbar.ToString();
            amount_slot_hotbar_hotbar.SetActive(true);
        }
    }

    //*** Permet de récupérer le nombre de pièce ***//
    public int GetPiece() {
        return amount_piece;
    }

    //*** Permet de récupérer le nombre de rubis ***//
    public int GetRubis() {
        return amount_rubis;
    }

    //*** Permet de récupérer le nombre de potion dans le slot 1 ***//
    public int GetAmountSlot1() {
        return amount_slot_1;
    }

    //*** Permet de récupérer le nombre de potion dans le slot 2 ***//
    public int GetAmountSlot2() {
        return amount_slot_2;
    }

    //*** Permet de récupérer le type dans le slot 3 ***//
    public string GetSlot1Type() {
        return slot1_type;
    }

    //*** Permet de récupérer le type dans le slot 3 ***//
    public string GetSlot2Type() {
        return slot2_type;
    }

    //*** Permet de récupérer le type dans le slot 3 ***//
    public string GetSlot3Type() {
        return slot3_type;
    }

    //*** Permet de récupérer le type dans la hotbar ***//
    public string GetHotbarType() {
        return hotbar_type;
    }
    
    //*** Permet de récupérer le nombre de potion dans le slot 3 ***//
    public int GetAmountSlot3() {
        return amount_slot_3;
    }

    //*** Permet de récupérer le nombre de potion dans la hotbar ***//
    public int GetAmountHotBar() {
        return amount_slot_hotbar;
    }

    //*** Permet de changer le nombre de potion dans le slot 1 ***//
    public void SetAmountSlot1(int i) {
        amount_slot_1 = amount_slot_1 - i;
        var p = amount_slot_object_1.GetComponent<Text>();
        p.text = amount_slot_1.ToString();
        if(amount_slot_1 > 0) {
            amount_slot_object_1.SetActive(true);
        } else {
            amount_slot_object_1.SetActive(false);
        }
    } 

    //*** Permet de changer le nombre de potion dans le slot 2 ***//
    public void SetAmountSlot2(int i) {
        amount_slot_2 = amount_slot_2 - i;
        var p = amount_slot_object_2.GetComponent<Text>();
        p.text = amount_slot_2.ToString();
        if(amount_slot_2 > 0) {
            amount_slot_object_2.SetActive(true);
        } else {
            amount_slot_object_2.SetActive(false);
        }
    }

    //*** Permet de changer le nombre de potion dans le slot 3 ***//
    public void SetAmountSlot3(int i) {
        amount_slot_3 = amount_slot_3 - i;
        var p = amount_slot_object_3.GetComponent<Text>();
        p.text = amount_slot_3.ToString();
        if(amount_slot_3 > 0) {
            amount_slot_object_3.SetActive(true);
        } else {
            amount_slot_object_3.SetActive(false);
        }
    }

    //*** Permet de changer le nombre de rubis ***//
    public void SetRubis(int x, GameObject item, SlotsInventaire slot) {
        amount_rubis = amount_rubis + x;
        var p = amount_rubis_object.GetComponent<Text>();
        p.text = amount_rubis.ToString();
        if(amount_rubis > 0 && slot.isFull[2] == false) {
            slotsPiece = slot;
            itemRubis = item;
            Instantiate(item, slot.slots[2].transform, false);
            if(slot.transform.gameObject.transform.GetChild(0).gameObject.transform.GetChild(1).gameObject.name == "rubis_image(Clone)") {
                slot.transform.gameObject.transform.GetChild(0).gameObject.transform.GetChild(1).gameObject.transform.SetSiblingIndex(0);
            }
            amount_rubis_object.SetActive(true);
        } else if(amount_rubis == 0) {
            amount_rubis_object.SetActive(false);
        }
    }

    //*** Permet de changer le nombre de pièce ***//
    public void SetPiece(int x, GameObject item, SlotsInventaire slot) {
        amount_piece = amount_piece + x;
        var p = amount_piece_object.GetComponent<Text>();
        p.text = amount_piece.ToString();
        if(amount_piece > 0 && slot.isFull[0] == false) {
            slotsPiece = slot;
            itemPiece = item;
            Instantiate(item, slot.slots[0].transform, false);
            if(slot.transform.gameObject.transform.GetChild(2).gameObject.transform.GetChild(1).gameObject.name == "coin_image(Clone)") {
                slot.transform.gameObject.transform.GetChild(2).gameObject.transform.GetChild(1).gameObject.transform.SetSiblingIndex(0);
            }
            amount_piece_object.SetActive(true);
        } else if(amount_piece == 0) {
            amount_piece_object.SetActive(false);
        }
    }

    //*** Permet d'ajouter/soustraire le nombre de potion dans le slot 1 ***//
    public void SetPotionSlot1(int x, GameObject item, SlotsInventaire slot) {
        amount_slot_1 = amount_slot_1 + x;
        var p = amount_slot_object_1.GetComponent<Text>();
        p.text = amount_slot_1.ToString();
        if(amount_slot_1 > 0 && amount_slot_1 <= 10 && slot.isFull[0] == false) {
            Instantiate(itemPotion1, slot.slots[0].transform, false);
            slot.isFull[0] = true;
            amount_slot_object_1.SetActive(true);
        } else if(amount_slot_1 == 0) {
            amount_slot_object_1.SetActive(false);
        }
        if(slot.transform.gameObject.transform.GetChild(0).gameObject.transform.GetChild(1).gameObject.tag == "HealthPotionInventory") {
            slot.transform.gameObject.transform.GetChild(0).gameObject.transform.GetChild(1).gameObject.transform.SetSiblingIndex(0);
        }
    }

    //*** Permet d'ajouter/soustraire le nombre de potion dans le slot 2 ***//
    public void SetPotionSlot2(int x, GameObject item, SlotsInventaire slot) {
        amount_slot_2 = amount_slot_2 + x;
        var p = amount_slot_object_2.GetComponent<Text>();
        p.text = amount_slot_2.ToString();
        if(amount_slot_2 > 0 && amount_slot_2 <= 10 && slot.isFull[1] == false) {
            Instantiate(itemPotion2, slot.slots[1].transform, false);
            slot.isFull[1] = true;
            amount_slot_object_2.SetActive(true);
        } else if(amount_slot_2 == 0) {
            amount_slot_object_2.SetActive(false);
        }
        if(slot.transform.gameObject.transform.GetChild(1).gameObject.transform.GetChild(1).gameObject.tag == "ManaPotionInventory") {
            slot.transform.gameObject.transform.GetChild(1).gameObject.transform.GetChild(1).gameObject.transform.SetSiblingIndex(0);
        }
    }

    //*** Permet d'ajouter/soustraire le nombre de potion dans le slot 3 ***//
    public void SetPotionSlot3(int x, GameObject item, SlotsInventaire slot) {
        amount_slot_3 = amount_slot_3 + x;
        var p = amount_slot_object_3.GetComponent<Text>();
        p.text = amount_slot_3.ToString();
        if(amount_slot_3 > 0  && amount_slot_3 <= 5 && slot.isFull[2] == false) {
            Instantiate(item, slot.slots[2].transform, false);
            slot.isFull[2] = true;
            amount_slot_object_3.SetActive(true);
        } else if(amount_slot_3 == 0) {
            amount_slot_object_3.SetActive(false);
        }
        if(slot.transform.gameObject.transform.GetChild(2).gameObject.transform.GetChild(slot.transform.gameObject.transform.GetChild(2).gameObject.transform.childCount-1).gameObject.tag == "DamagePotionInventory" || slot.transform.gameObject.transform.GetChild(2).gameObject.transform.GetChild(slot.transform.gameObject.transform.GetChild(2).gameObject.transform.childCount-1).gameObject.tag == "DestructPotionInventory" || slot.transform.gameObject.transform.GetChild(2).gameObject.transform.GetChild(slot.transform.gameObject.transform.GetChild(2).gameObject.transform.childCount-1).gameObject.tag == "ShieldPotionInventory") {
            slot.transform.gameObject.transform.GetChild(2).gameObject.transform.GetChild(slot.transform.gameObject.transform.GetChild(2).gameObject.transform.childCount-1).gameObject.transform.SetSiblingIndex(0);
        }
    }

    //*** Permet de modifier le type présent dans le slot 1 ***//
    public void SetSlot1Type(string name) {
        slot1_type = name;
    }

    //*** Permet de modifier le type présent dans le slot 2 ***//
    public void SetSlot2Type(string name) {
        slot2_type = name;
    }
    
    //*** Permet de modifier le type présent dans le slot 3 ***//
    public void SetSlot3Type(string name) {
        slot3_type = name;
    }

    //*** Permet de modifier le type présent dans la hotbar ***//
    public void SetHotbarType(string name) {
        hotbar_type = name;
    }

    //*** Permet de changer le nombre de potion dans la hotbar ***//
    public void SetHotBarMany(int x, GameObject item = null) {
        amount_slot_hotbar = amount_slot_hotbar + x;
        var p = amount_slot_hotbar_hotbar.GetComponent<Text>();
        p.text = amount_slot_hotbar.ToString();
        if(amount_slot_hotbar >= 1) {
            amount_slot_hotbar_hotbar.SetActive(true);
        } else if(amount_slot_hotbar == 0) {
            amount_slot_hotbar_hotbar.SetActive(false);
        }
       //Debug.Log(slot.transform.gameObject.transform.GetChild(2).gameObject.transform.GetChild(slot.transform.gameObject.transform.GetChild(2).gameObject.transform.childCount-1).gameObject.tag);
        //if(slot.transform.gameObject.transform.GetChild(2).gameObject.transform.GetChild(slot.transform.gameObject.transform.GetChild(2).gameObject.transform.childCount-1).gameObject.tag == "DamagePotionInventory" || slot.transform.gameObject.transform.GetChild(2).gameObject.transform.GetChild(slot.transform.gameObject.transform.GetChild(2).gameObject.transform.childCount-1).gameObject.tag == "DestructPotionInventory" || slot.transform.gameObject.transform.GetChild(2).gameObject.transform.GetChild(slot.transform.gameObject.transform.GetChild(2).gameObject.transform.childCount-1).gameObject.tag == "ShieldPotionInventory") {
          //0  slot.transform.gameObject.transform.GetChild(2).gameObject.transform.GetChild(slot.transform.gameObject.transform.GetChild(2).gameObject.transform.childCount-1).gameObject.transform.SetSiblingIndex(0);
        //}
    }
}
