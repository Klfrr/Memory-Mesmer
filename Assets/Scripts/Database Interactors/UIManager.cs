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
    private backgroundDrop panelMgr;
    private audioMgr audio;
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        userName = "temp";

        panelMgr = FindObjectOfType<backgroundDrop>();
        audio = FindObjectOfType<audioMgr>();

        if(onlyInstance == null)
        {
            onlyInstance = gameObject;
        }
        else
        {
            Destroy(gameObject);
            
        }
        createDatabase();
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

    public void homePage()
    {
        SceneManager.LoadScene(0);
    }

    public void loginPage()
    {
        SceneManager.LoadScene(10);
    }

    public void registerPage()
    {
        SceneManager.LoadScene(9);
    }

    public void saveUISettings()//Register
    {
        int countOf = 0;
        if(userName != "temp")
        {
            string dataBaseConn = "URI=file:" + Application.dataPath + "/Database/Database.db"; 

            using(IDbConnection dbconn = new SqliteConnection(dataBaseConn))
            {
                dbconn.Open();

                using(IDbCommand readCmnd = dbconn.CreateCommand())
                {
                    string nameChecker = "SELECT COUNT(*) FROM UIPref WHERE Username = \"" + userName +"\"";


                    //Checks if the account already exists
                    readCmnd.CommandText = nameChecker;
                    using(IDataReader reader = readCmnd.ExecuteReader())
                    {
                        countOf = Int32.Parse(reader[0].ToString());
                        reader.Close();
                    }
                }

                if(countOf == 0)
                {
                    using(IDbCommand writeCmnd = dbconn.CreateCommand())
                    {
                        string settingCommand = "";
                        writeCmnd.CommandText ="INSERT INTO UIPref (Background,Volume,Username) VALUES (";
                        settingCommand += panelMgr.backDrop.value + "," +  PlayerPrefs.GetFloat("Volume") + ",\"" + userName + "\")";
                        writeCmnd.CommandText +=settingCommand;
                        writeCmnd.ExecuteNonQuery();
                    }
                }

                dbconn.Close();
            }
        }
    }

    public void loadUISettings()
    {
        int countOf = 0;
        if(userName != "temp")
        {
            string dataBaseConn = "URI=file:" + Application.dataPath + "/Database/Database.db"; 

            using(IDbConnection dbconn = new SqliteConnection(dataBaseConn))
            {
                dbconn.Open();

                using(IDbCommand readCmnd = dbconn.CreateCommand())
                {
                    string nameChecker = "SELECT COUNT(*) FROM UIPref WHERE Username = \"" + userName +"\"";


                    //Checks if the account already exists
                    readCmnd.CommandText = nameChecker;
                    using(IDataReader reader = readCmnd.ExecuteReader())
                    {
                        countOf = Int32.Parse(reader[0].ToString());
                        reader.Close();
                    }
                }

                if(countOf == 1)
                {
                    using(IDbCommand readerCmnd = dbconn.CreateCommand())
                    {
                        string valueReader = "SELECT * FROM UIPref WHERE Username = \"" + userName + "\"";

                        readerCmnd.CommandText = valueReader;
                        using(IDataReader reader = readerCmnd.ExecuteReader())
                        {
                            panelMgr.backDrop.value = Int32.Parse(reader[0].ToString());
                            PlayerPrefs.SetFloat("Volume", float.Parse(reader[1].ToString()));
                            panelMgr.backgroundChange();
                            audio.loadVolume();
                        }
                        
                    }
                }
                dbconn.Close();
            }
        }
    }

    public void updateSettings(int backDropValue, float volumeValue)
    {
        int countOf = 0;
        if(userName != "temp")
        {
            string dataBaseConn = "URI=file:" + Application.dataPath + "/Database/Database.db"; 

            using(IDbConnection dbconn = new SqliteConnection(dataBaseConn))
            {
                dbconn.Open();

                using(IDbCommand readCmnd = dbconn.CreateCommand())
                {
                    string nameChecker = "SELECT COUNT(*) FROM UIPref WHERE Username = \"" + userName +"\"";


                    //Checks if the account already exists
                    readCmnd.CommandText = nameChecker;
                    using(IDataReader reader = readCmnd.ExecuteReader())
                    {
                        countOf = Int32.Parse(reader[0].ToString());
                        reader.Close();
                    }
                }

                if(countOf == 1)
                {
                    using(IDbCommand writeCmnd = dbconn.CreateCommand())
                    {
                        string changeCommand = "";
                        writeCmnd.CommandText ="UPDATE UIPref SET ";
                        changeCommand += "Background = " + panelMgr.backDrop.value;
                        changeCommand += "," + "Volume = " + PlayerPrefs.GetFloat("Volume");
                        changeCommand += "WHERE Username = \"" + userName + "\"";
                        writeCmnd.CommandText += changeCommand;
                        writeCmnd.ExecuteNonQuery();
                    }
                }

                dbconn.Close();
            }
        }
    }

    private void createDatabase()
    {
        if(!Directory.Exists(Application.dataPath + "/Database"))
        {
            Directory.CreateDirectory(Application.dataPath + "/Database");
            File.Create(Application.dataPath + "/Database/Database.db");
        }
        

        string dataBaseConn = "URI=file:" + Application.dataPath + "/Database/Database.db"; 
        using(IDbConnection dbconn = new SqliteConnection(dataBaseConn))
            {
                dbconn.Open();

                using(IDbCommand createCmnd = dbconn.CreateCommand())
                {
                    string loginTable = "CREATE TABLE IF NOT EXISTS Login (User_Name TEXT, Password TEXT, PRIMARY KEY (User_Name,Password))";

                    createCmnd.CommandText = loginTable;
                    createCmnd.ExecuteNonQuery();

                    string UITable = "CREATE TABLE IF NOT EXISTS UIPref (Background INTEGER, Volume REAL,Username TEXT, PRIMARY KEY (Username))";
                    createCmnd.CommandText = UITable;
                    createCmnd.ExecuteNonQuery();

                    string ScoreTables = "CREATE TABLE IF NOT EXISTS Scores (User TEXT, Date TEXT, Time TEXT, Orientation NUMERIC, Simon TEXT, Pattern INTEGER, Naming INTEGER, Serialization INTEGER, Text2Speech INTEGER, LetterTracking INTEGER, PRIMARY KEY (User,Date,Time))";
                    createCmnd.CommandText = ScoreTables;
                    createCmnd.ExecuteNonQuery();
                }
                dbconn.Close();
            }
    }

}
