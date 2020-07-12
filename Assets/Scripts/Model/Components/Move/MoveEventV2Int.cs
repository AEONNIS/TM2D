using TM2D.ECS;
using UnityEngine;

namespace TM2D.Model.Components.Move
{
    public class MoveEventV2Int : IComponent
    {
        public Vector2Int Movement { get; }

        public MoveEventV2Int(Vector2Int movement) => Movement = movement;
    }
}
