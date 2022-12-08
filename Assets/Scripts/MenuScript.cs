using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuScript : MonoBehaviour
{
    public enum MenuStates {Start, Settings, Play, Import, Tutorial}
    public MenuStates currentState;

    public GameObject startMenu;
    public GameObject settingsMenu;
    public GameObject playMenu;
    public GameObject importMenu;
    public GameObject tutorialMenu;


    // Always starts at main menu
    void Awake()
    {
        currentState = MenuStates.Start;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        switch (currentState){
            case MenuStates.Start:

                break;

            case MenuStates.Settings:

                break;

            case MenuStates.Play:

                break;

            case MenuStates.Import:

                break;
            
            case MenuStates.Tutorial:

                break;
        }
    
    }

    public void onButtonLog()
    {
        Debug.Log("Pressed");
    
        //Change menu state
    }

    public void deactivateScreens()
    {
        settingsMenu.SetActive(false);
        startMenu.SetActive(false);
        playMenu.SetActive(false);
        importMenu.SetActive(false);
        tutorialMenu.SetActive(false);

    }

    public void onStartScreen()
    {
        deactivateScreens();
        startMenu.SetActive(true);
    }

    public void onSettingsScreen()
    {
        deactivateScreens();

        settingsMenu.SetActive(true);
    }

    public void toTutorialMain()
    {
        deactivateScreens();

        tutorialMenu.SetActive(true);
    }

    public void toImages()
    {
        deactivateScreens();

    }

    public void toGames()
    {
        deactivateScreens();
    }

    public void toSimonSays()
    {
        deactivateScreens();

    }

    public void toScoresScreen()
    {
        deactivateScreens();
        
    }

    public void toPlayScreen()
    {
        deactivateScreens();

        playMenu.SetActive(true);
    }

    public void exitGame()
    {
        Application.Quit();

        Debug.Log("Exit Successful");
    }

    public void toImport()
    {
        deactivateScreens();

        importMenu.SetActive(true);

    }


}
