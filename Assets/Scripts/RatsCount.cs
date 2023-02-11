using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RatsCount : MonoBehaviour
{
    private static float initialRats = 100;
    private static float finalRatCount = 1000000;
    private static float initialSphereMass = 5f;

    private static float finalScaleX = 100f;
    private static float finalScaleY = 100f;
    private static float finalScaleZ = 1f;
    private float ratCount;
    private float finalMass = 1f * (finalRatCount / initialRats);

    private static float sphereScaleFactor = 100f;
    private static float massScaleFactor = 2f;
    private bool stopAnim = false;
    private float timer = 0.5f;

    public delegate float RatScale();
    public static RatScale RatScaleEvent;

    private Rigidbody2D rb2D;
    private ParticleSystem DamageParticles;

    private void Awake() {
        this.ratCount = RatsCount.initialRats;
        this.rb2D = GetComponent<Rigidbody2D>();
        this.ChangeSphereSize();
        this.ChangeSphereMass();
        RatsCount.RatScaleEvent += GetRatScale;
        this.DamageParticles = transform.GetChild(2).GetComponent<ParticleSystem>();
        DamageParticles.Stop();
    }

    private void Update()
    {
        if (stopAnim)
        {
            timer -= Time.deltaTime;
        }

        if (timer <= 0f)
        {
            stopAnim = false;
            DamageParticles.Stop();
            timer = 0.5f;
        }
    }

    private void OnDestroy()
    {
        RatsCount.RatScaleEvent -= GetRatScale;
    }

    public float GetRatCount() {
        return this.ratCount;
    }

    public bool IsLosingRatCount() {
        return this.ratCount <= 0;
    }

    public bool IsWinningRatCount() {
        return this.ratCount >= RatsCount.finalRatCount;
    }

    public void Boost(float amount)
    {
        this.ratCount = Mathf.Max(0, this.ratCount + amount);
        this.ChangeSphereSize();
        this.ChangeSphereMass();
        RatCountText.UpdateText(this.ratCount);
    }

    public void ChangeRatCount(float amount) {
        this.ratCount = Mathf.Max(0, this.ratCount + amount);
        this.ChangeSphereSize();
        this.ChangeSphereMass();
        DamageParticles.Play();
        stopAnim = true;
        RatCountText.UpdateText(this.ratCount);
    }

    private void ChangeSphereSize() {
        //Debug.Log(this.ratCount);
        transform.localScale = new Vector3(this.ratCount / RatsCount.finalRatCount * RatsCount.finalScaleX * RatsCount.sphereScaleFactor,
            this.ratCount / RatsCount.finalRatCount * RatsCount.finalScaleY * RatsCount.sphereScaleFactor, RatsCount.finalScaleZ);
        //Debug.Log(this.ratCount / RatsCount.finalRatCount * RatsCount.finalScaleX * RatsCount.sphereScaleFactor);
    }

    private void ChangeSphereMass() {
        this.rb2D.mass = this.ratCount / RatsCount.finalRatCount * finalMass;
    }

    public float GetSphereMass() {
        return this.rb2D.mass;
    }

    private float GetRatScale()
    {
        return this.ratCount / RatsCount.finalRatCount;
    }

}
