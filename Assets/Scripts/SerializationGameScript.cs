using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class SerializationGameScript : MonoBehaviour
{
    public Sprite[] indicator;
    public int curVal = 100;
    public int calc = 0;
    public int correct = 0;
    private int input;
    public TMP_Text inputError;
    public TMP_Text outputText;
    public TMP_InputField userInput;
    public Text ScoreTxt;
    public int score = 0;
    public Text SequenceNumTxt;
    public int totalIterations = 0;
    
     //Timer info 
    public bool gameActive = false;
    public Text timeText;
    public int gameTime = 120;
    private float startTime = 0;

    // Start is called before the first frame update
    void Start()
    {
        timeText.text = "Time: " + GetTimeDisplay(gameTime);
        startTime = Time.time;
        gameActive = true;
        
        calc = Random.Range(-10,-5);
        outputText.text = "You start at 100\nCalculate and track the number\n" + calc.ToString();
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
            //SceneManager.LoadScene(4);
        }
    }

    public void ReadInput(string s)
    {
        totalIterations += 1;
        SequenceNumTxt.text = "Iteration: " + totalIterations.ToString();
        //parse input
        if(System.Int32.TryParse(s, out input))
        {
            
            if(input == (curVal+calc))
            {
                curVal += calc;
                score += 1;
                ScoreTxt.text = "Score: " + score.ToString();
                calc = Random.Range(-10,-5);
                outputText.text = calc.ToString();
                correct++;

            }
            print(curVal + calc);
            /*totalIterations += 1;
            SequenceNumTxt.text = "Sentence: " + totalIterations.ToString();*/
        }
        else if(s.Length == 0)
        {
            inputError.text = "Please input a value";
        }
        else
        {
            inputError.text = "Please input a number";
        }

        userInput.text = "";

        //win condition
        if(correct == 5)
        {
            outputText.text = "You win!";
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
