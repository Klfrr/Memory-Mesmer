using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/* Image Links:
 * https://pngtree.com/so/fabric fabric png from pngtree.com
 * https://unsplash.com/photos/K5OLjMlPe4U green gradient from Sincerely Media
 * https://www.vecteezy.com/free-png/white-rectangle white button from Vecteezy
 */
public class settingsMenu : MonoBehaviour
{
    [SerializeField] public Slider volumeSlider;

    [SerializeField] public Text volumeNumber = null;

    [SerializeField] private AudioMixer audioMixer;

    public const string volumeMixer = "Volume";

    private UIManager uiMgr;

    private void Awake()
    {
        volumeSlider.onValueChanged.AddListener(setVolume);
    }
    //Makes sure slider loads back to the value it was saved at
    //1f is default value here.
    void Start()
    {
        volumeSlider.value = PlayerPrefs.GetFloat(audioMgr.volumeKey, 1f);
        uiMgr = FindObjectOfType<UIManager>();
    }
    //sets value for number shown to user and allows audio mixer to be adjusted using slider
    public void setVolume(float volume)
    {
        volumeNumber.text = volume.ToString("0.0");

        audioMixer.SetFloat(volumeMixer, Mathf.Log10(volume) * 20);
    }
    //when setting scene is left the settings will be stored
    private void OnDisable()
    {
        PlayerPrefs.SetFloat(audioMgr.volumeKey, volumeSlider.value);
    }

    public void mainMenu()
    {
        uiMgr.updateSettings();
        SceneManager.LoadScene(0);
    }
}