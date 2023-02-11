using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Asteroid : MonoBehaviour
{
    private Rigidbody2D rb;

    private float scaleFactor = 5f;

    private void Awake() {
        rb = this.GetComponent<Rigidbody2D>();
    }

    public void setMass(float newMass) {
        rb.mass = newMass;
    } 

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.CompareTag("Player")) {
            RatsCount playerRatCount = other.gameObject.GetComponent<RatsCount>();
            Debug.Log(rb.mass);
            Debug.Log(playerRatCount.GetSphereMass());
            if (rb.mass > playerRatCount.GetSphereMass()) {
                playerRatCount.ChangeRatCount(- (rb.mass - playerRatCount.GetSphereMass()) * scaleFactor);
            }
        }
    }

}
