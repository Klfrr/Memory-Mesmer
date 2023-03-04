using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;
using TMPro;

//Vincent Ha

public class Serialization_Test
{
    [SetUp]
    public void Setup()
    {
        SceneManager.LoadScene("SerializationGame");
    }


    [UnityTest]
    public IEnumerator Serialization()
    {
        var output = GameObject.Find("outputText").GetComponent<TMP_Text>();

        Debug.Log(output.text);
        yield return null;

    }
}
