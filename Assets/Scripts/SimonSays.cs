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
    public Text ButtonActivity;
    private int level = 0;
    private int buttonClicked = 0;
    private bool alive = true;
    private bool passed;
    private Color32 red = new Color32(255,0,0,255);
    private Color32 blue = new Color32(0,0,255,255);
    private Color32 green = new Color32(0,255,0,255);
    private Color32 yellow = new Color32(255,255,0,255);
    private Color32 white = new Color32(255,255,255,255);
    Color32[] colorArray = new Color32[4];
    private int[] blinkArray;
    //Time info
    public bool gameActive = false;
    public Text timeText;
    public int gameTime = 120;
    private float startTime = 0;


    // Start is called before the first frame update
    void Start()
    {
        currentTest = new GameObject[10];
        blinkArray = new int[10];
        passed = true; 
        colorArray[0] = red;
        colorArray[1] = blue;
        colorArray[2] = green;
        colorArray[3] = yellow;
        addNextPattern();
        string temp = "Level:" + (level).ToString();
        levelText.text =  temp;

        timeText.text = "Time: " + GetTimeDisplay(gameTime);
        startTime = Time.time;
        gameActive = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time - startTime < gameTime)
        {
            float ElapsedTime = Time.time - startTime;
            SetTimeDisplay(gameTime - ElapsedTime);
        }
        else
        {
            gameActive = false;
            SetTimeDisplay(0);
            SceneManager.LoadScene(4);
        }

        if(!alive)
        {
            disableButtons();
            disableVisibility();
            SceneManager.LoadScene(4);
        }
        if(passed)
        {
            string temp = "Level:" + (level+1).ToString();
            levelText.text =  temp;
            StartCoroutine(nextPatternDelay());
        }
    }

    public void toMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    private void addNextPattern()
    {
        ButtonActivity.text = "Watch";
        passed = false; 
        buttonClicked = 0;
        int testValue = Random.Range(0, 4);
        currentTest[level] = buttons[testValue];
        blinkArray[level] = testValue;
        level++;
        testPrint();
        disableButtons();
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

        int colorIndex = 0;
        while(!(GameObject.ReferenceEquals(buttons[colorIndex],currentTest[buttonClicked])))
        {
            colorIndex++;
        }


        //Calls blink color which lights up the square and dims the light, user is unable to click during  this time.
        if(GameObject.ReferenceEquals(click, currentTest[buttonClicked]))
        {
            blinkColor(click, 1, colorIndex);
            buttonClicked += 1;
            if(buttonClicked == level)
            {
                Debug.Log("Passed");
                passed = true;
            }
        }
        else
        {
            alive = false; 
            blinkColor(click, 1, colorIndex);
            buttonClicked += 1;
            

        }
    }


    private void blinkColor(GameObject button,float duration, int colorIndex)
    {
        duration = duration/2;
        Image temp = button.GetComponent<Image>();
        var tempColor = temp.color;
        tempColor = colorArray[colorIndex];
        temp.color = tempColor;
        StartCoroutine(colorTimer(duration,temp));
    }

    private IEnumerator colorTimer(float delay,Image currentTile)
    {
        var tempColor = currentTile.color;
        yield return new WaitForSeconds(delay);
        tempColor = white;
        currentTile.color = tempColor;
        enableButtons();
    }

    private void testPrint()
    {
        disableButtons();
        StartCoroutine(testColorRecursion(0));
    }

    private IEnumerator testColorRecursion(int i)
    {
        Debug.Log(blinkArray[i]);
        if(i == level)
        {
            enableButtons();
            ButtonActivity.text = "Play";
        }
        else
        {
            GameObject tempButton = currentTest[i];
            Image temp = tempButton.GetComponent<Image>();
            var tempColor = colorArray[blinkArray[i]];
            temp.color = tempColor;
            yield return new WaitForSeconds(1);
            tempColor = white;
            temp.color = tempColor;
            yield return new WaitForSeconds(1);
            i++;
            StartCoroutine(testColorRecursion(i));
        }
    }

    private IEnumerator nextPatternDelay()
    {
        passed = false;
        yield return new WaitForSeconds(3);
        addNextPattern();
    }

    private void enableButtons()
    {
        Button tempButton;
        for(int i = 0; i < buttons.Length;i++)
        {
            tempButton = buttons[i].GetComponent<Button>();
            tempButton.interactable = true; 
        }
    }

    private void disableButtons()
    {
        Button tempButton;
        for (int i = 0; i < buttons.Length; i++)
        {
               tempButton = buttons[i].GetComponent<Button>();
               tempButton.interactable = false; 
        }
    }
    
    private void disableVisibility()
    {
        for(int i = 0; i <  buttons.Length;i++)
        {
            buttons[i].gameObject.SetActive(false);
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
}
