using UnityEngine;
using UnityEngine.UI;

namespace IronMountain.URLUtilities
{
    [RequireComponent(typeof(Button))]
    public class URLOpener : MonoBehaviour
    {
        public string url;
        
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
            if (string.IsNullOrEmpty(url)) return;
            Application.OpenURL(url);
        }
    }
}
