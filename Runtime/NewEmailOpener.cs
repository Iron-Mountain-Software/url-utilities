using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

namespace SpellBoundAR.URLUtilities
{
    [RequireComponent(typeof(Button))]
    public class NewEmailOpener : MonoBehaviour
    {
        public List<string> to;
        public List<string> cc;
        public List<string> bcc;
        public string subject;
        [TextArea(4, 10)] public string body;
        
        [Header("Cache")]
        private Button _button;

        private void Awake()
        {
            _button = GetComponent<Button>();
        }

        private void OnEnable()
        {
            if (_button) _button.onClick.AddListener(OpenEmail);
        }

        private void OnDisable()
        {
            if (_button) _button.onClick.RemoveListener(OpenEmail);
        }

        private void OpenEmail()
        {
            StringBuilder url = new StringBuilder("mailto:");
            url.AppendJoin(',', to).Append("?");
            if (cc.Count > 0) url.Append("&cc=").AppendJoin(',', cc);
            if (bcc.Count > 0) url.Append("&bcc=").AppendJoin(',', bcc);
            if (!string.IsNullOrWhiteSpace(subject))
            {
                url.Append("&subject=");
                url.Append(UnityWebRequest.EscapeURL(subject).Replace("+", "%20"));
            }
            if (!string.IsNullOrWhiteSpace(body))
            {
                url.Append("&body=");
                url.Append(UnityWebRequest.EscapeURL(body).Replace("+", "%20"));
            }
            Application.OpenURL(url.ToString());
        }
    }
}
