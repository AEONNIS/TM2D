﻿using TM2D.ECS;
using UnityEngine;

namespace TM2D.Model.Components
{
    public class MoveV2IntEvent : IComponent
    {
        public Vector2Int Movement { get; }

        public MoveV2IntEvent(Vector2Int movement) => Movement = movement;
    }
}
