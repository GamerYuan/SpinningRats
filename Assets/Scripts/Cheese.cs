using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Cheese : MonoBehaviour
{
    [SerializeField] private int size;
    [SerializeField] private List<Sprite> sprites;

    private void Awake() {
        gameObject.GetComponent<SpriteRenderer>().sprite = sprites[Random.Range(0, sprites.Count)];
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("Player") &&
            other.gameObject.GetComponent<RatsCount>().GetRatCount() >= size) {
            other.gameObject.GetComponent<RatsCount>().addRat(size);
            transform.parent.gameObject.GetComponent<CheeseManager>().RespawnCheese(gameObject);
        }
    }
}
