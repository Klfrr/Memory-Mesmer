using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Mono.Data.Sqlite;
using System.Data;
using System.IO;



public class Login : MonoBehaviour
{
    public Text userName;
    public Text userPassword;
    public Text results;
    private  int difficulty;

    private string loginUserName;
    // Start is called before the first frame update
    void Start()
    {  
        results.text = "";
        loginUserName = "";
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

                string readDatabase = "User_Name = \"" + userName.text  + "\" AND Password = \"" + userPassword.text + "\"";

                cmnd.CommandText = "SELECT * FROM Login WHERE ";
                cmnd.CommandText += readDatabase;



                try
                {
                    IDataReader reader = cmnd.ExecuteReader();
                    while(reader.Read())
                    {
                        loginUserName = reader[0].ToString();
                        Debug.Log(loginUserName);
                        results.text = "Login Successful";
                    }
                }
                catch (UnityException e)
                {
                    Debug.Log("Fail");
                }
            }

            

            dbconn.Close();
        }
    }
}
