using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class Statistiques : MonoBehaviour
{
    string chemin, jsonString;
    [SerializeField] private Text nbBulletText;
    [SerializeField] private Text nbDamageReceivedText;
    [SerializeField] private Text nbDamageDealtText;
    [SerializeField] private Text scoreText;
    
    void Start() {
        chemin = Application.streamingAssetsPath + "/Settings.json";
        jsonString = File.ReadAllText(chemin);
        SettingsGame settings = JsonUtility.FromJson<SettingsGame>(jsonString);
        if(settings.language == "fr") {
            nbBulletText.text = "Nombre de bullet : " + PlayerController.numberBullets.ToString();
            nbDamageReceivedText.text = "Degats reçus : " + PlayerController.numberDamagesReceived.ToString();
            nbDamageDealtText.text = "Degats Effectues : " + PlayerController.numberDamagesDealt.ToString();
            scoreText.text ="Score : " +  PlayerController.score.ToString();
        } else if(settings.language == "en") {
            nbBulletText.text = "Number of bullet : " + PlayerController.numberBullets.ToString();
            nbDamageReceivedText.text = "Damage received : " + PlayerController.numberDamagesReceived.ToString();
            nbDamageDealtText.text = "Damage done : " + PlayerController.numberDamagesDealt.ToString();
            scoreText.text ="Score : " +  PlayerController.score.ToString();
        }
    }
}
