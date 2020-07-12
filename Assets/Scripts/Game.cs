using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Transforms;
using Unity.Collections;
using Unity.Rendering;

public class Game : MonoBehaviour
{

    [SerializeField] private Mesh playerMesh;
    [SerializeField] private Material playerMaterial;

    [SerializeField] private Mesh objectMesh;
    [SerializeField] private Material objectMaterial;

    private EntityManager entityManager;

    private void Start()
    {
        entityManager = World.Active.EntityManager;
        CreatePlayer();
        CreateObjects();
        CreateInputComponents();
    }

    void Update()
    {

    }

    void CreatePlayer()
    {
        EntityArchetype playerArchetype = entityManager.CreateArchetype(
            typeof(Translation),
            typeof(RenderMesh),
            typeof(LocalToWorld),
            typeof(MoveSpeedComponent),
            typeof(PlayerComponent),
            typeof(GravityComponent),
            typeof(FloorComponent),
            typeof(FrictionComponent)
        );

        NativeArray<Entity> entityArray = new NativeArray<Entity>(1, Allocator.Temp);
        entityManager.CreateEntity(playerArchetype, entityArray);

        for (int i = 0; i < entityArray.Length; i++)
        {
            Entity entity = entityArray[i];

            entityManager.SetComponentData(entity,
                new MoveSpeedComponent
                {
                    moveSpeedX = 0,
                    moveSpeedY = 0
                }
                );

            entityManager.SetComponentData(entity,
                new FrictionComponent
                {
                    friction = 20.0f
                }
                );

            entityManager.SetComponentData(entity,
                new Translation
                {
                    Value = new Unity.Mathematics.float3(0,0, 0)
                }
                );

            entityManager.SetComponentData(entity,
                new GravityComponent
                {
                    gravity = 30.0f
                }
                );

            entityManager.SetComponentData(entity,
                new FloorComponent
                {
                    floorY = -2,
                    floored = false
                }
                );

            entityManager.SetComponentData(entity,
                new PlayerComponent
                {
                    acceleration = 45.0f,
                    maxSpeed = 10.0f,
                    jumpVelocity = 12.0f
                }
                );

            entityManager.SetSharedComponentData(entity,
                new RenderMesh
                {
                    mesh = playerMesh,
                    material = playerMaterial
                }
                );
        }

        entityArray.Dispose();
    }

    void CreateObjects()
    {
        EntityArchetype objectArchetype = entityManager.CreateArchetype(
            typeof(Translation),
            typeof(RenderMesh),
            typeof(LocalToWorld),
            typeof(ObjectComponent),
            typeof(RevolveComponent)
        );

        NativeArray<Entity> entityArray = new NativeArray<Entity>(1, Allocator.Temp);
        entityManager.CreateEntity(objectArchetype, entityArray);

        for (int i = 0; i < entityArray.Length; i++)
        {
            Entity entity = entityArray[i];


            entityManager.SetComponentData(entity,
                new RevolveComponent
                {
                    centerX = 0,
                    centerY = 0,
                    radius = 2.0f
                }
                );

            entityManager.SetComponentData(entity,
                new Translation
                {
                    Value = new Unity.Mathematics.float3(Random.Range(-8, 8f), Random.Range(-5, 5f), 0)
                }
                );

            entityManager.SetSharedComponentData(entity,
                new RenderMesh
                {
                    mesh = objectMesh,
                    material = objectMaterial
                }
                );
        }

        entityArray.Dispose();
    }

    void CreateInputComponents()
    {
        EntityArchetype keyboardInputArchetype = entityManager.CreateArchetype(
            typeof(InputComponent)
        );

        NativeArray<Entity> entityArray = new NativeArray<Entity>(1, Allocator.Temp);
        entityManager.CreateEntity(keyboardInputArchetype, entityArray);

        for (int i = 0; i < entityArray.Length; i++)
        {
            Entity entity = entityArray[i];


            entityManager.SetComponentData(entity,
                new InputComponent
                {
                    horizontal = 0,
                    vertical = 0,
                    mouseX = 0.0f,
                    mouseY = 0.0f
                }
                );
        }

        entityArray.Dispose();
    }
}
