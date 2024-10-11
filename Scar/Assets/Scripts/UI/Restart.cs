using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using UnityEditor;

public class Restart : MonoBehaviour
{
    public string scene;
    public string scene2;
    private string chemin, jsonString;
    public GameObject panel;
    private bool active;
    public GameObject panel2;
    [SerializeField] private AmountBoard amountBoard;
    public Animator retour;
    public Animator retour2;
    public Animator fadeAnimation;
    public GameObject confirmationDonjon;

    public void Awake() {
        if(SceneManager.GetActiveScene().name == "DonjonEditMap" || SceneManager.GetActiveScene().name == "BossRush") {
            amountBoard.amount_piece = 0;
            amountBoard.amount_rubis = 0;
            amountBoard.amount_slot_1 = 0;
            amountBoard.amount_slot_2 = 0;
            amountBoard.amount_slot_3 = 0;
            amountBoard.amount_slot_hotbar = 0;
            amountBoard.hotbar_type = "null";
            amountBoard.slot1_type = "null";
            amountBoard.slot2_type = "null";
            amountBoard.slot3_type = "null";
        }
    }

    public void Update() {
        if(panel.activeSelf == false) {
            Time.timeScale = 1f;
        }

        if(Input.GetKeyDown(KeyCode.Escape)) {
            panel.SetActive(true);
            Invoke("StopTime", 1.5f);
        }
    }

    private void StopTime() {
        Time.timeScale = 0f;
    }

    /* Fonction appelé lors du bouton menu principal dans les menus */
    public void Reload(int choice)
    {
        if(choice == 0)
        {   
            SceneManager.LoadScene(scene, LoadSceneMode.Single);
        }
        else if(choice == 1)
        {
            Time.timeScale = 1f;
            ResetJson();
            SceneManager.LoadScene(scene2, LoadSceneMode.Single);
        }
    }

    private void ResetJson() {
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

    /* Fonction appelé lors du bouton reprendre dans le menu pause */
    public void Reprendre() {
        Time.timeScale = 1f;
        retour.Play("Base Layer.BackToTop");
        Invoke("Reprendre2", 1.5f);
    }

    private void Reprendre2() {
        panel.SetActive(false);
    }

    /* Fonction appelé lors du bouton statistiques afin d'ouvrir le menu des statistiques et le fermer */
    public void OpenStats() {
        panel2.SetActive(true);
    }

    public void FermerStats() {
        panel2.SetActive(false);
    }

    /* Fonction appelé lors du bouton partager dans l'editeur de map */
    public void Partager() {
        Time.timeScale = 1f;
        #if UNITY_EDITOR
                EditorUtility.RevealInFinder(Application.streamingAssetsPath + "/EditeurMap.json");
        #endif
        Reload(0);
    }

    public void loadScene() {   
        Time.timeScale = 1f;
        if(SceneManager.GetActiveScene().name != "DonjonEditMap" || SceneManager.GetActiveScene().name != "BossRush") {
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
        SceneManager.LoadScene(scene, LoadSceneMode.Single);
    }

    public void Retour() {
        confirmationDonjon.SetActive(false);
    }

    public void Continue()
    {      
        if(SceneManager.GetActiveScene().name != "DonjonEditMap") {
            chemin = Application.streamingAssetsPath + "/inventory.json";
            jsonString = File.ReadAllText(chemin);
            VariableForJSON inventaire = JsonUtility.FromJson<VariableForJSON>(jsonString);
            inventaire.amount_piece = 0;
            inventaire.amount_rubis = 0;
            inventaire.amount_slot_1 = 0;
            inventaire.amount_slot_2 = 0;
            inventaire.amount_slot_3 = 0;
            inventaire.amount_slot_card = 0;
            inventaire.amount_slot_hotbar = 0;
            inventaire.hotbar_type = "";
            inventaire.slot1_type = "";
            inventaire.slot2_type = "";
            inventaire.slot3_type = "";
            inventaire.slotcard_type = "";
            jsonString = JsonUtility.ToJson(inventaire);
            File.WriteAllText(chemin, jsonString);
        }
        
        Time.timeScale = 1f;
        retour.Play("Base Layer.Retour");
        Invoke("Desactive", 1.5f);
    }

    public void Desactive() {
        panel.SetActive(false);
    }

    public void Quit()
    {
        Application.Quit();
    }
    
    public void Activate(int choice)
    {
        if (choice == 0)
        {
            if (active)
            {
                panel2.SetActive(false);
                active = false;
            }
            else
            {
                panel2.SetActive(true);
                active = true;
            }    
        }
        else if (choice == 1)
        {
            if (active)
            {
                panel.SetActive(false);
                active = false;
            }
            else
            {
                panel.SetActive(true);
                active = true;
            }
        }
        
    }
}
