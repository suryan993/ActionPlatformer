using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Transforms;
using Unity.Collections;
using Unity.Rendering;

public class Game : MonoBehaviour
{

    //[SerializeField] private Mesh playerMesh;
    //[SerializeField] private Material playerMaterial;

    //[SerializeField] private Mesh objectMesh;
    //[SerializeField] private Material objectMaterial;

    public PlayerAssetData playerData;
    public ObjectAssetData objectData;

    private EntityManager entityManager;

    private static Game instance;

    public static Game GetInstance()
    {
        return instance;
    }


    private void Awake()
    {
        instance = this;
    }
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
            typeof(MoveSpeedComponent),
            typeof(PlayerComponent),
            typeof(SpriteSheetComponent),
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
                    acceleration = 35.0f,
                    maxSpeed = 10.0f,
                    jumpVelocity = 15.0f
                }
                );

            entityManager.SetComponentData(entity,
                new SpriteSheetComponent
                {
                    sprite = true
                }
                );

        }

        entityArray.Dispose();
    }

    void CreateObjects()
    {
        EntityArchetype objectArchetype = entityManager.CreateArchetype(
            typeof(Translation),
            typeof(ObjectComponent),
            typeof(SpriteSheetComponent),
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

            entityManager.SetComponentData(entity,
                new SpriteSheetComponent
                {
                    sprite = true
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
                    keyLeft = 0,
                    keyRight = 0,
                    keyUp = 0,
                    mouseX = 0.0f,
                    mouseY = 0.0f
                }
                );
        }

        entityArray.Dispose();
    }
}
