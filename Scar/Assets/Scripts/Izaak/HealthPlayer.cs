using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthPlayer : MonoBehaviour
{
    [SerializeField]
    public Image healthFill;
    [SerializeField] TextMeshProUGUI statHealth;
    public static float maxHealth;
    public static float currentHealth;
    public float degatsBalle = 10;
    public float degatsCol = 5;

    public GameObject death;

    void Start()
    {
        maxHealth = GameInfo.maxHealthPlayer;
        currentHealth = GameInfo.maxHealthPlayer;
        
        Time.timeScale = 1f;

        if (GameObject.FindGameObjectWithTag("Shield"))
        {
            degatsBalle = degatsBalle * 90/100;
            degatsCol = degatsCol * 90 / 100;
        }

        if (GameObject.FindGameObjectWithTag("Shield2"))
        {
            degatsBalle = degatsBalle * 80 / 100;
            degatsCol = degatsCol * 80 / 100;
        }
    }
    void Update()
    {
        healthFill.fillAmount = currentHealth / maxHealth;
        statHealth.text = currentHealth + "/200";

        if (currentHealth <= 0)
        {
            Time.timeScale = 0f;
            death.SetActive(true);
        }

        if (gameObject.transform.position.y <= -10)
        {
            Time.timeScale = 0f;
            death.SetActive(true);
        }
    }
}
