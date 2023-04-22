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
        // Get scene first
        SceneManager.LoadScene("NamingAnimals");
    }

    [UnityTest]
    public IEnumerator PickAnimal()
    {
        // Use the Assert class to test conditions.
        
        // Find button
        Button animalButton = GameObject.Find("NamingButton1").GetComponent<Button>();
        //Assert.NotNull(animalButton);
        Debug.Log("Selected button name: " + animalButton.name);
        //Button testAnimalButton = animalButton.GetComponent<Button>();
        //bool clicked = false;
        //animalButton.onClick.AddListener(clicked);

        // Activate button
        animalButton.onClick.Invoke();

        Debug.Log("Test Finished.");
        // Check in the console if the output is correct in the console
        // Use yield to skip a frame.
        yield return null;
    }
}