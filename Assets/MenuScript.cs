using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuScript : MonoBehaviour
{
    public enum MenuStates {Start, Settings}
    public MenuStates currentState;

    public GameObject startMenu;
    public GameObject settingsMenu;

    // Always starts at main menu
    void Awake(){
        currentState = MenuStates.Start;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        switch (currentState){
            case MenuStates.Start:
                break;
            case MenuStates.Settings:
                break;
        }
    
    }

    public void onSettings(){
        Debug.Log("You Pressed Settings");
    
        //Change menu state
    }

}
