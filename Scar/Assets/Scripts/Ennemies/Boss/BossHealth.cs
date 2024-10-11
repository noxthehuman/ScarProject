using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHealth : MonoBehaviour
{
    [SerializeField] public Image healthFill;
    public int maxHealth;
    public float currentHealth;
    private int currentBoss;

    private void Start()
    {
        if (gameObject.name == "Lymule(Clone)")
        {
            BossBehaviour.isAlive = 1;
            currentBoss = 1;
        }
        else if (gameObject.name == "Korinh(Clone)")
        {
            KorinhBehaviour.isAlive = 1;
            currentBoss = 2;
        }
        else if (gameObject.name == "Bobb(Clone)")
        {
            BobbBehaviour.isAlive = 1;
            currentBoss = 3;
        }
        else if (gameObject.name == "Flue(Clone)")
        {
            FlueBehaviour.isAlive = 1;
            currentBoss = 4;
        }
        
    }
    void Update()
    {
        healthFill.fillAmount = currentHealth / maxHealth;

        if(currentHealth <= 0)
        {
            if(currentBoss == 1)
            {
                BossBehaviour.isAlive = 0;
                GameInfo.levelBoss = 1;
                SpawnEnemy.nbMonster -= 1;
                new WaitForSeconds(1);
            } 
            else if(currentBoss == 2)
            {
                KorinhBehaviour.isAlive = 0;
                GameInfo.levelBoss = 2;
                SpawnEnemy.nbMonster -= 1;
                new WaitForSeconds(1);
            }

            else if(currentBoss == 3)
            {
                BobbBehaviour.isAlive = 0;
                GameInfo.levelBoss = 3;
                SpawnEnemy.nbMonster -= 1;
                new WaitForSeconds(1);
            }
            
            
            else if(currentBoss == 4)
            {
                FlueBehaviour.isAlive = 0;
                GameInfo.levelBoss = 4;
                SpawnEnemy.nbMonster -= 1;
                new WaitForSeconds(1);
            }
            
            Destroy(gameObject);

        }
    }
}
