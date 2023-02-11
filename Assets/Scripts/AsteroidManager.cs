using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> AsteroidTypes;
    [SerializeField] private int numAsteroids;
    [SerializeField] private float xMin;
    [SerializeField] private float xMax;
    [SerializeField] private float yMin;
    [SerializeField] private float yMax;
    [SerializeField] private float minAsteroidMass;
    [SerializeField] private float maxAsteroidMass;
    [SerializeField] private float massLengthRatio;
    [SerializeField] private float unscaledAsteroidWidth;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < numAsteroids; i++)
        {
            float asteroidMass = Random.Range(minAsteroidMass, maxAsteroidMass);
            float asteroidLength = asteroidMass / massLengthRatio;
            Vector2 pos;
            int attempts = 0;
            do
            {
                pos = new Vector2(Random.Range(xMin, xMax), Random.Range(yMin, yMax));
                attempts++;
            } while (attempts < 20 && Physics2D.OverlapCircleAll(pos, asteroidLength / 2).Length > 0);
            if (attempts >= 20) {
                Debug.Log("Asteroid spawn failed");
                continue;
            }
            GameObject asteroid = Instantiate(AsteroidTypes[Random.Range(0, AsteroidTypes.Count)]);
            asteroid.transform.SetPositionAndRotation(pos, new Quaternion());
            asteroid.transform.localScale *= asteroidLength / unscaledAsteroidWidth;
            asteroid.GetComponent<Asteroid>().setMass(asteroidMass);
            asteroid.transform.parent = transform;
        }
    }
}
