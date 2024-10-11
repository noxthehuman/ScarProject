using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI; 
using UnityEngine.SceneManagement;

public class ChangeConso : MonoBehaviour
{
    [SerializeField] private GameObject consoInventory;
    [SerializeField] private GameObject hotbar;
    [SerializeField] private GameObject soinSlot1Conso;
    [SerializeField] private GameObject manaSlot2Conso;
    [SerializeField] private GameObject destructSlot3Conso;
    [SerializeField] private GameObject shieldSlot3Conso;
    [SerializeField] private GameObject damageSlot3Conso;
    [SerializeField] private GameObject soinSlotActualConso;
    [SerializeField] private GameObject manaSlotActualConso;
    [SerializeField] private GameObject destructSlotActualConso;
    [SerializeField] private GameObject shieldSlotActualConso;
    [SerializeField] private GameObject damageSlotActualConso;
    [SerializeField] private GameObject slot1Text;
    [SerializeField] private GameObject slot2Text;
    [SerializeField] private GameObject slot3Text;
    [SerializeField] private GameObject slotHotbarText;

    private GameObject potions;
    private GameObject amountBoard;
    private SlotsInventaire hotbarPart;
    private AmountBoard amounts;

    void Awake() {
        amountBoard = GameObject.FindWithTag("AmountBoard");
        amounts = amountBoard.GetComponent<AmountBoard>();
    }

    void Update() {
        if(Input.GetKeyDown(KeyCode.C)) { // Affiche le choix de la consommation rapide en appuyant sur la touche C
            consoInventory.SetActive(true);
        } 
        
        if(Input.GetKeyUp(KeyCode.C)) {
            consoInventory.SetActive(false);
        }

        CheckOnInventory();
        CheckOnHotBar();
        CheckHowMany(slot1Text, amounts.GetAmountSlot1());
        CheckHowMany(slot2Text, amounts.GetAmountSlot2());
        CheckHowMany(slot3Text, amounts.GetAmountSlot3());
        CheckHowMany(slotHotbarText, amounts.GetAmountHotBar());
    }

    //*** Vérifie si un conso est dans l'inventaire afin de l'afficher ***//
    private void CheckOnInventory() {
        CheckOnInventorySlot(amounts.GetSlot1Type(), "heal_potion", soinSlot1Conso);
        CheckOnInventorySlot(amounts.GetSlot2Type(), "mana_potion", manaSlot2Conso);
        switch(amounts.GetSlot3Type()) {
            case "destruct_potion":
                ChangeActivationDisplayPotionSlot3(false, false, true);
                break;
            case "damage_potion":
                ChangeActivationDisplayPotionSlot3(true, false, false);
                break;
            case "shield_potion":
                ChangeActivationDisplayPotionSlot3(false, true, false);
                break;
            case "null":
                ChangeActivationDisplayPotionSlot3(false, false, false);
                break;
            default:
                break;
        }
    }

    //*** Vérifie si un conso est dans la hotbar afin de l'afficher ***//
    private void CheckOnHotBar() {
        switch(amounts.GetHotbarType()) {
            case "heal_potion":
                ChangeActivationDisplayPotionHotbar(true, false, false, false, false);
                break;
            case "mana_potion":
                ChangeActivationDisplayPotionHotbar(false, true, false, false, false);
                break;
            case "damage_potion":
                ChangeActivationDisplayPotionHotbar(false, false, false, false, true);
                break;
            case "destruct_potion":
                ChangeActivationDisplayPotionHotbar(false, false, true, false, false);
                break;
            case "shield_potion":
                ChangeActivationDisplayPotionHotbar(false, false, false, true, false);
                break;
            case "null":
                ChangeActivationDisplayPotionHotbar(false, false, false, false, false);
                break;
            default:
                break;
        }
    }

    //*** Vérifie le nombre de potion dans chaque slot pour l'afficher dans le menu conso rapide ***//
    private void CheckHowMany(GameObject numberObject, int amountSlot) {
        Text p = numberObject.GetComponent<Text>();
        if(amountSlot > 0) {
            p.text = amountSlot.ToString();
            numberObject.SetActive(true);
        } else if(amountSlot == 0) {
            p.text = amountSlot.ToString();
            numberObject.SetActive(false); 
        }
    }

    //*** Permet d'activer/désactiver l'affichage de la potion du slot 1 ou 2 dans la conso rapide ***//
    private void CheckOnInventorySlot(string slotType, string typeTest, GameObject slotConso) {
        if(slotType == typeTest) {
            slotConso.SetActive(true);
        } else if(slotType == "null") {
            slotConso.SetActive(false);
        }
    }

    //*** Permet d'activer/désactiver l'affichage de la potion du slot 3 dans la conso rapide ***//
    private void ChangeActivationDisplayPotionSlot3(bool damageSlot, bool shieldSlot, bool destructSlot) {
        damageSlot3Conso.SetActive(damageSlot);
        shieldSlot3Conso.SetActive(shieldSlot);
        destructSlot3Conso.SetActive(destructSlot);
    }

    //*** Permet d'activer/désactiver l'affichage de la potion de la hotbar dans la conso rapide ***//
    private void ChangeActivationDisplayPotionHotbar(bool soinSlot, bool manaSlot, bool destructSlot, bool shieldSlot, bool damageSlot) {
        soinSlotActualConso.SetActive(soinSlot);
        manaSlotActualConso.SetActive(manaSlot);
        destructSlotActualConso.SetActive(destructSlot);
        shieldSlotActualConso.SetActive(shieldSlot);
        damageSlotActualConso.SetActive(damageSlot);
    }
}
