using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Mono.Data.Sqlite;
using System.Data;
using System;

public class StatisticsScript : MonoBehaviour
{
    private List<float> db_score;
    public GameObject canvasObject;
    private List<string> date;
    private UIManager gameScript;
    public GameObject SingleBarObject;
    // Start is called before the first frame update
    void Start()
    {
        gameScript = FindObjectOfType<UIManager>();
        date = new List<string>();
        db_score = new List<float>();
        //Single test for now, just to show data can be shown. Code not complex enough to allow selection. I will alter the code later to make it score all scores. For now just single use
        string dataBaseConn = "URI=file:" + Application.dataPath + "/Database/Database.db"; 
        
        using(IDbConnection dbconn = new SqliteConnection(dataBaseConn))
        {
            dbconn.Open();

            using(IDbCommand cmnd = dbconn.CreateCommand())
            {
                string userName = gameScript.getUserName();
                //Must change to make it moduler later, probably change into it's own function call so it can be account based or not account based
                string scoreLoader = "SELECT * FROM Scores WHERE User = \"" + userName +"\"";
                
                cmnd.CommandText = scoreLoader;
                IDataReader reader = cmnd.ExecuteReader();

                float score;
                while(reader.Read())
                {
                    score = 0;
                    //Will change later to make it modular
                    date.Add("Date: " + reader[1].ToString() + " Time: " + reader[2].ToString());
                    for(int i = 3; i<9;i++)
                    {   
                        
                        score += Int32.Parse(reader[i].ToString());
                    }
                    db_score.Add(score);
                }
                reader.Close();
                
            }

            

            dbconn.Close();
        }

        createBars();
    }

    // Update is called once per frame
    void Update()
    {   
        //Probably should make it a start function instead. 
        //SetBar(db_score);
    }

    private void createBars()
    {
        for(int i = 0; i < db_score.Count;i++)
        {
            float newY = 500-(250*i);
            GameObject barGraphClone = Instantiate(SingleBarObject, new Vector3(0 , newY,0),SingleBarObject.transform.rotation);
            barGraphClone.transform.SetParent(canvasObject.transform, false);
            SetBar(db_score[i],barGraphClone,i);
            barGraphClone.SetActive(true);
        }
    }

    // Max SHOULD be 50 so divide score by 50
    void SetBar(float score, GameObject barGraphClone,int count)
    {   
        //Math should be adjusted for the missing games. Note for later
        Text datePrint = barGraphClone.transform.GetChild(0).gameObject.GetComponent<Text>();
        datePrint.text = date[count];
        
        float barNum = score / 50f;
        Slider barGraphSlider = barGraphClone.transform.GetChild(1).gameObject.GetComponent<Slider>();
        barGraphSlider.value = barNum;

        Text scorePrinter = barGraphClone.transform.GetChild(2).gameObject.GetComponent<Text>();
        scorePrinter.text = (barNum*100).ToString() + "%";
        //barGraph.value = barNum;
    }
}

/*
*To do for this section.
*Add a onClick to display the numeric value when the user clicks on the bar graph, probably over the bar itself. kinda for now
*Optional* Add a way to make a single bar graph more indepth/break down of score. Can be done using a canvas like system
*/