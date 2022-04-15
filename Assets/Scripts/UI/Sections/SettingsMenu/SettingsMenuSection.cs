
using Assets.Scripts.Motion.Spec;
using Assets.Scripts.Repulsor.Field;
using Assets.Scripts.Settings;
using Assets.Scripts.UI.Elements;
using Assets.Scripts.Utils.Extensions;

using UnityEngine;
using UnityEngine.UIElements;

namespace Assets.Scripts.UI.Sections.SettingsMenu
{
    [CreateAssetMenu(fileName = "Settings Menu Section", menuName = "UI/Sections/Settings Menu")]
    public class SettingsMenuSection : BaseSection
    {
        private Toolbar _toolbar;

        private Slider _speedSlider;
        private Slider _accelerationSlider;
        private Slider _cooldownDistanceSlider;
        private Slider _repulsionRadiusSlider;



        [SerializeField]
        private SettingsController _controller;



        protected override void BindControls(VisualElement container)
        {
            _toolbar = container.Q<Toolbar>();
            _speedSlider = container.Q<Slider>("SpeedSlider");
            _accelerationSlider = container.Q<Slider>("AccelerationSlider");
            _cooldownDistanceSlider = container.Q<Slider>("CooldownDistanceSlider");
            _repulsionRadiusSlider = container.Q<Slider>("RepulsionRadiusSlider");


            _speedSlider.Setup(MotionSpec.MinSpeed, MotionSpec.MaxSpeed, _controller.Speed);
            _accelerationSlider.Setup(MotionSpec.MinAcceleration, MotionSpec.MaxAcceleration, _controller.Acceleration);
            _cooldownDistanceSlider.Setup(MotionSpec.MinCooldownDistance, MotionSpec.MaxCooldownDistance, _controller.CooldownDistance);
            _repulsionRadiusSlider.Setup(RepulsionFieldSpec.MinRadius, RepulsionFieldSpec.MaxRadius, _controller.FieldRadius);


            _toolbar.NavigateUp += OnNavigateUp;
            _speedSlider.RegisterValueChangedCallback(OnSpeedChanged);
            _accelerationSlider.RegisterValueChangedCallback(OnAccelerationChanged);
            _cooldownDistanceSlider.RegisterValueChangedCallback(OnCooldownDistanceChanged);
            _repulsionRadiusSlider.RegisterValueChangedCallback(OnRepulsionRadiusChanged);
        }



        protected override void UnbindControls()
        {
            _toolbar.NavigateUp -= OnNavigateUp;
            _speedSlider.UnregisterValueChangedCallback(OnSpeedChanged);
            _accelerationSlider.UnregisterValueChangedCallback(OnAccelerationChanged);
            _cooldownDistanceSlider.UnregisterValueChangedCallback(OnCooldownDistanceChanged);
            _repulsionRadiusSlider.UnregisterValueChangedCallback(OnRepulsionRadiusChanged);
        }



        private void OnNavigateUp()
        {
            GetNavigator().NavigateUp();
        }

        private void OnSpeedChanged(ChangeEvent<float> e)
        {
            _controller.SetSpeed(e.newValue);
        }

        private void OnAccelerationChanged(ChangeEvent<float> e)
        {
            _controller.SetAcceleration(e.newValue);
        }

        private void OnCooldownDistanceChanged(ChangeEvent<float> e)
        {
            _controller.SetCooldownDistance(e.newValue);
        }

        private void OnRepulsionRadiusChanged(ChangeEvent<float> e)
        {
            _controller.SetFieldRadius(e.newValue);
        }



        private void OnDestroy()
        {
            UnbindControls();
        }
    }
}
