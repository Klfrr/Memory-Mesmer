using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Slider? from Sleek Essential UI Pack

public class FillValueNumber : MonoBehaviour
{
    public Image TargetImage;
    // Update is called once per frame
    void Update()
    {
        float amount = TargetImage.fillAmount * 100;
        gameObject.GetComponent<Text>().text = amount.ToString("F0");
    }
}
