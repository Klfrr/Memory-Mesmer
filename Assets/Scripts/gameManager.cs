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
    private Touch touch;
    private float bufferTimer;
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        currentScene = 0;

        //loops to load the scene array with the sceneNodes order
        //Have to add code later to make sure certain patterns do not occur
        //Error checking

        for(int i = 0; i < arraySize; i++)
        {
            scenes[i] = i+1;
            scores[i] = 0;
        }

        int temp, placeHolder;

        for(int i = 1; i < arraySize; i++)
        {
            temp = Random.Range(1,arraySize);
            placeHolder = scenes[i];
            scenes[i] = scenes[temp];
            scenes[temp] = placeHolder;
        }
    }

    // Update is called once per frame
    void Update()
    {
        bufferTimer -= Time.deltaTime;
        if(Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);
        }
        //Testing Code, comment out when implemented
       if(touch.phase == TouchPhase.Moved && bufferTimer <= 0)
        {
            bufferTimer = 2;
            gameComplete(10);
        }
    }

    public void gameComplete(int gameScore)
    {
        //calls the input score to save score, and then attempts next scene
        inputScore(gameScore);
        currentScene++;
        if(currentScene == arraySize)
        {
            finishGame();
        }
        else
        {
            SceneManager.LoadScene(scenes[currentScene]);
        }        
    }

    private void inputScore(int gameScore)
    {
        Debug.Log(scenes[currentScene]-1);
        scores[scenes[currentScene]-1] = gameScore;
       
    }

    private void finishGame()
    {
        //Add code to upload scores
        SceneManager.LoadScene(7);
        for(int i =0; i < arraySize; i++)
        {
            Debug.Log("Scenes" + scenes[i] + " Score " + scores[i]);
        }
        Destroy(gameObject);
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
