using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Transforms;
using Unity.Rendering;

public class SpriteSheetRendererSystem : ComponentSystem
{

    protected override void OnUpdate()
    {
        Entities.ForEach((ref Translation translation, ref SpriteSheetComponent spriteSheetComponent, ref PlayerComponent playerComponent) =>
        {
            MaterialPropertyBlock materialPropertyBlock = new MaterialPropertyBlock();
            float uvWidth = 1f/6;
            float uvHeight = 1f;
            float uvOffsetX = 0f;
            float uvOffsetY = 0f;
            Vector4 uv = new Vector4(uvWidth, uvHeight, uvOffsetX, uvOffsetY);

            materialPropertyBlock.SetVectorArray("_MainTex_UV", new Vector4[] { uv});

            Graphics.DrawMesh(Game.GetInstance().playerData.Mesh, translation.Value, Quaternion.identity, Game.GetInstance().playerData.Material, 0, Camera.main, 0, materialPropertyBlock);
        });

        Entities.ForEach((ref Translation translation, ref SpriteSheetComponent spriteSheetComponent, ref ObjectComponent objectComponent) =>
        {
            Graphics.DrawMesh(Game.GetInstance().objectData.Mesh, translation.Value, Quaternion.identity, Game.GetInstance().objectData.Material, 0);
        });
    }
}
