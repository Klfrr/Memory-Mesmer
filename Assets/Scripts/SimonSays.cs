using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SimonSays : MonoBehaviour
{

    [SerializeField] public GameObject[] buttons;
    private GameObject[] currentTest;
    private int[] currentOrder;
    private  int level = 0;
    private int buttonClicked = 0;
    private bool alive = true;
    private bool passed;

    // Start is called before the first frame update
    void Start()
    {
        currentTest = new GameObject[20];
        currentOrder = new int[20];
        passed = true; 
        addNextPattern();
    }

    // Update is called once per frame
    void Update()
    {
        if(!alive)
        {

        }
        if(passed)
        {
            addNextPattern();
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

    void flashPattern()
    {
        disableButtons();
        for(int i = 0; i < level; i++)
        {
            blinkColor(buttons[i], 3);
        }
        enableButtons();
    }

    void resetLevel()
    {
        for(int i = 0; i < currentOrder.Length;i++)
        {
            currentOrder[i] = -1;
        }
        buttonClicked = 0;
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
        /*
          image = GetComponent<Image>();
          var tempColor = image.color;
          tempColor.a = 1f;
          image.color = tempColor;
          */


        //Calls blink color which lights up the square and dims the light, user is unable to click during  this time.

        blinkColor(click, 1);
        buttonClicked += 1;
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
        Debug.Log("TestPrint");
        for(int i = 0;i < level;i++)
        {
            blinkColor(currentTest[i],1);
        }
        
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
