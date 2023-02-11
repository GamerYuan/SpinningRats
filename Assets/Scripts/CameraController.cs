using FishNet.Object;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraController : NetworkBehaviour
{
    Quaternion iniRot;
    public override void OnStartClient()
    {
        base.OnStartClient();
        if (base.IsOwner)
        {
            Camera c = GetComponent<Camera>();
            c.enabled = true;
        }
    }

    void Update()
    {
        transform.rotation = Quaternion.identity;
    }
}
