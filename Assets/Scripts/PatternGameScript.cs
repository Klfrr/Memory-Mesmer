using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PatternGameScript : MonoBehaviour
{
    
    //public GameObject button1, button2, button3, button4, button5, button6, button7, button8, button9;
    bool[] blackWhiteList; //1 is white
    public List<GameObject> buttonList;
    public GameObject WatchLabel;
    public GameObject backButton;
    public Text ScoreLabel;

    public int whiteCount = 0;
    public int whiteClicked = 0;
    public int score = 0;
    public int timer = 0;

    //Timer info 
     public bool gameActive = false;
    public Text timeText;
    public int gameTime = 120;
    private float startTime = 0;
    public int timers = 0;
    public float delay =8;
    public float timerForFunction;

    //Jacky Added Code
    private gameManager gameScript;

    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
        gameScript = FindObjectOfType<gameManager>();

        //Disable buttons before watching
        WatchLabel.SetActive(true);
        DisableButtons();

        //StartCoroutine(StartGameAfterDelay());
        //StartCoroutine(instructionsTimer());
        StartCoroutine(startWatchTimer());
        blackWhiteList = new bool[buttonList.Count];

        // set all buttons to black
        for(int b = 0; b < buttonList.Count; b++)
            setBlack(buttonList[b]);

        for( int i = 0; i < buttonList.Count; i++)
        {
            bool randNum = Random.value > 0.5f; // returns true 50% of the time
            //Debug.Log("Random Number for " + i + ": " + randNum);
            blackWhiteList[i] = randNum;
            if(blackWhiteList[i]) //if button is 1 value in the bool list
            {
                setWhite(buttonList[i]); // make white 
                whiteCount++;
            }
        }
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
                gameActive = false;
                SetTimeDisplay(0);
                gameScript.gameComplete(score);
            }
            //SceneManager.LoadScene(4);
        }
        }
        ScoreLabel.text = score.ToString();
    }

    // function controls the timer
    public IEnumerator startWatchTimer()
    {
        while(timer > 0)
        {
/*             for(int i = 0; i < buttonList.Count; i++)
                buttonList[i].interactable = false; */

            for(int i = 0; i < timer; i++)
            {
                timer--;
                yield return new WaitForSeconds(1f);
            }
        }
        
        WatchLabel.SetActive(false);
        // set all buttons to black
        for(int b = 0; b < buttonList.Count; b++)
            setBlack(buttonList[b]);

        // Enable buttons after watching time
        EnableButtons();
    }

    public void EnableButtons()
    {
        for (int i = 0; i < buttonList.Count; i++)
            buttonList[i].GetComponent<Button>().interactable = true;
    }

    public void DisableButtons()
    {
        for (int i = 0; i < buttonList.Count; i++)
            buttonList[i].GetComponent<Button>().interactable = false;
    }

    //Uses a switch statement to check which button is being pressed and if it is correct. 
    void CheckButton(GameObject button)
    {
        button.GetComponent<Button>().interactable = false;
        string bname = button.name;
        Debug.Log(bname);
        switch(bname)
        {
            case "PatternButton1":
                if(blackWhiteList[0])
                {
                    setWhite(button);
                    setTextCorrect(button);
                } 
                else
                {
                    setBlack(button);
                    setTextIncorrect(button);
                }
                break;

            case "PatternButton2":
                if(blackWhiteList[1])
                {
                    setWhite(button);
                    setTextCorrect(button);
                } 
                else
                {
                    setBlack(button);
                    setTextIncorrect(button);
                }
                break;

            case "PatternButton3":
                if(blackWhiteList[2])
                {
                    setWhite(button);
                    setTextCorrect(button);
                } 
                else
                {
                    setBlack(button);
                    setTextIncorrect(button);
                }
                break;

            case "PatternButton4":
                if(blackWhiteList[3])
                {
                    setWhite(button);
                    setTextCorrect(button);
                } 
                else
                {
                    setBlack(button);
                    setTextIncorrect(button);
                }
                break;

            case "PatternButton5":
                if(blackWhiteList[4])
                {
                    setWhite(button);
                    setTextCorrect(button);
                } 
                else
                {
                    setBlack(button);
                    setTextIncorrect(button);
                }
                break;

            case "PatternButton6":
                if(blackWhiteList[5])
                {
                    setWhite(button);
                    setTextCorrect(button);
                } 
                else
                {
                    setBlack(button);
                    setTextIncorrect(button);
                }
                break;
            
            case "PatternButton7":
                if(blackWhiteList[6])
                {
                    setWhite(button);
                    setTextCorrect(button);
                } 
                else
                {
                    setBlack(button);
                    setTextIncorrect(button);
                }
                break;

            case "PatternButton8":
                if(blackWhiteList[7])
                {
                    setWhite(button);
                    setTextCorrect(button);
                } 
                else
                {
                    setBlack(button);
                    setTextIncorrect(button);
                }
                break;

            case "PatternButton9":
                if(blackWhiteList[8])
                {
                    setWhite(button);
                    setTextCorrect(button);
                } 
                else
                {
                    setBlack(button);
                    setTextIncorrect(button);
                }
                break;
        }

    }

    //Set colors
    public void setBlack(GameObject button)
    {
        button.GetComponent<Image>().color = Color.black;
    }

    public void setWhite(GameObject button)
    {
        button.GetComponent<Image>().color = Color.white;
    }

    // If user presses the right button, this function will increment the score and display the button being right.
    public void setTextCorrect(GameObject button)
    {
        Debug.Log(button.name + " is correct.");
        button.transform.GetChild(0).GetComponent<Text>().color = Color.green;
        button.transform.GetChild(0).GetComponent<Text>().text = "CORRECT";
        score++;
        whiteClicked++;

        //Jacky added code, Kalista double check this section
        if(whiteClicked == whiteCount)
        {
            if(gameScript == null)
            {
                StartCoroutine(sceneDelay());
            }
            else
            {
                gameScript.gameComplete(score);
            }
        }

    }

    // If user presses wrong button, this function will decrement the score and display the button being wrong.
    public void setTextIncorrect(GameObject button)
    {
        Debug.Log(button.name + " is incorrect.");
        button.transform.GetChild(0).GetComponent<Text>().color = Color.red;
        button.transform.GetChild(0).GetComponent<Text>().text = "X";
        score--;
    }

    public void reset()
    {

    }
    

    public void ChangeScene()
    {
        SceneManager.LoadScene(0);
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

    private IEnumerator StartGameAfterDelay()
    {
        yield return new WaitForSeconds(delay);

        gameActive = true;
        timeText.text = "Time: " + GetTimeDisplay(gameTime);
        startTime = Time.time;

        StartCoroutine(instructionsTimer());
        //StartCoroutine(startWaitTimer());
        WatchLabel.SetActive(true);
        
        blackWhiteList = new bool[buttonList.Count];

        // set all buttons to black
        for(int b = 0; b < buttonList.Count; b++)
            setBlack(buttonList[b]);

        for( int i = 0; i < buttonList.Count; i++)
        {
            bool randNum = Random.value > 0.5f; // returns true 50% of the time
            //Debug.Log("Random Number for " + i + ": " + randNum);
            blackWhiteList[i] = randNum;
            if(blackWhiteList[i]) //if button is 1 value in the bool list
            {
                setWhite(buttonList[i]); // make white 
                whiteCount++;
            }
        }
        StartCoroutine(startWatchTimer());


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
        
        WatchLabel.SetActive(false);
    }

    //Added code to transition scenes slowly if not gamemanger does not exist. Used to individual scene testing.
    private IEnumerator sceneDelay()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(7);
    
    }
}
