using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Mono.Data.Sqlite;
using System.Data;
using System.IO;



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

                string inputValues = "(\"" + userName.text + "\"," + "\"" + userPassword.text + "\"," + difficulty + ")";

                cmnd.CommandText = "INSERT INTO Login (User_Name, Password, Difficulty) VALUES ";
                cmnd.CommandText += inputValues;



                if(cmnd.ExecuteNonQuery() == 1)
                {
                    results.text = "Account Successfully created";
                }
                else
                {
                    results.text = "Account already created";
                }
            }

            

            //dbconn.Close();
        }
    }
}
