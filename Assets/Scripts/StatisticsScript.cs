using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Mono.Data.Sqlite;
using System.Data;
using System;

public class StatisticsScript : MonoBehaviour
{
    public float db_score;
    public Slider barGraph;
    public Text date;

    // Start is called before the first frame update
    void Start()
    {
        db_score = 0;
        //Single test for now, just to show data can be shown. Code not complex enough to allow selection. I will alter the code later to make it score all scores. For now just single use
        string dataBaseConn = "URI=file:" + Application.dataPath + "/Database/Database.db"; 
        
        using(IDbConnection dbconn = new SqliteConnection(dataBaseConn))
        {
            dbconn.Open();

            using(IDbCommand cmnd = dbconn.CreateCommand())
            {
                //Must change to make it moduler later, probably change into it's own function call so it can be account based or not account based
                string scoreLoader = "SELECT * FROM Scores WHERE User = \"" + "temp" +"\"";
                
                cmnd.CommandText = scoreLoader;
                IDataReader reader = cmnd.ExecuteReader();


                while(reader.Read())
                {
                    //Will change later to make it modular
                    date.text = "Date: " + reader[1].ToString() + " Time: " + reader[2].ToString();
                    for(int i = 3; i<9;i++)
                    {   
                        
                        db_score += Int32.Parse(reader[i].ToString());
                    }
                }
                reader.Close();
                
            }

            

            dbconn.Close();
        }
    }

    // Update is called once per frame
    void Update()
    {   
        //Probably should make it a start function instead. 
        SetBar(db_score);
    }

    // Max SHOULD be 50 so divide score by 50
    void SetBar(float score)
    {   
        //Math should be adjusted for the missing games. Note for later
        float barNum = db_score / 50f;
        barGraph.value = barNum;
    }
}

/*
*To do for this section.
*Add a UI manager so instead of temp, the user name can be accessed. 
*Add a object creation to create new bar graph for each new instance of row, maybe add a scroller like effect
*Each row should have their own text that is supposed to be the time and date at which they completed the game.
*Add a onClick to display the numeric value when the user clicks on the bar graph, probably over the bar itself.
*Optional* Add a way to make a single bar graph more indepth/break down of score. Can be done using a canvas like system
*Change it from  float singular to private vector of float values for multiple scores. 
*/