using UnityEngine;
using Zenject;

public class GameLocationInstaller : MonoInstaller
{
	[SerializeField]
	new private Camera camera;

	public override void InstallBindings()
	{
		Container.Bind<Camera>().FromInstance(camera);
	}
}
