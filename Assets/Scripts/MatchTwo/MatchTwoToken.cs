using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchTwoToken : MonoBehaviour
{
    SpriteRenderer spriteRender;
    public Sprite[] face;
    public Sprite back;
    public int faceIndex;

    public void OnMouseDown()
    {
        if(spriteRender.sprite == back)
        {
            spriteRender.sprite = face[faceIndex];
        }
        else
        {
            spriteRender.sprite = back; 
        }
    }

    private void Awake()
    {
        spriteRender = GetComponent<SpriteRenderer>();
    }
}
