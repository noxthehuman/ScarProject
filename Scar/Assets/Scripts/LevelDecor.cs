using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelDecor : MonoBehaviour
{
    public GameObject marecage;
    public GameObject arene;
    public GameObject cimetiere;
    

    void Start()
    {
        Scene scene = SceneManager.GetActiveScene();
        if(scene.name == "Main")
        {
            marecage.SetActive(true);
        }


        if (scene.name == "Donjon2")
        {
            arene.SetActive(true);
        }


        if (scene.name == "Donjon4")
        {
            cimetiere.SetActive(true);
        }

    }
}
