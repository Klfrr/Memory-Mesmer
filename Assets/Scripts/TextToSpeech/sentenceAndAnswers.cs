using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class sentenceAndAnswers
{   
    //Holds the question being asked
    public string sentenceAsked;
    //array for answers
    public string[] sentenceAnswers;
    //hold value of correct answer
    public int correctAnswer;
    public AudioClip aClip;
}
