using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using Unity.Rendering;
using Unity.Collections; //access to a special collection type called NativeArray. NativeArrays can loop through Entities with less memory overhead

public class EnemySpawner : MonoBehaviour
{
    private EntityManager entityManager;
    [SerializeField] private Mesh enemyMesh;
    [SerializeField] private Material enemyMaterial;

    [SerializeField] private GameObject enemyPrefab;
    
    private Entity enemyEntityPrefab;
 
    private void Start()
    {
        entityManager = World.DefaultGameObjectInjectionWorld.EntityManager;

        //Entity prefab that you can build at runtime
        var settings = GameObjectConversionSettings.FromWorld(World.DefaultGameObjectInjectionWorld, null); 
        enemyEntityPrefab = GameObjectConversionUtility.ConvertGameObjectHierarchy(enemyPrefab, settings);
 
        SpawnWave();

    }

    //randomly place an array of Entities in a circle formation
    private void SpawnWave()
    {
        // 1
        int spawnCount = 1000;
        NativeArray<Entity> enemyArray = new NativeArray<Entity>(spawnCount, Allocator.Temp);

        // 2
        for (int i = 0; i < enemyArray.Length; i++)
        {
            enemyArray[i] = entityManager.Instantiate(enemyEntityPrefab);

            // 3
            int minSpeed = -30;
            int maxSpeed = 30;
            entityManager.SetComponentData(enemyArray[i], new Translation { Value = UnityEngine.Random.Range(minSpeed, maxSpeed) }); 

            // 4
            entityManager.SetComponentData(enemyArray[i], new MoveForward { speed = UnityEngine.Random.Range(minSpeed, maxSpeed) }); 
        }

        // 5
        enemyArray.Dispose();

        // 6
        int difficultyBonus = 1;
        spawnCount += difficultyBonus;
    }

   
}
