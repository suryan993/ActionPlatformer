using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;

public struct InputComponent : IComponentData
{
    public float horizontal;
    public float vertical;
    public float mouseX;
    public float mouseY;
}
