
using System;

using Assets.Scripts.UI.Navigation;

using UnityEngine;

namespace Assets.Scripts.UI
{
    public partial class UIController : MonoBehaviour
    {
        private class UIContext : IContext
        {
            internal event Action<UIAction> ActionReqired;

            internal UIContext() { }

            public void RequireAction(UIAction action)
            {
                ActionReqired?.Invoke(action);
            }
        }

        public interface IContext
        {
            public void RequireAction(UIAction action);
        }
    }
}
