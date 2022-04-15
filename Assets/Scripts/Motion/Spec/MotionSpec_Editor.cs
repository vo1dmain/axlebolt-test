
using System;

using UnityEngine;

namespace Assets.Scripts.Motion.Spec
{
    public partial class MotionSpec : ScriptableObject
    {

        public readonly ISpecEditor Editor;

        public MotionSpec()
        {
            Editor = new SpecEditor(this);
        }


        private class SpecEditor : ISpecEditor
        {
            private readonly MotionSpec _spec;



            internal SpecEditor(MotionSpec spec)
            {
                _spec = spec;
            }



            public void SetSpeed(float speed)
            {
                if (speed > MaxSpeed) throw new ArgumentOutOfRangeException();
                if (speed < MinSpeed) throw new ArgumentOutOfRangeException();

                _spec._speed = speed;
            }

            public void SetAcceleration(float acceleration)
            {
                if (acceleration > MaxAcceleration) throw new ArgumentOutOfRangeException();
                if (acceleration < MinAcceleration) throw new ArgumentOutOfRangeException();

                _spec._acceleration = acceleration;
            }

            public void SetCooldownDistance(float cooldownDistance)
            {
                if (cooldownDistance > MaxCooldownDistance) throw new ArgumentOutOfRangeException();
                if (cooldownDistance < MinCooldownDistance) throw new ArgumentOutOfRangeException();

                _spec._cooldownDistance = cooldownDistance;
            }
        }

        public interface ISpecEditor
        {
            public void SetSpeed(float speed);
            public void SetAcceleration(float acceleration);
            public void SetCooldownDistance(float cooldownDistance);
        }
    }
}
