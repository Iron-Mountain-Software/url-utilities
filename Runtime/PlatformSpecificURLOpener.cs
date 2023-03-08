using UnityEngine;
using UnityEngine.UI;

namespace SpellBoundAR.URLUtilities
{
    [RequireComponent(typeof(Button))]
    public class PlatformSpecificURLOpener : MonoBehaviour
    {
        [SerializeField] private string androidUrl;
        [SerializeField] private string iPhoneUrl;
        [Space]
        [SerializeField] private string osxEditorUrl;
        [SerializeField] private string osxPlayerUrl;
        [Space]
        [SerializeField] private string windowsEditorUrl;
        [SerializeField] private string windowsPlayerUrl;

        [Header("Cache")]
        private Button _button;

        private void Awake()
        {
            _button = GetComponent<Button>();
        }

        private void OnEnable()
        {
            if (_button) _button.onClick.AddListener(OpenURL);
        }

        private void OnDisable()
        {
            if (_button) _button.onClick.RemoveListener(OpenURL);
        }

        private void OpenURL()
        {
            switch (Application.platform)
            {
                case RuntimePlatform.Android:
                    if (!string.IsNullOrEmpty(androidUrl)) Application.OpenURL(androidUrl);
                    break;
                case RuntimePlatform.IPhonePlayer:
                    if (!string.IsNullOrEmpty(iPhoneUrl)) Application.OpenURL(iPhoneUrl);
                    break;
                case RuntimePlatform.OSXEditor:
                    if (!string.IsNullOrEmpty(osxEditorUrl)) Application.OpenURL(osxEditorUrl);
                    break;
                case RuntimePlatform.OSXPlayer:
                    if (!string.IsNullOrEmpty(osxPlayerUrl)) Application.OpenURL(osxPlayerUrl);
                    break;
                case RuntimePlatform.WindowsEditor:
                    if (!string.IsNullOrEmpty(windowsEditorUrl)) Application.OpenURL(windowsEditorUrl);
                    break;
                case RuntimePlatform.WindowsPlayer:
                    if (!string.IsNullOrEmpty(windowsPlayerUrl)) Application.OpenURL(windowsPlayerUrl);
                    break;
            }
        }
    }
}