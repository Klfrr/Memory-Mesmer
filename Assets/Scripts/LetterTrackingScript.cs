using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LetterTrackingScript : MonoBehaviour
{
    public Button letterButton;
    public Text letter;
    public Text scoreLabel;
    
    public int repeats;
    public int timer = 0;
    public int score = 0;

    public float currentwait = 2;

    public bool gameActive = false;
    public Text timeText;
    public int gameTime = 120;
    private float startTime = 0;
    public GameObject instructionsLabel;
    public int timers = 0;
    public float delay =8;
    public float timerForFunction;
    private gameManager gameScript;

    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
        letterButton.interactable = false;
        gameScript = FindObjectOfType<gameManager>();
        StartCoroutine(StartGameAfterDelay());
        
        instructionsLabel.SetActive(true);

        StartCoroutine(instructionsTimer());
        //StartCoroutine(startWaitTimer());
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
                if(!gameActive)
                    {
                        gameActive = true;
                        gameOver(score);
                        SetTimeDisplay(0);
                    }
            }
        }
        scoreLabel.text = score.ToString();

    }

    //StartCoroutine(startWatchTimer());

    // function controls the timer
    public IEnumerator startWaitTimer()
    {
        int counter = 0;

        while(counter < repeats)
        {
            // Change to random Capital letter
            changeButton();

            // Enable button if clicked
            enableButton(letterButton);

            // increment counter
            counter++;


            // Wait for 2 seconds between changing letters
            yield return new WaitForSecondsRealtime(2);
        }
        gameScript.gameComplete(score);
    }

    //Function works, but may need to implement logic to include at least one A
    char randomizeLetter()
    {
        // Capital letters between 65 and 90
        int randnum = 0;
        randnum = Random.Range(65, 90);

        return (char)randnum;
    }

    public void changeButton()
    {
        letter.text = randomizeLetter().ToString();
    }

    
    public void checkButton(Text label)
    {
        disableButton(letterButton);

        if(label.text == "A")
            score++;
        else 
            score--;
    }

    void disableButton(Button button)
    {
        button.interactable = false;
    }  

    void enableButton(Button button)
    {
        button.interactable = true;
    }

    private IEnumerator StartGameAfterDelay()
    {
        yield return new WaitForSeconds(delay);

        gameActive = true;
        timeText.text = "Time: " + GetTimeDisplay(gameTime);
        startTime = Time.time;

        StartCoroutine(instructionsTimer());
        StartCoroutine(startWaitTimer());
        letterButton.interactable = true;

    }

      public IEnumerator instructionsTimer()
    {
        while(timers > 0)
        {       
            for(int i = 0; i < timers; i++)
            {
                timers--;
                yield return new WaitForSeconds(1f);
            }
        }
        
        instructionsLabel.SetActive(false);
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

    private void gameOver(int score)
    {

        gameScript.gameComplete(score);
    
    }
}
