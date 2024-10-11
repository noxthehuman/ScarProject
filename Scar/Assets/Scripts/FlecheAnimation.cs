using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class FlecheAnimation : MonoBehaviour {
    public Animator FlecheGauche;
    public Animator FlecheDroite;

    public void Start() {
        FlecheGauche.enabled = false;
        FlecheDroite.enabled = false;
    }

    public void OnEnterMouse() {
        FlecheGauche.enabled = true;
        FlecheDroite.enabled = true;
        FlecheGauche.Play("Base Layer.FlecheMovmentIN");
        FlecheDroite.Play("Base Layer.FlecheMovment2IN");
        FlecheGauche.SetBool("Fade", false);
        FlecheDroite.SetBool("Fade", false);
    }

    public void OnExitMouse() {
        FlecheGauche.SetBool("Fade", true);
        FlecheDroite.SetBool("Fade", true);
    }
}
