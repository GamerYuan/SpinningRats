using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moon : MonoBehaviour
{
    private float finalDimensions = 100f;

    private RectTransform rt;

    private void Awake()
    {
        this.rt = GetComponent<RectTransform>();
    }

    private void Update()
    {
        float ratScale = RatsCount.RatScaleEvent();
        float newDimension = ratScale * finalDimensions;
        rt.sizeDelta = new Vector2(newDimension, newDimension);
    }
}