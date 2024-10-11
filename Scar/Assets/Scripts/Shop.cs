using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
using System.IO;


public class Shop : MonoBehaviour
{
    public Animator cam;
    public GameObject shop;
    public GameObject inventaire;
    public GameObject avertissement;
    private AmountBoard money;
    public GameObject amountBoard;
    public GameObject partiePotion;
    public GameObject partieCarte;
    private string chemin, jsonString;

    void Awake()
    {
        money = amountBoard.GetComponent<AmountBoard>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            cam.Play("ShopCamera", -1, 0f);
            shop.SetActive(true);
            inventaire.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            cam.Play("ShopCameraOut", -1, 0f);
            shop.SetActive(false);
            inventaire.SetActive(false);
        }
    }

    public void GoToCardPart() {
        partiePotion.SetActive(false);
        partieCarte.SetActive(true);
    }

    public void GoToPotionPart() {
        partiePotion.SetActive(true);
        partieCarte.SetActive(false);
    }

    public void Health()
    {   
        chemin = Application.streamingAssetsPath + "/Settings.json";
        jsonString = File.ReadAllText(chemin);
        SettingsGame settings = JsonUtility.FromJson<SettingsGame>(jsonString);

        if(money.GetAmountSlot1() < 10 || money.GetSlot1Type() == "null") {
            if (money.amount_piece >= 50) {
                money.SetAmountSlot1(-1);
                if(money.GetSlot1Type() == "null") {
                    Instantiate(money.itemPotion1, money.slotsPotion.slots[0].transform, false);
                    money.slot1_type = "heal_potion";
                }
                money.SetPiece(-50, money.itemPiece, money.slotsPiece);
            } else {
                if(settings.language == "fr") {
                    Avertissment("Tu n'as pas assez d'argent!");
                } else if(settings.language == "en") {
                    Avertissment("You don't have enough money!");
                }
            }
        } else {
            if(settings.language == "fr") {
                Avertissment("Le slot 1 est plein!");
            } else if(settings.language == "en") {
                Avertissment("Slot 1 is full!");
            }
        }
    }

    public void Mana()
    {
        chemin = Application.streamingAssetsPath + "/Settings.json";
        jsonString = File.ReadAllText(chemin);
        SettingsGame settings = JsonUtility.FromJson<SettingsGame>(jsonString);
        if(money.GetAmountSlot2() < 10 || money.GetSlot2Type() == "null") {
            if (money.amount_piece >= 65) {
                money.SetAmountSlot2(-1);
                if(money.GetSlot2Type() == "null") {
                    Instantiate(money.itemPotion2, money.slotsPotion.slots[1].transform, false);
                    money.slot2_type = "mana_potion";
                }
                money.SetPiece(-65, money.itemPiece, money.slotsPiece);
            } else {
                if(settings.language == "fr") {
                    Avertissment("Tu n'as pas assez d'argent!");
                } else if(settings.language == "en") {
                    Avertissment("You don't have enough money!");
                }
            }
        } else {
            if(settings.language == "fr") {
                Avertissment("Le slot 2 est plein!");
            } else if(settings.language == "en") {
                Avertissment("Slot 2 is full!");
            }
        }
    }

    public void ShieldUp()
    {   
        chemin = Application.streamingAssetsPath + "/Settings.json";
        jsonString = File.ReadAllText(chemin);
        SettingsGame settings = JsonUtility.FromJson<SettingsGame>(jsonString);
        if(money.GetSlot3Type() == "shield_potion" || money.GetSlot3Type() == "null") {
            if(money.GetAmountSlot3() < 5) {
                if (money.amount_piece >= 400) {
                    money.SetAmountSlot3(-1);
                    if(money.GetSlot3Type() == "null") {
                        Instantiate(money.itemPotion3Shield, money.slotsPotion.slots[2].transform, false);
                        money.slot3_type = "shield_potion";
                    }
                    money.SetPiece(-400, money.itemPiece, money.slotsPiece);
                } else {
                    if(settings.language == "fr") {
                        Avertissment("Tu n'as pas assez d'argent!");
                    } else if(settings.language == "en") {
                        Avertissment("You don't have enough money!");
                    }
                }
            } else {
                if(settings.language == "fr") {
                    Avertissment("Le slot 3 est plein!");
                } else if(settings.language == "en") {
                    Avertissment("Slot 3 is full!");
                }
            }
        } else {
            if(settings.language == "fr") {
                Avertissment("Le slot 3 est deja pris!");
            } else if(settings.language == "en") {
                Avertissment("Slot 3 is already taken!");
            }
        }
    }

    public void AttackUp() {
        chemin = Application.streamingAssetsPath + "/Settings.json";
        jsonString = File.ReadAllText(chemin);
        SettingsGame settings = JsonUtility.FromJson<SettingsGame>(jsonString);
        if(money.GetSlot3Type() == "damage_potion" || money.GetSlot3Type() == "null") {
            if(money.GetAmountSlot3() < 5) {
                if (money.amount_piece >= 300) {
                    money.SetAmountSlot3(-1);
                    if(money.GetSlot3Type() == "null") {
                        Instantiate(money.itemPotion3Damage, money.slotsPotion.slots[2].transform, false);
                        money.slot3_type = "damage_potion";
                    }
                    money.slot3_type = "damage_potion";
                    money.SetPiece(-300, money.itemPiece, money.slotsPiece);
                } else {
                    if(settings.language == "fr") {
                        Avertissment("Tu n'as pas assez d'argent!");
                    } else if(settings.language == "en") {
                        Avertissment("You don't have enough money!");
                    }
                }
            } else {
                if(settings.language == "fr") {
                    Avertissment("Le slot 3 est plein!");
                } else if(settings.language == "en") {
                    Avertissment("Slot 3 is full!");
                }
            }
        } else {
            if(settings.language == "fr") {
                Avertissment("Le slot 3 est deja pris!");
            } else if(settings.language == "en") {
                Avertissment("Slot 3 is already taken!");
            }
        }
    }

    public void DeleteBullet() {
        chemin = Application.streamingAssetsPath + "/Settings.json";
        jsonString = File.ReadAllText(chemin);
        SettingsGame settings = JsonUtility.FromJson<SettingsGame>(jsonString);
        if(money.GetSlot3Type() == "destruction_potion" || money.GetSlot3Type() == "null") {
            if(money.GetAmountSlot3() < 5) {
                if (money.amount_piece >= 500) {
                    money.SetAmountSlot3(-1);
                    if(money.GetSlot3Type() == "null") {
                        Instantiate(money.itemPotion3Destruct, money.slotsPotion.slots[2].transform, false);
                        money.slot3_type = "destruction_potion";
                    }
                    money.slot3_type = "destruction_potion";
                    money.SetPiece(-500, money.itemPiece, money.slotsPiece);
                } else {
                    if(settings.language == "fr") {
                        Avertissment("Tu n'as pas assez d'argent!");
                    } else if(settings.language == "en") {
                        Avertissment("You don't have enough money!");
                    }
                }
            } else {    
                if(settings.language == "fr") {
                    Avertissment("Le slot 3 est plein!");
                } else if(settings.language == "en") {
                    Avertissment("Slot 3 is full!");
                }
            }
        } else {
            if(settings.language == "fr") {
                Avertissment("Le slot 3 est deja pris!");
            } else if(settings.language == "en") {
                Avertissment("Slot 3 is already taken!");
            }
        }
    }

    public void AttackCard() {
        if (money.amount_rubis >= 500) {
                chemin = Application.streamingAssetsPath + "/ActifPassif.json";
                jsonString = File.ReadAllText(chemin);
                JSONActifPassif choixPouvoir = JsonUtility.FromJson<JSONActifPassif>(jsonString);
                choixPouvoir.passif = "berserker";
                jsonString = JsonUtility.ToJson(choixPouvoir);
                File.WriteAllText(chemin, jsonString);
                money.SetRubis(-500, money.itemRubis, money.slotsPiece);
        } else {
            chemin = Application.streamingAssetsPath + "/Settings.json";
            jsonString = File.ReadAllText(chemin);
            SettingsGame settings = JsonUtility.FromJson<SettingsGame>(jsonString);
            if(settings.language == "fr") {
                Avertissment("Tu n'as pas assez de rubis!");
            } else if(settings.language == "en") {
                Avertissment("You don't have enough ruby!");
            }
        }
    }

    public void DefenseCard() {
        if (money.amount_rubis >= 500) {
                chemin = Application.streamingAssetsPath + "/ActifPassif.json";
                jsonString = File.ReadAllText(chemin);
                JSONActifPassif choixPouvoir = JsonUtility.FromJson<JSONActifPassif>(jsonString);
                choixPouvoir.passif = "rempart";
                jsonString = JsonUtility.ToJson(choixPouvoir);
                File.WriteAllText(chemin, jsonString);
                money.SetRubis(-500, money.itemRubis, money.slotsPiece);
        } else {
            chemin = Application.streamingAssetsPath + "/Settings.json";
            jsonString = File.ReadAllText(chemin);
            SettingsGame settings = JsonUtility.FromJson<SettingsGame>(jsonString);
            if(settings.language == "fr") {
                Avertissment("Tu n'as pas assez de rubis!");
            } else if(settings.language == "en") {
                Avertissment("You don't have enough ruby!");
            }
        }
    }

    public void RenvoieCard() {
        if (money.amount_rubis >= 500) {
                chemin = Application.streamingAssetsPath + "/ActifPassif.json";
                jsonString = File.ReadAllText(chemin);
                JSONActifPassif choixPouvoir = JsonUtility.FromJson<JSONActifPassif>(jsonString);
                choixPouvoir.passif = "rewind";
                jsonString = JsonUtility.ToJson(choixPouvoir);
                File.WriteAllText(chemin, jsonString);
                money.SetRubis(-500, money.itemRubis, money.slotsPiece);
        } else {
            chemin = Application.streamingAssetsPath + "/Settings.json";
            jsonString = File.ReadAllText(chemin);
            SettingsGame settings = JsonUtility.FromJson<SettingsGame>(jsonString);
            if(settings.language == "fr") {
                Avertissment("Tu n'as pas assez de rubis!");
            } else if(settings.language == "en") {
                Avertissment("You don't have enough ruby!");
            }
        }
    }

    public void TourbilolCard() {
        if (money.amount_rubis >= 500) {
                chemin = Application.streamingAssetsPath + "/ActifPassif.json";
                jsonString = File.ReadAllText(chemin);
                JSONActifPassif choixPouvoir = JsonUtility.FromJson<JSONActifPassif>(jsonString);
                choixPouvoir.actif = "tourbilol";
                jsonString = JsonUtility.ToJson(choixPouvoir);
                File.WriteAllText(chemin, jsonString);
                money.SetRubis(-500, money.itemRubis, money.slotsPiece);
        } else {
            chemin = Application.streamingAssetsPath + "/Settings.json";
            jsonString = File.ReadAllText(chemin);
            SettingsGame settings = JsonUtility.FromJson<SettingsGame>(jsonString);
            if(settings.language == "fr") {
                Avertissment("Tu n'as pas assez de rubis!");
            } else if(settings.language == "en") {
                Avertissment("You don't have enough ruby!");
            }
        }
    }

    //*** Fonction appeler X secondes après grâce à Invoke ***//
    private void DesactivateAvertissment() {
        avertissement.SetActive(false);
    }

    //*** Fonction appeler afin d'avertir que la hotbar est pleine ***//
    private void Avertissment(string description) {
        var texts = avertissement.GetComponent<Text>();
        texts.text = description; // LANGUAGE
        avertissement.SetActive(true);
        Invoke("DesactivateAvertissment", 5.0f);
    }
}
