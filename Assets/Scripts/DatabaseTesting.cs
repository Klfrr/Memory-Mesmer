using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mono.Data.Sqlite;
using System.Data;
using System;
using System.IO;
using UnityEngine;





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


        //string sqlQuery = "SELECT User,Score" + "FROM PlaceSequence";

        //dbcmd.CommandText = sqlQuery;
        //IDataReader reader = dbcmd.ExecuteReader();

        IDbCommand cmnd = dbconn.CreateCommand();
        cmnd.CommandText = "INSERT INTO Scores (User,Score) VALUES (0, 5)";
        cmnd.ExecuteNonQuery();

        dbconn.Close();

        //code from https://medium.com/@rizasif92/sqlite-and-unity-how-to-do-it-right-31991712190

        IDbConnection dbReadConn;
        dbReadConn = new SqliteConnection(dataBaseConn);
        dbReadConn.Open();

        IDbCommand  readerCmnd = dbReadConn.CreateCommand();
        string query = "SELECT * FROM Scores";

        readerCmnd.CommandText = query;
        IDataReader reader = readerCmnd.ExecuteReader();

        while(reader.Read())
        {
            Debug.Log("User: " + reader[0].ToString());
            Debug.Log("Score: "+ reader[1].ToString());
        }
        dbReadConn.Close();

    }



    // Update is called once per frame
    void Update()
    {
        
    }

    public void onClick()
    {
        string dataBaseConn = "URI=file:" + Application.dataPath + "/Database/Database.db";    
        IDbConnection dbDelete = new SqliteConnection(dataBaseConn);

        dbDelete.Open();
        IDbCommand dltCmnd = dbDelete.CreateCommand();
        dltCmnd.CommandText = "DELETE FROM Scores WHERE User=0";

        dltCmnd.ExecuteNonQuery();
        dbDelete.Close();

    }

}
