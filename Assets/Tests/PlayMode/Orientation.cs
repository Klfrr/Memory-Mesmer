using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;

public class Orientation
{
    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
    [SetUp]
    public void Setup()
    {
        SceneManager.LoadScene("Orientation");
    }


    [UnityTest]
    public IEnumerator SceneTest()
    {
        var sceneChanger = GameObject.Find("Scene Change");
        var changerButton = sceneChanger.GetComponent<Button>();

        changerButton.onClick.Invoke();

        yield return null;

        var sceneId = SceneManager.GetActiveScene().buildIndex;
        Assert.AreEqual(0,sceneId);
    }
}
