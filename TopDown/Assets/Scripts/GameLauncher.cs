using Cysharp.Threading.Tasks;
using TopDown.Saves;
using TopDown.SceneLoader;

namespace TopDown
{
	public class GameLauncher
	{
		private readonly ISceneLoaderDecorator sceneLoader;
		private readonly ISaveLoader saveLoader;

		public GameLauncher(ISceneLoaderDecorator sceneLoader,
			ISaveLoader saveLoader)
		{
			this.sceneLoader = sceneLoader;
			this.saveLoader = saveLoader;
			Launch().Forget();
		}

		private async UniTask Launch()
		{
			saveLoader.Load();
			await EventBus.WaitFor<SaveLoadedEvent>();
			sceneLoader.LoadStartScenes().Forget();
		}
	}
}