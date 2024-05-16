using DefaultNamespace.GameManager;
using DefaultNamespace.Popupes;
using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace
{
    public class EnterPoint: MonoBehaviour
    {
        [SerializeField] private Button _openMenuPrefab;
        [SerializeField] private Transform _buttonPerent;
        [SerializeField] private PausePopup _pausePopup;

        
        public void Start()
        {
            var button = Instantiate(_openMenuPrefab, _buttonPerent);
            button.onClick.AddListener(() => OpenPopup(button));
        }

        private void OpenPopup(Button button)
        {
            _pausePopup.Show(button);
        }
    }
}