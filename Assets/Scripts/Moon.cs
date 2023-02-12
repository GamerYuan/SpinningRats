using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moon : MonoBehaviour
{
    private float finalDimensions = 50f;
    private float scaleFactor = 20f;
    private RectTransform rt;

    private void Awake()
    {
        this.rt = GetComponent<RectTransform>();
    }

    private void Update()
    {
        Debug.Log("!!!");
        float ratScale = RatsCount.RatScaleEvent();
        float newDimension = ratScale * finalDimensions * scaleFactor;
        Debug.Log(newDimension);
        rt.sizeDelta = new Vector2(newDimension, newDimension);
    }
}