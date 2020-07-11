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
        //Get Input
        int keyLeft = 0;
        int keyRight = 0;
        int keyUp = 0;
        float mouseX = 0;
        float mouseY = 0;
        Entities.ForEach((ref InputComponent inputComponent) =>
        {
            keyLeft = inputComponent.keyLeft;
            keyRight = inputComponent.keyRight;
            keyUp = inputComponent.keyUp;
            mouseX = inputComponent.mouseX;
            mouseY = inputComponent.mouseY;
        });

        //Velocity movement
        Entities.ForEach((ref Translation translation, ref MoveSpeedComponent moveSpeedComponent) =>
        {
            translation.Value.x += moveSpeedComponent.moveSpeedX * Time.deltaTime;
            translation.Value.y += moveSpeedComponent.moveSpeedY * Time.deltaTime;
        });

        //Horizontal move of player entities
        Entities.ForEach((ref Translation translation, ref MoveSpeedComponent moveSpeedComponent, ref PlayerComponent playerComponent, ref FloorComponent floorComponent) =>
        {
            if (floorComponent.floored)
            {
                moveSpeedComponent.moveSpeedX += (-playerComponent.acceleration * keyLeft * Time.deltaTime) + (playerComponent.acceleration * keyRight * Time.deltaTime);
            } else
            {
                moveSpeedComponent.moveSpeedX += (-playerComponent.acceleration * keyLeft * Time.deltaTime) + (playerComponent.acceleration * keyRight * Time.deltaTime) * 0.5f;
            }

            if(moveSpeedComponent.moveSpeedX > playerComponent.maxSpeed)
            {
                moveSpeedComponent.moveSpeedX = playerComponent.maxSpeed;
            }

            if (moveSpeedComponent.moveSpeedX < -playerComponent.maxSpeed)
            {
                moveSpeedComponent.moveSpeedX = -playerComponent.maxSpeed;
            }

        });

        //Jump Speed and action of player entities
        Entities.ForEach((ref Translation translation, ref MoveSpeedComponent moveSpeedComponent, ref PlayerComponent playerComponent, ref FloorComponent floorComponent) =>
        {
            if (floorComponent.floored && keyUp == 1)
            {
                moveSpeedComponent.moveSpeedY = playerComponent.jumpVelocity;
                floorComponent.floored = false;
            }
        });

        //Move object entities around player
        Entities.ForEach((ref Translation translation, ref RevolveComponent revolveComponent) =>
        {
            Vector2 centerPos = new Vector2(revolveComponent.centerX, revolveComponent.centerY);
            Vector2 mousePos = new Vector2(mouseX, mouseY);
            float radius = revolveComponent.radius;

            Vector2 centerToMouse = mousePos - centerPos;
            Vector2 finalPos = centerToMouse.normalized * revolveComponent.radius + centerPos;

            translation.Value.x = finalPos.x;
            translation.Value.y = finalPos.y;

        });

    }
}
