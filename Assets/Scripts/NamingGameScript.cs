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

    public Button correctButton;
    public int score;
    public int random;
    string path = "/Animal_Pictures/";

    // Start is called before the first frame update
    void Start()
    {
        // Random Animal object is selected as the right answer, then its image is displayed.
        int cIndex = Random.Range(0, options.Count);
        Debug.Log(options[cIndex] + " is the answer.");

        Animal correctAnimal = new Animal(options[cIndex], cIndex);

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
        for(int i = 0; i < buttonsList.Count; i++) //for each button
        {
            if (randUnpicked[i] == options[cIndex]) //if actual answer, log and set correct button 
            {
                Debug.Log(buttonsList[i].name + " is the correct button.");
                buttonsList[i].GetComponent<Text>().text = options[cIndex]; // for some reason the buttons' text isn't getting set correctly
                correctButton = buttonsList[i];
            }
            else // else, make the other buttons the wrong buttons
            {
                buttonsList[i].GetComponent<Text>().text = randUnpicked[i];
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        
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
        button.GetComponent<Button>().interactable = false;
        Debug.Log(button.name + " is correct.");
        button.transform.GetChild(0).GetComponent<Text>().color = Color.green;
        button.transform.GetChild(0).GetComponent<Text>().text = "CORRECT";
        score++;
    }

    //Should repeat 3 times
    void reset()
    {
        
    }

    public void ChangeScene()
    {
        SceneManager.LoadScene(0);
    }
}
