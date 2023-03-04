using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LetterTrackingScript : MonoBehaviour
{
    public GameObject letterButton;
    public GameObject letterLabel;

    public int timer = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //StartCoroutine(startWatchTimer());

    // function controls the timer
    public IEnumerator startWaitTimer()
    {
        while(timer > 0)
        {
            for(int i = 0; i < timer; i++)
            {
                timer--;
                yield return new WaitForSeconds(1f);
            }
        }
        // Wait for 2 seconds beteween changing letters

        // Change to random Letter

    }

    char randomizeLabel()
    {
        // Capital letters between 65 and 90
        int randnum = 0;
        //= Random.value(65, 90);

        return (char)randnum;
    }

    public void checkButton()
    {

    }
}
