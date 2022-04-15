using System;

using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Scripts.Repulsor.Field
{
    [RequireComponent(typeof(CircleCollider2D))]
    public class RepulsionField : MonoBehaviour, IPointerMoveHandler
    {
        [SerializeField]
        private RepulsionFieldSpec _spec;


        public event Action<Vector2> Hovered;


        public void OnPointerMove(PointerEventData eventData)
        {
            Vector2 worldMousePosition = Camera.main.ScreenToWorldPoint(eventData.position);

            Hovered?.Invoke(worldMousePosition);
        }
    }
}
