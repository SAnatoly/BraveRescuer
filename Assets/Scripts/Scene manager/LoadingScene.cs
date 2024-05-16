using System.Collections;
using System.Collections.Generic;
using DefaultNamespace.Presenters;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingScene
{
    private LoadingScenePresenter _presenter;
    
    public LoadingScene(LoadingScenePresenter presenter)
    {
        _presenter = presenter;
    }

    public void Quit()
    {
        Application.Quit();
    }

    public IEnumerator<string> AsyncLoadLevel(string LVL)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(LVL);
        
        while(!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);
            _presenter.UpdateProgress(progress);
            yield return null;
        }
    }
}
