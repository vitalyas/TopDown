using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine.SceneManagement;

namespace TopDown.SceneLoader
{
	public class SceneLoader : ISceneLoader
	{
		// Задумка в том, чтобы можно было показывать игровую сцену под UI
		// В то же время есть возможность загружать разные сцены в зависимости от прогресса игрока по уровням
		// Или например полностью изменить интерфейс на время ивента
		// Так же позволяет прятать UI во время игры силами самого UI без загрузок
		// Подобная система подойдет не любому проекту, тут нужно более детально понимать будущее проекта, хотя бы схематично
		private readonly Dictionary<SceneType, string> loadedScenes = new();

		public async UniTask Load(string sceneName, SceneType sceneType)
		{
			if (loadedScenes.TryGetValue(sceneType, out var loadedSceneName))
			{
				await SceneManager.UnloadSceneAsync(loadedSceneName);
			}

			switch (sceneType)
			{
				case SceneType.UI:
					await SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
					break;
				case SceneType.Game:
					await SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
					break;
			}

			loadedScenes[sceneType] = sceneName;
		}
	}
}