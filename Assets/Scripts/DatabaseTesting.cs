using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mono.Data.Sqlite;
using System.Data;
using System;
using System.IO;




public class DatabaseTesting : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        //Code from https://answers.unity.com/questions/743400/database-sqlite-setup-for-unity.html
        //Used to build the connection path to the database
        string dataBaseConn = "URI=file:" + Application.dataPath + "/Database/Database.db"; 
        
        //Creates the connection to the database
        IDbConnection dbconn;
        dbconn = new SqliteConnection(dataBaseConn);
        dbconn.Open();


        IDbCommand dbcmd = dbconn.CreateCommand(); 

        //string sqlQuery = "SELECT User,Score" + "FROM PlaceSequence";

        //dbcmd.CommandText = sqlQuery;
        //IDataReader reader = dbcmd.ExecuteReader();

        IDbCommand cmnd = dbconn.CreateCommand();
        cmnd.CommandText = "INSERT INTO Scores (User,Score) VALUES (0, 5)";
        cmnd.ExecuteNonQuery();

        dbconn.Close();


    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
