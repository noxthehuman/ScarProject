using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamages : MonoBehaviour
{
    private HealthPlayer player;
    [SerializeField] private float degats;
    public static float damageMultiplication = 1f;

    private void Start()
    {
        player = FindObjectOfType<HealthPlayer>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            HealthPlayer.currentHealth -= degats * damageMultiplication;
            PlayerController.numberDamagesReceived += degats;
            PlayerController.score -= 1;
        }
    }
}
