using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.Rendering;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float speed;
    [SerializeField] private float degrees;

    private float initialMass = 100f;
    private bool stopAnim = false;
    private float timer = 1f;
    
    private Rigidbody2D rb;
    private RatsCount ratCount;
    private Transform particle;
    private ParticleSystem BoostParticles;

    void Awake()
    {
        this.particle = transform.GetChild(1);
        this.BoostParticles = transform.GetChild(1).GetComponent<ParticleSystem>();
        BoostParticles.Stop();
        rb = GetComponent<Rigidbody2D>();
        ratCount = GetComponent<RatsCount>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (stopAnim)
        {
            timer -= Time.deltaTime;
        }

        if (timer <= 0f)
        {
            stopAnim = false;
            BoostParticles.Stop();
            timer = 1f;
        }
        
        if ((Input.GetKey(KeyCode.A) && Input.GetKeyDown(KeyCode.D)) || (Input.GetKeyDown(KeyCode.A) && Input.GetKey(KeyCode.D)))
        {
            
            BoostParticles.Play();
            stopAnim = true;
            float rotation = (transform.eulerAngles.z + 90) * Mathf.Deg2Rad;
            ratCount.Boost(-1);
            float currCount = ratCount.GetRatCount();
            float currSpeed = speed * currCount / initialMass;
            rb.AddForce(new Vector2(currSpeed * Mathf.Cos(rotation), currSpeed * Mathf.Sin(rotation)), ForceMode2D.Impulse);
        }
    }

    void FixedUpdate()
    {
        float horizontalMove = Input.GetAxisRaw("Horizontal");
        
        if (!stopAnim)
        {
            BoostParticles.Stop();
        }

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
