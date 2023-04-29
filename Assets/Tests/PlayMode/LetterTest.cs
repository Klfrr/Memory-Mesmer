using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;
using TMPro;

public class LetterTest
{
    [SetUp]
    public void Setup()
    {
        SceneManager.LoadScene("LetterTracking");
    }

    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
    [UnityTest]
    public IEnumerator LetterTestWithEnumeratorPasses()
    {
        var LetterScript = GameObject.Find("LetterTrackingCanvas").GetComponent<LetterTrackingScript>();
        float wait = LetterScript.gameTime + LetterScript.delay + 1;


        yield return new WaitForSeconds(wait);

        Assert.IsTrue(LetterScript.gameTime - Time.time < 2);
    }
}
