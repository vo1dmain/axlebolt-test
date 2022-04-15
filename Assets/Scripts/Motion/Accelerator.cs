using System.Collections;

using Assets.Scripts.Utils.Extensions;

using UnityEngine;
using UnityEngine.InputSystem;

namespace Assets.Scripts.Motion
{
    public class Accelerator : MonoBehaviour
    {
        [SerializeField]
        private Motion _motion;

        private Coroutine _accelerationRoutine;

        private Coroutine _distanceCheckRoutine;



        public void Accelerate()
        {
            _accelerationRoutine?.Let(it => StopCoroutine(it));
            _accelerationRoutine = StartCoroutine(nameof(AccelerationRoutine));

            _distanceCheckRoutine?.Let(it => StopCoroutine(it));
            _distanceCheckRoutine = StartCoroutine(nameof(DistanceCheckRoutine));
        }

        private IEnumerator AccelerationRoutine()
        {
            var waitForSeconds = new WaitForSeconds(1f);

            while (true)
            {
                _motion.IncreaseCurrentSpeed();

                yield return waitForSeconds;
            }
        }

        private IEnumerator DistanceCheckRoutine()
        {
            var waitForEndOfFrame = new WaitForEndOfFrame();

            while (true)
            {
                Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
                float distanceToMouse = Vector2.Distance(mousePosition, transform.position);
                
                if (distanceToMouse >= _motion.Spec.CooldownDistance) break;

                yield return waitForEndOfFrame;
            }

            CoolDown();
        }


        private void CoolDown()
        {
            _accelerationRoutine?.Let(it => StopCoroutine(it));
            _accelerationRoutine = null;
            _distanceCheckRoutine.Let(it => StopCoroutine(it));
            _distanceCheckRoutine = null;

            _motion.ResetTarget();
        }



        private void OnDestroy()
        {
            StopAllCoroutines();
            _accelerationRoutine = null;
            _distanceCheckRoutine = null;
        }
    }
}
