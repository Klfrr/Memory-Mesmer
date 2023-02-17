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

    //What the cards do when interacted with
    public void OnMouseDown()
    {
        //checks if cards are on unflip timer
        //Check To see if already matched
        //Check to see side
        if(gameControl.GetComponent<MatchTwoGameControl>().pauseInput == false)
        {
            if(matched == false)
            {
                if(spriteRender.sprite == back)
                {
                    //Check to see if too many cards flipped
                    if(gameControl.GetComponent<MatchTwoGameControl>().TwoCardsUp() == false)
                    {
                        spriteRender.sprite = face[faceIndex];
                        gameControl.GetComponent<MatchTwoGameControl>().addVisibleFace(faceIndex);
                        matched = gameControl.GetComponent<MatchTwoGameControl>().checkMatch();

                        //stops inputs and creates initial time pause
                        if(gameControl.GetComponent<MatchTwoGameControl>().TwoCardsUp() == true)
                        {
                            gameControl.GetComponent<MatchTwoGameControl>().pauseInput = true;
                            gameControl.GetComponent<MatchTwoGameControl>().pauseTime = 2f;
                        }
                    }
                }
            }
        }
    }

    public void hide()
    {
        spriteRender.sprite = back;
    }

    private void Awake()
    {
        gameControl = GameObject.Find("MatchTwoGameControl");
        spriteRender = GetComponent<SpriteRenderer>();
    }
}       
         
