using System;
using DefaultNamespace.Presenters;
using UnityEngine.UI;
using TMPro;
using UnityEngine;

namespace View
{
    public class LoadingView: MonoBehaviour
    {
        public Image _loadingBar;
        public TMP_Text _loadingProgress;
        public float _progress;

        public void Start()
        {
            gameObject.SetActive(false);
        }

        private ILoadingScenePresenter _iLoadingScenePresenter;

        public void SetPresenter(ILoadingScenePresenter presenter)
        {
            _iLoadingScenePresenter = presenter;
        }

        public void Show()
        {
            gameObject.SetActive(true);
        }
        
        public void Refresh()
        {
            _progress = _iLoadingScenePresenter.Progress;

            _loadingBar.fillAmount = _progress;
            _loadingProgress.text = $"Загрузка: {_progress}%";
        }

        public void Update()
        {
            Refresh();
        }
    }
}