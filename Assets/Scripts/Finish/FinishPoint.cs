using System;

using UnityEngine;

namespace Assets.Scripts.Finish
{
    [RequireComponent(typeof(Collider2D))]
    public class FinishPoint : MonoBehaviour
    {
        public event Action<IFinishable> Crossed;

        private void OnTriggerEnter2D(Collider2D intruder)
        {
            if (intruder.gameObject.TryGetComponent(out IFinishable finisher))
            {
                finisher.Finish();
                Crossed?.Invoke(finisher);
            }
        }
    }
}


