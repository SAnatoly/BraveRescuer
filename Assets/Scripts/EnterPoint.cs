using DefaultNamespace.GameManager;
using DefaultNamespace.Listeners;
using DefaultNamespace.Popupes;
using DefaultNamespace.Scene_manager;
using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace
{
    public class EnterPoint: MonoBehaviour
    {
        [SerializeField] private Button _openMenuPrefab;
        [SerializeField] private Transform _buttonPerent;
        [SerializeField] private PausePopup _pausePopup;
        [SerializeField] private LevelManager _levelManager;
        
        public void Start()
        {
            var button = Instantiate(_openMenuPrefab, _buttonPerent);
            button.onClick.AddListener(() => OpenPopup(button));
            _pausePopup._exitButton.onClick.AddListener(() =>_levelManager.LoadLevel("Menu"));
        }

        private void OpenPopup(Button button)
        {
            _pausePopup.Show(button);
        }
    }
}