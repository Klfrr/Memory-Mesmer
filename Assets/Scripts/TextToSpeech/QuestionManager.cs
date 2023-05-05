using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; // Remove after testing
public class QuestionManager : MonoBehaviour
{   
    [SerializeField] public AudioSource audioSource;
    public List<sentenceAndAnswers> senAndAns;
    public GameObject[] options;
    public int currentSentence;

    public Text QuestionTxt;
    public Text ScoreTxt;
    public Text SentenceNumTxt;
    public int totalSentences = 0;
    public int sentenceNumber = 0;
    public int score = 0;
    public int answeredSentences = 0;
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
        totalSentences = gameScript.currentDifficulty(); //prevents first sentence from being generated.
        generateQuestion();
        //yesButton.interactable = false;
        //noButton.interactable = false;
        //StartCoroutine(StartGameAfterDelay());
        //StartCoroutine(playAudio());

    }


    public void correct()
    {
        score += 1;
        answeredSentences+=1;
        senAndAns.RemoveAt(currentSentence);
        ScoreTxt.text = "Score: " + score.ToString();
        generateQuestion();

        if(answeredSentences == totalSentences)
        {
            if(gameScript == null)
            {
                StartCoroutine(sceneDelay());
            }
            else
            {
                //normalizes score to 4
                if(score > 0)
                    {
                        score = (int)((double)score / totalSentences * 4);
                    }
                if(score == totalSentences)
                    gameScript.gameComplete(score,"pass");
                else if(score > totalSentences /2)
                    gameScript.gameComplete(score,"same");
                else
                    gameScript.gameComplete(score,"fail");
            }
        }


    }

    void SetAnswers()
    {
        for(int i = 0; i < options.Length; i++)
        {
            options[i].GetComponent<AnswersScript>().isCorrect = false;
            options[i].transform.GetChild(0).GetComponent<Text>().text = senAndAns[currentSentence].sentenceAnswers[i];

            if(senAndAns[currentSentence].correctAnswer == i + 1)
            {
                options[i].GetComponent<AnswersScript>().isCorrect = true;
            }
        }
    }

    public void wrong()
    {

        senAndAns.RemoveAt(currentSentence);
        generateQuestion();
        answeredSentences += 1;
        if(answeredSentences == totalSentences)
        {
            if(gameScript == null)
            {
                StartCoroutine(sceneDelay());
            }
            else
            {
                //Vincent, normalizes score to 4
                if(score > 0)
                    {
                        score = (int)((double)score / (double)totalSentences * 4);
                    }
                if(score == totalSentences)
                    gameScript.gameComplete(score,"pass");
                else if(score > totalSentences /2)
                    gameScript.gameComplete(score,"same");
                else
                    gameScript.gameComplete(score,"fail");
            }
        }
        
    }

    void generateQuestion()
    {
        if(senAndAns.Count > 0)
        {
            sentenceNumber += 1;
            currentSentence = Random.Range(0, senAndAns.Count);
            SentenceNumTxt.text = "Sentence: " + sentenceNumber.ToString();
            QuestionTxt.text = senAndAns[currentSentence].sentenceAsked;
            SetAnswers();

            AudioSource audioClip = GetComponent<AudioSource>();
            audioClip.clip = senAndAns[currentSentence].aClip;
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
        //Vincent, normalizes score to 4
        if(score > 0)
            {
                score = (int)((double)score / (double)totalSentences * 4);
            }
        return score;
    }

    public string getResults()
    {  
        if(score == totalSentences)
            return "pass";
        else if(score > totalSentences /2)
            return "same";
        else
            return "fail";
    }
    /*private IEnumerator playAudio(){

    yield return new WaitForSeconds(2);
    audioSource.PlayOneShot(QnA[0].aClip,volume);

    }*/

}
