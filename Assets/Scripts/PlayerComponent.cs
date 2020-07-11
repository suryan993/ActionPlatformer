using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;

public struct PlayerComponent : IComponentData
{
    public float acceleration;
    public float maxSpeed;
    public float jumpVelocity;
}
