using System;
using UnityEngine;

public class AnimBoss : MonoBehaviour
{
    public GameObject bossPanel;
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("essai");
            DisplayPanelOn();
        }
    }

    private void Update()
    {
        DisplayPanelOff();
    }

    private void DisplayPanelOn()
    {
        bossPanel.SetActive(true);
        Time.timeScale = 0f;
    }
    
    private void DisplayPanelOff()
    {
        if (Input.GetMouseButtonDown(1) || Input.GetMouseButtonDown(0))
        {
            Time.timeScale = 1f;
            bossPanel.SetActive(false);   
            Destroy(gameObject);
        }
    }
}
