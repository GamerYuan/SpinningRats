using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : StaticObstacle
{

    [SerializeField]
    private int asteroidRatDamage;

    public void Awake()
    {
        this.setRatDamage(asteroidRatDamage);
    }

}