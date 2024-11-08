using System.Runtime.CompilerServices;
using UnityEngine;

namespace ZooWorld
{
    public static class VectorExtensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 FromXZ(this Vector2 vector, float y = 0)
        {
            return new Vector3(vector.x, y, vector.y);
        }
    }
}