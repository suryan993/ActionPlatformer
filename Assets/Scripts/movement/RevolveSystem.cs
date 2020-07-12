using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Transforms;
using Unity.Mathematics;

public class RevolveSystem : ComponentSystem
{
    protected override void OnUpdate()
    {
        float playerX = 0;
        float playerY = 0;
        Entities.ForEach((ref PlayerComponent playerComponent, ref Translation translation) =>
        {
            playerX = translation.Value.x;
            playerY = translation.Value.y;
        });

        Entities.ForEach((ref RevolveComponent revolveComponent) =>
        {
            revolveComponent.centerX = playerX;
            revolveComponent.centerY = playerY;
        });
    }
}
