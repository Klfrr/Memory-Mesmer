using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class panelController : MonoBehaviour
{
    public void OrangePanel()
    {
        // Find the main panel by name and deactivate it
        GameObject mainPanel = GameObject.Find("MainPanel");
        if (mainPanel != null)
        {
            //turning off main panel
            mainPanel.SetActive(false);
            // Save the active state of the main panel
            PlayerPrefs.SetInt("MainPanelActive", 0);
        }

        // Find the orange panel by name and activate it
        GameObject orangePanel = GameObject.Find("OrangePanel");
        if (orangePanel != null)
        {
            //turning on orange panel
            orangePanel.SetActive(true);
            // Save the active state of the orange panel
            PlayerPrefs.SetInt("OrangePanelActive", 1);
        }
    }

    void Start()
    {
        // Restore the active state of the main and orange panels
        if (PlayerPrefs.HasKey("MainPanelActive"))
        {
            
            GameObject mainPanel = GameObject.Find("MainPanel");
            if (mainPanel != null) mainPanel.SetActive(PlayerPrefs.GetInt("MainPanelActive") != 0);
        }
        if (PlayerPrefs.HasKey("OrangePanelActive"))
        {
            GameObject orangePanel = GameObject.Find("OrangePanel");
            if (orangePanel != null) orangePanel.SetActive(PlayerPrefs.GetInt("OrangePanelActive") != 0);
        }
    }

}
