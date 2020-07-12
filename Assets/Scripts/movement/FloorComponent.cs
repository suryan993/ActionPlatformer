﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;

public struct FloorComponent : IComponentData
{
    public float floorY;
    public bool floored;
}
