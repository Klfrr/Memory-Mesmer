using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MatchTwo : MonoBehaviour
{

    int sizeX = 2; 
    int sizeY = 1;
    int playerX, playerY;
    int[][] cardArray;
    int level;
    bool status;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void increaseX()
    {
        sizeX++;
    }

    void increaseY()
    {
        sizeY++;
    }

    //rescrambles values behind cards
    void scramble()
    {
    
    }

    //Called after every increase in score
    //WIP: Hardcode boards or formula?
    void updateBoard()
    {

    }

    //reveal/unreveal card
    void flip()
    {

    }

    //Reveals card and adjusts score if same or flip over previous card 
    public void eachClick(GameObject click)
    {
        //K: Gets button chosen
        //Image
        //
    }
}
