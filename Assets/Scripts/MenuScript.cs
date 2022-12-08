using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuScript : MonoBehaviour
{
    public enum MenuStates {Start, Settings}
    public MenuStates currentState;

    public GameObject startMenu;
    public GameObject settingsMenu;


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


}
