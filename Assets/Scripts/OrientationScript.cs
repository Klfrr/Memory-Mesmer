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
    private float difference;
    private DateTime currentTime;
    private double tempAccuracy;
    private gameManager gameScript;

    // Start is called before the first frame update
    void Start()
    {
        currentTime = DateTime.Now;
        gameScript = FindObjectOfType<gameManager>();
        
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
        Debug.Log(timeDifference);
        if(timeDifference < 1)
        {
            tempAccuracy = 100;
        }
        else
        {
            tempAccuracy = 100*(1/timeDifference);
        }
        tempAccuracy = Math.Round(tempAccuracy,2);
        string accuracyScore = "Accuracy: " + tempAccuracy;

        accuracy.text = accuracyScore;
    }  

    public void sceneChange()
    {   
        gameScript.gameComplete(10);
        //SceneManager.LoadScene(0);
    }
}
