using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Mono.Data.Sqlite;
using System.Data;
using System.IO;
using System;


public class Registration : MonoBehaviour
{
    public Text userName;
    public Text userPassword;
    public Text results;
    private UIManager gameScript;

    // Start is called before the first frame update
    void Start()
    {  
        gameScript = FindObjectOfType<UIManager>();
        results.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void onClick()
    {
        string dataBaseConn;
        switch(UnityEngine.Device.Application.platform)
            {   
                case RuntimePlatform.IPhonePlayer:
                dataBaseConn = "URI=file:" + Application.persistentDataPath + "/Database/Database.db";
                break;
                default:
                    
                    dataBaseConn ="URI=file:" +Application.persistentDataPath + "/Database/Database.db"; 
                    break;
            }
        int countOf = 0;
        
        countOf = readFunction(dataBaseConn);
        if(countOf == 0)
        {
            writeFunction(dataBaseConn);
            createDifficulty(dataBaseConn);
            
        }
        else
        {
            results.text = "Account already created";
        }
    }

    private int readFunction(string dataBaseConn)
    {
        int countOf;
        
        using(IDbConnection dbconn = new SqliteConnection(dataBaseConn))
        {
            dbconn.Open();

            using(IDbCommand readCmnd = dbconn.CreateCommand())
            {
                string nameChecker = "SELECT COUNT(*) FROM Login WHERE User_Name = \"" + userName.text +"\"";


                //Checks if the account already exists
                readCmnd.CommandText = nameChecker;
                using(IDataReader reader = readCmnd.ExecuteReader())
                {
                    countOf = Int32.Parse(reader[0].ToString());
                    reader.Close();
                }
            }
            //Conditionals

            dbconn.Close();
        }
        return countOf;    
    }

    private void writeFunction(string dataBaseConn)
    {   
        using(IDbConnection dbconn = new SqliteConnection(dataBaseConn))
        {
            dbconn.Open();

            using(IDbCommand cmnd = dbconn.CreateCommand())
            {
                string inputValues = "(\"" + userName.text + "\"," + "\"" + userPassword.text + "\")";
                //Conditionals
                cmnd.CommandText = "INSERT INTO Login (User_Name,Password) VALUES ";
                cmnd.CommandText += inputValues;
                Debug.Log(cmnd.CommandText);
                cmnd.ExecuteNonQuery();
                results.text = "Account Successfully created";
                gameScript.loadInformation(userName.text);
                gameScript.saveUISettings();
                gameScript.loadInformation(userName.text);
                GameObject.Find("Canvas").GetComponent<buttonController>().loginScene();
            }

            dbconn.Close();
        }
    }

    private void createDifficulty(string dataBaseConn)
    {
        using(IDbConnection dbconn = new SqliteConnection(dataBaseConn))
        {
            dbconn.Open();
            using(IDbCommand cmnd = dbconn.CreateCommand())
            {
                string valueWriter = userName.text;
                
                cmnd.CommandText = "INSERT INTO Difficulty (User,Orientation,Simon,Pattern,Naming,Serialization,Text2Speech,LetterTracking) VALUES (\"";
                cmnd.CommandText += valueWriter + "\"";

                for(int i = 0; i < 7;i++)
                {
                    cmnd.CommandText += ", 4"; 
                } 
                cmnd.CommandText += ")";
                cmnd.ExecuteNonQuery();
            }
            dbconn.Close();
        }
    }
    
    public void homeScreen()
    {
        gameScript.homePage();
    }

    public void loginPage()
    {
        gameScript.loginPage();
    }
}
