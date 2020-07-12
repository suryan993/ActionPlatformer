using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;

public struct RevolveComponent : IComponentData
{
    public float centerX;
    public float centerY;
    public float radius;
}
