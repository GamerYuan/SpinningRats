using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RatsCount : MonoBehaviour
{
    private static int initialRats = 100;
    private static int finalRatCount = 1000000;

    private static float finalScaleX = 100f;
    private static float finalScaleY = 100f;
    private static float finalScaleZ = 1f;
    private int ratCount;

    private static float sphereScaleFactor = 100f;

    private void Awake() {
        this.ratCount = RatsCount.initialRats;
        this.ChangeSphereSize();
    }

    public void ChangeRatCount(int amount) {
        this.ratCount = Mathf.Max(0, this.ratCount + amount);
    }

    public void ChangeSphereSize() {
        transform.localScale = new Vector3((float) this.ratCount / RatsCount.finalRatCount * RatsCount.finalScaleX * RatsCount.sphereScaleFactor,
            (float) this.ratCount / RatsCount.finalRatCount * RatsCount.finalScaleY * RatsCount.sphereScaleFactor, RatsCount.finalScaleZ);
    }

}