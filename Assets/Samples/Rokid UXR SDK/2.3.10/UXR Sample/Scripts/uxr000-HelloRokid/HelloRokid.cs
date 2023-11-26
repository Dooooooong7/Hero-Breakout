using UnityEngine;
using UnityEngine.UI;
using Rokid.UXR.Native;
using Rokid.UXR.Module;
using Rokid.UXR.Utility;

namespace Rokid.UXR.Demo
{
    public class HelloRokid : MonoBehaviour
    {
        public Text snText;
        public Text brightnessText;
        public Text deviceNameText;
        public Text pidText;
        public Text firewareVersionText;
        public Text deviceModelText;
        public Text keycodeInfo;
        public Text systemInfo;
        public Text cameraRunTimeVFov;
        public Text cameraRunTimeProMaxrix;


        void Start()
        {
            if (Application.platform == RuntimePlatform.Android)
            {
                Api.UpdateScreenParams();
            }

            RKVirtualController.Instance.Change(ControllerType.NORMAL);
            snText.text = "Glass SN: " + NativeInterface.NativeAPI.GetGlassSN();
            deviceNameText.text = "Glass Name: " + NativeInterface.NativeAPI.GetGlassName();
            pidText.text = "Glass PID: " + NativeInterface.NativeAPI.GetGlassPID();
            firewareVersionText.text = "Glass FirmwareVersion: " + NativeInterface.NativeAPI.GetGlassFirmwareVersion();
            systemInfo.text = "INCREMENTAL:" + NativeInterface.NativeAPI.INCREMENTAL;
            deviceModelText.text = "Device Model: " + SystemInfo.deviceModel;
            cameraRunTimeVFov.text = "CameraRunTimeVFov:" + Camera.main.fieldOfView;
            cameraRunTimeProMaxrix.text = "CameraRunTimeProMaxrix: \n" + Camera.main.projectionMatrix;
            RKLog.Info("CameraRunTimeProMaxrix: \n" + Camera.main.projectionMatrix);
            //  Set Glass brightness
            NativeInterface.NativeAPI.RegisterGlassBrightUpdate(OnGlassBrightUpdate);
            int brightness = NativeInterface.NativeAPI.GetGlassBrightness();
            RKLog.Info("====HeadTrackingScene==== Oribrightness:" + brightness);
            NativeInterface.NativeAPI.SetGlassBrightness(brightness + 1);
        }

        private void OnDestroy()
        {
            NativeInterface.NativeAPI.UnregisterOnGlassBrightUpdate(OnGlassBrightUpdate);
        }

        private void OnGlassBrightUpdate(int brightness)
        {
            Loom.QueueOnMainThread(() =>
            {
                brightnessText.text = "Glass Brightness: " + brightness;
                RKLog.Info("====HeadTrackingScene==== brightness:" + brightness);
            });
        }

        void Update()
        {
            //only for debug, do not call these get methods in update. low fps
            foreach (KeyCode kcode in System.Enum.GetValues(typeof(KeyCode)))
            {
                if (Input.GetKeyDown(kcode))
                {
                    keycodeInfo.text = "KeyCodeInfo KeyCode down: " + kcode;
                    RKLog.Info("-uxr- KeyCode down: " + kcode);
                }

                if (Input.GetKeyUp(kcode))
                {
                    keycodeInfo.text = "KeyCodeInfo KeyCode Up: " + kcode;
                    RKLog.Info("-uxr- KeyCode Up: " + kcode);
                }
            }
        }
    }
}
