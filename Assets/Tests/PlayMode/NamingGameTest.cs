using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NUnit.Framework;
using UnityEngine.TestTools;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NamingGameTest
{
    [SetUp]
    public void Setup()
    {
        SceneManager.LoadScene("NamingAnimals");
    }

    [UnityTest]
    public IEnumerator PickAnimal()
    {
        // Use the Assert class to test conditions.
        // Get scene first

        Button animalButton = GameObject.Find("NamingButton1").GetComponent<Button>();
        //Assert.NotNull(animalButton);
        Debug.Log("Selected button name: " + animalButton.name);
        //Button testAnimalButton = animalButton.GetComponent<Button>();
        //bool clicked = false;
        //animalButton.onClick.AddListener(clicked);
        animalButton.onClick.Invoke();

        Debug.Log("Test Finished.");
        // Use yield to skip a frame.
        yield return null;
    }
}
