// using Unity.Entities;
// using Unity.Mathematics;
// using Unity.Transforms;
// using UnityEngine;

// public class FacePlayerSystem : ComponentSystem
// { 
//    [SerializeField] public GameManager GameManager;

     
//     protected override void OnUpdate()
//     {   
//         float3 playerPos = (float3)GameManager.GetPlayerPosition();
 
//         Entities.ForEach((Entity entity, ref Translation trans, ref Rotation rot) =>
//         {
//             // 5
//             float3 direction = playerPos - trans.Value;
//             direction.y = 0f;

//             // 6
//             rot.Value = quaternion.LookRotation(direction, math.up());
//         });
//     }
// }
