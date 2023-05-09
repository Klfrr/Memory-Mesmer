using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NUnit.Framework;
using UnityEngine.TestTools;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Pattern_test
{
    [SetUp]
    public void Setup()
    {
        SceneManager.LoadScene("PatternGameScene");
    }

    [UnityTest]
    public IEnumerator PickButton()
    {
        // Find button 1
        Button b = GameObject.Find("PatternButton1").GetComponent<Button>();

        // Activate Button
        b.onClick.Invoke();

        // Check to see if the button has debug logged.
        
        Debug.Log("Test Finished.");

        // Use yield to skip a frame.
        yield return null;
    }

    
}
