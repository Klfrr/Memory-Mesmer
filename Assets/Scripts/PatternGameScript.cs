using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatternGameScript : MonoBehaviour
{
    public GameObject button1;
    public GameObject button2, button3, button4, button5, button6, button7, button8, button9;

    // Start is called before the first frame update
    void Start()
    {
        var colors = GetComponent<Button>().colors;
        colors.normalColor = Color.black;
        GetComponent<Button>().colors = colors;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setBlack()
    {
        var colors = GetComponent<Button>().colors;
        colors.normalColor = Color.black;
        GetComponent<Button>().colors = colors;
    }

    public void setWhite()
    {
        var colors = GetComponent<Button>().colors;
        colors.normalColor = Color.white;
        GetComponent<Button>().colors = colors;
    }
}
