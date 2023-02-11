using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Asteroid : MonoBehaviour
{

    private float mass;

    private float scaleFactor = 5f;

    private void Awake() {
        this.mass = this.GetComponent<Rigidbody2D>().mass;
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.CompareTag("Player")) {
            RatsCount playerRatCount = other.gameObject.GetComponent<RatsCount>();
            Debug.Log(this.mass);
            Debug.Log(playerRatCount.GetSphereMass());
            if (this.mass > playerRatCount.GetSphereMass()) {
                playerRatCount.ChangeRatCount(- (this.mass - playerRatCount.GetSphereMass()) * scaleFactor);
            }
        }
    }

}