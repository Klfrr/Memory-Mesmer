using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class correctIndicator : MonoBehaviour
{
    public Sprite initial;
    public Sprite correct;
    SpriteRenderer spriteRender;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void isCorrect()
    {
        spriteRender.sprite = correct;
    }
}
