using Cysharp.Threading.Tasks;

namespace TopDown.SceneLoader
{
	public interface ISceneLoaderDecorator : ISceneLoader
	{
		UniTask LoadStartScenes();
	}
}