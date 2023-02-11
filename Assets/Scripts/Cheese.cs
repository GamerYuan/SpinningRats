using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cheese : RatChangeObject
{
    [SerializeField]
    private int cheeseGainAmount;

    private void Awake() 
    {
        this.SetRatChangeAmount(this.cheeseGainAmount);
    }
}