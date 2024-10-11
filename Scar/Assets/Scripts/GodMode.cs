using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GodMode : MonoBehaviour
{
    [SerializeField] private HealthPlayer playerHealth;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            HealthPlayer.currentHealth = 9999999999;
            GunController.timeBetweenShots = 0;
        }
        if (Input.GetKeyDown(KeyCode.N))
        {
            HealthPlayer.currentHealth = 200;
            GunController.timeBetweenShots = 0.1f;
        }
    }
}
