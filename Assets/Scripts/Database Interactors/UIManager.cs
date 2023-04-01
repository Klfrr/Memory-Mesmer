using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Mono.Data.Sqlite;
using System.Data;
using System.IO;
using System;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    private string userName;
    private static GameObject onlyInstance = null;
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        userName = "temp";

        if(onlyInstance == null)
        {
            onlyInstance = gameObject;
        }
        else
        {
            Destroy(gameObject);
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void loadInformation(string currentUserName)
    {
        userName = currentUserName;
    }

    public string getUserName()
    {
        return userName;
    }

    public void loadDataBase()
    {
        //add the information when the time comes, for now, this function exist.
    }

    //Call this function on start of each program
    public void UIload()
    {

    }

    public void homePage()
    {
        SceneManager.LoadScene(0);
    }

}
