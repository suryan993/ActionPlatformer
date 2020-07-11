using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;

public struct InputComponent : IComponentData
{
    public int keyLeft;
    public int keyRight;
    public int keyUp;
    public float mouseX;
    public float mouseY;
}
