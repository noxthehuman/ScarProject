using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventaire : MonoBehaviour
{
    [SerializeField] private GameObject inventaire;

    public Inventaire() {}

    // En appuyant sur "E", active/désactive l'inventaire.
    void Update() {
        if (Input.GetKeyDown(KeyCode.E)) {
            if(inventaire.activeSelf) {
                inventaire.SetActive(false);
            } else if(!inventaire.activeSelf) {
                inventaire.SetActive(true);
            }
        }
    }
}
