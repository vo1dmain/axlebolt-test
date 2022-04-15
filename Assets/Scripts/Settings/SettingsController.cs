
using Assets.Scripts.Motion.Spec;
using Assets.Scripts.Repulsor.Field;

using UnityEngine;

namespace Assets.Scripts.Settings
{
    [CreateAssetMenu(fileName = "Settings Controller", menuName = "Scriptable Object/Settings Controller")]
    public class SettingsController : ScriptableObject
    {
        [SerializeField]
        private MotionSpec _motionSpec;

        [SerializeField]
        private RepulsionFieldSpec _fieldSpec;


        public float Speed => _motionSpec.Speed;
        public float Acceleration => _motionSpec.Acceleration;
        public float CooldownDistance => _motionSpec.CooldownDistance;
        public float FieldRadius => _fieldSpec.Radius;



        public void SetSpeed(float speed)
        {
            _motionSpec.Editor.SetSpeed(speed);
        }

        public void SetAcceleration(float acceleration)
        {
            _motionSpec.Editor.SetAcceleration(acceleration);
        }

        public void SetCooldownDistance(float cooldownDistance)
        {
            _motionSpec.Editor.SetCooldownDistance(cooldownDistance);
        }

        public void SetFieldRadius(float fieldRadius)
        {
            _fieldSpec.Editor.SetRadius(fieldRadius);
        }
    }
}
