using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LetterTrackingScript : MonoBehaviour
{
    public Button letterButton;
    public Text letterLabel;
    public Text scoreLabel;
    
    public static int repeats;
    //public int timer = 0;
    public int score = 0;
    public int totalA = 0;
    public int mina;
    char[] randomLetters;
    //int f = 0;

    public float currentwait = 2;

    public bool gameActive = false;
    public Text timeText;
    public int gameTime = 120;
    private float startTime = 0;
    public GameObject instructionsLabel;
    public int timers = 0;
    public float delay;
    public float timerForFunction;
    private gameManager gameScript;
    private int chosenRepeats = 0;

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

        randomLetters = new char[repeats]; // this?
        //StartCoroutine(instructionsTimer());
        StartCoroutine(startLetterTimer());
        letterButton.interactable = true;

        //StartCoroutine(instructionsTimer());
        //StartCoroutine(startWaitTimer());
        randomLetters = randLetterString();
        Debug.Log("Random Letters Array: " + randomLetters.ToString());

        foreach (char letter in randomLetters)
        {
            if(letter == 'A')
                totalA++;
        }

    }

    // Update is called once per frame
    void Update()
    {
        //timerForFunction += Time.deltaTime;

   /*     if(Time.time - startTime < gameTime)
        {
            float ElapsedTime = Time.time - startTime;
            SetTimeDisplay(gameTime - ElapsedTime);
        }
        else
        {
            if(gameActive)
            {
                //Vincent, normalizes score to 4
                if(score > 0)
                    {
                        score = (int)((double)score / chosenRepeats * 4);
                    }
                gameActive = false;
                SetTimeDisplay(0);
                if(score == totalA)
                    gameScript.gameComplete(score,"pass");
                if(score > totalA/2)
                    gameScript.gameComplete(score,"same");
                else
                    gameScript.gameComplete(score,"fail");
            }
            //SceneManager.LoadScene(4);
        }*/

        scoreLabel.text = score.ToString();
        
    }

    //StartCoroutine(startWatchTimer());

    // function controls the timer
    public IEnumerator startLetterTimer()
    {
        int counter = 0;

        while(counter < repeats)
        {
            // Change Label to random Capital letter
            // Debug.Log("Index c: " + counter.ToString());
            letterLabel.text = randomLetters[counter].ToString();
            //changeLabel(counter);

            // Enable button if ready
            enableButton(letterButton);

            // increment counter
            counter++;

            if(counter >= repeats)
            {
                if(score == totalA)
                    gameScript.gameComplete(score,"pass");
                if(score > totalA/2)
                    gameScript.gameComplete(score,"same");
                else
                    gameScript.gameComplete(score,"fail");
            }

            // Wait for 2 seconds between changing letters
            yield return new WaitForSecondsRealtime(delay);
        }
    }

    //Function works, but may need to implement logic to include at least one A
    // Outputs one character at a time
    char randomizeLetter()
    {
        // Capital letters between 65 and 90
        int randnum = 0;
        randnum = Random.Range(65, 90);

        if(randnum == 65)
        {
            chosenRepeats++;
        }

        return (char)randnum;
    }

    // Randomizes a whole char array and adds a minimum # of a's
    char[] randLetterString()
    {
        char[] letters = new char[repeats];
        for(int i = 0; i < repeats; i++)
        {
            int randnum = Random.Range(65, 90);
            if(randnum == 65)
            {
                chosenRepeats++;
            }
            letters[i] = (char)randnum;
        }

        // add a minimum number mina of A's
        // find UNIQUE indeces
        Debug.Log(mina);

        for(int i = 0; i < mina; i++)
        {
            // pick random index
            int randI = Random.Range(0, repeats);

            // Use Recursion so A won't be shown again
            int ind = recursiveA(letters, randI);

            letters[ind] = 'A';

        }

        /*
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
        */

        return letters;
    }

    int recursiveA(char[] letters, int k)
    {
        if(letters[k] == 'A')
        {
            int randI = Random.Range(0, repeats);
            return recursiveA(letters, randI);
        }
        else
            return k;
    }
/*
    public void changeLabel(int f)
    {
        letterLabel.text = randLetterString()[f].ToString();
    }
*/
    
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
/* 
    private IEnumerator StartGameAfterDelay()
    {
        yield return new WaitForSeconds(delay);

       gameActive = true;
        timeText.text = "Time: " + GetTimeDisplay(gameTime);
        startTime = Time.time;

        StartCoroutine(instructionsTimer());
        StartCoroutine(startWaitTimer());
        letterButton.interactable = true;
*/
   // }

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
