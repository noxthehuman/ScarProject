using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassiveSkills : MonoBehaviour
{
    private bool berserker1;
    private bool berserker2;
    
    [SerializeField] private BulletController bullet;

    private bool rempart1;
    private bool rempart2;
    
    private void Start()
    {
        berserker1 = false;
        berserker2 = false;
        rempart1 = false;
        rempart2 = false;
    }

    private void Update()
    {
        switch (GameInfo.passiveSkill)
        {
            case "berserker":
                Berserker();
                break;
            case "rempart":
                Rempart();
                break;
        }
    }

    private void Rempart()
    {
        switch (GameInfo.passiveLevel)
        {
            case 1:
                if (HealthPlayer.currentHealth <= HealthPlayer.maxHealth * 0.15 && rempart2 == false)
                {
                    EnemyDamages.damageMultiplication = 0.7f;
                    rempart2 = true;
                }
                else if(HealthPlayer.currentHealth <= HealthPlayer.maxHealth * 0.5 && rempart1 == false)
                {
                    EnemyDamages.damageMultiplication = 0.9f;
                    rempart1 = true;
                }
                break;
            case 2:
                if (HealthPlayer.currentHealth <= HealthPlayer.maxHealth * 0.15 && rempart2 == false)
                {
                    EnemyDamages.damageMultiplication = 0.5f;
                    rempart2 = true;
                }
                else if(HealthPlayer.currentHealth <= HealthPlayer.maxHealth * 0.5 && rempart1 == false)
                {
                    EnemyDamages.damageMultiplication = 0.7f;
                    rempart1 = true;
                }
                break;
            case 3:
                if (HealthPlayer.currentHealth <= HealthPlayer.maxHealth * 0.15 && rempart2 == false)
                {
                    EnemyDamages.damageMultiplication = 0.25f;
                    rempart2 = true;
                }
                else if(HealthPlayer.currentHealth <= HealthPlayer.maxHealth * 0.5 && rempart1 == false)
                {
                    EnemyDamages.damageMultiplication = 0.5f;
                    rempart1 = true;
                }
                break;
        }
    }
    
    private void Berserker()
    {
        switch (GameInfo.passiveLevel)
        {
            case 1:
                if (HealthPlayer.currentHealth <= HealthPlayer.maxHealth * 0.1 && berserker2 == false)
                {
                    GameInfo.rangedDamage *= 1.2f;
                    berserker2 = true;
                }
                else if (HealthPlayer.currentHealth <= HealthPlayer.maxHealth * 0.5 && berserker1 == false)
                {
                    GameInfo.rangedDamage *= 1.1f;
                    berserker1 = true;
                }
                break;
            case 2:
                if (HealthPlayer.currentHealth <= HealthPlayer.maxHealth * 0.1 && berserker2 == false)
                {
                    GameInfo.rangedDamage *= 1.5f;
                    berserker2 = true;
                }
                else if (HealthPlayer.currentHealth <= HealthPlayer.maxHealth * 0.5 && berserker1 == false)
                {
                    GameInfo.rangedDamage *= 1.3f;
                    berserker1 = true;
                }
                break;
            case 3:
                if (HealthPlayer.currentHealth <= HealthPlayer.maxHealth * 0.1 && berserker2 == false)
                {
                    GameInfo.rangedDamage *= 2;
                    berserker2 = true;
                }
                else if (HealthPlayer.currentHealth <= HealthPlayer.maxHealth * 0.5 && berserker1 == false)
                {
                    GameInfo.rangedDamage *= 1.5f;
                    berserker1 = true;
                }
                break;
        }
    }

    /* COMP2TENCE REWIND */
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("bulEnemy") && PlayerController.isDashing && GameInfo.passiveSkill == "rewind")
        {
            other.gameObject.transform.Rotate(Vector3.up, 180);
            var direction = other.gameObject.transform.rotation;
            var position = other.gameObject.transform.position;
            BulletController newBullet = Instantiate(bullet, position, direction);
            switch (GameInfo.passiveLevel)
            {
                case 1:
                    IzaakDamages.dmgMultiplier = 1.2f;
                    break;
                case 2:
                    IzaakDamages.dmgMultiplier = 1.3f;
                    break;
                case 3:
                    IzaakDamages.dmgMultiplier = 1.6f;
                    break;
            }
            Destroy(other.gameObject);

            
        }
    }
}
