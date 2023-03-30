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

        public string AndroidUrl
        {
            get => androidUrl;
            set => androidUrl = value;
        }
        
        public string IPhoneUrl
        {
            get => iPhoneUrl;
            set => iPhoneUrl = value;
        }
        
        public string OSXEditorUrl
        {
            get => osxEditorUrl;
            set => osxEditorUrl = value;
        }
        
        public string OSXPlayerUrl
        {
            get => osxPlayerUrl;
            set => osxPlayerUrl = value;
        }
        
        public string WindowsEditorUrl
        {
            get => windowsEditorUrl;
            set => windowsEditorUrl = value;
        }
        
        public string WindowsPlayerUrl
        {
            get => windowsPlayerUrl;
            set => windowsPlayerUrl = value;
        }

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
                    if (!string.IsNullOrEmpty(AndroidUrl)) Application.OpenURL(AndroidUrl);
                    break;
                case RuntimePlatform.IPhonePlayer:
                    if (!string.IsNullOrEmpty(IPhoneUrl)) Application.OpenURL(IPhoneUrl);
                    break;
                case RuntimePlatform.OSXEditor:
                    if (!string.IsNullOrEmpty(OSXEditorUrl)) Application.OpenURL(OSXEditorUrl);
                    break;
                case RuntimePlatform.OSXPlayer:
                    if (!string.IsNullOrEmpty(OSXPlayerUrl)) Application.OpenURL(OSXPlayerUrl);
                    break;
                case RuntimePlatform.WindowsEditor:
                    if (!string.IsNullOrEmpty(WindowsEditorUrl)) Application.OpenURL(WindowsEditorUrl);
                    break;
                case RuntimePlatform.WindowsPlayer:
                    if (!string.IsNullOrEmpty(WindowsPlayerUrl)) Application.OpenURL(WindowsPlayerUrl);
                    break;
            }
        }
    }
}