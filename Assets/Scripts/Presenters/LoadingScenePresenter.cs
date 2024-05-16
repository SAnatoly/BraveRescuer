namespace DefaultNamespace.Presenters
{
    public class LoadingScenePresenter: ILoadingScenePresenter
    {
        public float Progress { get; private set; }

        public void UpdateProgress(float progress)
        {
            Progress = progress;
        }
    }
}