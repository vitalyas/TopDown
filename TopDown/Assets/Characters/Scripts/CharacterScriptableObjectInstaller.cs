using UnityEngine;
using Zenject;

namespace TopDown.Game.Character
{
	[CreateAssetMenu(menuName = "TopDown/Character/CharacterInstaller")]
	public class CharacterScriptableObjectInstaller : ScriptableObjectInstaller
	{
		[SerializeField]
		private CharacterSettings characterSettings;

		public override void InstallBindings()
		{
			// Нстройки персонажа биндятся без использования интерфейсов т.к. они излишни
			// Это просто набор циферок, реализации какой-либо логики там быть не дожжно
			// Соответственно и абстрагировать нечего
			Container.Bind<CharacterSettings>().FromInstance(characterSettings);
		}
	}
}