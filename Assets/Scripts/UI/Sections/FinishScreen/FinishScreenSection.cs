
using Assets.Scripts.UI.Navigation;

using UnityEngine;
using UnityEngine.UIElements;

namespace Assets.Scripts.UI.Sections.FinishScreen
{

    [CreateAssetMenu(fileName = "Finish Screen Section", menuName = "UI/Sections/Finish Screen")]
    public class FinishScreenSection : BaseSection
    {
        private Button _restartButton;
        private Button _returnToMenuButton;



        protected override void BindControls(VisualElement container)
        {
            _restartButton = container.Q<Button>("RestartButton");
            _returnToMenuButton = container.Q<Button>("ReturnToMenuButton");

            _restartButton.RegisterCallback<ClickEvent>(OnRestartClick);
            _returnToMenuButton.RegisterCallback<ClickEvent>(OnReturnToMenuClick);
        }

        protected override void UnbindControls()
        {
            _restartButton.UnregisterCallback<ClickEvent>(OnRestartClick);
            _returnToMenuButton.UnregisterCallback<ClickEvent>(OnReturnToMenuClick);

            _restartButton = null;
            _returnToMenuButton = null;
        }



        private void OnRestartClick(ClickEvent _)
        {
            RequireAction(UIAction.RestartGame);
        }

        private void OnReturnToMenuClick(ClickEvent _)
        {
            RequireAction(UIAction.ResetGame);
            GetNavigator().NavigateTo(NavIds.MAIN_MENU);
        }
    }
}

