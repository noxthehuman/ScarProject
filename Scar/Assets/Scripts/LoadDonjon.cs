using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class LoadDonjon : MonoBehaviour
{
    [SerializeField] private GameObject confirmation;
    [SerializeField] private AmountBoard amountBoard;
    private string chemin, jsonString;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            confirmation.SetActive(true);
        }
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            confirmation.SetActive(false);
        }
    }

    public void Confirme()
    {
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

        string currentScene = SceneManager.GetActiveScene().name;
        switch (currentScene)
        {
            case "Village":
                SceneManager.LoadScene("Main", LoadSceneMode.Single);
                break;
            case  "Village2":
                SceneManager.LoadScene("Donjon2", LoadSceneMode.Single);
                break;
            case "Village3":
                SceneManager.LoadScene("Donjon3", LoadSceneMode.Single);
                break;
            case "Village4":
                SceneManager.LoadScene("Donjon4", LoadSceneMode.Single);
                break;
        }
    }
}