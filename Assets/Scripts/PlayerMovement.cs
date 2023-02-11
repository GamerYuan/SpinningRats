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
    
    private Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetKey(KeyCode.A) && Input.GetKeyDown(KeyCode.D)) || (Input.GetKeyDown(KeyCode.A) && Input.GetKey(KeyCode.D)))
        {
            float rotation = (transform.eulerAngles.z + 90) * Mathf.Deg2Rad;
            rb.AddForce(new Vector2(speed * Mathf.Cos(rotation), speed * Mathf.Sin(rotation)), ForceMode2D.Impulse);
        }
    }
    void FixedUpdate()
    {
        float horizontalMove = Input.GetAxisRaw("Horizontal");

        if (horizontalMove > 0) {
            rb.AddTorque(-degrees * Mathf.Deg2Rad * rb.inertia, ForceMode2D.Impulse);
        } 
        else if (horizontalMove < 0)
        {
            rb.AddTorque(degrees * Mathf.Deg2Rad * rb.inertia, ForceMode2D.Impulse);
        }

    }
}
