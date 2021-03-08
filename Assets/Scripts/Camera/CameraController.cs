using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : SingleBehaviour<CameraController>
{
    public Transform target;
    public Vector3 offset;

    public void FixedUpdate()
    {
        if (target == null) return;
        transform.position = Vector3.Lerp(transform.position, target.position + offset, 0.05f);
    }

}
