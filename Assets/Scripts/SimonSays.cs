using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SimonSays : MonoBehaviour
{

    public GameObject[] buttons;
    int[] currentTest;
    int[] currentOrder;
    int level = 0;
    int buttonClicked = 0;
    bool alive = true;
    bool passed = false;
    Color32 red = new Color32(255,0,0,255);
    Color32 blue = new Color32(0, 0, 255, 255);
    Color32 green = new Color32(0, 255, 0, 255);
    Color32 purple = new Color32(255, 0, 255, 255);

    // Start is called before the first frame update
    void Start()
    {
        currentTest = new int[20];
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
        currentTest[level] = Random.Range(0, 3);
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
        Image image = click.GetComponent<Image>(); 
        var tempColor = image.color;
        tempColor.a = 1f;
        image.color = tempColor;
        //K: Color has to be changed all together, not just alpha
        /*
          image = GetComponent<Image>();
          var tempColor = image.color;
          tempColor.a = 1f;
          image.color = tempColor;
          */
        //yield return new WaitForSeconds(2); //K: New wait is reserved for functions with type public IEnumerator
        //click.GetComponent<Image>().color.a = ;

        buttonClicked += 1;

    }


    void blinkColor(GameObject button,int duration)
    {
       //button.GetComponent<Image>().color.a = ;
       //yield return new WaitForSeconds(duration);
       //button.GetComponent<Image>().color.a = 0;
    }
}
