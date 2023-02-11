using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticObstacle : MonoBehaviour
{
    private int ratDamage;

    public void setRatDamage(int ratDamage) {
        this.ratDamage = ratDamage;
    }

    public int getRatDamage() {
        return this.ratDamage;
    }

}