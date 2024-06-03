using UnityEngine;
using Zenject;

namespace TopDown.SceneLoader
{
	public class LoadingInstaller : MonoInstaller
	{
		[SerializeField]
		private LoadingScreen loadingScreen;

		public override void InstallBindings()
		{
			Container.Bind<LoadingScreen>().FromComponentInNewPrefab(loadingScreen).AsSingle();
			Container.Bind<ISceneLoaderDecorator>().To<SceneLoaderDecorator>().AsSingle();
		}
	}
}