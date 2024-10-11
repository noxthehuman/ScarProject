using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IzaakDamages : MonoBehaviour
{
    private HealthEnemy healthEnemy;
    private BossHealth bossHealth;
    private float degats;
    public static float dmgMultiplier = 1f;

    private void FixedUpdate()
    {
        degats = GameInfo.rangedDamage;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            healthEnemy = collision.gameObject.GetComponent<HealthEnemy>();
            var dmgTemp = degats * dmgMultiplier;
            healthEnemy.currentHealth -= dmgTemp;

        }
        else if (collision.gameObject.CompareTag("boss"))
        {
            bossHealth = collision.gameObject.GetComponent<BossHealth>();
            var dmgTemp = degats * dmgMultiplier;
            bossHealth.currentHealth -= dmgTemp;
        }
    }
}
