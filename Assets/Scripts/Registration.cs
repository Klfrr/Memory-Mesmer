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
    private  int difficulty;
    // Start is called before the first frame update
    void Start()
    {  
        difficulty = 4;
        results.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void onClick()
    {
        string dataBaseConn = "URI=file:" + Application.dataPath + "/Database/Database.db"; 
        
        using(IDbConnection dbconn = new SqliteConnection(dataBaseConn))
        {
            dbconn.Open();

            using(IDbCommand cmnd = dbconn.CreateCommand())
            {


                string nameChecker = "SELECT COUNT(*) FROM Login WHERE User_Name = \"" + userName.text +"\"" +" AND Password = \"" + userPassword.text + "\"";

                string inputValues = "(\"" + userName.text + "\"," + "\"" + userPassword.text + "\"," + difficulty + ")";



                //Checks if the account already exists
                cmnd.CommandText = nameChecker;
                IDataReader reader = cmnd.ExecuteReader();

                int countOf = Int32.Parse(reader[0].ToString());

                reader.Close();
                

                //Conditionals
                if(countOf == 0)
                {
                    cmnd.CommandText = "INSERT INTO Login (User_Name, Password, Difficulty) VALUES ";
                    cmnd.CommandText += inputValues;
                    cmnd.ExecuteNonQuery();
                    results.text = "Account Successfully created";
                }
                else
                {
                    results.text = "Account already created";
                }
                
            }

            

            dbconn.Close();
        }
    }
}
