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

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(startWaitTimer());
    }

    // Update is called once per frame
    void Update()
    {
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
}
