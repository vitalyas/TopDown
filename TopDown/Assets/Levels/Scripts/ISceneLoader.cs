using Cysharp.Threading.Tasks;

public interface ISceneLoader
{
	UniTask Load(string sceneName, SceneType sceneType);
}
