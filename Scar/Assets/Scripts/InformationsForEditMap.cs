using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InformationsForEditMap : MonoBehaviour
{
    public string typeSalle = "null";
    public string typeHabillage = "null";
    public string typeBoss = "null";
    public int numberPat = 0;
    public int numberPit = 0;
    public int numberPot = 0;
    public int numberPut = 0;
    [SerializeField]private GameObject salle1;
    [SerializeField]private GameObject salle2;
    [SerializeField]private GameObject salle3;
    [SerializeField]private GameObject habillage1;
    [SerializeField]private GameObject habillage2;
    [SerializeField]private GameObject habillage3;
    [SerializeField]private GameObject boss1;
    [SerializeField]private GameObject boss2;
    [SerializeField]private GameObject boss3;
    [SerializeField]private GameObject boss4;
    [SerializeField]private GameObject inputField1;
    [SerializeField]private GameObject inputField2;
    [SerializeField]private GameObject inputField3;
    [SerializeField]private GameObject inputField4;

    public void ActivateSalle(string salle) {
        if(salle == "salle1") {
            salle1.SetActive(true);
            salle2.SetActive(false);
            salle3.SetActive(false);
            typeSalle = "salle1";
        } else if(salle == "salle2") {
            salle1.SetActive(false);
            salle2.SetActive(true);
            salle3.SetActive(false);
            typeSalle = "salle2";
        } else if(salle == "salle3") {
            salle1.SetActive(false);
            salle2.SetActive(false);
            salle3.SetActive(true);
            typeSalle = "salle3";
        }
    }

    public void ActivateHabillage(string habillage) {
        if(habillage == "habillage1") {
            habillage1.SetActive(true);
            habillage2.SetActive(false);
            habillage3.SetActive(false);
            typeHabillage = "habillage1";
        } else if(habillage == "habillage2") {
            habillage1.SetActive(false);
            habillage2.SetActive(true);
            habillage3.SetActive(false);
            typeHabillage = "habillage2";
        } else if(habillage == "habillage3") {
            habillage1.SetActive(false);
            habillage2.SetActive(false);
            habillage3.SetActive(true);
            typeHabillage = "habillage3";
        }
    }

    public void ActivateBoss(string boss) {
        if(boss == "lymul") {
            boss1.SetActive(true);
            boss2.SetActive(false);
            boss3.SetActive(false);
            boss4.SetActive(false);
            typeBoss = "lymul";
        } else if(boss == "korinh") {
            boss1.SetActive(false);
            boss2.SetActive(true);
            boss3.SetActive(false);
            boss4.SetActive(false);
            typeBoss = "korinh";
        } else if(boss == "bob") {
            boss1.SetActive(false);
            boss2.SetActive(false);
            boss3.SetActive(true);
            boss4.SetActive(false);
            typeBoss = "bob";
        } else if(boss == "flue") {
            boss1.SetActive(false);
            boss2.SetActive(false);
            boss3.SetActive(false);
            boss4.SetActive(true);
            typeBoss = "flue";
        }
    }

    public void GetNumberOfEnemy() {
        numberPat = int.Parse(inputField1.GetComponent<TMP_InputField>().text);
        numberPit = int.Parse(inputField2.GetComponent<TMP_InputField>().text);
        numberPot = int.Parse(inputField3.GetComponent<TMP_InputField>().text);
        numberPut = int.Parse(inputField4.GetComponent<TMP_InputField>().text);
    }
}
