using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LetterTrackingScript : MonoBehaviour
{
    public Button letterButton;
    public Text letterLabel;
    public Text scoreLabel;
    
    public int repeats;
    //public int timer = 0;
    public int score = 0;
    public int mina;
    char[] randomLetters;
    int c = 0;

    public float currentwait = 2;

    public bool gameActive = false;
    public Text timeText;
    public int gameTime = 120;
    private float startTime = 0;
    public GameObject instructionsLabel;
    public int timers = 0;
    public float delay = 0;
    public float timerForFunction;
    private gameManager gameScript;

    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
        gameScript = FindObjectOfType<gameManager>();
        repeats = gameScript.currentDifficulty() * 5;
        mina = gameScript.currentDifficulty();
        letterButton.interactable = false;
        //StartCoroutine(StartGameAfterDelay());

        //Game starts
        gameActive = true;
        timeText.text = "Time: " + GetTimeDisplay(gameTime);
        startTime = Time.time;

        //StartCoroutine(instructionsTimer());
        StartCoroutine(startLetterTimer());
        letterButton.interactable = true;

        //StartCoroutine(instructionsTimer());
        //StartCoroutine(startWaitTimer());
        randomLetters = randLetterString();
    }

    // Update is called once per frame
    void Update()
    {
        //timerForFunction += Time.deltaTime;

        if(Time.time - startTime < gameTime)
        {
            float ElapsedTime = Time.time - startTime;
            SetTimeDisplay(gameTime - ElapsedTime);
        }
        else
        {
            if(gameActive)
            {
                gameActive = false;
                SetTimeDisplay(0);
                if(score == mina)
                    gameScript.gameComplete(score,"pass");
                if(score > mina/2)
                    gameScript.gameComplete(score,"same");
                else
                    gameScript.gameComplete(score,"fail");
            }
            //SceneManager.LoadScene(4);
        }
        scoreLabel.text = score.ToString();
        
    }

    //StartCoroutine(startWatchTimer());

    // function controls the timer
    public IEnumerator startLetterTimer()
    {
        int counter = 0;

        while(counter < repeats)
        {
            // Change to random Capital letter
            changeButton(randomLetters);

            // Enable button if clicked
            enableButton(letterButton);

            // increment counter
            counter++;

            if(counter >= repeats)
            {
                if(score == mina)
                    gameScript.gameComplete(score,"pass");
                if(score > mina/2)
                    gameScript.gameComplete(score,"same");
                else
                    gameScript.gameComplete(score,"fail");
            }

            // Wait for 2 seconds between changing letters
            yield return new WaitForSecondsRealtime(2);
        }
    }

    //Function works, but may need to implement logic to include at least one A
    char randomizeLetter()
    {
        // Capital letters between 65 and 90
        int randnum = 0;
        randnum = Random.Range(65, 90);

        return (char)randnum;
    }

    char[] randLetterString()
    {
        char[] letters = new char[repeats];
        for(int i = 0; i < repeats; i++)
        {
            int randnum = Random.Range(65, 90);
            letters[i] = (char)randnum;
        }

        int lastI = -1;
        // add a minimum number mina of A's
        for(int i = 0; i < mina; i++)
        {
            // pick random index
            int randI = Random.Range(0, repeats);

            if(randI == lastI)
            {
                randI = Random.Range(0, repeats);
            }

            letters[randI] = 'A';

            lastI = randI;
        }

        return letters;
    }

    public void changeButton(char[] randomLetters)
    {
        
        letterLabel.text = randLetterString()[c].ToString();
        c++;
        
    }

    
    public void checkButton(Text label)
    {
        //If the user clicks, disable button so they can't spam
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

/*        gameActive = true;
        timeText.text = "Time: " + GetTimeDisplay(gameTime);
        startTime = Time.time;

        StartCoroutine(instructionsTimer());
        StartCoroutine(startWaitTimer());
        letterButton.interactable = true;
*/
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
        
        // Deactivate the button while instructions are onscreen
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
}
