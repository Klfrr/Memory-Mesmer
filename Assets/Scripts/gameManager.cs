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
            scenes[i] = i+2;
            scores[i] = 0;
        }

        int temp, placeHolder;

        for(int i = 0; i < arraySize; i++)
        {
            temp = Random.Range(0,arraySize);
            placeHolder = scenes[i];
            scenes[i] = scenes[temp];
            scenes[temp] = placeHolder;
        }

        for(int i = 0;i < arraySize; i++)
        {
            Debug.Log(scenes[i]);
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
            bufferTimer = 3;
            gameComplete(10);
            Debug.Log(scenes[currentScene]);
        }
    }

    public void gameComplete(int gameScore)
    {
        //calls the input score to save score, and then attempts next scene
        inputScore(gameScore);
        currentScene++;
        if(currentScene > arraySize)
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
        scores[scenes[currentScene]-2] = gameScore;
       
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
