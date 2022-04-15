using Assets.Scripts.Motion;
using Assets.Scripts.Repulsor.Field;

using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts.Repulsor
{
    [RequireComponent(typeof(RepulsionField))]
    public class Repulsor : MonoBehaviour
    {
        [SerializeField]
        private Motion.Motion _motion;

        [SerializeField]
        private RepulsionField _field;


        [SerializeField]
        private UnityEvent _pushed;



        private void PushFrom(Vector2 position)
        {
            _motion.TargetOn(position, Motion.Motion.Mode.Opposite);
            _pushed?.Invoke();
        }



        private void Awake()
        {
            _field = GetComponent<RepulsionField>();
            _field.Hovered += PushFrom;
        }

        private void OnDestroy()
        {
            _field.Hovered -= PushFrom;
            _field = null;
        }
    }
}
