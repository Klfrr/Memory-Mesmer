using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatisticsScript : MonoBehaviour
{
    public float db_score;
    public Slider barGraph;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SetBar(db_score);
    }

    // Max SHOULD be 50 so divide score by 50
    void SetBar(float score)
    {
        float barNum = db_score / 50f;
        barGraph.value = barNum;
    }
}
