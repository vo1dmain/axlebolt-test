using System;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UIElements;

namespace Assets.Scripts.UI.Elements
{
    public class Toolbar : VisualElement
    {
        private string _title = "Title";
        public string Title
        {
            get { return _title; }
            set
            {
                _title = value;
                _titleLabel.text = _title;
            }
        }


        private readonly Label _titleLabel;
        private readonly Button _navigationButton;



        public event Action NavigateUp;



        public Toolbar()
        {
            var asset = Resources.Load<VisualTreeAsset>("ToolbarTemplate");
            var template = asset.Instantiate();
            Add(template);

            _navigationButton = contentContainer.Q<Button>("nav-button");
            _navigationButton.RegisterCallback<ClickEvent>(OnNavigationButtonClicked);

            _titleLabel = contentContainer.Q<Label>("title");
        }



        private void OnNavigationButtonClicked(ClickEvent _)
        {
            NavigateUp?.Invoke();
        }


        ~Toolbar()
        {
            _navigationButton.UnregisterCallback<ClickEvent>(OnNavigationButtonClicked);
        }

        public new class UxmlFactory : UxmlFactory<Toolbar, UxmlTraits> { }

        public new class UxmlTraits : VisualElement.UxmlTraits
        {
            private readonly UxmlStringAttributeDescription _title = new UxmlStringAttributeDescription
            {
                name = "title",
                defaultValue = "Title"
            };

            public override IEnumerable<UxmlChildElementDescription> uxmlChildElementsDescription
            {
                get { yield break; }
            }

            public override void Init(VisualElement ve, IUxmlAttributes bag, CreationContext cc)
            {
                base.Init(ve, bag, cc);
                var toolbar = ve as Toolbar;

                toolbar.Title = _title.GetValueFromBag(bag, cc);
            }
        }
    }
}
