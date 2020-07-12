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
        // Smoothened input float
        float vertical = Input.GetAxis("Vertical");
        float horizontal = Input.GetAxis("Horizontal");
        Vector2 screenPosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 worldPosition = Camera.main.ScreenToWorldPoint(screenPosition);
        Entities.ForEach((ref InputComponent inputComponent) =>
        {
            inputComponent.horizontal = horizontal;
            inputComponent.vertical = vertical;
            inputComponent.mouseX = worldPosition.x;
            inputComponent.mouseY = worldPosition.y;
        });
    }
}
