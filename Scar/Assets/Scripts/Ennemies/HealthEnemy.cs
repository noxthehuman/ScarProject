using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HealthEnemy : MonoBehaviour
{
    [SerializeField] public Image healthFill;
    public float maxHealth;
    public float currentHealth;
    private float degatsBullet = GameInfo.rangedDamage;
    private float degatWeapon = 50;

    [SerializeField] private GameObject coin;
    [SerializeField] private GameObject rubis;
    [SerializeField] private GameObject health_potion;
    [SerializeField] private GameObject mana_potion;
    [SerializeField] private GameObject damage_potion;
    [SerializeField] private GameObject shield_potion;
    [SerializeField] private GameObject destruct_potion;
    public static float percent_health_potion;
    public static float percent_mana_potion;
    public static float percent_damage_potion;
    public static float percent_shield_potion;
    public static float percent_destruct_potion;
    public static float percent_coin;
    public static float percent_rubis;


    private void Start()
    {
        if (GameObject.FindGameObjectWithTag("Attaque"))
        {
            degatsBullet = degatsBullet * 110 / 100;
        }

        //if (GameObject.FindGameObjectWithTag("Attaque2"))
        //{
            //degats = degats * 120 / 100;
        //}
        percent_health_potion = 0.73f;
        percent_mana_potion = 0.73f;
        percent_damage_potion = 0.73f;
        percent_shield_potion = 0.73f;
        percent_destruct_potion = 0.73f;
        percent_coin = 0.5f;
        percent_rubis = 0.5f;
    }

    void Update()
    {
        healthFill.fillAmount = currentHealth / maxHealth;

        if(currentHealth <= 0)
        {
            if (maxHealth > 200)
            {
                PlayerController.score += 30;
            }
            else
            {
                PlayerController.score += 10;
            }

            DropItem(health_potion, percent_health_potion);
            DropItem(mana_potion, percent_mana_potion);
            DropItem(damage_potion, percent_damage_potion);
            DropItem(shield_potion, percent_shield_potion);
            DropItem(destruct_potion, percent_destruct_potion);
            DropItem(coin, percent_coin);
            DropItem(rubis, percent_rubis);

            if(SceneManager.GetActiveScene().name != "DonjonEditMap") { 
                SpawnEnemy.nbMonster -= 1;
            } else if(SceneManager.GetActiveScene().name == "DonjonEditMap") {
                SpawnEnemyEditMap.nbMonster -= 1;
            }
            new WaitForSeconds(0.1f);
            Destroy(gameObject);
        }
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("bulBasic"))
        {
            currentHealth -= degatsBullet;
            PlayerController.numberDamagesDealt += degatsBullet;
            Destroy(collision.gameObject);
        }
    }

    //*** Permet de drop un item en fonction d'un pourcentage donné : Random.value donne un nombre entre 0.0 et 1.0 ***//
    private void DropItem(GameObject items, float percent) {
        transform.position = new Vector3(transform.position.x + Random.Range(-2, 2), transform.position.y + 2, transform.position.z + Random.Range(-2, 2)); // drop dans un diametre de 4m autour de l'ennemi
        if(Random.value > percent) { //*** Exemple: si random > 0.7, 30% de chance ***//
            Instantiate(items, transform.position, Quaternion.Euler (90f, Random.Range(-45f, 45f), 0f));
        }
    }
}
