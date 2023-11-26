using UnityEngine;
using UnityEngine.SceneManagement;
using Rokid.UXR.Module;
//using Google.XR.Cardboard;
using Rokid.UXR.Native;

namespace Rokid.UXR.Demo
{
    public class MainSceneSample : MonoBehaviour
    {
        private bool loadUI;

        [SerializeField]
        private GameObject ui;
        void Start()
        {
            if (Application.platform == RuntimePlatform.Android)
            {
                Api.UpdateScreenParams();
            }
#if UNITY_EDITOR
            ui.gameObject.SetActive(true);
#endif
        }

        private void OnDestroy()
        {

        }


        public void LoadScene(string sceneName)
        {
            SceneManager.LoadSceneAsync(sceneName);
        }

        private void Update()
        {
#if !UNITY_EDITOR
            if (!loadUI && NativeInterface.NativeAPI.GetHeadTrackingStatus() == HeadTrackingStatus.Tracking)
            {
                loadUI = true;
                ui.gameObject.SetActive(true);
            }
#endif
        }
    }
}

