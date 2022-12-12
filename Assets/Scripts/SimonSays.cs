using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SimonSays : MonoBehaviour
{

    [SerializeField] public GameObject[] buttons;
    private GameObject[] currentTest;
    private  int level = 0;
    private int buttonClicked = 0;
    private bool alive = true;
    private bool passed;

    // Start is called before the first frame update
    void Start()
    {
        currentTest = new GameObject[10];
        passed = true; 
        addNextPattern();
    }

    // Update is called once per frame
    void Update()
    {
        if(!alive)
        {
            disableButtons();
        }
        if(passed)
        {
            StartCoroutine(nextPatternDelay());
        }
    }

    private void addNextPattern()
    {
        passed = false; 
        buttonClicked = 0;
        int testValue = Random.Range(0, 3);
        currentTest[level] = buttons[testValue];
        level++;
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

        //Calls blink color which lights up the square and dims the light, user is unable to click during  this time.
        if(GameObject.ReferenceEquals(click, currentTest[buttonClicked]))
        {
            blinkColor(click, 1);
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
        }
    }


    private void blinkColor(GameObject button,float duration)
    {
        disableButtons();
        Image temp = button.GetComponent<Image>();
        var tempColor = temp.color;
        tempColor.a = .65f;
        temp.color = tempColor;
        StartCoroutine(colorTimer(duration,temp));
    }

    private IEnumerator colorTimer(float delay,Image currentTile)
    {
        var tempColor = currentTile.color;
        yield return new WaitForSeconds(delay);
        tempColor.a = 1f;
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
        if(i == level)
        {
            enableButtons();
        }
        else
        {
            GameObject tempButton = currentTest[i];
            Image temp = tempButton.GetComponent<Image>();
            var tempColor = temp.color;
            tempColor.a = .65f;
            temp.color = tempColor;
            yield return new WaitForSeconds(2);
            tempColor.a = 1f;
            temp.color = tempColor;
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
}
