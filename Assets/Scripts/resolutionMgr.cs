using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class resolutionMgr : MonoBehaviour
{
    void Start()
    {
        float screenRatio = (float)Screen.width / (float)Screen.height;
        float targetRatio = 16.0f / 9.0f;

        if (screenRatio >= targetRatio)
        {
            Camera.main.orthographicSize = 5.0f / screenRatio;
        }
        else
        {
            float differenceInSize = targetRatio / screenRatio;
            Camera.main.orthographicSize = 5.0f * differenceInSize;
        }
    }
}
