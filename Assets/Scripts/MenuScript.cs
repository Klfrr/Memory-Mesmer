using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuScript : MonoBehaviour
{
    public enum MenuStates {Start, Settings, Play, Import, Tutorial, Games, Scores};
    public MenuStates currentState;

    public GameObject startMenu;
    public GameObject settingsMenu;
    public GameObject playMenu;
    public GameObject importMenu;
    public GameObject tutorialMenu;
    public GameObject scoreMenu;
    public GameObject selectGameMenu; 
    public GameObject patternScreen;
    public GameObject patternGame;
    public GameObject simonSaysGame;
    public GameObject simonSaysScreen;


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
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            QuitGame();
        }
    }

    public void QuitGame()
    {

        UnityEditor.EditorApplication.isPlaying = false;
        Debug.Log("Editor Exit Successful");
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
        scoreMenu.SetActive(false);
        selectGameMenu.SetActive(false);
        importMenu.SetActive(false);
        tutorialMenu.SetActive(false);

        patternGame.SetActive(false);
        simonSaysGame.SetActive(false);
        simonSaysScreen.SetActive(false);
        

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
        selectGameMenu.SetActive(true);
    }

    public void toSimonSays()
    {
        deactivateScreens();
        simonSaysGame.SetActive(true);
        
    }

    public void toPatternScreen()
    {
        deactivateScreens();
        patternScreen.SetActive(true);
    }

    public void toScoresScreen()
    {
        deactivateScreens();
        scoreMenu.SetActive(true);
        
    }

    public void toPlayScreen()
    {
        deactivateScreens();

        playMenu.SetActive(true);
    }

    public void exitGame()
    {
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        Debug.Log("Editor Exit Successful");
        #endif
        Application.Quit();
        Debug.Log("Exit Successful");
    }

    public void toImport()
    {
        deactivateScreens();

        importMenu.SetActive(true);

    }

    public void toPatternGame()
    {
        deactivateScreens();

        patternGame.SetActive(true);
    }

    public void toSimonScreen()
    {
      SceneManager.LoadScene(2);
    }

    public void toMatchTwo()
    {
        SceneManager.LoadScene(1);
    }
    
    public void toMainMenu()
    {
        SceneManager.LoadScene(0);
    }

}
