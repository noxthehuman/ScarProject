using UnityEngine;

public class AudioManage : MonoBehaviour {

    public AudioClip[] playlist;
    public AudioSource audioSource;
    int i = 0;

    void Start()
    {
        audioSource.clip = playlist[0];
        audioSource.Play();
    }

    void Update()
    {
        if(GameObject.FindGameObjectsWithTag("boss").Length > 0 && i == 0) {
            i = 1;
            audioSource.clip = playlist[1];
            audioSource.Play();
        }
    }
}
