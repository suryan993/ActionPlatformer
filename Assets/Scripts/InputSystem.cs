using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Transforms;
using Unity.Mathematics;

public class KeyboardInputSystem : ComponentSystem
{
    protected override void OnUpdate()
    {
        Entities.ForEach((ref InputComponent inputComponent) =>
        {
            if (Input.GetKey("left"))
            {
                inputComponent.keyRight = 0;
                inputComponent.keyLeft = 1;
            } else if (Input.GetKey("right"))
            {
                inputComponent.keyRight = 1;
                inputComponent.keyLeft = 0;
            } else
            {
                inputComponent.keyRight = 0;
                inputComponent.keyLeft = 0;
            }

            if (Input.GetKeyDown("up"))
            {
                inputComponent.keyUp= 1;
            } else
            {
                inputComponent.keyUp = 0;
            }

            Vector2 screenPosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            Vector2 worldPosition = Camera.main.ScreenToWorldPoint(screenPosition);

            inputComponent.mouseX = worldPosition.x;
            inputComponent.mouseY = worldPosition.y;
        });
    }
}
