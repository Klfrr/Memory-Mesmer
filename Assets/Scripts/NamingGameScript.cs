using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

class Animal
{
public Animal(string name, Image image, int index)
    {
        m_image = image;
        m_name = name;
        m_index = index;
    }

    private Image m_image;
    private string m_name;
    private int m_index;
}

public class NamingGameScript : MonoBehaviour
{
    public List<GameObject> buttonsList;
    public List<string> options;


    // Start is called before the first frame update
    void Start()
    {
        // Random Animal object is selected, then its image is displayed.
        // The "correct" button is picked as the right answer
        // The other buttons are filled in with other random answers that are NOT the same as the right answer
        // If user clicks the right button, their score is increased
        // If user clicks wrong button, score is decreased

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
