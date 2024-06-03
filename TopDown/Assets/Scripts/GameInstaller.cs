using TopDown.Saves;
using Zenject;

namespace TopDown
{
	public class GameInstaller : MonoInstaller
	{
		public override void InstallBindings()
		{
			Container.Bind<SaveProvider>().AsSingle().NonLazy();
			Container.Bind<GameLauncher>().AsSingle().NonLazy();
		}
	}
}