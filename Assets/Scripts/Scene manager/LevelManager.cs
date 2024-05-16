using DefaultNamespace.Presenters;
using UnityEngine;
using View;

namespace DefaultNamespace.Scene_manager
{
    public class LevelManager: MonoBehaviour
    {
        public LoadingView _LoadingView;
        private LoadingScene loadingScene;
        
        public void LoadLevel(string LVL)
        {
            var presenter = new LoadingScenePresenter();
            _LoadingView.Show();
            _LoadingView.SetPresenter(presenter);
            loadingScene = new LoadingScene(presenter);
            StartCoroutine(loadingScene.AsyncLoadLevel(LVL));
        }

        public void Quit()
        {
            loadingScene.Quit();
        }
    }
}