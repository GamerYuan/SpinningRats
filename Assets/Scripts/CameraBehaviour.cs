
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private GameObject player;

    private RatsCount ratCount;
    private float currRatCount;
    private float ortho;

    void Start()
    {
        ratCount = player.GetComponent<RatsCount>();
    }

    // Update is called once per frame
    void Update()
    {
        currRatCount = ratCount.GetRatCount();
    }
}
