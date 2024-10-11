using System;
using System.IO;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LoadSave : MonoBehaviour
{
    [SerializeField] private GameObject panel;
    public Animator anim;

    private void Awake()
    {
        string destination = Application.persistentDataPath + "/game.json";
        if (File.Exists(destination)) {

            panel.SetActive(true);   
        }
    }

    public void Load()
    {
        string destination = Application.persistentDataPath + "/game.json";
        if (File.Exists(destination))
        {
            string saveString = File.ReadAllText(destination);
            DataToSave data = JsonUtility.FromJson<DataToSave>(saveString);
            
            GameInfo.rangedDamage = data.rangeDamage;
            GameInfo.closedDamage = data.closeDamage;
            GameInfo.shootDelay = data.shootDelay;
            GameInfo.maxHealthPlayer = data.maxHealthPlayer;
            GunController.timeBetweenShots = data.shootDelay;
            GameInfo.levelBoss = data.levelBoss;

            GameInfo.activeSkill = data.activeSkill;
            GameInfo.activeLevel = data.activeLevel;
            
            GameInfo.passiveSkill = data.passiveSkill;
            GameInfo.passiveLevel = data.passiveLevel;

            if (data.levelBoss == 0)
            {   
                anim.SetBool("Fade", true);
                Invoke("LoadVillage1", 1.0f);
            }
            else if (data.levelBoss == 1)
            {
                anim.SetBool("Fade", true);
                Invoke("LoadVillage2", 1.0f);
            }
            else if (data.levelBoss == 2)
            {
                anim.SetBool("Fade", true);
                Invoke("LoadVillage4", 1.0f);
            }
            else if (data.levelBoss == 3)
            {
                anim.SetBool("Fade", true);
                Invoke("LoadVillage4", 1.0f);
            }
            else if (data.levelBoss == 4)
            {
                anim.SetBool("Fade", true);
                Invoke("LoadVillage1", 1.0f);
            }
        }
    }

    public void LoadVillage1() {
        SceneManager.LoadScene("Village");
    }

    public void LoadVillage2() {
        SceneManager.LoadScene("Village2");
    }

    public void LoadVillage4() {
        SceneManager.LoadScene("Village4");
    }


}
