using UnityEngine;
using UnityEngine.UI;

namespace UI.Debug
{
    [RequireComponent(typeof(Text))]
    public class DisplayFps : MonoBehaviour
    {
        // ReSharper disable once InconsistentNaming
        private const float UI_REFRESH_RATE = 1f;
        
        private float _frameRate;
        private float _frameTimer;
        private Text _display;

        public void Start()
        {
            _display = GetComponent<Text>();
        }

        public void Update()
        {
            if (Time.unscaledTime < _frameTimer) return;
            
            _frameTimer = Time.unscaledTime + UI_REFRESH_RATE;
            _frameRate = 1f / Time.unscaledDeltaTime;
            _display.text = "FPS: " + _frameRate;
        }
    }
}