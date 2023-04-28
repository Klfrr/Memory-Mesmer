using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class textureDrop : MonoBehaviour
{
    public GameObject texture1;
    public GameObject texture2;
    public GameObject texture3;
    public GameObject texture4;
    public Dropdown textureDropdown;

    // Start is called before the first frame update

    //
    //Changed the way this works
    //

    /*void Start()
    {
        // Check if the texture1 is active
        if (PlayerPrefs.GetInt("Texture1Active", 1) == 1)
        {
            // If not, turn it off
            texture1.SetActive(false);
        }

        // Check if the texture2 is active
        if (PlayerPrefs.GetInt("Texture2Active", 1) == 1)
        {
            // If so, turn it on
            texture2.SetActive(true);
        }
        // Check if the texture3 is active
        if (PlayerPrefs.GetInt("Texture3Active", 1) == 1)
        {
            // If so, turn it on
            texture3.SetActive(true);
        }
        // Check if the texture4 is active
        if (PlayerPrefs.GetInt("Texture4Active", 1) == 1)
        {
            // If so, turn it on
            texture4.SetActive(true);
        }
        //loads dropdown value to stored value
        int selectedColor = PlayerPrefs.GetInt("SelectedOption", 0);
        textureDropdown.value = selectedColor;
    }

    public void backgroundChange()
    {
        //turns off all textures besides the Texture1
        if (textureDropdown.value == 0)
        {
            // Turn on the Texture1
            texture1.SetActive(true);
            // Save the active state of the Texture1
            PlayerPrefs.SetInt("Texture1Active", 1);

            // Turn off the Texture2
            texture2.SetActive(false);
            // Save the active state of the Texture2
            PlayerPrefs.SetInt("Texture2Active", 0);

            // Turn off the Texture3
            texture3.SetActive(false);
            // Save the active state of the Texture3
            PlayerPrefs.SetInt("Texture3Active", 0);

            // Turn off the Texture4
            texture4.SetActive(false);
            // Save the active state of the Texture4
            PlayerPrefs.SetInt("Texture4Active", 0);
        }
        //turns off all besides the texture2
        else if (textureDropdown.value == 1)
        {
            /// Turn off the Texture1
            texture1.SetActive(false);
            // Save the active state of the Texture1
            PlayerPrefs.SetInt("Texture1Active", 0);

            // Turn on the Texture2
            texture2.SetActive(true);
            // Save the active state of the Texture2
            PlayerPrefs.SetInt("Texture2Active", 1);

            // Turn off the Texture3
            texture3.SetActive(false);
            // Save the active state of the Texture3
            PlayerPrefs.SetInt("Texture3Active", 0);

            // Turn off the Texture4
            texture4.SetActive(false);
            // Save the active state of the Texture4
            PlayerPrefs.SetInt("Texture4Active", 0);


        }
        //turns off all besides the texture3
        else if (textureDropdown.value == 2)
        {
            // Turn off the Texture1
            texture1.SetActive(false);
            // Save the active state of the Texture1
            PlayerPrefs.SetInt("Texture1Active", 0);

            // Turn off the Texture2
            texture2.SetActive(false);
            // Save the active state of the Texture2
            PlayerPrefs.SetInt("Texture2Active", 0);

            // Turn on the Texture3
            texture3.SetActive(true);
            // Save the active state of the Texture3
            PlayerPrefs.SetInt("Texture3Active", 1);

            // Turn off the Texture4 
            texture4.SetActive(false);
            // Save the active state of the Texture4
            PlayerPrefs.SetInt("Texture4Active", 0);


        }
        //turns off all besides the texture4 
        else if (textureDropdown.value == 3)
        {
            // Turn off the Texture1
            texture1.SetActive(false);
            // Save the active state of the Texture1 
            PlayerPrefs.SetInt("Texture1Active", 0);

            // Turn off the Texture2
            texture2.SetActive(false);
            // Save the active state of the Texture2
            PlayerPrefs.SetInt("Texture2Active", 0);

            // Turn off the Texture3
            texture3.SetActive(false);
            // Save the active state of the Texture3
            PlayerPrefs.SetInt("Texture3Active", 0);

            // Turn off the Texture4
            texture4.SetActive(true);
            // Save the active state of the Texture4
            PlayerPrefs.SetInt("Texture4Active", 1);


        }
        //saves selected value to be stored
        int selectedOption = textureDropdown.value;
        PlayerPrefs.SetInt("SelectedOption", textureDropdown.value);
    }*/

    void Start()
    {
        // Turn on the Texture1
        texture1.SetActive(true);

        // Check the active state of the Texture2
        if (PlayerPrefs.GetInt("Texture2Active", 0) == 1)
        {
            // If it's active, turn it on
            texture2.SetActive(true);
        }
        else
        {
            // If it's not active, turn it off
            texture2.SetActive(false);
        }

        // Check the active state of the Texture3
        if (PlayerPrefs.GetInt("Texture3Active", 0) == 1)
        {
            // If it's active, turn it on
            texture3.SetActive(true);
        }
        else
        {
            // If it's not active, turn it off
            texture3.SetActive(false);
        }

        // Check the active state of the Texture4
        if (PlayerPrefs.GetInt("Texture4Active", 0) == 1)
        {
            // If it's active, turn it on
            texture4.SetActive(true);
        }
        else
        {
            // If it's not active, turn it off
            texture4.SetActive(false);
        }

        //loads dropdown value to stored value
        int selectedCo = PlayerPrefs.GetInt("Option", 0);
        textureDropdown.value = selectedCo;

        // Set the initial panel based on the stored value
        backgroundChange();
    }

    public void backgroundChange()
    {
        // Save the selected value
        int selected = textureDropdown.value;
        PlayerPrefs.SetInt("Option", selected);

        // Turn off all panels
        texture1.SetActive(false);
        texture2.SetActive(false);
        texture3.SetActive(false);
        texture4.SetActive(false);

        // Turn on the selected panel
        switch (selected)
        {
            case 0:
                // Turn on the Texture1
                texture1.SetActive(true);
                // Save the active state of the Texture1
                PlayerPrefs.SetInt("Texture1Active", 1);
                break;
            case 1:
                // Turn on the Texture1
                texture2.SetActive(true);
                // Save the active state of the Texture1
                PlayerPrefs.SetInt("Texture2Active", 1);
                break;
            case 2:
                // Turn on the Texture1
                texture3.SetActive(true);
                // Save the active state of the Texture1
                PlayerPrefs.SetInt("Texture3Active", 1);
                break;
            case 3:
                // Turn on the Texture1
                texture4.SetActive(true);
                // Save the active state of the Texture1
                PlayerPrefs.SetInt("Texture4Active", 1);
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
