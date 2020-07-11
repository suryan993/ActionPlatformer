using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Transforms;
using Unity.Mathematics;

public class MoverSystem : ComponentSystem
{
    protected override void OnUpdate()
    {
        Entities.ForEach((ref Translation translation, ref MoveSpeedComponent moveSpeedComponent) =>
        {
            if(translation.Value.y > 5f)
            {
                moveSpeedComponent.moveSpeed = -math.abs(moveSpeedComponent.moveSpeed);
            }

            if (translation.Value.y < -5f)
            {
                moveSpeedComponent.moveSpeed = +math.abs(moveSpeedComponent.moveSpeed);
            }

            translation.Value.y += 1f * moveSpeedComponent.moveSpeed * Time.deltaTime;
        });
    }
}
