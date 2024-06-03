using Cysharp.Threading.Tasks;

namespace TopDown.SceneLoader
{
	public class SceneLoaderDecorator : ISceneLoaderDecorator
	{
		private readonly SceneLoader sceneLoader = new();
		private readonly LoadingScreen loadingScreen;
		private readonly ScenesSettings scenesSettings;

		public SceneLoaderDecorator(LoadingScreen loadingScreen,
			ScenesSettings scenesSettings)
		{
			this.loadingScreen = loadingScreen;
			this.scenesSettings = scenesSettings;
			LoadStartScenes().Forget();
		}

		public async UniTask Load(string sceneName, SceneType sceneType)
		{
			await sceneLoader.Load(sceneName, sceneType);
		}

		public async UniTask LoadStartScenes()
		{
			loadingScreen.Show();
			await Load("Menu", SceneType.UI);
			await Load(scenesSettings.GameSceneName, SceneType.Game);
			// Искренне не понимаю зачем экрану висеть n секунд.
			// Игрока и так могут раздражать загрузки, нет причин делать их дольше.
			await UniTask.Delay(2000);
			loadingScreen.Hide();
		}
	}
}