using Assets.Scripts.UI.Navigation;

using UnityEngine;
using UnityEngine.UIElements;

namespace Assets.Scripts.UI.Sections.MainMenu
{
    [CreateAssetMenu(fileName = "Main Menu Section", menuName = "UI/Sections/Main Menu")]
    public class MainMenuSection : BaseSection
    {
        private Button _startButton;
        private Button _settingsButton;
        private Button _exitButton;


        protected override void BindControls(VisualElement container)
        {
            _startButton = container.Q<Button>("StartButton");
            _settingsButton = container.Q<Button>("SettingsButton");
            _exitButton = container.Q<Button>("ExitButton");

            _startButton.RegisterCallback<ClickEvent>(OnStartClick);
            _settingsButton.RegisterCallback<ClickEvent>(OnSettingsClick);
            _exitButton.RegisterCallback<ClickEvent>(OnExitClick);
        }

        protected override void UnbindControls()
        {
            _startButton.UnregisterCallback<ClickEvent>(OnStartClick);
            _settingsButton.UnregisterCallback<ClickEvent>(OnSettingsClick);
            _exitButton.UnregisterCallback<ClickEvent>(OnExitClick);

            _startButton = null;
            _settingsButton = null;
            _exitButton = null;
        }



        private void OnStartClick(ClickEvent _)
        {
            RequireAction(UIAction.StartGame);
        }

        private void OnSettingsClick(ClickEvent _)
        {
            GetNavigator().NavigateTo(NavIds.SETTINGS_MENU);
        }

        private void OnExitClick(ClickEvent _)
        {
            Application.Quit();
        }



        private void OnDestroy()
        {
            UnbindControls();
        }
    }
}
