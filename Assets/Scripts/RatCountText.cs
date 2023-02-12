using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RatCountText : MonoBehaviour
{
    private static TMP_Text numRats;

    private void Awake()
    {
        RatCountText.numRats = GetComponent<TMP_Text>();
        RatCountText.numRats.text = RatsCount.RatCountEvent().ToString();
    }

    public static void UpdateText(float numRats)
    {
        RatCountText.numRats.text = Mathf.Floor(numRats).ToString();
    }
}
