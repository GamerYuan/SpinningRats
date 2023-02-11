using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : RatChangeObject
{

    [SerializeField]
    private int asteroidRatDamage;

    public void Awake()
    {
        this.SetRatChangeAmount(-asteroidRatDamage);
    }

}