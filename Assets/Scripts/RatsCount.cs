using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RatsCount : MonoBehaviour
{
    private static float initialRats = 100;
    private static float finalRatCount = 100000;
    private static float initialSphereMass = 5f;

    private static float finalScaleX = 100f;
    private static float finalScaleY = 100f;
    private static float finalScaleZ = 1f;
    private float ratCount;
    private float finalMass = 1f * (finalRatCount / initialRats);

    private static float sphereScaleFactor = 0.05f;
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

    public static float GetInitialRatCount() {
        return RatsCount.initialRats;
    }

    public static float GetInitialScale() {
        return RatsCount.initialRats / RatsCount.finalRatCount;
    }

    public float GetSphereSize() {
        return transform.localScale.x;
    }

    public bool IsLosingRatCount() {
        return this.ratCount <= 0;
    }

    public bool IsWinningRatCount() {
        return this.ratCount >= RatsCount.finalRatCount;
    }

    public void Boost()
    {
        this.ratCount -= Mathf.Max(1, this.ratCount * 0.01F);
        this.ChangeSphereSize();
        this.ChangeSphereMass();
        Moon.SetMoonSize();
        RatCountText.UpdateText(this.ratCount);
    }

    public void ChangeRatCount(float amount) {
        this.ratCount = Mathf.Max(0, this.ratCount + amount);
        this.ChangeSphereSize();
        this.ChangeSphereMass();
        Moon.SetMoonSize();
        DamageParticles.Play();
        stopAnim = true;
        RatCountText.UpdateText(this.ratCount);
    }

    public void addRat(float amount)
    {
        this.ratCount = Mathf.Max(0, this.ratCount + amount);
        this.ChangeSphereSize();
        this.ChangeSphereMass();
        Moon.SetMoonSize();
        RatCountText.UpdateText(this.ratCount);
    }

    private void ChangeSphereSize() {
        //Debug.Log(this.ratCount);
        transform.localScale = new Vector3(Mathf.Pow(this.ratCount, 0.3f) * RatsCount.sphereScaleFactor,
            Mathf.Pow(this.ratCount, 0.3f) * RatsCount.sphereScaleFactor, 1);
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
