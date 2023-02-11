using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheeseManager : MonoBehaviour
{
    public List<GameObject> CheeseTypes;
    public List<int> cheeseQuantities;
    public float xMin;
    public float xMax;
    public float yMin;
    public float yMax;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < CheeseTypes.Count; i++)
        {
            for (int j = 0; j < cheeseQuantities[i]; j++)
            {
                GameObject cheese = Instantiate(CheeseTypes[i]);
                cheese.transform
                .SetPositionAndRotation(new Vector2(Random.Range(xMin, xMax), Random.Range(yMin, yMax)),
                                        new Quaternion());
                cheese.transform.parent = this.transform;
            }
        }
    }
}
