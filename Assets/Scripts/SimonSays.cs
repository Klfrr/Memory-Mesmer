using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SimonSays : MonoBehaviour
{

    [SerializeField] public GameObject[] buttons;
    GameObject[] currentTest;
    int[] currentOrder;
    int level = 0;
    int buttonClicked = 0;
    bool alive = true;
    bool passed = false;

    // Start is called before the first frame update
    void Start()
    {
        currentTest = new GameObject[20];
        currentOrder = new int[20];
    }

    // Update is called once per frame
    void Update()
    {
        if(!alive)
        {

        }
        if(passed)
        {

        }
    }

    void addNextPattern()
    {
        int testValue = Random.Range(0, 3);
        currentTest[level] = buttons[testValue];
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

    void eachClick(GameObject click)
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
        disableButtons();
        timer(2); //K: New wait is reserved for functions with type public IEnumerator
        blinkColor(click, 2);
        buttonClicked += 1;
        enableButtons();
    }


    void blinkColor(GameObject button,int duration)
    {
        Image temp = button.GetComponent<Image>();
        var tempColor = temp.color;
        tempColor.a = 1f;
        temp.color = tempColor;
        timer(duration);
        tempColor.a = 0f;
        temp.color = tempColor;
    }

    public IEnumerator timer(int delay)
    {
        yield return new WaitForSeconds(delay);
    }

    void  enableButtons()
    {
        for(int i = 0; i < buttons.Length;i++)
        {
            buttons[i].GetComponent<Button>().interactable = true;
        }
    }

    void disableButtons()
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].GetComponent<Button>().interactable = false;
        }
    }


}
