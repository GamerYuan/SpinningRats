using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Asteroid : MonoBehaviour
{

    [SerializeField] private float density;

    private Rigidbody2D rb;

    private float scaleFactor = 5f;

    private void Awake() {
        rb = this.GetComponent<Rigidbody2D>();
        float scale = rb.mass / density;
        this.transform.localScale = new Vector3(scale, scale, 1);
    }

    public void setMass(float newMass) {
        this.transform.localScale *= newMass / rb.mass;
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
