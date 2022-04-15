using System;

using Assets.Scripts.Finish;
using Assets.Scripts.Motion.Spec;
using Assets.Scripts.Utils.Extensions;

using UnityEngine;

namespace Assets.Scripts.Motion
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Motion : MonoBehaviour, IBeginable, IFinishable
    {
        [SerializeField]
        private MotionSpec _spec;
        internal MotionSpec Spec => _spec;

        [SerializeField]
        private Rigidbody2D _rigidbody;

        [SerializeField]
        private FinishPoint _finish;

        [SerializeField]
        private Mode _motionMode = Mode.Towards;



        private float _currentSpeed;

        private bool _finished = false;

        private Vector2 _targetPosition;



        public void TargetOn(Vector2 position, Mode motionMode)
        {
            SetTargetPosition(position);
            _motionMode = motionMode;
        }

        public void Begin()
        {
            ResetTarget();
        }

        public void Finish()
        {
            _finished = true;
        }



        internal void ResetTarget()
        {
            SetTargetPosition(_finish.transform.position);
            _currentSpeed = _spec.Speed;
            _motionMode = Mode.Towards;
        }

        internal void IncreaseCurrentSpeed()
        {
            _currentSpeed += _spec.Acceleration;
        }

        

        private void SetTargetPosition(Vector2 position)
        {
            if (_finished) return;

            _targetPosition = position;
        }

        private void MoveToNextPosition()
        {
            Vector2 nextPosition = CalculateNextPosition();
            _rigidbody.MovePosition(nextPosition);
        }

        private Vector2 CalculateNextPosition()
        {
            var maxDistanceDelta = _currentSpeed * Time.fixedDeltaTime;

            maxDistanceDelta = _motionMode switch
            {
                Mode.Opposite => maxDistanceDelta.Negative(),
                Mode.Towards => maxDistanceDelta.Positive(),
                _ => throw new ArgumentOutOfRangeException()
            };

            var motion = Vector2.MoveTowards(_rigidbody.position, _targetPosition, maxDistanceDelta);
            var velocity = _rigidbody.velocity;

            return Vector2.SmoothDamp(_rigidbody.position, motion, ref velocity, 0f);
        }



        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            _finish = FindObjectOfType<FinishPoint>();
        }

        private void FixedUpdate()
        {
            if (_finished) return;

            MoveToNextPosition();
        }



        public enum Mode : byte
        {
            Towards,
            Opposite
        }
    }

}