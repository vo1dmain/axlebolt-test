using System;

using UnityEngine;

namespace Assets.Scripts.Bounds
{
    [CreateAssetMenu(fileName = "Bounds", menuName = "Scriptable Object/Bounds")]
    public class Bounds : ScriptableObject
    {
        protected Vector2 _topRight = Vector2.zero;
        public Vector2 TopRight => TryGetValue(ref _topRight);

        protected Vector2 _bottomLeft = Vector2.zero;
        public Vector2 BottomLeft => TryGetValue(ref _bottomLeft);


        public float Right => TryGetValue(ref _topRight.x);
        public float Left => TryGetValue(ref _bottomLeft.x);

        public float Top => TryGetValue(ref _topRight.y);
        public float Bottom => TryGetValue(ref _bottomLeft.y);



        internal void Write(Vector2 topRight, Vector2 bottomLeft)
        {
            _topRight = topRight;
            _bottomLeft = bottomLeft;
        }



        public Vector2 Reflect(Vector2 inDirection, Vector2 objectSize)
        {
            var coords = CalculateObjectBounds(inDirection, objectSize);

            var normalX = coords[0] == Left ? Vector2.right.x : coords[2] == Right ? Vector2.left.x : 0;
            var normalY = coords[1] == Top ? Vector2.down.y : coords[3] == Bottom ? Vector2.up.y : 0;

            var inNormal = new Vector2(normalX, normalY);

            return Vector2.Reflect(inDirection, inNormal) * 2f;
        }

        public bool AreCrossed(Vector2 position, Vector2 objectSize)
        {
            var coords = CalculateObjectBounds(position, objectSize);

            return coords[0] < Left || coords[1] > Top || coords[2] > Right || coords[3] < Bottom;
        }

        public bool AreTouched(Vector2 position, Vector2 objectSize)
        {
            var coords = CalculateObjectBounds(position, objectSize);

            return coords[0] == Left || coords[1] == Top || coords[2] == Right || coords[3] == Bottom;
        }




        /// <summary>
        /// Returns the coords of object's bounds clockwise (left, top, right, bottom).
        /// </summary>
        /// <param name="position">Current position of object.</param>
        /// <param name="objectSize">Size of object (x,y).</param>
        /// <returns></returns>
        protected float[] CalculateObjectBounds(Vector2 position, Vector2 objectSize)
        {
            var leftCoord = position.x - objectSize.x / 2;
            var rightCoord = position.x + objectSize.x / 2;

            var topCoord = position.y + objectSize.y / 2;
            var bottomCoord = position.y - objectSize.y / 2;

            return new float[] { leftCoord, topCoord, rightCoord, bottomCoord };
        }

        /// <summary>
        /// Returns value of the given field if bounds are calculated.
        /// Otherwise calculates the bounds and then returns the value.
        /// </summary>
        /// <typeparam name="T">Type of the given field.</typeparam>
        /// <param name="value">Reference to the field, which value should be given.</param>
        /// <returns></returns>
        protected ref T TryGetValue<T>(ref T value)
        {
            if (_topRight == _bottomLeft) throw new InvalidOperationException("Bounds' coords cannot be the same");

            return ref value;
        }
    }
}
