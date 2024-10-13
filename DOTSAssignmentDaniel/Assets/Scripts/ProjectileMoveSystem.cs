
using Unity.Burst;
using Unity.Entities;
using Unity.Transforms;


public partial struct ProjectileMoveSystem : ISystem
{
        [BurstCompile]
    public void OnUpdate( ref SystemState State )
    {
        float deltaTime = SystemAPI.Time.DeltaTime;
        foreach (var ( transform, moveSpeed , direction) in SystemAPI.Query<RefRW<LocalTransform>, ProjectileMoveSpeed, ProjectileMoveDirection>())
        {
           transform.ValueRW.Position += direction.Value * moveSpeed.Value * deltaTime;
        }
        
    }

}
