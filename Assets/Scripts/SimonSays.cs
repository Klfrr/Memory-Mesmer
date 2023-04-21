using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class SimonSays : MonoBehaviour
{

    [SerializeField] public GameObject[] buttons;
    private GameObject[] currentTest;
    public  Text levelText; 
    public Text playerHelper;
    public Text ButtonActivity;
    private int level = 0;
    private int buttonClicked = 0;
    private Color32 red = new Color32(255,0,0,255);
    private Color32 blue = new Color32(0,0,255,255);
    private Color32 green = new Color32(0,255,0,255);
    private Color32 yellow = new Color32(255,255,0,255);
    private Color32 white = new Color32(255,255,255,255);
    Color32[] colorArray = new Color32[4];
    private int[] blinkArray;
    private int patternVersion;
    private gameManager gameScript;
    private bool gameFinished = false;
    //Time info
    public Text timeText;
    public int gameTime = 120;
    private float startTime = 0;
    public int timer = 0;
    public float delay =8;
    public float timerForFunction;
    
    


    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
        StartCoroutine(StartGameAfterDelay());
        gameScript = FindObjectOfType<gameManager>();
        level = 5;
        currentTest = new GameObject[10];
        blinkArray = new int[10];
        colorArray[0] = red;
        colorArray[1] = blue;
        colorArray[2] = green;
        colorArray[3] = yellow;
        createPattern();
    }

    // Update is called once per frame
    void Update()
    {
        //If the player fails to pass, calls game over but with a lower level.
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
                if(!gameFinished)
                {
                    gameFinished = true;
                    gameOver(level-1);
                    SetTimeDisplay(0);
                }
            }
        }
    }
    


    //Useless code, not useful in this situation
    public void toMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    //create an array of random button values and chooses forwards or backwards.
    private void createPattern()
    {
        ButtonActivity.text = "Watch";
        buttonClicked = 0;
        int testValue;
        patternVersion = Random.Range(0,2);
        for(int i = 0; i < level; i++)
        {
            testValue = Random.Range(0, 4);
            currentTest[i] = buttons[testValue];
            blinkArray[i] = testValue;
        }
    
        testPrint();
    }

    public void eachClick(GameObject click)
    {
        //K: Changed from button to parameter click
        //K: GetComponent capitalized
        //Image image = click.GetComponent<Image>(); 
        //var tempColor = image.color;
        //tempColor.a = 1f;
        //image.color = tempColor;
        //K: Color has to be changed all together, not just alpha


        //Find the right color index for each button
        int colorIndex = 0;
        while(!(GameObject.ReferenceEquals(buttons[colorIndex],click)))
        {
            colorIndex++;
        }


        //Calls blink color which lights up the square and dims the light, user is unable to click during  this time.
        if(GameObject.ReferenceEquals(click, currentTest[buttonClicked]))
        {
            blinkColor(click, 1, colorIndex);
            buttonClicked += 1;
            ButtonActivity.text = "Continue";
            if(buttonClicked == level)
            {
                //If player passes the game, calls the gameover function with the currnet level
                gameOver(level);
            }
        }
        //If the players missclicks an object button, the game restarts the button clicked to 0, and says try again
        else
        {
            ButtonActivity.text = "Try \nAgain"; 
            blinkColor(click, 1, colorIndex);
            buttonClicked = 0;
        }
    }

    //Blink function to change the button color back and forth
    private void blinkColor(GameObject button,float duration, int colorIndex)
    {
        duration = duration/2;
        Image temp = button.GetComponent<Image>();
        var tempColor = temp.color;
        tempColor = colorArray[colorIndex];
        temp.color = tempColor;
        StartCoroutine(colorTimer(duration,temp));
    }

    //A timer to delay the total time a button color is blinked.
    private IEnumerator colorTimer(float delay,Image currentTile)
    {
        var tempColor = currentTile.color;
        yield return new WaitForSeconds(delay);
        tempColor = white;
        currentTile.color = tempColor;
        enableButtons();
    }

    //Calls the test color recursion with different values depending on the game version
    private void testPrint()
    {
        disableButtons();
        if(patternVersion == 0)
        {
            StartCoroutine(testColorRecursion(0,1,0));
        }
        else
        {
            StartCoroutine(testColorRecursion(level-1,-1,0));
        }
        
    }

    //Repeatidly calls itself to print the next button in the array
    private IEnumerator testColorRecursion(int i, int incrementor,int repeated)
    {
        if(repeated == level)
        {
            enableButtons();
            ButtonActivity.text = "Play";
            if(patternVersion == 0)
            {
                playerHelper.text = "Forward Pattern";
            }
            else
            {
                playerHelper.text = "Backward Pattern";
            }
        }
        else
        {
            GameObject tempButton = currentTest[i];
            Debug.Log("Button" + tempButton);
            Image temp = tempButton.GetComponent<Image>();
            var tempColor = colorArray[blinkArray[i]];
            temp.color = tempColor;
            yield return new WaitForSeconds(1);
            tempColor = white;
            temp.color = tempColor;
            yield return new WaitForSeconds(1);
            i += incrementor;
            repeated++;
            StartCoroutine(testColorRecursion(i,incrementor,repeated));
        }
    }

    //Enables all the buttons to be pressed again
    private void enableButtons()
    {
        Button tempButton;
        for(int i = 0; i < buttons.Length;i++)
        {
            tempButton = buttons[i].GetComponent<Button>();
            tempButton.interactable = true; 
        }
    }

    //Turns off all the buttons from being pressed
    private void disableButtons()
    {
        Button tempButton;
        for (int i = 0; i < buttons.Length; i++)
        {
               tempButton = buttons[i].GetComponent<Button>();
               tempButton.interactable = false; 
        }
    }
    
    //Useless code, was used before
    /*
    private void disableVisibility()
    {
        for(int i = 0; i <  buttons.Length;i++)
        {
            buttons[i].gameObject.SetActive(false);
        }
    }
    */

    //Edward's code
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

    //Calls the game manager script to go to next scene passing in a score, or for independent testing, goes to game over.
    private void gameOver(int score)
    {
        if(gameScript == null)
        {
            SetTimeDisplay(0);
            SceneManager.LoadScene(8);
        }
        else
        {
            gameScript.gameComplete(score);
        }
    }
    private IEnumerator StartGameAfterDelay()
    {
        yield return new WaitForSeconds(delay);
        timeText.text = "Time: " + GetTimeDisplay(gameTime);
        startTime = Time.time;
        string temp = "Level:" + (level).ToString();
        levelText.text =  temp;
        StartCoroutine(instructionsTimer());
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
        
    }
}
