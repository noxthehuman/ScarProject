using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class InventaireExterne : MonoBehaviour
{   
    public GameObject loading;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Save();
            StartCoroutine(Rotate());
        }
    }

    /*        SAUVEGARDE DES INFORMATIONS DU JOUEUR        */
    private void Save()
    {
        string destination = Application.persistentDataPath + "/game.json";
        DataToSave dataToSave = new DataToSave
        {
            shootDelay = GunController.timeBetweenShots,
            maxHealthPlayer = HealthPlayer.maxHealth,
            rangeDamage = GameInfo.rangedDamage,
            closeDamage = GameInfo.closedDamage,
            levelBoss = GameInfo.levelBoss,
            activeSkill = GameInfo.activeSkill,
            activeLevel = GameInfo.activeLevel,
            passiveSkill = GameInfo.passiveSkill,
            passiveLevel = GameInfo.passiveLevel
        };
        string json = JsonUtility.ToJson(dataToSave);
        File.WriteAllText(destination, json);
    }

    IEnumerator Rotate() {
        loading.SetActive(true);
        for(int i = 0; i < 25; i++) {
            loading.transform.Rotate(0.0f, 0.0f, 5.0f, Space.Self);
            yield return new WaitForSeconds(0.1f);
        }
        loading.SetActive(false);
    }
}
