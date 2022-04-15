using System.Collections.Generic;

using Assets.Scripts.UI.Navigation;

using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;

namespace Assets.Scripts.UI
{
    [RequireComponent(typeof(UIDocument))]
    [RequireComponent(typeof(UINavigator))]
    public partial class UIController : MonoBehaviour
    {
        [SerializeField]
        private UIDocument _document;

        [SerializeField]
        private string _rootName;

        [SerializeField]
        private UINavigator _navigator;


        [Header("Events")]
        [SerializeField]
        private UnityEvent _startRequired;

        [SerializeField]
        private UnityEvent _restartRequired;

        [SerializeField]
        private UnityEvent _resetRequired;


        private VisualElement _currentSection;
        private VisualElement _root;



        public void ShowMainMenu()
        {
            _navigator.NavigateTo(NavIds.MAIN_MENU);
            ShowUI();
        }

        public void ShowFinishScreen()
        {
            _navigator.NavigateTo(NavIds.FINISH_SCREEN);
            ShowUI();
        }



        private void HideUI()
        {
            _root.visible = false;
        }

        private void ShowUI()
        {
            _root.visible = true;
        }



        private void InitializeSections(IEnumerable<NavNode> navigationNodes)
        {
            _root = _document.rootVisualElement.Q<VisualElement>(_rootName);
            _root.Clear();

            foreach (var node in navigationNodes)
            {
                node.Section.AttachContext(_context);

                var sectionInstance = node.Section.Instantiate();

                sectionInstance.SetEnabled(false);
                sectionInstance.style.display = DisplayStyle.None;
                sectionInstance.name = node.Id;

                _root.Add(sectionInstance);
                _instances.Add(node.Id, sectionInstance);
            }
        }

        private void ChangeCurrentSection(string nextSectionId)
        {
            ToggleCurrentSectionVisibility(false);
            _currentSection = _instances[nextSectionId];
            ToggleCurrentSectionVisibility(true);
        }

        private void ToggleCurrentSectionVisibility(bool visible)
        {
            if (_currentSection is null) return;

            _currentSection.style.display = visible ? DisplayStyle.Flex : DisplayStyle.None;
            _currentSection.SetEnabled(visible);
        }



        private void OnNavigated(string destinationId)
        {
            ChangeCurrentSection(destinationId);
        }

        private void OnActionRequired(UIAction action)
        {
            switch (action)
            {
                case UIAction.StartGame:
                    OnStartRequired();
                    break;
                case UIAction.RestartGame:
                    OnRestartRequired();
                    break;
                case UIAction.ResetGame:
                    _resetRequired.Invoke();
                    break;
                default:
                    throw new System.NotImplementedException();
            }
        }

        private void OnStartRequired()
        {
            HideUI();
            _startRequired.Invoke();
        }

        private void OnRestartRequired()
        {
            HideUI();
            _restartRequired.Invoke();
        }



        private void Awake()
        {
            _document = GetComponent<UIDocument>();
            _navigator = GetComponent<UINavigator>();

            _navigator.Init();

            InitializeSections(_navigator.Graph.Nodes);

            _navigator.Navigated += OnNavigated;
            _navigator.NavigateToStartNode();

            _context.ActionReqired += OnActionRequired;
        }

        private void OnDestroy()
        {
            _navigator.Navigated -= OnNavigated;
            _navigator = null;

            _instances.Clear();
        }

        private void OnValidate()
        {
            if (_document is null) return;
            if (_document.rootVisualElement is null) return;

            _rootName = _document.rootVisualElement.ElementAt(0).name;
        }


        private readonly UIContext _context = new();

        private readonly Dictionary<string, VisualElement> _instances = new();
    }
}