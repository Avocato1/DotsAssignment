
using Unity.Entities;
using Unity.Mathematics;

public struct Spawner : IComponentData
{
    public Entity prefab;
    public float2 SpawnPosition;
    public float NextSpawnTime;
    public float SpawnRate;
}