using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    //requirements:
    //allow drag and connect points
    //make line between points
    //needs to check line collision
    //3x3 array of points(randomized)
    //tapping on a spot will undo the connection
    //reset button?


public class VisualSpatialGame : MonoBehaviour
{
    public GameObject lineSettings;
    
    private const int boardSize = 3;
    public VisSpaceToken[,] SpatialBoard = new VisSpaceToken[boardSize, boardSize];

    VisSpaceToken currentToken;

    // Start is called before the first frame update
    void Start()
    {
        //fills 2d array in numerical order row by row
        for(int i = 0; i < boardSize; i++)
        {
            for(int j = 0; j < boardSize; j++)
            {
                SpatialBoard[i,j] = new VisSpaceToken();
                SpatialBoard[i,j].value = (j+1) + i*3;
            }
        }

        //finds two values to swap and swaps
        int randOne = Random.Range(1,9);
        int randTwo;
        do
        {
            randTwo = Random.Range(1,9);
        } while (randOne == randTwo);
        int temp = SpatialBoard[(randOne/boardSize), (randOne%boardSize)].value;
        SpatialBoard[(randOne/boardSize), (randOne%boardSize)].value = SpatialBoard[(randTwo/boardSize), (randTwo%boardSize)].value;
        SpatialBoard[(randTwo/boardSize), (randTwo%boardSize)].value = temp;


        for(int i = 0; i < boardSize; i++)
                {
                    for(int j = 0; j < boardSize; j++)
                    {
                        //print(SpatialBoard[i,j].value);
                    }
                }
    }

    // Update is called once per frame
    void Update()
    {
        //pressing down
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 worldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(worldPos, Vector2.zero);

            //select token clicked on
            if(hit.collider != null)
            {
                if(hit.collider.name == "VisSpaceToken")
                {
                    currentToken = hit.transform.gameObject.GetComponent<VisSpaceToken>();
                    currentToken.resetLine();
                }
            }
        }
        
        if (Input.GetMouseButtonUp(0))
        {
            //connects lines and resets current line
            Vector2 worldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(worldPos, Vector2.zero);
             if(hit.collider != null)
            {
                if(hit.collider.gameObject.name == "VisSpaceToken")
                {
                    print("center");
                    currentToken.updateLine(hit.transform.position);
                }
            }
            currentToken = null;
        }

        //holding down
        if (currentToken != null)
        {
            Vector2 worldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            currentToken.updateLine(worldPos);
        }   
    }
}
