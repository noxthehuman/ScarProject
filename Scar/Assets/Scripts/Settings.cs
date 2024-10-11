using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using TMPro;

public class Settings : MonoBehaviour {

    string chemin, jsonString;
    public AudioSource audioSrc;
    public Slider slider;
    public Text boutonJouer;
    public Text boutonEditMap;
    public Text boutonOptions;
    public Text rushBoss;
    public Text boutonQuitter;
    [SerializeField] TextMeshProUGUI titleOptions;
    [SerializeField] TextMeshProUGUI titleLanguage;
    [SerializeField] TextMeshProUGUI loadSaveTxt;
    [SerializeField] TextMeshProUGUI loadSaveYes;
    [SerializeField] TextMeshProUGUI loadSaveNo;
    [SerializeField] TextMeshProUGUI editeurDeMap;
    [SerializeField] TextMeshProUGUI description1;
    [SerializeField] TextMeshProUGUI nouvellePartie1;
    [SerializeField] TextMeshProUGUI chargerPartie;
    [SerializeField] TextMeshProUGUI nombreDeSalle;
    [SerializeField] TextMeshProUGUI nouvellePartie2;
    [SerializeField] TextMeshProUGUI description2;
    [SerializeField] TextMeshProUGUI play;
    [SerializeField] TextMeshProUGUI[] salle;
    [SerializeField] TextMeshProUGUI[] habillage;
    [SerializeField] TextMeshProUGUI[] ennemi;
    [SerializeField] TextMeshProUGUI[] typeSalle;

    void Start() {
        chemin = Application.streamingAssetsPath + "/Settings.json";
        jsonString = File.ReadAllText(chemin);
        SettingsGame settings = JsonUtility.FromJson<SettingsGame>(jsonString);
        audioSrc.volume = settings.volume;
        slider.value = settings.volume;
        if(settings.language == "fr") {
            ENToFR();
        } else if(settings.language == "en") {
            FRToEN();
        }
    }

    public void FRToEN() {
        if(boutonJouer != null) boutonJouer.text = "PLAY";
        if(boutonEditMap != null) boutonEditMap.text = "MAP EDITOR";
        if(boutonOptions != null) boutonOptions.text = "SETTINGS";
        if(rushBoss != null) rushBoss.text = "BOSS RUSH";
        if(boutonQuitter != null) boutonQuitter.text = "QUIT";
        if(titleOptions != null) titleOptions.text = "SETTINGS";
        if(titleLanguage != null) titleLanguage.text = "LANGUAGE";
        if(loadSaveTxt != null) loadSaveTxt.text = "A backup is available! Do you want to use it ?";
        if(loadSaveYes != null) loadSaveYes.text = "YES";
        if(loadSaveNo != null) loadSaveNo.text = "NO";
        if(editeurDeMap != null) editeurDeMap.text = "MAP EDITOR";
        if(description1 != null) description1.text = "CREATE YOUR OWN DUNGEON AND PLAY IT!";
        if(nouvellePartie1 != null) nouvellePartie1.text = "New dungeon";
        if(chargerPartie != null) chargerPartie.text = "Load a dungeon";
        if(nombreDeSalle != null) nombreDeSalle.text = "Number of rooms";
        if(nouvellePartie2 != null) nouvellePartie2.text = "New dungeon";
        if(description2 != null) description2.text = "Click on a room to configure it!";
        if(play != null) play.text = "PLAY";
        for(int i = 0; i < 15; i++) {
            if(salle[i] != null) salle[i].text = "Room " + (i+1);
            if(habillage[i] != null) habillage[i].text = "Dress :";
            if(ennemi[i] != null) ennemi[i].text = "Enemy type :";
            if(typeSalle[i] != null) typeSalle[i].text = "Room type :";
        }
        chemin = Application.streamingAssetsPath + "/Settings.json";
        jsonString = File.ReadAllText(chemin);
        SettingsGame settings = JsonUtility.FromJson<SettingsGame>(jsonString);
        settings.language = "en";
        jsonString = JsonUtility.ToJson(settings);
        File.WriteAllText(chemin, jsonString);
    }

    public void ENToFR() {
        if(boutonJouer != null) boutonJouer.text = "JOUER";
        if(boutonEditMap != null) boutonEditMap.text = "EDITEUR DE MAP";
        if(boutonOptions != null) boutonOptions.text = "OPTIONS";
        if(rushBoss != null) rushBoss.text = "RUSH BOSS";
        if(boutonQuitter != null) boutonQuitter.text = "QUITTER";
        if(titleOptions != null) titleOptions.text = "OPTIONS";
        if(titleLanguage != null) titleLanguage.text = "LANGUE";
        if(loadSaveTxt != null) loadSaveTxt.text = "Une sauvegarde est disponible! Voulez-vous l'utiliser ?";
        if(loadSaveYes != null) loadSaveYes.text = "OUI";
        if(loadSaveNo != null) loadSaveNo.text = "NON";
        if(editeurDeMap != null) editeurDeMap.text = "EDITEUR DE MAP";
        if(description1 != null) description1.text = "CREER TON PROPRE DONJON ET JOUE-LE!";
        if(nouvellePartie1 != null) nouvellePartie1.text = "Nouvelle partie";
        if(chargerPartie != null) chargerPartie.text = "Charger une partie";
        if(nombreDeSalle != null) nombreDeSalle.text = "Nombre de salles";
        if(nouvellePartie2 != null) nouvellePartie2.text = "Nouvelle partie";
        if(description2 != null) description2.text = "Clique sur une salle pour la configurer !";
        if(play != null) play.text = "JOUER";
        for(int i = 0; i < 15; i++) {
            if(salle[i] != null) salle[i].text = "Salle " + (i+1);
            if(habillage[i] != null) habillage[i].text = "Habillage :";
            if(ennemi[i] != null) ennemi[i].text = "Type d'ennemi :";
            if(typeSalle[i] != null) typeSalle[i].text = "Type de salle :";
        }
        chemin = Application.streamingAssetsPath + "/Settings.json";
        jsonString = File.ReadAllText(chemin);
        SettingsGame settings = JsonUtility.FromJson<SettingsGame>(jsonString);
        settings.language = "fr";
        jsonString = JsonUtility.ToJson(settings);
        File.WriteAllText(chemin, jsonString);
    }
}

public class SettingsGame {
    public float volume;
    public string language;
}