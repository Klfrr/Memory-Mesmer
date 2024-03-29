using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MatchTwoGameControl : MonoBehaviour
{
    GameObject token;
    List<int> faceIndexes = new List<int> {0, 0, 1, 1, 2, 2, 3, 3};
    public static System.Random rng = new System.Random();
    public int shuffleNum = 0;
    public bool pauseInput = false;
    public float pauseTime;

    //negative numbers are to act as indicators of unflipped cards
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
        token.GetComponent<MatchTwoToken>().faceIndex = faceIndexes[0];
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

    //visibleFaces stores currently shown faces
    //add is when a new one is shown, remove is for when is flipped back onto its back
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
    public void removeVisibileFace(int index)
    {
        if(visibleFaces[0] == index)
        {
            visibleFaces[0] = -1;
        }
        else if(visibleFaces[1] == index)
        {
            visibleFaces[1] = -2;
        }
    }

    //compares cureently visible faces to see if matching
    public bool checkMatch()
    {
        if(visibleFaces[0] == visibleFaces[1])
        {
            visibleFaces[0] = -1;
            visibleFaces[1] = -2;
            return true;
        }
        return false;

    }

    private void Awake() 
    {
        token = GameObject.Find("Token");
    }

    // Update is called once per frame
    void Update()
    {
        if(pauseInput)
        {
            pauseTime -= Time.deltaTime;
            if(pauseTime <= 0)
            {
                pauseInput = false;
                removeVisibileFace(visibleFaces[0]);
                removeVisibileFace(visibleFaces[1]);
            }
        }
    }

    public void changeScene()
    {
        SceneManager.LoadScene(0);
    }
}


