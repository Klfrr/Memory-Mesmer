using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Mono.Data.Sqlite;
using System;
using System.Data;
using System.IO;

public class gameManager : MonoBehaviour
{
    private const int arraySize = 7;
    private int[] scenes = new int[arraySize];
    private double[] scores = new double[arraySize];
    private int currentScene;
    private Touch touch;
    private float bufferTimer;
    private UIManager userInfo;

    private string gameType = "";
    private int pastValue;
    private static GameObject onlyInstance = null;

    // Start is called before the first frame update
    void Start()
    {
        gameType = "Full";
        userInfo = FindObjectOfType<UIManager>();
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
            temp = UnityEngine.Random.Range(1,arraySize);
            placeHolder = scenes[i];
            scenes[i] = scenes[temp];
            scenes[temp] = placeHolder;
        }

        if(onlyInstance == null)
        {
            onlyInstance = gameObject;
        }
        else
        {
            Destroy(gameObject);
            
        }

    }

    // Update is called once per frame
    void Update()
    {
        /*
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
        */
    }

    public void gameComplete(int gameScore)
    {
        //calls the input score to save score, and then attempts next scene
        pastValue = SceneManager.GetActiveScene().buildIndex;
        inputScore(gameScore);
        currentScene++; 
        if(gameType == "Single")
        {
            SceneManager.LoadScene(8);
        }
        else
        {
            StartCoroutine(sceneChange());
        }
    }

    private void inputScore(int gameScore)
    {
        if(gameType == "Single")
        {
            scores[pastValue-1] = gameScore;
        }
        else
        {
            scores[scenes[currentScene]-1] = gameScore;
        }
    }

    private void finishGame()
    {
        
            DateTime currentTime = DateTime.Now;

            //Add code to upload scores
            SceneManager.LoadScene(8);

            string dataBaseConn = "URI=file:" + Application.dataPath + "/Database/Database.db"; 

            //Creates the connection to the database
            IDbConnection dbconn;
            dbconn = new SqliteConnection(dataBaseConn);
            dbconn.Open();

            string scoreValues = "(";
            scoreValues = scoreValues + "\"" + userInfo.getUserName() + "\"," + "\"" + currentTime.ToShortDateString() +"\"," + "\"" + currentTime.ToShortTimeString() +"\"";

            for(int i = 0; i < arraySize;i++)
            {
                scoreValues += ",";
                scoreValues += scores[i];
            }
            scoreValues += ")";

            IDbCommand cmnd = dbconn.CreateCommand();
            cmnd.CommandText = "INSERT INTO Scores (User,Date,Time,Orientation,Simon,Pattern,Naming,Serialization,Text2Speech,LetterTracking) VALUES" ;
            cmnd.CommandText += scoreValues;
            cmnd.ExecuteNonQuery();

            dbconn.Close();

        
    }

    public void quitGame()
    {
        for(int i = 0; i < arraySize; i++)
        {
            scores[i] = 0;
        }
        Destroy(gameObject);
    }

    private IEnumerator sceneChange()
    {
        yield return new WaitForSeconds(2);
        if(currentScene == arraySize)
        {
            finishGame();
        }
        else
        {
            SceneManager.LoadScene(scenes[currentScene]);
        }       
    }

    public void loadGameType(string type)
    {
        gameType = type;
    }

    public string getScore()
    {
        double value = 0;
        if(gameType == "Full")
        {
            for(int i = 0; i < arraySize; i++)
            {
                value += scores[i];
            }
            return value + "/" + "50";
        }
        else
        {
            value = scores[pastValue-1];
            return value + "/" + "5";
        }
    }

    public void destroySelf()
    {
        Destroy(gameObject);
    }
}
