using UnityEngine;
using Zenject;

namespace TopDown.SceneLoader
{
	[CreateAssetMenu(menuName = "TopDown/Configs/GameSceneInstaller")]
	public class LevelsInstaller : ScriptableObjectInstaller
	{
		[SerializeField]
		private ScenesSettings scenesSettings;

		public override void InstallBindings()
		{
			Container.Bind<ScenesSettings>().FromInstance(scenesSettings);
		}
	}
}