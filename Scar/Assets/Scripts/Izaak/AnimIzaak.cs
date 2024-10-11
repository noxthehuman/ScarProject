using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class AnimIzaak : MonoBehaviour
{
    public Animator izaak;
    
    void Start()
    {
        izaak = GetComponent<Animator>();
    }

    void Update()
    {
        /*if (Input.GetAxis("Dash") > 0.5)
        {
            izaak.SetBool("dodge", true);
        }*/

        if (Input.GetKey(KeyCode.Z))
        {
            izaak.SetBool("isRuningF", true);
            izaak.SetBool("isRuningB", false);
            izaak.SetBool("isRuningL", false);
            izaak.SetBool("isRuningR", false);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            izaak.SetBool("isRuningF", false);
            izaak.SetBool("isRuningB", true);
            izaak.SetBool("isRuningL", false);
            izaak.SetBool("isRuningR", false);
        }
        else if (Input.GetKey(KeyCode.Q))
        {
            izaak.SetBool("isRuningF", false);
            izaak.SetBool("isRuningB", false);
            izaak.SetBool("isRuningL", true);
            izaak.SetBool("isRuningR", false);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            izaak.SetBool("isRuningF", false);
            izaak.SetBool("isRuningB", false);
            izaak.SetBool("isRuningL", false);
            izaak.SetBool("isRuningR", true);
        }
        else
        {
            izaak.SetBool("isRuningF", false);
            izaak.SetBool("isRuningB", false);
            izaak.SetBool("isRuningL", false);
            izaak.SetBool("isRuningR", false);
            //izaak.SetBool("dodge", false);
        }
        
    }
}
