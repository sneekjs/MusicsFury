using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class OrbData
{
    public float StartingSpeed;
    public float DestroyDelay;

    public bool UseAcceleration;
    public float AccelerationMultiplier;

    public bool MoveToTarget;
    public Vector3 TargetLocation;
}
