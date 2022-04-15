
using UnityEngine.UIElements;

namespace Assets.Scripts.Utils.Extensions
{
    public static class SliderExtensions
    {
        public static void Setup(this Slider slider, float lowValue, float highValue, float currentValue)
        {
            slider.lowValue = lowValue;
            slider.highValue = highValue;
            slider.value = currentValue;
        }
    }
}
