using UnityEngine;

namespace Assets.Scripts.Bounds
{
    public class BoundsCalculator : MonoBehaviour
    {
        [SerializeField]
        private Camera _camera;

        [SerializeField]
        private Bounds _boundsToCalculate;



        private void Start()
        {
            Vector2 topRight = _camera.ViewportToWorldPoint(new Vector2(1, 1));
            Vector2 bottomLeft = _camera.ViewportToWorldPoint(new Vector2(0, 0));
            _boundsToCalculate.Write(topRight, bottomLeft);
        }
    }
}
