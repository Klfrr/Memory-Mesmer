using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestionManager : MonoBehaviour
{   
    public List<QuestionsAndAnswers> QnA;
    public GameObject[] options;
    public int currentQuestion;

    public Text QuestionTxt;
    public Text ScoreTxt;
    public Text SentenceNumTxt;
    public int totalQuestions = 0;
    public int score = 0;

    void Start()
    {   
        generateQuestion();
    }

    public void correct()
    {
        score += 1;
        QnA.RemoveAt(currentQuestion);
        ScoreTxt.text = "Score: " + score.ToString();
        generateQuestion();

    }

    void SetAnswers()
    {
        for(int i = 0; i < options.Length; i++)
        {
            options[i].GetComponent<AnswersScript>().isCorrect = false;
            options[i].transform.GetChild(0).GetComponent<Text>().text = QnA[currentQuestion].Answers[i];

            if(QnA[currentQuestion].CorrectAnswer == i + 1)
            {
                options[i].GetComponent<AnswersScript>().isCorrect = true;
            }
        }
    }

    public void wrong()
    {

        QnA.RemoveAt(currentQuestion);
        generateQuestion();
        
    }

    void generateQuestion()
    {
        if(QnA.Count > 0)
        {
            totalQuestions += 1;
            currentQuestion = Random.Range(0, QnA.Count);
            SentenceNumTxt.text = "Sentence: " + totalQuestions.ToString();
            QuestionTxt.text = QnA[currentQuestion].Question;
            SetAnswers();

        }
        else
        {
            Debug.Log("Game is done");
        }

    
    }


    /*
    [System.Serializable]

    public class Question
    {
        public string questionInfo;
        public QuestionType questionType;
        public AudioClip qustionClip;
        public List<string> options;
        public string correctAns;
        public string question;

    }

    [System.Serializable]

    public enum QuestionType
    {
        TEXT,
        AUDIO
    }*/
}
