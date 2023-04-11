using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class panelController : MonoBehaviour
{  
        public GameObject mainPanel;
        public GameObject orangePanel;

        private void Start()
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
        }

        public void OrangePanel()
        {
            // Turn off the MainPanel
            mainPanel.SetActive(false);
            // Save the active state of the MainPanel
            PlayerPrefs.SetInt("MainPanelActive", 0);

            // Turn on the OrangePanel
            orangePanel.SetActive(true);
            // Save the active state of the OrangePanel
            PlayerPrefs.SetInt("OrangePanelActive", 1);
        }

        public void MainPanel()
        {
            // Turn on the MainPanel
            mainPanel.SetActive(true);
            // Save the active state of the MainPanel
            PlayerPrefs.SetInt("MainPanelActive", 1);

            // Turn off the OrangePanel
            orangePanel.SetActive(false);
            // Save the active state of the OrangePanel
            PlayerPrefs.SetInt("OrangePanelActive", 0);
        }




}
