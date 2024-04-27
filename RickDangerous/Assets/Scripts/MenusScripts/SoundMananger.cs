using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SoundMananger : MonoBehaviour
{
    [SerializeField] private Slider volumeSlider;
    [SerializeField] private TMP_Text text;

    // Start is called before the first frame update
    void Start()
    {
        if (!PlayerPrefs.HasKey("musicVolume"))
        {
            PlayerPrefs.SetFloat("musicVolume", 1);
            Load();
        }
        else { 
            Load();
        }
    }

    public void ChangeVolume()
    {
        float volumeLevel = volumeSlider.value;
        AudioListener.volume = volumeLevel;
        int volumeLevelInt = Mathf.RoundToInt(volumeLevel * 100);
        text.text = volumeLevelInt +"%";
        Save();
    }

    private void Load()
    {
        volumeSlider.value = PlayerPrefs.GetFloat("musicVolume");
    }

    private void Save() {

        PlayerPrefs.SetFloat("musicVolume", volumeSlider.value);
    }

}
