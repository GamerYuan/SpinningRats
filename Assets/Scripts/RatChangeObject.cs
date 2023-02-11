using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RatChangeObject : MonoBehaviour
{
    private int ratDamage;

    public void SetRatChangeAmount(int ratDamage) {
        this.ratDamage = ratDamage;
    }

    public int GetRatChangeAmount() {
        return this.ratDamage;
    }

}