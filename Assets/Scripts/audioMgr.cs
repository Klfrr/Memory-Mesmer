using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class audioMgr : MonoBehaviour
{
    [SerializeField] AudioMixer audioMixer;
    public static audioMgr instance;
    public const string volumeKey = "Volume";

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        loadVolume();
    }

    void loadVolume()
    {   //1f is for the default in case there is nothing to load.
        float soundVolume = PlayerPrefs.GetFloat(volumeKey, 1f);
        //mixer uses logarithmic value and slider does linear so we need to use this formula
        //to convert it when loading 
        audioMixer.SetFloat(settingsMenu.volumeMixer, Mathf.Log10(soundVolume) * 20);
    }
}
