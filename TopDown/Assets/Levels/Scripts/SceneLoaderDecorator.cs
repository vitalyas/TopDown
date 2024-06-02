using Cysharp.Threading.Tasks;

public class SceneLoaderDecorator : ISceneLoader
{
	private readonly SceneLoader sceneLoader = new();
	private readonly LoadingScreen loadingScreen;

	public SceneLoaderDecorator(LoadingScreen loadingScreen)
	{
		this.loadingScreen = loadingScreen;
		LoadStartScenes().Forget();
	}

	public async UniTask Load(string sceneName, SceneType sceneType)
	{
		await sceneLoader.Load(sceneName, sceneType);
	}

	private async UniTask LoadStartScenes()
	{
		loadingScreen.Show();
		await Load("Menu", SceneType.UI);
		await Load("Level_0", SceneType.Game);
		// Искренне не понимаю зачем экрану висеть n секунд.
		// Игрока и так могут раздражать загрузки, нет причин делать их дольше.
		await UniTask.Delay(2000);
		loadingScreen.Hide();
	}
}
