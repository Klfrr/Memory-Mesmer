using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;


public class settingsMenu : MonoBehaviour
{
    [SerializeField] public Slider volumeSlider = null;

    [SerializeField] public Text volumeNumber = null;

    //public AudioMixer audioMixer;

    public void Start()
    {
        //this is where you would load user volume settings
        loadVolume();
    }

    public void setVolume(float volume)
    {
        volumeNumber.text = volume.ToString("0.0");

       // audioMixer.SetFloat("Volume", volume);
    }

    public void saveVolume()
    {
        float volumeValue = volumeSlider.value;
        PlayerPrefs.SetFloat("VolumeValue", volumeValue);
        loadVolume();
    }

    void loadVolume()
    {
        float volumeValue = PlayerPrefs.GetFloat("VolumeValue");
        volumeSlider.value = volumeValue;
        AudioListener.volume = volumeValue;

    }
}