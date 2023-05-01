using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using Mono.Data.Sqlite;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using System.Data;
using System;

public class SerializationDatabaseTest
{
    string userName = "asdf";
    string passWord = "asdf";

    // A Test behaves as an ordinary method
    [Test]
    public void SerializationDatabaseTestSimplePasses()
    {
        string dataBaseConn = "URI=file:" + Application.dataPath + "/Database/Database.db"; 

        IDbConnection dbReadConn;
        dbReadConn = new SqliteConnection(dataBaseConn);
        dbReadConn.Open();

        IDbCommand cmnd = dbReadConn.CreateCommand();

        //attempts to access account
        string nameChecker = "SELECT COUNT(*) FROM Login WHERE User_Name = \"" + userName +"\"" +" AND Password = \"" + passWord + "\"";
        cmnd.CommandText = nameChecker;
        IDataReader reader = cmnd.ExecuteReader();
        int countOf = Int32.Parse(reader[0].ToString());
        reader.Close();

        if(countOf == 1)
        {
            cmnd.CommandText = "SELECT * FROM Login WHERE ";
            cmnd.CommandText += "User_Name = \"" + userName + "\" AND Password = \"" + passWord + "\"";
            Debug.Log("connection to test account " + userName + " established");
            reader = cmnd.ExecuteReader();

        }
        else 
        {
            Debug.Assert(false, "connection to test account " + userName + " failed");
        }

        // IDbCommand  readerCmnd = dbReadConn.CreateCommand();
        // string query = "SELECT * FROM Scores WHERE User = \"" + userName + "\"";

        // readerCmnd.CommandText = query;
        // IDataReader reader = readerCmnd.ExecuteReader();

        // while(reader.Read())
        // {
        //     Debug.Log("User: " + reader[0].ToString());
        //     Debug.Log("Score: "+ reader[1].ToString());
        // }
        // dbReadConn.Close();
    }
}
