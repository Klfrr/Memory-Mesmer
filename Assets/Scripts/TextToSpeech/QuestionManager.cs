using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; // Remove after testing
public class QuestionManager : MonoBehaviour
{   
    [SerializeField] public AudioSource audioSource;
    public List<QuestionsAndAnswers> QnA;
    public GameObject[] options;
    public int currentQuestion;

    public Text QuestionTxt;
    public Text ScoreTxt;
    public Text SentenceNumTxt;
    public int totalQuestions = 0;
    public int score = 0;
    public int answeredQuestions = 0;
    public float delay = 8;
    public Button yesButton;
    public Button noButton;
    public float volume = 0.5f;

    //Game manager stuff
    private gameManager gameScript;
    //disable buttons at start and delay game until insturctions screen is done
    void Start()
    {   
        gameScript = FindObjectOfType<gameManager>();
        generateQuestion();
        //yesButton.interactable = false;
        //noButton.interactable = false;
        //StartCoroutine(StartGameAfterDelay());
        //StartCoroutine(playAudio());

    }


    public void correct()
    {
        score += 1;
        answeredQuestions+=1;
        QnA.RemoveAt(currentQuestion);
        ScoreTxt.text = "Score: " + score.ToString();
        generateQuestion();

        if(answeredQuestions == totalQuestions)
        {
            if(gameScript == null)
            {
                StartCoroutine(sceneDelay());
            }
            else
            {
                gameScript.gameComplete(score);
            }
        }


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
        answeredQuestions+=1;
        if(answeredQuestions == totalQuestions)
        {
            if(gameScript == null)
            {
                StartCoroutine(sceneDelay());
            }
            else
            {
                gameScript.gameComplete(score);
            }
        }
        
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

            AudioSource audioClip = GetComponent<AudioSource>();
            audioClip.clip = QnA[currentQuestion].aClip;
            audioClip.Play();

        }
        else
        {
            Debug.Log("Game is done");
        }

    
    }

    // Start is called before the first frame update

    /*private IEnumerator StartGameAfterDelay()
    {
        yield return new WaitForSeconds(delay);
        generateQuestion();
        yesButton.interactable = true;
        noButton.interactable = true;
    }*/

    //Added code to transition scenes slowly if not gamemanger does not exist. Used to individual scene testing.
    private IEnumerator sceneDelay()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(7);

    }

    public int getScore()
    {
        return score;
    }
    /*private IEnumerator playAudio(){

    yield return new WaitForSeconds(2);
    audioSource.PlayOneShot(QnA[0].aClip,volume);

    }*/

}
