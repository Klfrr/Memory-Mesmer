using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

// Lion, camel, and rhino pictures: https://www.memorylosstest.com/dl/moca-test-english-7-1.pdf
// Cat picture: https://coloringonly.com/pages/somali-cat-coloring-page/
// Dog Picture: https://edgcoloringpages.s3.us-east-2.amazonaws.com/1315-easy-realistic-dog-coloring-page.pdf
// Pig Picture: https://www.supercoloring.com/coloring-pages/fat-pig
// Rabbit picture: https://pngtree.com/element/down?id=NTMyOTQ3Mg==&type=1&time=1683263243&token=ZjVlNzdhNDlhNjc2OWFhYmFkNmEwN2ZjMmVmOWJmMjA=&t=0
// Tiger Picture: https://clipartix.com/tiger-clip-art-image-53726/
// Mouse Picture: https://www.deviantart.com/ashleyphotographics/art/FREE-Mouse-Lineart-316441007

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
    private int finalScore = 0;
    public int round = 0;

    Button correctButton;
    public int score = 0;
    public int random;

    // Start is called before the first frame update
    void Start()
    {
        gameScript = FindObjectOfType<gameManager>();
        finalScore = gameScript.currentDifficulty();
        //Set all images to not appear
        resetImages();

        // create the objects for all the animals in the list (unused for now)
        for(int i = 0; i < animalNameList.Count; i++)
        {
            Animal correctAnimal = new Animal(animalNameList[i], i, animalImage[i]);
        }

        // A random "correct" button is picked as the right answer
        correctButton = randomizeButtons(buttonsList, animalNameList);

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
        if(round >= finalScore) // After 3 rounds, the game will end
        {
            if(gameScript == null)
            {
                StartCoroutine(sceneDelay());
            }
            else
            {
                //Vincent, normalize score to 4
                if(score > 0)
                {
                    score = (int)((double)score / (double)finalScore * 4);
                }
                else
                {
                    score = 0;
                }
                
                if(score == finalScore)
                    gameScript.gameComplete(score,"pass");
                else if(score > finalScore/2)
                    gameScript.gameComplete(score,"same");
                else
                    gameScript.gameComplete(score,"fail");
            }
        }
    }

    Button randomizeButtons(List<Button> buttonsList,  List<string> animalNameList)
    {
        // Random Animal object is selected as the right answer, then its image is displayed.
        int cIndex = Random.Range(0, animalNameList.Count);
        string cAnimal = animalNameList[cIndex];
        Debug.Log(cAnimal + " is the answer.");

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

        Button correctButton = null;
        // Second Loop: Now assign all the buttons to the animals contained in rand unpicked
        bool setAnswer = false;
        for(int i = 0; i < buttonsList.Count; i++) //for each button
        {
            if (randUnpicked[i] == cAnimal) //if animal is the answer, log and set correct button 
            {
                checkDisplayImage(cAnimal);
                Debug.Log(buttonsList[i].name + " is the correct button.");
                correctButton = buttonsList[i];
                setAnswer = true;
            }
            buttonsList[i].transform.GetChild(0).GetComponent<Text>().text = randUnpicked[i];
        }

        if(!setAnswer)
        {
            checkDisplayImage(cAnimal);
            correctButton = buttonsList[Random.Range(0, buttonsList.Count)];
            correctButton.transform.GetChild(0).GetComponent<Text>().text = cAnimal;
        }
        setAllInteractable();

        // Remove correct answer so it won't be used again
        animalNameList.Remove(cAnimal);

        if(correctButton != null)
            return correctButton;
        else
            return null;
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
            case "Cat":
                animalImage[3].SetActive(true);
                break;
            case "Dog":
                animalImage[4].SetActive(true);
                break;
            case "Pig":
                animalImage[5].SetActive(true);
                break;
            case "Rabbit":
                animalImage[6].SetActive(true);
                break;
            case "Tiger":
                animalImage[7].SetActive(true);
                break;
            case "Mouse":
                animalImage[8].SetActive(true);
                break;
            default:
                print("Image failed!!");
                break;
        }
    }

    void setAllUninteractable()
    {
        for(int u = 0; u < buttonsList.Count; u++)
            buttonsList[u].GetComponent<Button>().interactable = false;
    }

    void setAllInteractable()
    {
        for(int u = 0; u < buttonsList.Count; u++)
            buttonsList[u].GetComponent<Button>().interactable = true;
    }

    // If user presses wrong button, this function will decrement the score and display the button being wrong.
     void setTextIncorrect(Button button)
    {
        button.GetComponent<Button>().interactable = false;
        Debug.Log(button.name + " is incorrect.");
        button.transform.GetChild(0).GetComponent<Text>().color = Color.red;
        button.transform.GetChild(0).GetComponent<Text>().text = "X";
        score--;
    }

    // If user presses the right button, this function will increment the score and display the button being right. Then the round is repeated.
    void setTextCorrect(Button button)
    {
        setAllUninteractable();
        Debug.Log(button.name + " is correct.");
        button.transform.GetChild(0).GetComponent<Text>().color = Color.green;
        button.transform.GetChild(0).GetComponent<Text>().text = "Correct!";
        score++;
        round++;
        // Add wait for 1 second here before moving to the next round
        StartCoroutine(roundDelay());
        
    }

    //Should repeat 3 times
    void resetImages()
    {
        for(int i = 0; i < animalImage.Count; i++)
        {
            animalImage[i].SetActive(false);
        }
    }

    public void ChangeScene()
    {
        SceneManager.LoadScene(0);
    }

    //Added code to transition scenes slowly if not gamemanger does not exist. Used to individual scene testing.
    private IEnumerator sceneDelay()
    {
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene(7);
    
    }

    private IEnumerator roundDelay()
    {
        yield return new WaitForSeconds(1);
        for(int i = 0; i < buttonsList.Count; i++)
            buttonsList[i].transform.GetChild(0).GetComponent<Text>().color = Color.black;
        resetImages();
        correctButton = randomizeButtons(buttonsList, animalNameList);
    }

}
