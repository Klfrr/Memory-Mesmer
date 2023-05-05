using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class OrientationScript : MonoBehaviour
{
    public Text dateInput;
    public Text timeInput;
    public Text accuracy;
    public GameObject tutorialCanvas;
    private float difference;
    private DateTime currentTime;
    private double tempAccuracy;
    private gameManager gameScript;
    private int difficulty;

    // Start is called before the first frame update
    void Start()
    {
        showTutorial();
        currentTime = DateTime.Now;
        gameScript = FindObjectOfType<gameManager>();
        difficulty = gameScript.currentDifficulty();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void onClick()
    {
        string inputDate = dateInput.text + " " + timeInput.text;   

        DateTime testDate = DateTime.Parse(inputDate);

        double timeDifference = Math.Abs((testDate-currentTime).TotalHours);
        if(timeDifference < 1)
        {
            tempAccuracy = 100;
        }
        else
        {
            tempAccuracy = 100 - (10 * timeDifference);
        }
        tempAccuracy = Math.Round(tempAccuracy,2);
        string accuracyScore = "Accuracy: " + tempAccuracy;

        accuracy.text = accuracyScore;
    }  

    public void sceneChange()
    {
        Debug.Log(tempAccuracy);
        onClick();
        if(tempAccuracy >= difficulty*10)
            gameScript.gameComplete(5,"pass");
        else if(tempAccuracy >= difficulty * 7)
            gameScript.gameComplete(4,"same");
        else if(tempAccuracy >= difficulty * 5)
            gameScript.gameComplete(3,"same");
        else if(tempAccuracy >= difficulty * 3)
            gameScript.gameComplete(2,"same");
        else if(tempAccuracy >= difficulty * 1)
            gameScript.gameComplete(1,"same");
        else
            gameScript.gameComplete(0,"same");
    }

    public void showTutorial()
    {

    }
}
