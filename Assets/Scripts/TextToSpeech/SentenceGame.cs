using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class SentenceGame : MonoBehaviour
{ 
    public bool gameActive = false;
    public Text timeText;
    public int gameTime = 120;
    private float startTime = 0;
    public GameObject instructionsLabel;
    public int timer = 0;
    public float delay =8;
    public float timerForFunction;
    private gameManager gameScript;

     // Start is called before the first frame update
    void Start()
    {   
        gameScript = FindObjectOfType<gameManager>();
        StartCoroutine(StartGameAfterDelay());
        instructionsLabel.SetActive(true);

        StartCoroutine(instructionsTimer());
    }

    // Update is called once per frame
    void Update()
    {
        timerForFunction += Time.deltaTime;
        if (timerForFunction > delay)
        {
            if(Time.time - startTime < gameTime)
        {
            float ElapsedTime = Time.time - startTime;
            SetTimeDisplay(gameTime - ElapsedTime);
        }
        else
        {
            if(gameActive)
            {
                QuestionManager scoreTracker = FindObjectOfType<QuestionManager>();
                gameActive = false;
                SetTimeDisplay(0);
                gameScript.gameComplete(scoreTracker.getScore());
            }
            //SceneManager.LoadScene(4);
        }
        }

        
    }

     private void SetTimeDisplay(float timeDisplay)
    {
        timeText.text = "Time: " + GetTimeDisplay(timeDisplay);
    }
    private string GetTimeDisplay (float timeToShow)
    {
        int secondsToShow = Mathf.CeilToInt(timeToShow);
        int seconds = secondsToShow % 60;
        string secondsDisplay = (seconds < 10 ) ? "0" + seconds.ToString() : seconds.ToString();
        int minutes = (secondsToShow - seconds) / 60;
        return minutes.ToString() + ":" + seconds.ToString();
    }

      public IEnumerator instructionsTimer()
    {
        while(timer > 0)
        {       
            for(int i = 0; i < timer; i++)
            {
                timer--;
                yield return new WaitForSeconds(1f);
            }
        }
        
        instructionsLabel.SetActive(false);
    }

    // Start is called before the first frame update

    private IEnumerator StartGameAfterDelay()
    {
        yield return new WaitForSeconds(delay);

        gameActive = true;
        timeText.text = "Time: " + GetTimeDisplay(gameTime);
        startTime = Time.time;

        StartCoroutine(instructionsTimer());
    }

}
