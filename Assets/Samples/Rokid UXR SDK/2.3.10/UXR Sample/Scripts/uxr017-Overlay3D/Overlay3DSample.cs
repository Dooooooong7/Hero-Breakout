
using Rokid.UXR.Native;
using Rokid.UXR.Utility;
using UnityEngine;
using UnityEngine.UI;

namespace Rokid.UXR.Demo
{
    public class Overlay3DSample : AutoInjectBehaviour
    {
        [SerializeField, Autowrited]
        private Text overlay3DText;
        [SerializeField, Autowrited]
        private Slider overlay3DSlider;

        int lastValue = 0;

        private void Start()
        {
            RKLog.Error("Overlay3DSample Start");

            overlay3DSlider.value = NativeInterface.NativeAPI.GetGlassBrightness() / 100.0f;
            printValue((int)(overlay3DSlider.value * 100));
            overlay3DSlider.onValueChanged.AddListener(value =>
            {
                int newValue = (int)(value * 100);
                if (lastValue == newValue)
                {
                    return;
                }
                lastValue = newValue;
                printValue(lastValue);
                NativeInterface.NativeAPI.SetGlassBrightness(lastValue);
            });
            NativeInterface.NativeAPI.RegisterGlassBrightUpdate(OnGlassBrightUpdate);
        }

        private void printValue(int value)
        {
            RKLog.Error($"Slider value: {value}");
            overlay3DText.text = $"Slider value: {value}";
        }

        private void OnGlassBrightUpdate(int brightness)
        {
            Loom.QueueOnMainThread(() =>
            {
                if (lastValue == brightness)
                {
                    return;
                }
                lastValue = brightness;
                printValue(lastValue);
                overlay3DSlider.value = lastValue / 100.0f;
            });
        }
    }
}
