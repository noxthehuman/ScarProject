using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomCursor : MonoBehaviour {

    public Texture2D cursorArrow;
    public Texture2D cursorArrow2;
    public GameObject OptionsMenu;
    public GameObject LoadSaveMenu;
    public GameObject Jouer;
    public GameObject EditMap;
    public GameObject Options;
    public GameObject Quitter;
    public AudioSource audioSrc;

    void Start()
    {
        Cursor.SetCursor(cursorArrow, Vector2.zero, CursorMode.ForceSoftware);
    }

    public void ChangeCursorToClick() {
        Cursor.SetCursor(cursorArrow2, Vector2.zero, CursorMode.ForceSoftware);
    }

    public void ChangeCursorToNormal() {
        Cursor.SetCursor(cursorArrow, Vector2.zero, CursorMode.ForceSoftware);
    }
    
    public void PlayMusic() {
        audioSrc.Play(0);
    }
}
