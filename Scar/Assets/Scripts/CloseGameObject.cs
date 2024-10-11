using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseGameObject : MonoBehaviour
{
    [SerializeField]private GameObject Panel;
    public Animator options;

    public void FermerMenu() {
        options.Play("Base Layer.Retour");
        Invoke("FermerMenu2", 1.5f);
    }

    public void FermerMenu2() {
        Panel.SetActive(false);
    }

    public void OuvrirMenu() {
        Panel.SetActive(true);
    }
}
