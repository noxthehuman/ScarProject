using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class ChoixPassifActif : MonoBehaviour
{
    [SerializeField] private GameObject inventaire;
    private string chemin, jsonString;
    public string type;
    

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P)) {
            if(inventaire.activeSelf) {
                inventaire.SetActive(false);
            } else if(!inventaire.activeSelf) {
                inventaire.SetActive(true);
            }
        }
    }

    public void ChooseActivePassive(string pouvoir) {
        chemin = Application.streamingAssetsPath + "/ActifPassif.json";
        jsonString = File.ReadAllText(chemin);
        JSONActifPassif choixPouvoir = JsonUtility.FromJson<JSONActifPassif>(jsonString);
        if(type == "actif") {
            choixPouvoir.actif = pouvoir;
        } else if(type == "passif") {
            choixPouvoir.passif = pouvoir;
        }
        jsonString = JsonUtility.ToJson(choixPouvoir);
        File.WriteAllText(chemin, jsonString);
    }
}

public class JSONActifPassif {
    public string actif = "null";
    public string passif = "null";
}
