using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Mono.Data.Sqlite;
using System.Data;
using System.IO;
using System;

public class Login : MonoBehaviour
{
    public Text userName;
    public Text userPassword;
    public Text results;
    private  int difficulty;

    private string loginUserName;
    private UIManager gameScript;

    // Start is called before the first frame update
    void Start()
    {  
        gameScript = FindObjectOfType<UIManager>();
        results.text = "";
        loginUserName = "";
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
        
        using(IDbConnection dbconn = new SqliteConnection(dataBaseConn))
        {
            dbconn.Open();

            using(IDbCommand cmnd = dbconn.CreateCommand())
            {
                
                string nameChecker = "SELECT COUNT(*) FROM Login WHERE User_Name = \"" + userName.text +"\"" +" AND Password = \"" + userPassword.text + "\"";
                
                //Checks if the account already exists
                cmnd.CommandText = nameChecker;
                IDataReader reader = cmnd.ExecuteReader();

                int countOf = Int32.Parse(reader[0].ToString());

                reader.Close();

                

                if(countOf == 1)
                {
                    string readDatabase = "User_Name = \"" + userName.text  + "\" AND Password = \"" + userPassword.text + "\"";
                    cmnd.CommandText = "SELECT * FROM Login WHERE ";
                    cmnd.CommandText += readDatabase;

                    reader = cmnd.ExecuteReader();
                    while(reader.Read())
                    {
                        loginUserName = reader[0].ToString();
                        gameScript.loadInformation(loginUserName);
                        gameScript.loadUISettings();
                        homeScreen();
                    }
                    reader.Close();
                }
                else
                {
                    results.text = "Account does not Exist";
                }
            }

            

            dbconn.Close();
        }
    }

    public void homeScreen()
    {
        gameScript.homePage();
    }

    public void register()
    {
        gameScript.registerPage();
    }
}
