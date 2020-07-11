using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Transforms;
using Unity.Mathematics;

public class FloorSystem : ComponentSystem
{
    protected override void OnUpdate()
    {
        Entities.ForEach((ref Translation translation, ref FloorComponent floorComponent, ref MoveSpeedComponent moveSpeedComponent) =>
        {
            if (translation.Value.y < floorComponent.floorY)
            {
                translation.Value.y = floorComponent.floorY;
                moveSpeedComponent.moveSpeedY = 0;
                floorComponent.floored = true;
            }
        });
    }
}
