using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This swaps the canvas.
//Step 1 - insert game canvas into CanvasSwapper script
//Step 2 - set tutorial active and current game inactive 

public class CanvasSwap : MonoBehaviour
{
    public GameObject canvas1;
    public GameObject canvas2;

    void Start()
    {

    }

    public void SwitchCanvas()
    {
        canvas1.SetActive(false);
        canvas2.SetActive(true);
    }
}
