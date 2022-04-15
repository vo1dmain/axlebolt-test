
using System;

using Assets.Scripts.UI.Navigation;

using UnityEngine;
using UnityEngine.UIElements;

using static Assets.Scripts.UI.UIController;

namespace Assets.Scripts.UI
{
    public abstract class BaseSection : ScriptableObject
    {
        [SerializeField]
        private VisualTreeAsset _asset;

        private UINavigator _navigator;

        private IContext _context;

        internal VisualElement Instantiate()
        {
            var instance = _asset.Instantiate().contentContainer;
            BindControls(instance);

            return instance;
        }

        internal void AttachNavigator(UINavigator navigator)
        {
            _navigator = navigator;
        }

        internal void AttachContext(IContext context)
        {
            _context = context;
        }

        protected UINavigator GetNavigator()
        {
            if (_navigator == null) throw new InvalidOperationException("Not yet attached to navigator");
            return _navigator;
        }

        protected void RequireAction(UIAction action)
        {
            _context.RequireAction(action);
        }
        


        protected abstract void BindControls(VisualElement container);
        protected abstract void UnbindControls();
    }
}
