using Cysharp.Threading.Tasks;

namespace TopDown.SceneLoader
{
	public interface ISceneLoader
	{
		UniTask Load(string sceneName, SceneType sceneType);
	}
}