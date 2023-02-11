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

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < numAsteroids; i++)
        {
            GameObject asteroid = Instantiate(AsteroidTypes[Random.Range(0, AsteroidTypes.Count)]);
            asteroid.transform
                .SetPositionAndRotation(new Vector2(Random.Range(xMin, xMax), Random.Range(yMin, yMax)),
                                        new Quaternion());
            transform.parent = transform;
            asteroid.GetComponent<Asteroid>().setMass(Random.Range(minAsteroidMass, maxAsteroidMass));
        }
    }
}
