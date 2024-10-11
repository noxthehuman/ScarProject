using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CutScenesEnter : MonoBehaviour
{
    private GameObject cameraPlayer;
    public GameObject cutSceneCam;
    private bool firstActive = true;
    private float timer;
    public static bool isCutscene;
    
    private void Start()
    {
        cameraPlayer = GameObject.FindGameObjectWithTag("MainCamera");
        if (SceneManager.GetActiveScene().name == "Village" || SceneManager.GetActiveScene().name == "Village2" ||SceneManager.GetActiveScene().name == "Village3" ||SceneManager.GetActiveScene().name == "Village4")
        {
            timer = 13;
        }
        else
        {
            timer = 6;
        }
    }
    
    private void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            cameraPlayer.SetActive(true);
            cutSceneCam.SetActive(false);
            isCutscene = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") & firstActive)
        {
            isCutscene = true;
            firstActive = false;
            cutSceneCam.SetActive(true);
            cameraPlayer.SetActive(false);
            StartCoroutine(FinishCut());
        }

        IEnumerator FinishCut()
        {
            yield return new WaitForSeconds(timer);
            isCutscene = false;
            cameraPlayer.SetActive(true);
            cutSceneCam.SetActive(false);
        }
    }
}
