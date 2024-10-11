using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Consommables : MonoBehaviour
{
    private HealthPlayer player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<HealthPlayer>();    
    }
    
    public void Potion()
    {
        if (gameObject.CompareTag("Potion1"))
        {
            HealthPlayer.currentHealth += 15; 
            Destroy(gameObject);
        }

        //if(gameObject.CompareTag("Potion2"))
        {
           // player.currentHealth += 25;
           //Destroy(gameObject);
        }

    }
  
}
