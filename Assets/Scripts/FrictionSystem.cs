using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Transforms;
using Unity.Mathematics;

public class FrictionSystem : ComponentSystem
{
    protected override void OnUpdate()
    {
        Entities.ForEach((ref FrictionComponent frictionComponent, ref MoveSpeedComponent moveSpeedComponent, ref FloorComponent floorComponent) =>
        {
            if (floorComponent.floored)
            {
                moveSpeedComponent.moveSpeedX += math.sign(moveSpeedComponent.moveSpeedX) * -1 * frictionComponent.friction * Time.deltaTime;
            }
        });
    }
}
