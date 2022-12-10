using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PatternGameScript : MonoBehaviour
{
    //public GameObject button1, button2, button3, button4, button5, button6, button7, button8, button9;
    bool[] blackWhiteList;
    public GameObject[] buttonList;
    public GameObject WatchLabel;


    // Start is called before the first frame update
    void Start()
    {

        blackWhiteList = new bool[buttonList.Length];

        // set all buttons to black
        for(int b = 0; b < buttonList.Length; b++)
            setBlack(buttonList[b]);

        for( int i = 0; i < buttonList.Length; i++)
        {
            bool randNum = Random.value > 0.5f; // returns true 50% of the time
            //Debug.Log("Random Number for " + i + ": " + randNum);
            blackWhiteList[i] = randNum;
            if(blackWhiteList[i])
            {
                setWhite(buttonList[i]);
            }
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
        

        
    }

    void checkButton()
    {
        
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
}
