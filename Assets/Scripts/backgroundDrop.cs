using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class backgroundDrop : MonoBehaviour
{

    public GameObject mainPanel;
    public GameObject orangePanel;
    public GameObject bluePanel;
    public Dropdown backDrop;

    // Start is called before the first frame update
    void Start()
    {
        // Check if the MainPanel is active
        if (PlayerPrefs.GetInt("MainPanelActive", 1) == 0)
        {
            // If not, turn it off
            mainPanel.SetActive(false);
        }

        // Check if the OrangePanel is active
        if (PlayerPrefs.GetInt("OrangePanelActive", 0) == 1)
        {
            // If so, turn it on
            orangePanel.SetActive(true);
        }

        if (PlayerPrefs.GetInt("BluePanelActive", 1) == 0)
        {
            // If so, turn it on
            bluePanel.SetActive(false);
        }
        //loads dropdown value to stored value
        int selectedColor = PlayerPrefs.GetInt("SelectedOption", 0);
        backDrop.value = selectedColor;
    }

    public void backgroundChange()
    {
        if (backDrop.value == 0)
        {
            // Turn on the MainPanel
            mainPanel.SetActive(true);
            // Save the active state of the MainPanel
            PlayerPrefs.SetInt("MainPanelActive", 1);

            // Turn off the OrangePanel
            orangePanel.SetActive(false);
            // Save the active state of the OrangePanel
            PlayerPrefs.SetInt("OrangePanelActive", 0);

            // Turn off the bluePanel
            bluePanel.SetActive(false);
            // Save the active state of the bluePanel
            PlayerPrefs.SetInt("BluePanelActive", 0);
        }
        else if (backDrop.value == 1)
        {
            // Turn off the MainPanel
            mainPanel.SetActive(false);
            // Save the active state of the MainPanel
            PlayerPrefs.SetInt("MainPanelActive", 0);

            // Turn on the OrangePanel
            orangePanel.SetActive(true);
            // Save the active state of the OrangePanel
            PlayerPrefs.SetInt("OrangePanelActive", 1);

            // Turn off the bluePanel
            bluePanel.SetActive(false);
            // Save the active state of the bluePanel
            PlayerPrefs.SetInt("BluePanelActive", 0);


        }
        else if (backDrop.value == 2)
        {
            // Turn off the MainPanel
            mainPanel.SetActive(false);
            // Save the active state of the MainPanel
            PlayerPrefs.SetInt("MainPanelActive", 0);

            // Turn off the OrangePanel
            orangePanel.SetActive(false);
            // Save the active state of the OrangePanel
            PlayerPrefs.SetInt("OrangePanelActive", 0);

            // Turn off the bluePanel
            bluePanel.SetActive(true);
            // Save the active state of the bluePanel
            PlayerPrefs.SetInt("BluePanelActive", 1);


        }
        //saves selected value to be stored
        int selectedOption = backDrop.value;
        PlayerPrefs.SetInt("SelectedOption", backDrop.value);
    }

    private void OnApplicationQuit()
    {
        PlayerPrefs.DeleteAll();
    }

    private void OnDestroy()
    {
        PlayerPrefs.Save();
    }
}
