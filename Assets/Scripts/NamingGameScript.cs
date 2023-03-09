using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NamingGameScript : MonoBehaviour
{
    class Animal
    {
        public Animal(string name, int index)
        {
            m_name = name;
            m_index = index;
        }
        public Animal(string name, Image image, int index)
        {
            m_image = image;
            m_name = name;
            m_index = index;
        }

        Image m_image;
        string m_name;
        int m_index;
    }

    public List<Button> buttonsList;
    public List<string> options;
    List<Animal> animalList;
    public GameObject rhinoImage;
    public GameObject lionImage;
    public GameObject camelImage;
    public Text scoreLabel;

    Button correctButton;
    public int score = 0;
    public int random;
    // string path = "/Animal_Pictures/";

    // Start is called before the first frame update
    void Start()
    {
        //Set all images to not appear
        reset();

        // Random Animal object is selected as the right answer, then its image is displayed.
        int cIndex = Random.Range(0, options.Count);
        string cAnimal = options[cIndex];
        Debug.Log(cAnimal + " is the answer.");

        Animal correctAnimal = new Animal(cAnimal, cIndex);

        // A random "correct" button is picked as the right answer
        int bIndex = Random.Range(0, buttonsList.Count);

        // The other buttons are filled in with other random answers that are NOT the same as the right answer
        // First Loop: Assign all the options into rand unpicked and shuffle
        List<string> randUnpicked = options;
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
    }

    void checkDisplayImage(string ans)
    {
        switch(ans)
        {
            case "Lion": 
                lionImage.SetActive(true);
                break;
            case "Rhino":
                rhinoImage.SetActive(true);
                break;
            case "Camel":
                camelImage.SetActive(true);
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
    }

    //Should repeat 3 times
    void reset()
    {
        rhinoImage.SetActive(false);
        lionImage.SetActive(false);
        camelImage.SetActive(false);
    }

    public void ChangeScene()
    {
        SceneManager.LoadScene(0);
    }
}
