using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchTwoGameLayout : MonoBehaviour
{
    GameObject token;
    List<int> faceIndexes = new List<int> {0, 1, 2, 3, 0, 1, 2, 3};
    public static System.Random rng = new System.Random();
    public int shuffleNum = 0;
    int[] visibleFaces = {-1, -2};

    // Start is called before the first frame update
    void Start()
    {
        int originalLength = faceIndexes.Count;
        float xPos = -2.2f;
        float yPos = 2.3f;
        for(int i = 0; i < 7; i++)
        {
            shuffleNum = rng.Next(0, (faceIndexes.Count));
            var temp = Instantiate(token, new Vector3(xPos, yPos, 0)
                                    , Quaternion.identity);
            temp.GetComponent<MatchTwoToken>().faceIndex = faceIndexes[shuffleNum];
            faceIndexes.Remove(faceIndexes[shuffleNum]);
            xPos += 4;

            if(i == (originalLength/2 - 2))
            {
                xPos = -6.2f;
                yPos = -2.3f;
            }
        }
    }

    //returns true if two cards up and false if not
    public bool TwoCardsUp()
    {
        if(visibleFaces[0] >= 0 && visibleFaces[1] >= 0)
        {
            return true;
        }
        return false;
    }

    public void addVisibleFace(int index)
    {
        if(visibleFaces[0] == -1)
        {
            visibleFaces[0] = index;
        }
        else if(visibleFaces[1] == -2)
        {
            visibleFaces[1] = index;
        }
    }

    private void Awake() 
    {
        token = GameObject.Find("Token");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
