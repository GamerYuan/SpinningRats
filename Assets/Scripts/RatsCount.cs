using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RatsCount : MonoBehaviour
{
    private static int initialRats = 100;
    private static int finalRatCount = 1000000;
    private static float initialSphereMass = 5f;

    private static float finalScaleX = 100f;
    private static float finalScaleY = 100f;
    private static float finalScaleZ = 1f;
    private int ratCount;
    private float finalMass = 1f * ((float) finalRatCount / initialRats);

    private static float sphereScaleFactor = 100f;
    private static float massScaleFactor = 2f;

    private Rigidbody2D rb2D;

    private void Awake() {
        this.ratCount = RatsCount.initialRats;
        this.rb2D = GetComponent<Rigidbody2D>();
        this.ChangeSphereSize();
        this.ChangeSphereMass();
    }

    public void ChangeRatCount(int amount) {
        this.ratCount = Mathf.Max(0, this.ratCount + amount);
        this.ChangeSphereSize();
        this.ChangeSphereMass();
    }

    private void ChangeSphereSize() {
        Debug.Log(this.ratCount);
        transform.localScale = new Vector3((float) this.ratCount / RatsCount.finalRatCount * RatsCount.finalScaleX * RatsCount.sphereScaleFactor,
            (float) this.ratCount / RatsCount.finalRatCount * RatsCount.finalScaleY * RatsCount.sphereScaleFactor, RatsCount.finalScaleZ);
        Debug.Log((float) this.ratCount / RatsCount.finalRatCount * RatsCount.finalScaleX * RatsCount.sphereScaleFactor);
    }

    private void ChangeSphereMass() {
        this.rb2D.mass = (float) this.ratCount / RatsCount.finalRatCount * finalMass;
    }

}