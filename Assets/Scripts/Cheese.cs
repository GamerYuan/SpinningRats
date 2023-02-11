using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Cheese : MonoBehaviour
{
    [SerializeField] private int size;

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("Player") &&
            other.gameObject.GetComponent<RatsCount>().GetRatCount() >= size) {
            other.gameObject.GetComponent<RatsCount>().ChangeRatCount(size);
            transform.parent.gameObject.GetComponent<CheeseManager>().RespawnCheese(gameObject);
        }
    }
}
