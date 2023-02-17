using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class buttonController : MonoBehaviour
{
    //Might Not do this 
    /*public void toTutorialMenu()
    {

    }*/
    public void toSimon()
    {
        SceneManager.LoadScene(2);    
    }

    public void toPattern()
    {
        SceneManager.LoadScene(3);
    }

     public void toMoca()
    {
        SceneManager.LoadScene(0);
    }

        public void toMatchTwo()
    {
        SceneManager.LoadScene(1);
    }

    public void toScoresMatchTwo()
    {
        SceneManager.LoadScene(0);
        
    }
    
    public void toScoresSimon()
    {
        SceneManager.LoadScene(0);
        
    }

    public void toScoresPattern()
    {
        SceneManager.LoadScene(0);
        
    }

    public void toScoresMoca()
    {
        SceneManager.LoadScene(0);
        
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

    public void mainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void photoLibray()
    {
        SceneManager.LoadScene(0);
    }

    public void settings()
    {
        SceneManager.LoadScene(0);
    }

    public void accountManage()
    {
        SceneManager.LoadScene(0);
    }
    

}