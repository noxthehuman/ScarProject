using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoDestructionGameObject : MonoBehaviour
{
    /***
    *** Permet à un GameObject de ne jamais être supprimer lors d'un changement de scène.
    ***/
    void Awake() {
        DontDestroyOnLoad(this.gameObject);
    }
}
