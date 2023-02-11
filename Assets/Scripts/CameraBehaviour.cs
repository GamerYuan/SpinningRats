using Cinemachine;
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
    private CinemachineVirtualCamera cam;
    private float currRatCount;
    private float ortho;

    void Start()
    {
        ratCount = player.GetComponent<RatsCount>();
        cam = GetComponent<CinemachineVirtualCamera>();
        ortho = cam.m_Lens.OrthographicSize;
    }

    // Update is called once per frame
    void Update()
    {
        currRatCount = ratCount.GetRatCount();
        cam.m_Lens.OrthographicSize = currRatCount / 100 * ortho;
    }
}
