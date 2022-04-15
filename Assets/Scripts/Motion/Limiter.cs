using UnityEngine;

namespace Assets.Scripts.Motion
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class Limiter : MonoBehaviour
    {
        [SerializeField]
        private SpriteRenderer _objectBody;

        [SerializeField]
        private Motion _motion;

        [SerializeField]
        private Bounds.Bounds _bounds;



        private Vector2 ClampPositionToBounds(Vector2 position)
        {
            var minPositionX = _bounds.Left + (_objectBody.size.x / 2);
            var maxPositionX = _bounds.Right - (_objectBody.size.x / 2);

            var minPositionY = _bounds.Bottom + (_objectBody.size.y / 2);
            var maxPositionY = _bounds.Top - (_objectBody.size.y / 2);

            position.x = Mathf.Clamp(position.x, minPositionX, maxPositionX);
            position.y = Mathf.Clamp(position.y, minPositionY, maxPositionY);

            return position;
        }



        private void Awake()
        {
            _objectBody = GetComponent<SpriteRenderer>();
        }

        private void LateUpdate()
        {
            Vector2 clampedPosition = ClampPositionToBounds(transform.position);
            transform.position = clampedPosition;

            if (_bounds.AreTouched(clampedPosition, _objectBody.size))
            {
                Vector2 reflection = _bounds.Reflect(clampedPosition, _objectBody.size);
                _motion.TargetOn(reflection, Motion.Mode.Towards);
            }
        }
    }
}

