using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FinalScorePage : MonoBehaviour
{
    private gameManager gameScript;
    public Text scoreText;

    // Start is called before the first frame update
    void Start()
    {
        gameScript = FindObjectOfType<gameManager>();
        scoreText.text = gameScript.getScore();
        gameScript.destroySelf();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void homePage()
    {
        SceneManager.LoadScene(0);
    }

    public void scorePage()
    {
        SceneManager.LoadScene(10);
    }

}
