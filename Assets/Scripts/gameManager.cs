using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameManager : MonoBehaviour
{
    private const int arraySize = 6;
    private int[] scenes = new int[arraySize];
    private double[] scores = new double[arraySize];
    private int currentScene;
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        int temp;
        currentScene = 0;
        bool exist = false;
        int i =  0;
        scenes[0] = 0;
        scenes[1] = 4;
        scenes[2] = 2;

        //loops to load the scene array with the sceneNodes order
        //Have to add code later to make sure certain patterns do not occur
        //Error checking
        /*while(i<arraySize)
        {
            exist = false;
            temp = Random.Range(2, 7);
            //checks for any dupes
            for(int j = 0; j < arraySize; j++)
            {
                if(scenes[i] == scenes[j] && i != j)
                {
                    exist = true;
                }
            }
            if(!exist)
            {
                scenes[i] = temp;
                scores[i] = 0;
                i++;
            }
        }*/
    }

    // Update is called once per frame
    void Update()
    {
        //Testing Code, comment out when implemented
        if(Input.GetKeyDown("space"))
        {
            gameComplete(10);
            Debug.Log("Space");
        }   
    }

    public void gameComplete(int gameScore)
    {
        //calls the input score to save score, and then attempts next scene
        inputScore(gameScore);
        currentScene++;
        if(currentScene > arraySize)
        {
            Debug.Log(scores[currentScene-1]);
            finishGame();
        }
        else
        {
            SceneManager.LoadScene(scenes[currentScene]);
        }
    }

    private void inputScore(int gameScore)
    {
        scores[scenes[currentScene]] = gameScore;
       
    }

    private void finishGame()
    {
        //Add code to upload scores
    }

    public void quitGame()
    {
        for(int i = 0; i < arraySize; i++)
        {
            scores[i] = 0;
        }
        Destroy(gameObject);
    }


}
