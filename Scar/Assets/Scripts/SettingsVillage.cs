using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using TMPro;

public class SettingsVillage : MonoBehaviour
{
    string chemin, jsonString;
    [SerializeField] TextMeshProUGUI titleConfDonjon;
    [SerializeField] TextMeshProUGUI yesConfDonjon;
    [SerializeField] TextMeshProUGUI noConfDonjon;
    [SerializeField] TextMeshProUGUI confirmVillage;
    public Text changementConso;
    public Text changementConsoOmbre;
    [SerializeField] TextMeshProUGUI reprendrePause;
    [SerializeField] TextMeshProUGUI menuPrincipalPause;

    void Start() {
        chemin = Application.streamingAssetsPath + "/Settings.json";
        jsonString = File.ReadAllText(chemin);
        SettingsGame settings = JsonUtility.FromJson<SettingsGame>(jsonString);
        if(settings.language == "fr") {
            ENToFRPanel();
        } else if(settings.language == "en") {
            FRToENPanel();
        }
    }

    public void FRToENPanel() {
        if(SceneManager.GetActiveScene().name == "Village") {
            if(titleConfDonjon != null) titleConfDonjon.text = "Dungeon 1 Gate";
        } else if(SceneManager.GetActiveScene().name == "Village2") {
            if(titleConfDonjon != null) titleConfDonjon.text = "Dungeon 2 Gate";
        } else if(SceneManager.GetActiveScene().name == "Village4") {
            if(titleConfDonjon != null) titleConfDonjon.text = "Dungeon 3 Gate";
        }
        if(yesConfDonjon != null) yesConfDonjon.text = "Go";
        if(noConfDonjon != null) noConfDonjon.text = "Not yet..";
        if(confirmVillage != null) confirmVillage.text = "Choose the village you want to go to";
        if(changementConso != null) changementConso.text = "POTION USED";
        if(changementConsoOmbre != null) changementConsoOmbre.text = "POTION USED";
        if(reprendrePause != null) reprendrePause.text = "Back";
        if(menuPrincipalPause != null) menuPrincipalPause.text = "Main Menu";
        chemin = Application.streamingAssetsPath + "/Settings.json";
        jsonString = File.ReadAllText(chemin);
        SettingsGame settings = JsonUtility.FromJson<SettingsGame>(jsonString);
        settings.language = "en";
        jsonString = JsonUtility.ToJson(settings);
        File.WriteAllText(chemin, jsonString);
    }

    public void ENToFRPanel() {
        if(SceneManager.GetActiveScene().name == "Village") {
            if(titleConfDonjon != null) titleConfDonjon.text = "Porte du Donjon 1";
        } else if(SceneManager.GetActiveScene().name == "Village2") {
            if(titleConfDonjon != null) titleConfDonjon.text = "Porte du Donjon 2";
        } else if(SceneManager.GetActiveScene().name == "Village4") {
            if(titleConfDonjon != null) titleConfDonjon.text = "Porte du Donjon 3";
        }
        if(yesConfDonjon != null) yesConfDonjon.text = "J'y vais";
        if(noConfDonjon != null) noConfDonjon.text = "Pas encore..";
        if(confirmVillage != null) confirmVillage.text = "Choisissez le village vers lequel vous souhaitez vous rendre";
        if(changementConso != null) changementConso.text = "POTION UTILISE";
        if(changementConsoOmbre != null) changementConsoOmbre.text = "POTION UTILISE";
        if(reprendrePause != null) reprendrePause.text = "Reprendre";
        if(menuPrincipalPause != null) menuPrincipalPause.text = "Menu Principal";
        chemin = Application.streamingAssetsPath + "/Settings.json";
        jsonString = File.ReadAllText(chemin);
        SettingsGame settings = JsonUtility.FromJson<SettingsGame>(jsonString);
        settings.language = "fr";
        jsonString = JsonUtility.ToJson(settings);
        File.WriteAllText(chemin, jsonString);
    }
}