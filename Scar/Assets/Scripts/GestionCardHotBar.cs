using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
using System.IO;

public class GestionCardHotBar : MonoBehaviour
{
    [SerializeField]private GameObject tourbilol;
    [SerializeField]private GameObject attack;
    [SerializeField]private GameObject defense;
    [SerializeField]private GameObject renvoi;
    private string chemin, jsonString;


    void Update() {
        chemin = Application.streamingAssetsPath + "/ActifPassif.json";
        jsonString = File.ReadAllText(chemin);
        JSONActifPassif choixPouvoir = JsonUtility.FromJson<JSONActifPassif>(jsonString);
        if(choixPouvoir.passif == "berserker") {
            attack.SetActive(true);
            defense.SetActive(false);
            renvoi.SetActive(false);
        } else if(choixPouvoir.passif == "rempart") {
            attack.SetActive(false);
            defense.SetActive(true);
            renvoi.SetActive(false);
        } else if(choixPouvoir.passif == "rewind") {
            attack.SetActive(false);
            defense.SetActive(false);
            renvoi.SetActive(true);
        }

        if(choixPouvoir.actif == "tourbilol") {
            tourbilol.SetActive(true);
        }
    }
}
