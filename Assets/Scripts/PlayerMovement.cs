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
    [SerializeField] private float ratDepletionRate;
    
    private Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    
    // Update is called once per frame
    void FixedUpdate()
    {
        float horizontalMove = Input.GetAxisRaw("Horizontal");

        if (horizontalMove > 0) {
            rb.AddTorque(-degrees * Mathf.Deg2Rad * rb.inertia, ForceMode2D.Force);
        } 
        else if (horizontalMove < 0)
        {
            rb.AddTorque(degrees * Mathf.Deg2Rad * rb.inertia, ForceMode2D.Force);
        }

        if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.D)) {
            float rotation = (transform.eulerAngles.z + 90) * Mathf.Deg2Rad;
            rb.AddForce(new Vector2(speed * Mathf.Cos(rotation), speed * Mathf.Sin(rotation)), ForceMode2D.Force);
            gameObject.GetComponent<RatsCount>().ChangeRatCount(-ratDepletionRate * Time.deltaTime);
            Debug.Log(gameObject.GetComponent<RatsCount>().GetRatCount());
        }
    }
}
