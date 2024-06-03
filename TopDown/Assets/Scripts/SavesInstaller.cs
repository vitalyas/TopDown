using UnityEngine;
using Zenject;

namespace TopDown.Saves
{
	[CreateAssetMenu(menuName = "TopDown/Configs/SaveInstaller")]
	public class SavesInstaller : ScriptableObjectInstaller
	{
		[SerializeField]
		private SaveMode saveMode;
		public override void InstallBindings()
		{
			switch (saveMode)
			{
				case SaveMode.Local:
					Container.Bind<ISaveLoader>().To<LocalSaveLoader>().AsSingle();
					break;
				case SaveMode.Remote:
					Container.Bind<ISaveLoader>().To<RemoteSaveLoader>().AsSingle();
					break;
			}

		}
	}
}