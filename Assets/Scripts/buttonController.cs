using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class buttonController : MonoBehaviour
{
    private gameManager gameScript;

    void Start()
    {
        gameScript = FindObjectOfType<gameManager>();
    }
    //Might Not do this 
    /*public void toTutorialMenu()
    {

    }*/
    public void mainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void startGame()
    {
        SceneManager.LoadScene(1);  
    }

    public void toOrientation()
    {
        gameScript.loadGameType("Single");
        SceneManager.LoadScene(1);    
    }
    
    public void toSimon()
    {
        gameScript.loadGameType("Single");
        SceneManager.LoadScene(2);    
    }

    public void toPattern()
    {
        gameScript.loadGameType("Single");
        SceneManager.LoadScene(3);
    }

    public void toNamingAnimals()
    {
        gameScript.loadGameType("Single");
        SceneManager.LoadScene(4);    
    }

    public void toSerialization()
    {
        gameScript.loadGameType("Single");
        SceneManager.LoadScene(5);    
    }

    public void toText2Speech()
    {
        gameScript.loadGameType("Single");
        SceneManager.LoadScene(6);    
    }

    public void accountManage()
    {
        
        SceneManager.LoadScene(9);
    }

    public void toScoresMoca()
    {
        
        SceneManager.LoadScene(10);
        
    }
    public void settings()
    {
        SceneManager.LoadScene(11);
    }
     public void toMoca()
    {
        
        SceneManager.LoadScene(12);
    }





    public void exitGame()
    {
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        Debug.Log("Editor Exit Successful");
        #endif
        Application.Quit();
        PlayerPrefs.DeleteAll();
        Debug.Log("Exit Successful");
    }
    

}