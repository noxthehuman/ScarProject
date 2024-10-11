using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VictoryCondition : MonoBehaviour
{
    [SerializeField] private GameObject panel;

    private void Start()
    {
        BossBehaviour.isAlive = 1;
        KorinhBehaviour.isAlive = 1;
        BobbBehaviour.isAlive = 1;
        FlueBehaviour.isAlive = 1;
    }

    void Update()
    {
        if (SceneManager.GetActiveScene().name == "BossRush")
        {
            if (BossBehaviour.isAlive == 0 && KorinhBehaviour.isAlive == 0 && BobbBehaviour.isAlive == 0 && FlueBehaviour.isAlive == 0 && SpawnEnemy.nbMonster <= 0)
            {
                panel.SetActive(true);
                Time.timeScale = 0f;
            }   
        }
        else
        {
            if (BossBehaviour.isAlive == 0 && SpawnEnemy.nbMonster <= 0 || KorinhBehaviour.isAlive == 0 && SpawnEnemy.nbMonster <= 0 || BobbBehaviour.isAlive == 0 && SpawnEnemy.nbMonster <= 0 || FlueBehaviour.isAlive == 0 && SpawnEnemy.nbMonster <= 0)
            {
                panel.SetActive(true);
                Time.timeScale = 0f;
            }   
        }
    }
}
