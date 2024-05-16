using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace.Popupes
{
    public class PausePopup: MonoBehaviour
    {
        public Button _resumeButton;
        public Button _exitButton;
        public Button _closeButton;

        private Button _pauseButton;
        public void Show(Button pauseButton)
        {
            _pauseButton = pauseButton;
            gameObject.SetActive(true);
            _pauseButton.gameObject.SetActive(false);
            _closeButton.onClick.AddListener(Hide);
        }

        public void Hide()
        {
            _pauseButton.gameObject.SetActive(true);
            _closeButton.onClick.RemoveListener(Hide);
            gameObject.SetActive(false);
        }
    }
}