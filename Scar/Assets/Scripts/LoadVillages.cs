using System;
using UnityEngine.SceneManagement;
using UnityEngine;
using System.IO;

public class LoadVillages : MonoBehaviour
{
    [SerializeField] private GameObject confirmation;
    [SerializeField] private GameObject Village2Button;
    [SerializeField] private GameObject Village3Button;
    [SerializeField] private GameObject Village4Button;
    [SerializeField] private AmountBoard amountBoard;
    private const string village1 = "Village";
    private const string village2 = "Village2";
    private const string village3 = "Village3";
    private const string village4 = "Village4";
    private string chemin, jsonString;


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            confirmation.SetActive(true);
            switch (GameInfo.levelBoss)
            {
                case 0:
                    break;
                case 1:
                    Village2Button.SetActive(true);
                    break;
                case 2:
                    Village2Button.SetActive(true);
                    //Village3Button.SetActive(true);
                    Village4Button.SetActive(true);
                    break;
                default:
                    Village2Button.SetActive(true);
                    //Village3Button.SetActive(true);
                    Village4Button.SetActive(true);
                    break;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            confirmation.SetActive(false);
        }
    }

    public void Village1()
    {
        ChargeInventory();
        SceneManager.LoadScene(village1, LoadSceneMode.Single);
    }
    public void Village2()
    {
        ChargeInventory();
        SceneManager.LoadScene(village2, LoadSceneMode.Single);
    }
    public void Village3()
    {
        ChargeInventory();
        SceneManager.LoadScene(village3, LoadSceneMode.Single);
    }
    public void Village4()
    {
        ChargeInventory();
        SceneManager.LoadScene(village4, LoadSceneMode.Single);
    }

    private void ChargeInventory() {
        chemin = Application.streamingAssetsPath + "/inventory.json";
        jsonString = File.ReadAllText(chemin);
        VariableForJSON inventaire = JsonUtility.FromJson<VariableForJSON>(jsonString);
        inventaire.amount_piece = amountBoard.amount_piece;
        inventaire.amount_rubis = amountBoard.amount_rubis;
        inventaire.amount_slot_1 = amountBoard.amount_slot_1;
        inventaire.amount_slot_2 = amountBoard.amount_slot_2;
        inventaire.amount_slot_3 = amountBoard.amount_slot_3;
        inventaire.amount_slot_card = amountBoard.amount_slot_card;
        inventaire.amount_slot_hotbar = amountBoard.amount_slot_hotbar;
        inventaire.hotbar_type = amountBoard.hotbar_type;
        inventaire.slot1_type = amountBoard.slot1_type;
        inventaire.slot2_type = amountBoard.slot2_type;
        inventaire.slot3_type = amountBoard.slot3_type;
        inventaire.slotcard_type = amountBoard.slotcard_type;
        jsonString = JsonUtility.ToJson(inventaire);
        File.WriteAllText(chemin, jsonString);
    } 
}
