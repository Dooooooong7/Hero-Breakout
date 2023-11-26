using UnityEngine;
using UnityEngine.UI;
using Rokid.UXR.Interaction;
using Rokid.UXR.Native;
using System;

namespace Rokid.UXR.Demo
{
    public class AttributeRegulation : AutoInjectBehaviour
    {

        [SerializeField, Autowrited]
        private PokeInteractable[] interactables;

        [SerializeField, Autowrited]
        private Text hoverTip;
        [SerializeField, Autowrited]
        private Text palmTip;

        [SerializeField, Autowrited]
        private Toggle fishEyeToggle;

        [SerializeField, Autowrited]
        private Toggle dspCloseAll;

        [SerializeField, Autowrited]
        private Toggle dspOnlyDetection;
        [SerializeField, Autowrited]
        private Toggle dspOnlyFollow;
        [SerializeField, Autowrited]
        private Toggle dspOpenAll;
        [SerializeField, Autowrited]
        private Toggle logToggle;

        [SerializeField, Autowrited]
        private Slider userHeightSlider;

        [SerializeField, Autowrited]
        private Text userHeightText;
        [SerializeField, Autowrited]
        private Toggle headHandToggle;
        [SerializeField, Autowrited]
        private Button gesCalibButton;
        [SerializeField, Autowrited]
        private Button forceChangeToGes;
        [SerializeField, Autowrited]
        private Text gesCailText;

        [SerializeField, Autowrited]
        private Toggle inputStatusChangeLockToggle;

        private bool forceToGes = false;


        private void Start()
        {
            interactables = GameObject.FindObjectsOfType<PokeInteractable>();

            fishEyeToggle?.onValueChanged.AddListener(isOn =>
            {
                SetUseFishEyeDistort(isOn ? 1 : 0);
            });


            dspCloseAll?.onValueChanged.AddListener(isOn =>
            {
                if (isOn)
                {
                    SetUseDsp(0);
                }
            });

            dspOnlyDetection?.onValueChanged.AddListener(isOn =>
            {
                if (isOn)
                {
                    SetUseDsp(1);
                }
            });

            dspOnlyFollow?.onValueChanged.AddListener(isOn =>
            {
                if (isOn)
                {
                    SetUseDsp(2);
                }
            });

            dspOpenAll?.onValueChanged.AddListener(isOn =>
            {
                if (isOn)
                {
                    SetUseDsp(3);
                }
            });

            logToggle?.onValueChanged.AddListener(isOn =>
            {
                Debug.unityLogger.logEnabled = isOn;
            });

            if (dspOnlyDetection != null)
            {
                dspOnlyDetection.isOn = true;
            }
            userHeightSlider.value = 170.0f / 200;
            userHeightText.text = $"User Height :{(int)(userHeightSlider.value * 200)}";
            userHeightSlider.onValueChanged.AddListener(value =>
            {
                userHeightText.text = $"User Height :{(int)(userHeightSlider.value * 200)}";
                GesEventInput.Instance.SetUserHeight((int)(userHeightSlider.value * 200));
            });
            headHandToggle.onValueChanged.AddListener(value =>
            {
                if (value)
                {
                    GesEventInput.Instance.ActiveHandOrHeadHand(HandOrHeadHandType.HeadHand);
                }
                else
                {
                    GesEventInput.Instance.ActiveHandOrHeadHand(HandOrHeadHandType.NormalHand);
                }
            });

            gesCalibButton.onClick.AddListener(() =>
            {
                NativeInterface.NativeAPI.BeginGestureCalibrate();
            });

            NativeInterface.NativeAPI.OnGesCalibStateChange += OnGesCalibStateChange;

            inputStatusChangeLockToggle.onValueChanged.AddListener(value =>
            {
                if (value)
                {
                    InputModuleManager.Instance.LockInputModuleChange();
                }
                else
                {
                    InputModuleManager.Instance.ReleaseInputModuleChange();
                }
            });

            forceChangeToGes.onClick.AddListener(() =>
            {
                forceToGes = true;
                InputModuleManager.Instance.ForceActiveModule(InputModuleType.Gesture);
            });

            GesEventInput.OnTrackedSuccess += OnTrackedSuccess;


        }

        private void OnTrackedSuccess(HandType handType)
        {
            if (handType == HandType.RightHand && forceToGes)
            {
                InputModuleManager.Instance.LockInputModuleChange();
            }
        }


        private void OnGesCalibStateChange(int result)
        {
            gesCailText.text = "GesCailResult:" + result;
        }


        /// <summary>
        /// 是否使用鱼眼校正,0-否,1-是
        /// </summary>
        public void SetUseFishEyeDistort(int useFishEyeDistort)
        {
            NativeInterface.NativeAPI.SetUseFishEyeDistort(useFishEyeDistort);
        }

        /// <summary>
        /// 0 是 检测 和 跟踪都不开 dsp
        /// 1 是 检测开 跟踪不开 
        /// 2 是 检测不开 跟踪开
        /// 3 是 都开
        /// </summary>
        public void SetUseDsp(int useDsp)
        {
            RKLog.KeyInfo("SetUseDsp:" + useDsp);
            NativeInterface.NativeAPI.SetUseDsp(useDsp);
        }
    }
}
