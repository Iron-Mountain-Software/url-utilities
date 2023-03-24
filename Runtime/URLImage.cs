using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

namespace SpellBoundAR.URLUtilities
{
    [DisallowMultipleComponent]
    [RequireComponent(typeof(Image))]
    public class URLImage : MonoBehaviour
    {
        [SerializeField] private string url;
        [SerializeField] private Sprite defaultSprite;
        [SerializeField] private bool applyAspectRatio;

        [Header("Cache")]
        private Image _image;
        private AspectRatioFitter _aspectRatioFitter;
        
        private AspectRatioFitter AspectRatioFitter 
        {
            get
            {
                if (!_aspectRatioFitter) _aspectRatioFitter = GetComponent<AspectRatioFitter>();
                if (!_aspectRatioFitter) _aspectRatioFitter = gameObject.AddComponent<AspectRatioFitter>();
                return _aspectRatioFitter;
            }
        }

        public string URL
        {
            get => url;
            set
            {
                if (url == value) return;
                url = value;
                Reload();
            }
        }

        private void Awake()
        {
            _image = GetComponent<Image>();
            SetSprite(defaultSprite);
        }

        protected void OnEnable()
        {
            Reload();
        }

        public void Reload()
        {
            if (!enabled) return;
            StopAllCoroutines();
            Sprite sprite = URLImageCache.LoadFromCache(url);
            if (sprite) SetSprite(sprite);
            else StartCoroutine(ReloadRunner());
        }

        private IEnumerator ReloadRunner()
        {
            Sprite sprite = null;

            UnityWebRequest webRequest = UnityWebRequestTexture.GetTexture(url);
            
            yield return webRequest.SendWebRequest();

            switch (webRequest.result)
            {
                case UnityWebRequest.Result.ConnectionError:
                case UnityWebRequest.Result.ProtocolError:
                case UnityWebRequest.Result.DataProcessingError:
                    sprite = defaultSprite;
                    break;
                case UnityWebRequest.Result.Success:
                    Texture2D texture = ((DownloadHandlerTexture) webRequest.downloadHandler).texture;
                    texture.name = url;
                    sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(.5f, .5f));
                    sprite.name = url;
                    URLImageCache.AddToCache(url, sprite);
                    break;
            }

            SetSprite(sprite);
        }

        private void SetSprite(Sprite sprite)
        {
            if (!_image) return; 
            _image.sprite = sprite;
            _image.color = _image.sprite ? Color.white : Color.clear;
            ApplyAspectRatio();
        }

        private void ApplyAspectRatio()
        {
            if (!applyAspectRatio || !_image.sprite || !_image.sprite.texture) return;
            AspectRatioFitter.aspectRatio = (float) _image.sprite.texture.width / _image.sprite.texture.height;
        }
    }
}
