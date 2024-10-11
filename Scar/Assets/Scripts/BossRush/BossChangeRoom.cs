using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class BossChangeRoom : MonoBehaviour
{
    public GameObject nextRoom;
    public GameObject spawnPoint;
    private bool hasSpawn;
    private bool endFirstPart;
    


    private void Start()
    {
        hasSpawn = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && hasSpawn == false)
        {
            Instantiate(nextRoom, spawnPoint.transform.position, spawnPoint.transform.rotation);
            PlayerController.cpt++;
            hasSpawn = true;
            endFirstPart = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject, 1);
        }
    }
}
