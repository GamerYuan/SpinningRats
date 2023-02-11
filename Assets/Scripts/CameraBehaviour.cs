using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private GameObject player;

    private RatsCount ratCount;
    private float currRatCount;
    private CinemachineVirtualCamera cam;

    void Start()
    {
        ratCount = player.GetComponent<RatsCount>();
        cam = GetComponent<CinemachineVirtualCamera>();
    }

    // Update is called once per frame
    void Update()
    {
        currRatCount = ratCount.GetRatCount();
    }
}
