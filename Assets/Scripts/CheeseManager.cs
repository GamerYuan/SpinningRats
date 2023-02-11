using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheeseManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> CheeseTypes;
    [SerializeField] private List<int> cheeseQuantities;
    [SerializeField] private float xMin;
    [SerializeField] private float xMax;
    [SerializeField] private float yMin;
    [SerializeField] private float yMax;

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
                cheese.transform.parent = transform;
            }
        }
    }

    public void RespawnCheese(GameObject cheese)
    {
        cheese.transform
            .SetPositionAndRotation(new Vector2(Random.Range(xMin, xMax), Random.Range(yMin, yMax)),
                                    new Quaternion());
    }
}
