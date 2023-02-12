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
    [SerializeField] private float asteroidSizeFactor;
    [SerializeField] private float unscaledAsteroidLength;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < numAsteroids; i++)
        {
            float asteroidMass = Mathf.Pow(Random.Range(Mathf.Pow(minAsteroidMass, 0.3f), Mathf.Pow(maxAsteroidMass, 0.3f)), 1/0.3f);
            float asteroidLength = Mathf.Pow(asteroidMass, 0.3f) * asteroidSizeFactor;
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
            asteroid.transform.localScale *= asteroidLength / unscaledAsteroidLength;
            asteroid.GetComponent<Asteroid>().setMass(asteroidMass);
            asteroid.transform.parent = transform;
        }
    }
}
