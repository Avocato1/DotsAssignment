
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

public partial struct  SpawnerSystem : ISystem
{
    public void OnCreate(ref SystemState state){ }
    public void OnDestroy(ref SystemState state){ }

    public void OnUpdate(ref SystemState state)
    {
        // Get the players position
        float3 playerPosition = float3.zero; 
        foreach (var (transform, input) in SystemAPI.Query<LocalTransform, PlayerMoveInput>())
        {
            playerPosition = transform.Position;
            break; 
        }
        
        foreach (RefRW<Spawner> spawner in SystemAPI.Query<RefRW<Spawner>>())
        {
            if (spawner.ValueRO.NextSpawnTime < SystemAPI.Time.ElapsedTime)
            {
                //Randomize the X position within a range of players position
                float randomOffsetX = UnityEngine.Random.Range(-8f, 8f);
                // always spawn above the player
                float spawnHeightAbovePlayer = 8f;
                float3 spawnPos = playerPosition + new float3(randomOffsetX, spawnHeightAbovePlayer, 0);
                
                Entity newEntity = state.EntityManager.Instantiate(spawner.ValueRO.prefab);
                state.EntityManager.SetComponentData(newEntity, LocalTransform.FromPosition(spawnPos));
                
                spawner.ValueRW.NextSpawnTime = (float)SystemAPI.Time.ElapsedTime + spawner.ValueRO.SpawnRate;
            }
        }
    }
}

