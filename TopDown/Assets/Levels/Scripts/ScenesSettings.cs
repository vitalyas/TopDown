using UnityEngine;

namespace TopDown.SceneLoader
{
	// Супер быстрая реализация. 
	// Но даже так уже можно менять игровую сцену не меняя код.
	// В том числе удаленно. 
	// При наличии системы скачивания конфигом. Например через firebase
	[CreateAssetMenu(menuName = "TopDown/Configs/GameScene")]
	public class ScenesSettings : ScriptableObject
	{
		[SerializeField]
		private string gameSceneName;

		public string GameSceneName => gameSceneName;
	}
}