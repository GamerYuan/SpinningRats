using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moon : MonoBehaviour
{
    private static float finalDimensions = 50f;
    private static float scaleFactor = 20f;
    private static RectTransform rt;

    private void Awake()
    {
        Moon.rt = GetComponent<RectTransform>();
        float ratScale = RatsCount.GetInitialScale();
        float newDimension = ratScale * finalDimensions * scaleFactor;
        //Debug.Log(newDimension);
        rt.sizeDelta = new Vector2(newDimension, newDimension);
    }

    public static void SetMoonSize() {
        float ratScale = RatsCount.RatScaleEvent();
        float newDimension = ratScale * finalDimensions * scaleFactor;
        //Debug.Log(newDimension);
        rt.sizeDelta = new Vector2(newDimension, newDimension);
    }

}