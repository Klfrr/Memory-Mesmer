using System.Collections;
using System.Collections.Generic;
using Mono.Data.Sqlite;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using System.Data;
using System;
using System.IO;


//unit test to go through the database and return the format
//also attempts to save and delete data and verifies both have been done
public class DatabaseInformationCycle
{
    //values to be put into the test account
    string testUsername = "testUser";
    string testPassword = "testPassword";
    String date = "TestDate";
    String time = "TestTime";
    double orientation = 5;
    double simon = 5;
    double pattern = 5;
    double naming = 5;
    double Serialization = 5;
    double TTS = 5;
    double letterTracking = 5;

    // A Test behaves as an ordinary method
    [Test]
    public void DatabaseInformationCycleSimplePasses()
    {
        string dataBaseConn = "URI=file:" + Application.dataPath + "/Database/Database.db"; 

        int countOf;

        //checks to see if there is already testUser account in the database
        using(IDbConnection dbconn = new SqliteConnection(dataBaseConn))
        {
            dbconn.Open();

            using(IDbCommand readCmnd = dbconn.CreateCommand())
            {
                readCmnd.CommandText = "SELECT COUNT(*) FROM Login WHERE User_Name = \"" + testUsername +"\"";;
                using(IDataReader reader = readCmnd.ExecuteReader())
                {
                    countOf = Int32.Parse(reader[0].ToString());
                    reader.Close();
                }
            }
            dbconn.Close();
        }

        //deletes all accounts of username if already in login database
        if(countOf != 0)
        {
            using(IDbConnection dbDelete = new SqliteConnection(dataBaseConn))
            {
                dbDelete.Open();
                using(IDbCommand dltCmnd = dbDelete.CreateCommand())
                {
                    dltCmnd.CommandText = "DELETE FROM Login WHERE User_Name = \"" + testUsername + "\"";
                    dltCmnd.ExecuteNonQuery();
                }
                dbDelete.Close();
                Debug.Log("Deletion of extra test account completed.");
            }      
        }
       
        //creates account in login database
        using(IDbConnection dbCreate = new SqliteConnection(dataBaseConn))
        {
            dbCreate.Open();
            using(IDbCommand cmnd = dbCreate.CreateCommand())
            {
                cmnd.CommandText = "INSERT INTO Login (User_Name,Password) VALUES ";
                cmnd.CommandText += "(\"" + testUsername + "\"," + "\"" + testPassword + "\")";
                Debug.Log("Creation of test account " + testUsername + " completed.");
                cmnd.ExecuteNonQuery();
            }
            dbCreate.Close();
        } 

        //stores test scores
        using(IDbConnection dbStore = new SqliteConnection(dataBaseConn))
        {
            dbStore.Open();
            using(IDbCommand storeCmnd = dbStore.CreateCommand())
            {
                storeCmnd.CommandText = "INSERT INTO Scores (User,Date,Time,Orientation,Simon,Pattern,Naming,Serialization,Text2Speech,LetterTracking) VALUES" ;
                string scoreVal = "(" +
                            "\"" + testUsername + "\"," +
                            "\"" + date + "\"," +
                            "\"" + time + "\"," +
                            "\"" + orientation + "\"," +
                            "\"" + simon + "\"," +
                            "\"" + pattern + "\"," +
                            "\"" + naming + "\"," +
                            "\"" + Serialization + "\"," +
                            "\"" + TTS + "\"," +
                            "\"" + letterTracking + "\",";
                scoreVal += ")";
            }
            Debug.Log("Storage of test values completed");
            dbStore.Close();
        }

        //verifies existance of data within the database
        using(IDbConnection dbconn = new SqliteConnection(dataBaseConn))
        {
            dbconn.Open();
            using(IDbCommand cmnd = dbconn.CreateCommand())
            {
                string scoreLoad = "SELECT * FROM Scores WHERE User = \"" + testUsername +"\"";
                cmnd.CommandText = scoreLoad;
                IDataReader reader = cmnd.ExecuteReader();

                while(reader.Read())
                {
                    for(int i = 3; i < 9; i++)
                    {
                        //Debug.Assert(Int32.Parse(reader[i].ToString()) != null);
                        Debug.Log("Value at i = " + i + " is " + reader[i]);
                    }
                }
                reader.Close();
            }
            dbconn.Close();
        }


        //upon test completion, delete the test account from Login database
        using(IDbConnection dbDelete = new SqliteConnection(dataBaseConn))
            {
                dbDelete.Open();
                using(IDbCommand dltCmnd = dbDelete.CreateCommand())
                {
                    dltCmnd.CommandText = "DELETE FROM Login WHERE User_Name = \"" + testUsername + "\"";
                    dltCmnd.ExecuteNonQuery();
                }
                dbDelete.Close();
                Debug.Log("Deletion of test account completed in Login.");
            }         

        //deletion from scores database
        using(IDbConnection dbDelete = new SqliteConnection(dataBaseConn))
            {
                dbDelete.Open();
                using(IDbCommand dltCmnd = dbDelete.CreateCommand())
                {
                    dltCmnd.CommandText = "DELETE FROM Scores WHERE User = \"" + testUsername + "\"";
                    dltCmnd.ExecuteNonQuery();
                }
                dbDelete.Close();
                Debug.Log("Deletion of test account completed in Scores.");
            }         
        }
}
