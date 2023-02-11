using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moon : MonoBehaviour
{
    private float finalDimensions = 100f;

    private void Update()
    {
        float ratScale = RatsCount.RatScaleEvent();
        transform.localScale = new Vector3(ratScale * finalDimensions, ratScale * finalDimensions, 1f);
    }
}