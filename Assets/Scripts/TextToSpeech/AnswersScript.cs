using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnswersScript : MonoBehaviour
{   
    public bool isCorrect = false;
    public QuestionManager questionManager;
    public void answer()
    {
        if(isCorrect)
        {
            Debug.Log("correct answer");
            questionManager.correct();
        }
        else
        {
            Debug.Log("wrong answer");
            questionManager.wrong();
        }

    }
}
