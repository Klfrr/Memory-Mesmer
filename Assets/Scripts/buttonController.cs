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
    public void mainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void toOrientation()
    {
        SceneManager.LoadScene(1);    
    }
    
    public void toSimon()
    {
        SceneManager.LoadScene(2);    
    }

    public void toPattern()
    {
        SceneManager.LoadScene(3);
    }

    public void toNamingAnimals()
    {
        SceneManager.LoadScene(4);    
    }

    public void toSerialization()
    {
        SceneManager.LoadScene(5);    
    }

    public void toText2Speech()
    {
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