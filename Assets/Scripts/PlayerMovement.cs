using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.Rendering;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float speed;
    [SerializeField] private float degrees;

    private float initialMass = 100f;
    
    private Rigidbody2D rb;
    private RatsCount ratCount;

    private ParticleSystem BoostParticles;
    private ParticleSystem DamageParticles;

    void Awake()
    {
        this.BoostParticles = transform.GetChild(1).GetComponent<ParticleSystem>();
        this.DamageParticles = transform.GetChild(2).GetComponent<ParticleSystem>();
        DamageParticles.Stop();
        BoostParticles.Stop();
        rb = GetComponent<Rigidbody2D>();
        ratCount = GetComponent<RatsCount>();
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetKey(KeyCode.A) && Input.GetKeyDown(KeyCode.D)) || (Input.GetKeyDown(KeyCode.A) && Input.GetKey(KeyCode.D)))
        {
            float rotation = (transform.eulerAngles.z + 90) * Mathf.Deg2Rad;
            ratCount.ChangeRatCount(-5);
            float currCount = ratCount.GetRatCount();
            float currSpeed = speed * currCount / initialMass;
            BoostAnim();
            rb.AddForce(new Vector2(currSpeed * Mathf.Cos(rotation), currSpeed * Mathf.Sin(rotation)), ForceMode2D.Impulse);
        }
    }

    void BoostAnim()
    {
        BoostParticles.Play();
        StartCoroutine(waitForTime(5.0f));
        BoostParticles.Stop();

    }

    public void TakeDamage()
    {
        DamageParticles.Play();
        StartCoroutine(waitForTime(1.0f));
        DamageParticles.Stop();
    }

    IEnumerator waitForTime(float timeToWait)
    {
        yield return new WaitForSeconds(timeToWait);
    }
    void FixedUpdate()
    {
        float horizontalMove = Input.GetAxisRaw("Horizontal");
        
        if (horizontalMove != 0f)
        {
            float currCount = ratCount.GetRatCount();
            float currRot = degrees* currCount / initialMass;

            if (horizontalMove > 0)
            {
                rb.AddTorque(-currRot * Mathf.Deg2Rad * rb.inertia, ForceMode2D.Impulse);
            }
            else if (horizontalMove < 0)
            {
                rb.AddTorque(currRot * Mathf.Deg2Rad * rb.inertia, ForceMode2D.Impulse);
            }
        }

    }
}
