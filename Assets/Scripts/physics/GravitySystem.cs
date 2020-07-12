using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Transforms;
using Unity.Mathematics;

public class GravitySystem : ComponentSystem
{
    protected override void OnUpdate()
    {
        Entities.ForEach((ref GravityComponent gravityComponent, ref Translation translation, ref FloorComponent floorComponent, ref MoveSpeedComponent moveSpeedComponent) =>
        {
            if (!floorComponent.floored)
            {
                moveSpeedComponent.moveSpeedY -= gravityComponent.gravity * Time.deltaTime;
            }
        });
    }
}
