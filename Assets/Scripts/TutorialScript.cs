using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialScript : MonoBehaviour
{
    public CanvasSwap canvasController;
    public GameObject startingButton;
    public GameObject startingText;
    public GameObject timerText;
    private float timerNum = 3;
    private bool countdown = false;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(timerNum > 0 && countdown)
        {
            timerText.GetComponent<UnityEngine.UI.Text>().text = Mathf.Floor(timerNum+1).ToString();
            timerNum -= Time.deltaTime;
        }
        if(timerNum <= 0)
        {
            canvasController.SwitchCanvas();
        }
    }

    public void startTimer()
    {
        startingButton.SetActive(false);
        startingText.SetActive(true);
        timerText.SetActive(true);
        countdown = true;
    }
}
