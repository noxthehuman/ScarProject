using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using TMPro;

public class SettingsPanel : MonoBehaviour
{
    string chemin, jsonString;
    [SerializeField] TextMeshProUGUI pauseTitle;
    [SerializeField] TextMeshProUGUI reprendrePause;
    [SerializeField] TextMeshProUGUI menuPrincipalPause;
    [SerializeField] TextMeshProUGUI victoireTitle;
    [SerializeField] TextMeshProUGUI partagerVictoire;
    [SerializeField] TextMeshProUGUI statsVictoire;
    [SerializeField] TextMeshProUGUI menuPrincipalVictoire;
    [SerializeField] TextMeshProUGUI defaiteTitle;
    [SerializeField] TextMeshProUGUI partagerDefaite;
    [SerializeField] TextMeshProUGUI menuPrincipalDefaite;
    public Text potionUtiliser;
    public Text potionUtiliserOmbre;
    public Text avertissement;

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
        if(pauseTitle != null) pauseTitle.text = "Pause";
        if(reprendrePause != null) reprendrePause.text = "Back";
        if(menuPrincipalPause != null) menuPrincipalPause.text = "Main Menu";
        if(victoireTitle != null) victoireTitle.text = "Victory";
        if(partagerVictoire != null) partagerVictoire.text = "Share";
        if(statsVictoire != null) statsVictoire.text = "Statistics";
        if(menuPrincipalVictoire != null) menuPrincipalVictoire.text = "Main Menu";
        if(defaiteTitle != null) defaiteTitle.text = "Defeat";
        if(partagerDefaite != null) partagerDefaite.text = "Share";
        if(menuPrincipalDefaite != null) menuPrincipalDefaite.text = "Main Menu";
        if(potionUtiliser != null) potionUtiliser.text = "POTION USED";
        if(potionUtiliserOmbre != null) potionUtiliserOmbre.text = "POTION USED";
        if(avertissement != null) avertissement.text = "THE HOTBAR SLOT IS FULL !";
        if(SceneManager.GetActiveScene().name == "Main") {
            if(menuPrincipalPause != null) menuPrincipalPause.text = "Lakeham";
            if(menuPrincipalVictoire != null) menuPrincipalVictoire.text = "Lakeham";
            if(menuPrincipalDefaite != null) menuPrincipalDefaite.text = "Lakeham";
        } else if(SceneManager.GetActiveScene().name == "Donjon2") {
            if(menuPrincipalPause != null) menuPrincipalPause.text = "Eastborn";
            if(menuPrincipalVictoire != null) menuPrincipalVictoire.text = "Eastborn";
            if(menuPrincipalDefaite != null) menuPrincipalDefaite.text = "Eastborn";
        } else if(SceneManager.GetActiveScene().name == "Donjon4") {
            if(menuPrincipalPause != null) menuPrincipalPause.text = "Grimsban";
            if(menuPrincipalVictoire != null) menuPrincipalVictoire.text = "Grimsban";
            if(menuPrincipalDefaite != null) menuPrincipalDefaite.text = "Grimsban";
        }
        chemin = Application.streamingAssetsPath + "/Settings.json";
        jsonString = File.ReadAllText(chemin);
        SettingsGame settings = JsonUtility.FromJson<SettingsGame>(jsonString);
        settings.language = "en";
        jsonString = JsonUtility.ToJson(settings);
        File.WriteAllText(chemin, jsonString);
    }

    public void ENToFRPanel() {
        if(pauseTitle != null) pauseTitle.text = "Pause";
        if(reprendrePause != null) reprendrePause.text = "Reprendre";
        if(menuPrincipalPause != null) menuPrincipalPause.text = "Menu Principal";
        if(victoireTitle != null) victoireTitle.text = "Victoire";
        if(partagerVictoire != null) partagerVictoire.text = "Partager";
        if(statsVictoire != null) statsVictoire.text = "Statistiques";
        if(menuPrincipalVictoire != null) menuPrincipalVictoire.text = "Menu Principal";
        if(defaiteTitle != null) defaiteTitle.text = "Defaite";
        if(partagerDefaite != null) partagerDefaite.text = "Partager";
        if(menuPrincipalDefaite != null) menuPrincipalDefaite.text = "Menu Principal";
        if(potionUtiliser != null) potionUtiliser.text = "POTION UTILISE";
        if(potionUtiliserOmbre != null) potionUtiliserOmbre.text = "POTION UTILISE";
        if(avertissement != null) avertissement.text = "LE SLOT DE LA HOTBAR EST PLEIN !";
        if(SceneManager.GetActiveScene().name == "Main") {
            if(menuPrincipalPause != null) menuPrincipalPause.text = "Lakeham";
            if(menuPrincipalVictoire != null) menuPrincipalVictoire.text = "Lakeham";
            if(menuPrincipalDefaite != null) menuPrincipalDefaite.text = "Lakeham";
        } else if(SceneManager.GetActiveScene().name == "Donjon2") {
            if(menuPrincipalPause != null) menuPrincipalPause.text = "Eastborn";
            if(menuPrincipalVictoire != null) menuPrincipalVictoire.text = "Eastborn";
            if(menuPrincipalDefaite != null) menuPrincipalDefaite.text = "Eastborn";
        } else if(SceneManager.GetActiveScene().name == "Donjon4") {
            if(menuPrincipalPause != null) menuPrincipalPause.text = "Grimsban";
            if(menuPrincipalVictoire != null) menuPrincipalVictoire.text = "Grimsban";
            if(menuPrincipalDefaite != null) menuPrincipalDefaite.text = "Grimsban";
        }
        chemin = Application.streamingAssetsPath + "/Settings.json";
        jsonString = File.ReadAllText(chemin);
        SettingsGame settings = JsonUtility.FromJson<SettingsGame>(jsonString);
        settings.language = "fr";
        jsonString = JsonUtility.ToJson(settings);
        File.WriteAllText(chemin, jsonString);
    }
}
