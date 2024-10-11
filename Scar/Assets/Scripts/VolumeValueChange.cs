using UnityEngine;
using System.IO;
using System.Collections;
using UnityEngine.UI;

public class VolumeValueChange : MonoBehaviour {

    private AudioSource audioSrc;
    private float musicVolume = 0.5f;
    string chemin, jsonString;
    [SerializeField]private Slider slider;

	void Start () {
        audioSrc = GetComponent<AudioSource>();
        chemin = Application.streamingAssetsPath + "/Settings.json";
        jsonString = File.ReadAllText(chemin);
        SettingsGame settings = JsonUtility.FromJson<SettingsGame>(jsonString);
        musicVolume = settings.volume;
        audioSrc.volume = settings.volume;
        slider.value = settings.volume;
	}
	
	void Update () {
        audioSrc.volume = musicVolume;
	}

    public void SetVolume(float vol) {
        musicVolume = vol;
    }

    public void SendVolume() {
        chemin = Application.streamingAssetsPath + "/Settings.json";
        jsonString = File.ReadAllText(chemin);
        SettingsGame settings = JsonUtility.FromJson<SettingsGame>(jsonString);
        settings.volume = slider.value;
        jsonString = JsonUtility.ToJson(settings);
        File.WriteAllText(chemin, jsonString);
    }
}