using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SerializationGameScript : MonoBehaviour
{
    int curVal = 100;
    int calc = 0;
    int correct = 0;
    private int input;
    public TMP_Text inputError;
    public TMP_Text outputText;
    public TMP_InputField userInput;
    
    // Start is called before the first frame update
    void Start()
    {
        calc = Random.Range(-10,-5);
        outputText.text = calc.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ReadInput(string s)
    {
        //parse input
        if(System.Int32.TryParse(s, out input))
        {
            
            if(input == (curVal+calc))
            {
                curVal += calc;
                calc = Random.Range(-10,-5);
                outputText.text = calc.ToString();
                correct++;
            }
            print(curVal + calc);
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
}
