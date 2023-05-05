using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TempScoreScreen : MonoBehaviour
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

    public void next()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

}
