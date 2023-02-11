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
    }

    public static void UpdateText(float numRats)
    {
        RatCountText.numRats.text = numRats.ToString();
    }
}