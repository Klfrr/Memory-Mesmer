using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NamingGameScript : MonoBehaviour
{
    public List<Button> buttonsList;
    public List<string> animalNameList;
    List<Animal> animalList;
    public List<GameObject> animalImage;
    //public GameObject lionImage;
    public Text scoreLabel;

    //Variables for checking game over;
    private gameManager gameScript;
    private int gameOver = 0;

    Button correctButton;
    public int score = 0;
    public int random;

    // Start is called before the first frame update
    void Start()
    {
        gameScript = FindObjectOfType<gameManager>();
        //Set all images to not appear
        reset();

        // create the objects for all the animals in the list
        for(int i = 0; i < animalNameList.Count; i++)
        {
            Animal correctAnimal = new Animal(animalNameList[i], i, animalImage[i]);
        }
        
        // Random Animal object is selected as the right answer, then its image is displayed.
        int cIndex = Random.Range(0, animalNameList.Count);
        string cAnimal = animalNameList[cIndex];
        Debug.Log(cAnimal + " is the answer.");

        // A random "correct" button is picked as the right answer
        int bIndex = Random.Range(0, buttonsList.Count);

        // The other buttons are filled in with other random answers that are NOT the same as the right answer
        // First Loop: Assign all the animalNameList into rand unpicked and shuffle
        List<string> randUnpicked = animalNameList;
        for (int b = 0; b < randUnpicked.Count; b++)
        {
            string temp = randUnpicked[b];
            int randomIndex = Random.Range(b, randUnpicked.Count);
            randUnpicked[b] = randUnpicked[randomIndex];
            randUnpicked[randomIndex] = temp;
        }

        // Second Loop: Now assign all the buttons to the animals contained in rand unpicked
        for(int i = 0; i < randUnpicked.Count; i++) //for each button
        {
            if (randUnpicked[i] == cAnimal) //if animal is the answer, log and set correct button 
            {
                checkDisplayImage(cAnimal);
                Debug.Log(buttonsList[i].name + " is the correct button.");
                correctButton = buttonsList[i];
            }
            buttonsList[i].transform.GetChild(0).GetComponent<Text>().text = randUnpicked[i];
        }

    }

    // Update is called once per frame
    void Update()
    {
        scoreLabel.text = score.ToString();
    }

    // Check the button to see if the clicked one was right; else run incorrect scenario
    public void CheckButton(Button button)
    {
        string bname = button.name;
        switch(bname)
        {
            case "NamingButton1":
                if(button == correctButton)
                {
                    setTextCorrect(button);
                } 
                else
                {
                    setTextIncorrect(button);
                }
                break;

            case "NamingButton2":
                if(button == correctButton)
                {
                    setTextCorrect(button);
                } 
                else
                {
                    setTextIncorrect(button);
                }
                break;

            case "NamingButton3":
                if(button == correctButton)
                {
                    setTextCorrect(button);
                } 
                else
                {
                    setTextIncorrect(button);
                }
                break;

            case "NamingButton4":
                if(button == correctButton)
                {
                    setTextCorrect(button);
                } 
                else
                {
                    setTextIncorrect(button);
                }
                break;

            case "NamingButton5":
                if(button == correctButton)
                {
                    setTextCorrect(button);
                } 
                else
                {
                    setTextIncorrect(button);
                }
                break;
        }

        // Wait 1 second, then change scenes
        // 
        //Jacky's Code 
        if(gameOver == 1)//Final image checker, not sure what kalista uses
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

    void checkDisplayImage(string ans)
    {
        switch(ans)
        {
            case "Lion": 
                animalImage[0].SetActive(true);
                break;
            case "Rhino":
                animalImage[1].SetActive(true);
                break;
            case "Camel":
                animalImage[2].SetActive(true);
                break;
            default:
                reset();
                break;
        }
    }

    void setAllUninteractable()
    {
        for(int u = 0; u < buttonsList.Count; u++)
            buttonsList[u].GetComponent<Button>().interactable = false;
    }

    // If user presses wrong button, this function will decrement the score and display the button being wrong.
     void setTextIncorrect(Button button)
    {
        button.GetComponent<Button>().interactable = false;
        Debug.Log(button.name + " is incorrect.");
        button.transform.GetChild(0).GetComponent<Text>().color = Color.red;
        button.transform.GetChild(0).GetComponent<Text>().text = "WRONG";
        score--;
    }

    // If user presses the right button, this function will increment the score and display the button being right.
    void setTextCorrect(Button button)
    {
        setAllUninteractable();
        Debug.Log(button.name + " is correct.");
        button.transform.GetChild(0).GetComponent<Text>().color = Color.green;
        button.transform.GetChild(0).GetComponent<Text>().text = "CORRECT";
        score++;
        gameOver++;
    }

    //Should repeat 3 times
    void reset()
    {
        for(int i = 0; i < animalImage.Count; i++)
            animalImage[i].SetActive(false);
    }

    public void ChangeScene()
    {
        SceneManager.LoadScene(0);
    }

    //Added code to transition scenes slowly if not gamemanger does not exist. Used to individual scene testing.
    private IEnumerator sceneDelay()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(7);
    
    }
}
