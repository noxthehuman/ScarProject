using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloquerSortie : MonoBehaviour
{
    [SerializeField] private GameObject porte;
    [SerializeField] private GameObject[] sorties;
    [SerializeField] private GameObject entree;

    private Boolean mustBlockEntry;
    private Boolean mustBlockExit;

    private void Start()
    {
        mustBlockEntry = true;
        mustBlockExit = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (mustBlockEntry)
            {
                foreach (var spawn in sorties)
                {
                    Instantiate(porte, spawn.transform.position, spawn.transform.rotation);
                }
                mustBlockEntry = false;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (mustBlockExit)
        {
            if (other.CompareTag("Player"))
            {
                Instantiate(porte, entree.transform.position, entree.transform.rotation); 
            }
            mustBlockExit = false;
        }
    }
}
