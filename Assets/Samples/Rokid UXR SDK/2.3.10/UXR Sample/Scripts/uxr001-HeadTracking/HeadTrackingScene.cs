using UnityEngine;
using UnityEngine.UI;
using Rokid.UXR.Module;
using Rokid.UXR.Utility;
using Rokid.UXR.Native;

namespace Rokid.UXR.Demo
{
    public class HeadTrackingScene : AutoInjectBehaviour
    {
        [Autowrited]
        private Text infoTxt;
        [Autowrited]
        private Text engineTxt;
        [Autowrited]
        private Button zeroDofButton;
        [Autowrited]
        private Button threeDofButton;
        [Autowrited]
        private Button sixDofButton;

        private RKCameraRig cameraRig;

        public Camera mainCamera;


        void Start()
        {
            // Configures the app to not shut down the screen
            Screen.sleepTimeout = SleepTimeout.NeverSleep;
            NativeInterface.NativeAPI.Recenter();  // reset glass 3dof
            RKVirtualController.Instance.Change(ControllerType.NORMAL);
            if (mainCamera == null)
            {
                mainCamera = MainCameraCache.mainCamera;
            }

            cameraRig = mainCamera.GetComponent<RKCameraRig>();
            zeroDofButton.onClick.AddListener(() =>
            {
                cameraRig.headTrackingType = RKCameraRig.HeadTrackingType.None;
            });

            threeDofButton.onClick.AddListener(() =>
            {
                cameraRig.headTrackingType = RKCameraRig.HeadTrackingType.RotationOnly;
            });

            sixDofButton.onClick.AddListener(() =>
            {
                cameraRig.headTrackingType = RKCameraRig.HeadTrackingType.RotationAndPosition;
            });
        }

        private void Update()
        {
            if (RKNativeInput.Instance.GetKeyDown(RKKeyEvent.KEY_RESET) || Input.GetKeyDown(KeyCode.JoystickButton0)) //长按虚拟面板 HOME键事件
            {
                RKLog.Info("UXR-UNITY::KEY_RESET");
                NativeInterface.NativeAPI.Recenter();
            }

            infoTxt.text = string.Format("Position:{0}\r\nEuler:{1}\r\nRotation:{2}", mainCamera.transform.position.ToString("f3"), mainCamera.transform.rotation.eulerAngles.ToString(), mainCamera.transform.rotation.ToString("f3"));

            engineTxt.text = $"DebugInfo:{NativeInterface.NativeAPI.GetHeadTrackingStatus()},{NativeInterface.NativeAPI.GetDebugInfo()}";
        }

        private void OnEnable()
        {
            RKLog.Info("-UXR-  HeadTrackingScene OnEnable");
        }

        private void OnBecameVisible()
        {
            RKLog.Info("-UXR-  HeadTrackingScene OnBecameVisible ");
        }

        private void OnDisable()
        {
            RKLog.Info("-UXR-  HeadTrackingScene OnDisable ");
        }
    }
}
