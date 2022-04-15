using System;

using UnityEngine;

namespace Assets.Scripts.Repulsor.Field
{
    [CreateAssetMenu(fileName = "Repulsion Field Spec", menuName = "Scriptable Object/Repulsion Field Spec")]
    public partial class RepulsionFieldSpec : ScriptableObject
    {
        [SerializeField]
        [Range(MinRadius, MaxRadius)]
        private float _radius = .5f;
        public float Radius => _radius;



        public const float MinRadius = .5f;
        public const float MaxRadius = 10f;
    }
}
