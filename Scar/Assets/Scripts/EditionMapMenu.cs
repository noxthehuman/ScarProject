using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EditionMapMenu : MonoBehaviour
{
    [SerializeField]private GameObject inputField;
    [SerializeField]private GameObject salle1;
    [SerializeField]private GameObject salle2;
    [SerializeField]private GameObject salle3;
    [SerializeField]private GameObject salle4;
    [SerializeField]private GameObject salle5;
    [SerializeField]private GameObject salle6;
    [SerializeField]private GameObject salle7;
    [SerializeField]private GameObject salle8;
    [SerializeField]private GameObject salle9;
    [SerializeField]private GameObject salle10;
    [SerializeField]private GameObject salle11;
    [SerializeField]private GameObject salle12;
    [SerializeField]private GameObject salle13;
    [SerializeField]private GameObject salle14;
    [SerializeField]private GameObject salle15;
    string text;
    public int numberOfBossSalle = 0;
    public int numberOfMiniBossSalle = 0;
    
    void Update() {
        text = inputField.GetComponent<TMP_InputField>().text;
        DisplaySalle(int.Parse(text));
        ChooseSalleMiniBossAndBoss(int.Parse(text));
    }
    
    private void DisplaySalle(int i) {
         if(i <= 1) {
            salle1.SetActive(true);
            salle2.SetActive(false);
            salle3.SetActive(false);
            salle4.SetActive(false);
            salle5.SetActive(false);
            salle6.SetActive(false);
            salle7.SetActive(false);
            salle8.SetActive(false);
            salle9.SetActive(false);
            salle10.SetActive(false);
            salle11.SetActive(false);
            salle12.SetActive(false);
            salle13.SetActive(false);
            salle14.SetActive(false);
            salle15.SetActive(false);
        } else if(i == 2) {
            salle1.SetActive(true);
            salle2.SetActive(true);
            salle3.SetActive(false);
            salle4.SetActive(false);
            salle5.SetActive(false);
            salle6.SetActive(false);
            salle7.SetActive(false);
            salle8.SetActive(false);
            salle9.SetActive(false);
            salle10.SetActive(false);
            salle11.SetActive(false);
            salle12.SetActive(false);
            salle13.SetActive(false);
            salle14.SetActive(false);
            salle15.SetActive(false);
        } else if(i == 3) {
            salle1.SetActive(true);
            salle2.SetActive(true);
            salle3.SetActive(true);
            salle4.SetActive(false);
            salle5.SetActive(false);
            salle6.SetActive(false);
            salle7.SetActive(false);
            salle8.SetActive(false);
            salle9.SetActive(false);
            salle10.SetActive(false);
            salle11.SetActive(false);
            salle12.SetActive(false);
            salle13.SetActive(false);
            salle14.SetActive(false);
            salle15.SetActive(false);
        } else if(i == 4) {
            salle1.SetActive(true);
            salle2.SetActive(true);
            salle3.SetActive(true);
            salle4.SetActive(true);
            salle5.SetActive(false);
            salle6.SetActive(false);
            salle7.SetActive(false);
            salle8.SetActive(false);
            salle9.SetActive(false);
            salle10.SetActive(false);
            salle11.SetActive(false);
            salle12.SetActive(false);
            salle13.SetActive(false);
            salle14.SetActive(false);
            salle15.SetActive(false);
        } else if(i == 5) {
            salle1.SetActive(true);
            salle2.SetActive(true);
            salle3.SetActive(true);
            salle4.SetActive(true);
            salle5.SetActive(true);
            salle6.SetActive(false);
            salle7.SetActive(false);
            salle8.SetActive(false);
            salle9.SetActive(false);
            salle10.SetActive(false);
            salle11.SetActive(false);
            salle12.SetActive(false);
            salle13.SetActive(false);
            salle14.SetActive(false);
            salle15.SetActive(false);
        } else if(i == 6) {
            salle1.SetActive(true);
            salle2.SetActive(true);
            salle3.SetActive(true);
            salle4.SetActive(true);
            salle5.SetActive(true);
            salle6.SetActive(true);
            salle7.SetActive(false);
            salle8.SetActive(false);
            salle9.SetActive(false);
            salle10.SetActive(false);
            salle11.SetActive(false);
            salle12.SetActive(false);
            salle13.SetActive(false);
            salle14.SetActive(false);
            salle15.SetActive(false);
        } else if(i == 7) {
            salle1.SetActive(true);
            salle2.SetActive(true);
            salle3.SetActive(true);
            salle4.SetActive(true);
            salle5.SetActive(true);
            salle6.SetActive(true);
            salle7.SetActive(true);
            salle8.SetActive(false);
            salle9.SetActive(false);
            salle10.SetActive(false);
            salle11.SetActive(false);
            salle12.SetActive(false);
            salle13.SetActive(false);
            salle14.SetActive(false);
            salle15.SetActive(false);
        } else if(i == 8) {
            salle1.SetActive(true);
            salle2.SetActive(true);
            salle3.SetActive(true);
            salle4.SetActive(true);
            salle5.SetActive(true);
            salle6.SetActive(true);
            salle7.SetActive(true);
            salle8.SetActive(true);
            salle9.SetActive(false);
            salle10.SetActive(false);
            salle11.SetActive(false);
            salle12.SetActive(false);
            salle13.SetActive(false);
            salle14.SetActive(false);
            salle15.SetActive(false);
        } else if(i == 9) {
            salle1.SetActive(true);
            salle2.SetActive(true);
            salle3.SetActive(true);
            salle4.SetActive(true);
            salle5.SetActive(true);
            salle6.SetActive(true);
            salle7.SetActive(true);
            salle8.SetActive(true);
            salle9.SetActive(true);
            salle10.SetActive(false);
            salle11.SetActive(false);
            salle12.SetActive(false);
            salle13.SetActive(false);
            salle14.SetActive(false);
            salle15.SetActive(false);
        } else if(i == 10) {
            salle1.SetActive(true);
            salle2.SetActive(true);
            salle3.SetActive(true);
            salle4.SetActive(true);
            salle5.SetActive(true);
            salle6.SetActive(true);
            salle7.SetActive(true);
            salle8.SetActive(true);
            salle9.SetActive(true);
            salle10.SetActive(true);
            salle11.SetActive(false);
            salle12.SetActive(false);
            salle13.SetActive(false);
            salle14.SetActive(false);
            salle15.SetActive(false);
        } else if(i == 11) {
            salle1.SetActive(true);
            salle2.SetActive(true);
            salle3.SetActive(true);
            salle4.SetActive(true);
            salle5.SetActive(true);
            salle6.SetActive(true);
            salle7.SetActive(true);
            salle8.SetActive(true);
            salle9.SetActive(true);
            salle10.SetActive(true);
            salle11.SetActive(true);
            salle12.SetActive(false);
            salle13.SetActive(false);
            salle14.SetActive(false);
            salle15.SetActive(false);
        } else if(i == 12) {
            salle1.SetActive(true);
            salle2.SetActive(true);
            salle3.SetActive(true);
            salle4.SetActive(true);
            salle5.SetActive(true);
            salle6.SetActive(true);
            salle7.SetActive(true);
            salle8.SetActive(true);
            salle9.SetActive(true);
            salle10.SetActive(true);
            salle11.SetActive(true);
            salle12.SetActive(true);
            salle13.SetActive(false);
            salle14.SetActive(false);
            salle15.SetActive(false);
        } else if(i == 13) {
            salle1.SetActive(true);
            salle2.SetActive(true);
            salle3.SetActive(true);
            salle4.SetActive(true);
            salle5.SetActive(true);
            salle6.SetActive(true);
            salle7.SetActive(true);
            salle8.SetActive(true);
            salle9.SetActive(true);
            salle10.SetActive(true);
            salle11.SetActive(true);
            salle12.SetActive(true);
            salle13.SetActive(true);
            salle14.SetActive(false);
            salle15.SetActive(false);
        } else if(i == 14) {
            salle1.SetActive(true);
            salle2.SetActive(true);
            salle3.SetActive(true);
            salle4.SetActive(true);
            salle5.SetActive(true);
            salle6.SetActive(true);
            salle7.SetActive(true);
            salle8.SetActive(true);
            salle9.SetActive(true);
            salle10.SetActive(true);
            salle11.SetActive(true);
            salle12.SetActive(true);
            salle13.SetActive(true);
            salle14.SetActive(true);
            salle15.SetActive(false);
        } else if(i >= 15) {
            salle1.SetActive(true);
            salle2.SetActive(true);
            salle3.SetActive(true);
            salle4.SetActive(true);
            salle5.SetActive(true);
            salle6.SetActive(true);
            salle7.SetActive(true);
            salle8.SetActive(true);
            salle9.SetActive(true);
            salle10.SetActive(true);
            salle11.SetActive(true);
            salle12.SetActive(true);
            salle13.SetActive(true);
            salle14.SetActive(true);
            salle15.SetActive(true);
        }
    }

    private void ChooseSalleMiniBossAndBoss(int i) {
        if(i <= 1) {
            numberOfBossSalle = 1;
            numberOfMiniBossSalle = 0; 
        } else if(i == 2) {
            numberOfBossSalle = 2;
            numberOfMiniBossSalle = 1; 
        } else if(i == 3) {
            numberOfBossSalle = 3;
            numberOfMiniBossSalle = 2; 
        } else if(i == 4) {
            numberOfBossSalle = 4;
            numberOfMiniBossSalle = 2; 
        } else if(i == 5) {
            numberOfBossSalle = 5;
            numberOfMiniBossSalle = 3; 
        } else if(i == 6) {
            numberOfBossSalle = 6;
            numberOfMiniBossSalle = 3; 
        } else if(i == 7) {
            numberOfBossSalle = 7;
            numberOfMiniBossSalle = 4; 
        } else if(i == 8) {
            numberOfBossSalle = 8;
            numberOfMiniBossSalle = 4; 
        } else if(i == 9) {
            numberOfBossSalle = 9;
            numberOfMiniBossSalle = 5; 
        } else if(i == 10) {
            numberOfBossSalle = 10;
            numberOfMiniBossSalle = 5; 
        } else if(i == 11) {
            numberOfBossSalle = 11;
            numberOfMiniBossSalle = 6; 
        } else if(i == 12) {
            numberOfBossSalle = 12;
            numberOfMiniBossSalle = 6; 
        } else if(i == 13) {
            numberOfBossSalle = 13;
            numberOfMiniBossSalle = 7; 
        } else if(i == 14) {
            numberOfBossSalle = 14;
            numberOfMiniBossSalle = 7; 
        } else if(i >= 15) {
            numberOfBossSalle = 15;
            numberOfMiniBossSalle = 8; 
        }
    }
}
