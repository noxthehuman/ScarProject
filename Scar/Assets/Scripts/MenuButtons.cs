using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour
{   
    [SerializeField]private GameObject Panel;
    [SerializeField]private GameObject Panel2;
    public string scene;
    public Animator fadeAnimation;
    public Animator edit1;

    public void Start() {
        Time.timeScale = 1f;
    }
    
    public void DoExitGame() {
        fadeAnimation.SetBool("Fade", true);
        Invoke("DoExitGame2", 1.0f);
    }

    public void DoExitGame2() {
        Application.Quit();
    }

    public void LoadScene() {
        fadeAnimation.SetBool("Fade", true);
        Invoke("LoadScene2", 1.0f);
    }

    public void LoadScene2() {
        SceneManager.LoadScene(scene);
    }

    public void LoadPanel() {
        Panel.SetActive(true);
    }

    public void LoadNewEditGame() {
        edit1.Play("Base Layer.Retour");
        Invoke("FermerMenu2", 1.5f);
    }

    public void FermerMenu2() {
        Panel.SetActive(false);
        Panel2.SetActive(true);
    }
}
 