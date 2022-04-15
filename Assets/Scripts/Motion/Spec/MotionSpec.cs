
using System;

using UnityEngine;

namespace Assets.Scripts.Motion.Spec
{
    [CreateAssetMenu(fileName = "Motion Spec", menuName = "Scriptable Object/Motion Spec")]
    public partial class MotionSpec : ScriptableObject
    {
        [SerializeField]
        [Range(MinSpeed, MaxSpeed)]
        private float _speed = 10f;
        public float Speed => _speed;



        [SerializeField]
        [Range(MinAcceleration, MaxAcceleration)]
        private float _acceleration = .1f;
        public float Acceleration => _acceleration;



        [SerializeField]
        [Range(MinCooldownDistance, MaxCooldownDistance)]
        private float _cooldownDistance = 10f;
        public float CooldownDistance => _cooldownDistance;



        public const float MaxSpeed = 20f;
        public const float MinSpeed = 10f;


        public const float MaxAcceleration = .5f;
        public const float MinAcceleration = .1f;


        public const float MaxCooldownDistance = 100f;
        public const float MinCooldownDistance = 10f;
    }
}
