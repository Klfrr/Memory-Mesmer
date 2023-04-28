using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class backgroundDrop : MonoBehaviour
{

    public GameObject greenPanel;
    public GameObject orangePanel;
    public GameObject bluePanel;
    public GameObject pinkPanel;
    public Dropdown backDrop;

    //
    //Initial idea but was flawed, I overcomplicated this. Made it way easier to understand
    //will be easier using other idea when adding more options.
    //

    // Start is called before the first frame update
    /*void Start()
    {

        // Check the active state of the GreenPanel
        if (PlayerPrefs.GetInt("GreenPanelActive", 0) == 1)
        {
            // If it's active, turn it on
            greenPanel.SetActive(true);
        }
        else
        {
            // If it's not active, turn it off
            greenPanel.SetActive(false);
        }

        // Check the active state of the OrangePanel
        if (PlayerPrefs.GetInt("OrangePanelActive", 0) == 1)
        {
            // If it's active, turn it on
            orangePanel.SetActive(true);
        }
        else
        {
            // If it's not active, turn it off
            orangePanel.SetActive(false);
        }

        // Check the active state of the BluePanel
        if (PlayerPrefs.GetInt("BluePanelActive", 0) == 1)
        {
            // If it's active, turn it on
            bluePanel.SetActive(true);
        }
        else
        {
            // If it's not active, turn it off
            bluePanel.SetActive(false);
        }

        // Check the active state of the PinkPanel
        if (PlayerPrefs.GetInt("PinkPanelActive", 0) == 1)
        {
            // If it's active, turn it on
            pinkPanel.SetActive(true);
        }
        else
        {
            // If it's not active, turn it off
            pinkPanel.SetActive(false);
        }

        greenPanel.SetActive(true);

        //loads dropdown value to stored value
        int selectedColor = PlayerPrefs.GetInt("SelectedOption", 0);
        backDrop.value = selectedColor;
    }

    public void backgroundChange()
    {
        //turns off all panels besides the GreenPanel
        if (backDrop.value == 0)
        {
            // Turn on the GreenPanel
            greenPanel.SetActive(true);
            // Save the active state of the GreenPanel
            PlayerPrefs.SetInt("GreenPanelActive", 1);

            // Turn off the OrangePanel
            orangePanel.SetActive(false);
            // Save the active state of the OrangePanel
            PlayerPrefs.SetInt("OrangePanelActive", 0);

            // Turn off the bluePanel
            bluePanel.SetActive(false);
            // Save the active state of the bluePanel
            PlayerPrefs.SetInt("BluePanelActive", 0);

            // Turn off the PinkPanel
            pinkPanel.SetActive(false);
            // Save the active state of the PinkPanel
            PlayerPrefs.SetInt("PinkPanelActive", 0);
        }
        //turns off all panels besides the OrangePanel
        else if (backDrop.value == 1)
        {
            // Turn off the GreenPanel
            greenPanel.SetActive(false);
            // Save the active state of the GreenPanel
            PlayerPrefs.SetInt("GreenPanelActive", 0);

            // Turn on the OrangePanel
            orangePanel.SetActive(true);
            // Save the active state of the OrangePanel
            PlayerPrefs.SetInt("OrangePanelActive", 1);

            // Turn off the bluePanel
            bluePanel.SetActive(false);
            // Save the active state of the bluePanel
            PlayerPrefs.SetInt("BluePanelActive", 0);

            // Turn off the PinkPanel
            pinkPanel.SetActive(false);
            // Save the active state of the PinkPanel
            PlayerPrefs.SetInt("PinkPanelActive", 0);


        }
        //turns off all panels besides the BluePanel
        else if (backDrop.value == 2)
        {
            // Turn off the GreenPanel
            greenPanel.SetActive(false);
            // Save the active state of the GreenPanel
            PlayerPrefs.SetInt("GreenPanelActive", 0);

            // Turn off the OrangePanel
            orangePanel.SetActive(false);
            // Save the active state of the OrangePanel
            PlayerPrefs.SetInt("OrangePanelActive", 0);

            // Turn on the bluePanel
            bluePanel.SetActive(true);
            // Save the active state of the bluePanel
            PlayerPrefs.SetInt("BluePanelActive", 1);

            // Turn off the PinkPanel
            pinkPanel.SetActive(false);
            // Save the active state of the PinkPanel
            PlayerPrefs.SetInt("PinkPanelActive", 0);


        }
        //turns off all panels besides the PinkPanel
        else if (backDrop.value == 3)
        {
            // Turn off the GreenPanel
            greenPanel.SetActive(false);
            // Save the active state of the GreenPanel
            PlayerPrefs.SetInt("GreenPanelActive", 0);

            // Turn off the OrangePanel
            orangePanel.SetActive(false);
            // Save the active state of the OrangePanel
            PlayerPrefs.SetInt("OrangePanelActive", 0);

            // Turn off the bluePanel
            bluePanel.SetActive(false);
            // Save the active state of the bluePanel
            PlayerPrefs.SetInt("BluePanelActive", 0);

            // Turn on the PinkPanel
            pinkPanel.SetActive(true);
            // Save the active state of the PinkPanel
            PlayerPrefs.SetInt("PinkPanelActive", 1);


        }
        //saves selected value to be stored
        int selectedOption = backDrop.value;
        PlayerPrefs.SetInt("SelectedOption", backDrop.value);
    }*/

    void Start()
    {
        // Turn on the GreenPanel
        greenPanel.SetActive(true);

        // Check the active state of the OrangePanel
        if (PlayerPrefs.GetInt("OrangePanelActive", 0) == 1)
        {
            // If it's active, turn it on
            orangePanel.SetActive(true);
        }
        else
        {
            // If it's not active, turn it off
            orangePanel.SetActive(false);
        }

        // Check the active state of the BluePanel
        if (PlayerPrefs.GetInt("BluePanelActive", 0) == 1)
        {
            // If it's active, turn it on
            bluePanel.SetActive(true);
        }
        else
        {
            // If it's not active, turn it off
            bluePanel.SetActive(false);
        }

        // Check the active state of the PinkPanel
        if (PlayerPrefs.GetInt("PinkPanelActive", 0) == 1)
        {
            // If it's active, turn it on
            pinkPanel.SetActive(true);
        }
        else
        {
            // If it's not active, turn it off
            pinkPanel.SetActive(false);
        }

        //loads dropdown value to stored value
        int selectedColor = PlayerPrefs.GetInt("SelectedOption", 0);
        backDrop.value = selectedColor;

        // Set the initial panel based on the stored value
        backgroundChange();
    }

    public void backgroundChange()
    {
        // Save the selected value
        int selectedOption = backDrop.value;
        PlayerPrefs.SetInt("SelectedOption", selectedOption);

        // Turn off all panels
        greenPanel.SetActive(false);
        orangePanel.SetActive(false);
        bluePanel.SetActive(false);
        pinkPanel.SetActive(false);

        // Turn on the selected panel
        switch (selectedOption)
        {
            case 0:
                // Turn on the GreenPanel
                greenPanel.SetActive(true);
                // Save the active state of the GreenPanel
                PlayerPrefs.SetInt("GreenPanelActive", 1);
                break;
            case 1:
                // Turn on the OrangePanel
                orangePanel.SetActive(true);
                // Save the active state of the OrangePanel
                PlayerPrefs.SetInt("OrangePanelActive", 1);
                break;
            case 2:
                // Turn on the BluePanel
                bluePanel.SetActive(true);
                // Save the active state of the BluePanel
                PlayerPrefs.SetInt("BluePanelActive", 1);
                break;
            case 3:
                // Turn on the PinkPanel
                pinkPanel.SetActive(true);
                // Save the active state of the PinkPanel
                PlayerPrefs.SetInt("PinkPanelActive", 1);
                break;
        }
    }


    private void OnApplicationQuit()
    {
        PlayerPrefs.DeleteAll();//deletes all saved values when game is closed
    }

    private void OnDestroy()
    {
        PlayerPrefs.Save();//when scene is switched the settings are saved and stored
    }
}
