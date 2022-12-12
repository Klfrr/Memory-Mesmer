using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchTwoToken : MonoBehaviour
{
    GameObject gameControl;
    SpriteRenderer spriteRender;
    public Sprite[] face;
    public Sprite back;
    public int faceIndex;
    public bool matched = false;

    public void OnMouseDown()
    {
        //Check To See if already matched
        if(matched == false)
        {
            //Check to see side
            if(spriteRender.sprite == back)
            {
                //Check to see if too many cards flipped
                if(gameControl.GetComponent<MatchTwoGameControl>().TwoCardsUp() == false)
                {
                    spriteRender.sprite = face[faceIndex];
                    gameControl.GetComponent<MatchTwoGameControl>().addVisibleFace(faceIndex);
                    matched = gameControl.GetComponent<MatchTwoGameControl>().checkMatch();
                }
            }
            else
            {
                spriteRender.sprite = back; 
            }
        }
    }

    private void Awake()
    {
        gameControl = GameObject.Find("MatchTwoGameControl");
        spriteRender = GetComponent<SpriteRenderer>();
    }
}
