using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform Target;
    public Vector3 CameraPosOffset;

    private void Update()
    {
        transform.position = Target.position - CameraPosOffset;
    }
}
