using UnityEngine;
using Zenject;

public class LoadingInstaller : MonoInstaller
{
	[SerializeField]
	private LoadingScreen loadingScreen;

	public override void InstallBindings()
	{
		Container.Bind<LoadingScreen>().FromComponentInNewPrefab(loadingScreen).AsSingle();
		Container.Bind<ISceneLoader>().To<SceneLoaderDecorator>().AsSingle().NonLazy();
	}
}
