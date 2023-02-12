using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Asteroid : MonoBehaviour
{
    private Rigidbody2D rb;

    private float scaleFactor = 0.1f;

    private void Awake() {
        rb = GetComponent<Rigidbody2D>();
    }

    public void setMass(float newMass) {
        rb.mass = newMass;
    } 

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.CompareTag("Player")) {
            RatsCount playerRatCount = other.gameObject.GetComponent<RatsCount>();
            if (10 * rb.mass >= playerRatCount.GetRatCount()) {
                playerRatCount.ChangeRatCount(Mathf.Min(-playerRatCount.GetRatCount() * scaleFactor, -1));
            }
        }
    }

}
