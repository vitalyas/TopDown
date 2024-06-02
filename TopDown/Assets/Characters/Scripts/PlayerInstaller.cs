using TopDown.Game.Character;
using UnityEngine.AI;
using Zenject;

public class PlayerInstaller : MonoInstaller
{
	public override void InstallBindings()
	{
		// Эти компоненты можно закинуть на префаб в ручную
		// В теории может возникуть ситуация когда например может понадобиться заменить логику ходьбы
		// Однако исходя из моего опыта такие возможности хоть и бывают в ТЗ от дизайнеров, ими никогда не пользуются
		// С другой стороны если нужны разные персонажи (а вот это уже действительно бывает), 
		// создать новый префаб будет легче за счет того, что компоненты не нужно закидывать.
		// Достаточно инсталлеров
		Container.Bind<NavMeshAgent>().FromComponentOnRoot().AsSingle();
		Container.Bind<CharacterWalker>().FromNewComponentOnRoot().AsSingle();
		Container.Bind<PlayerFacade>().FromNewComponentOnRoot().AsSingle().NonLazy();
	}
}
