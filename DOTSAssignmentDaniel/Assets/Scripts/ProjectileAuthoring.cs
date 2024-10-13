
using Unity.Entities;
using UnityEngine;

public class ProjectileAuthoring : MonoBehaviour
{
    public float ProjectileSpeed;
    public Vector3 Direction = Vector3.up;
    
    public class ProjectileAuthoringBaker : Baker<ProjectileAuthoring>
    {
        public override void Bake(ProjectileAuthoring authoring)
        {
            Entity entity = GetEntity(TransformUsageFlags.Dynamic);
            AddComponent(entity, new ProjectileMoveSpeed
            {
                Value = authoring.ProjectileSpeed
            });
            
            //Direction of the projectile. Can be used on other objects to change move direction
            AddComponent(entity, new ProjectileMoveDirection
            {
                Value = authoring.Direction
            });
        }
    }
}
