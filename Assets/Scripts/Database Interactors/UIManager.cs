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
    private static GameObject nameTextBox;
    private static GameObject onlyInstance = null;
    private backgroundDrop panelMgr;
    private audioMgr audio;
    //private textureDrop texture;
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        userName = "temp";
        if(onlyInstance == null)
        {
            onlyInstance = gameObject;
        }
        else
        {
            Destroy(gameObject);
            
        }
        createTable();
        createDatabase();
        userText();
    }

    // Update is called once per frame
    void Update()
    {
        panelMgr = FindObjectOfType<backgroundDrop>();
        audio = FindObjectOfType<audioMgr>();
        //texture = FindObjectOfType<textureDrop>();
    }

    void userText()
    {
        GameObject nameTextBox = null;
        if(nameTextBox == null)
        {
            nameTextBox = GameObject.Find("CurrentUser");
        }

        if(onlyInstance.GetComponent<UIManager>().getUserName() != "temp")
        {
            nameTextBox.SetActive(true);
            nameTextBox.GetComponent<Text>().text = "Logged in:\n" +
                                                    onlyInstance.GetComponent<UIManager>().getUserName();
        }
        else
        {
            nameTextBox.SetActive(false);
        }
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
                        writeCmnd.CommandText ="INSERT INTO UIPref (Background,Volume,Texture,Username) VALUES (";
                        settingCommand += panelMgr.backDrop.value + "," +  PlayerPrefs.GetFloat("Volume") + "," +  panelMgr.backDrop.value + ",\"" + userName + "\")";
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
                            panelMgr.backDrop.value = Int32.Parse(reader[2].ToString());
                            panelMgr.backgroundChange();
                            audio.loadVolume();
                        }
                        
                    }
                }
                dbconn.Close();
            }
        }
    }

    public void updateSettings()
    {
        int countOf = 0;
        if(userName != "temp")
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

                using(IDbCommand readCmnd = dbconn.CreateCommand())
                {
                    string nameChecker = "SELECT COUNT(*) FROM UIPref WHERE Username = \"" + userName +"\"";

                    
                    Debug.Log(nameChecker);
                    //Checks if the account already exists
                    readCmnd.CommandText = nameChecker;
                    using(IDataReader reader = readCmnd.ExecuteReader())
                    {
                        Debug.Log(reader[0].ToString());
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
                        changeCommand += "," + " Volume = " + PlayerPrefs.GetFloat("Volume");
                        changeCommand += "," + " Texture = " + panelMgr.backDrop.value;
                        changeCommand += " WHERE Username = \"" + userName + "\"";
                        writeCmnd.CommandText += changeCommand;
                        Debug.Log(writeCmnd.CommandText);
                        writeCmnd.ExecuteNonQuery();
                    }
                }

                dbconn.Close();
            }
        }
    }

    private void createDatabase()
    {
        
        string dataBaseConn;
        switch(UnityEngine.Device.Application.platform)
            {   
                case RuntimePlatform.IPhonePlayer:
                    dataBaseConn ="URI=file:" + Application.persistentDataPath + "/Database/Database.db";
                    Debug.Log(Application.persistentDataPath);
                    break;
                default:
                    
                    dataBaseConn ="URI=file:" +Application.persistentDataPath + "/Database/Database.db"; 
                    break;
            }   
            if(File.Exists(Application.dataPath + "/Raw" + "/Database/Database.db"))
                Debug.Log(dataBaseConn);
        using(IDbConnection dbconn = (IDbConnection) new SqliteConnection(dataBaseConn))
            {
                dbconn.Open();

                using(IDbCommand createCmnd = dbconn.CreateCommand())
                {
                    string loginTable = "CREATE TABLE IF NOT EXISTS Login (User_Name TEXT, Password TEXT, PRIMARY KEY (User_Name,Password))";
                    createCmnd.CommandText = loginTable;
                    createCmnd.ExecuteNonQuery();

                    string UITable = "CREATE TABLE IF NOT EXISTS UIPref (Background INTEGER, Volume REAL,Texture INTEGER,Username TEXT, PRIMARY KEY (Username))";
                    createCmnd.CommandText = UITable;
                    createCmnd.ExecuteNonQuery();

                    string ScoreTables = "CREATE TABLE IF NOT EXISTS Scores (User TEXT, Date TEXT, Time TEXT, Orientation NUMERIC, Simon TEXT, Pattern INTEGER, Naming INTEGER, Serialization INTEGER, Text2Speech INTEGER, LetterTracking INTEGER, PRIMARY KEY (User,Date,Time))";
                    createCmnd.CommandText = ScoreTables;
                    createCmnd.ExecuteNonQuery();

                    string difficultyTable = "CREATE TABLE IF NOT EXISTS Difficulty (User TEXT,Orientation NUMERIC, Simon TEXT, Pattern INTEGER, Naming INTEGER, Serialization INTEGER, Text2Speech INTEGER, LetterTracking INTEGER, PRIMARY KEY (User))";
                    createCmnd.CommandText = difficultyTable;
                    createCmnd.ExecuteNonQuery();
                }
                dbconn.Close();
            }


    }

    private void createTable()
    {
        
        switch(UnityEngine.Device.Application.platform)
        {   
            case RuntimePlatform.IPhonePlayer:
                if(!File.Exists(Application.persistentDataPath + "/Database/Database.db"))
                {
                    Directory.CreateDirectory(Application.persistentDataPath + "/Database");
                    File.Create(Application.persistentDataPath + "/Database/Database.db");
                }
                break;
            default:
                if(!File.Exists(Application.persistentDataPath + "/Database/Database.db"))
                {
                    Directory.CreateDirectory(Application.persistentDataPath + "/Database");
                    File.Create(Application.persistentDataPath + "/Database/Database.db");
                }
                break;
        }
        
    }

}
