using UnityEngine;

namespace TopDown.Game.Character
{
	// Можно было бы сделать обычным классом и настраивать все через Installer
	// Это бы упростило интерфейс настройки и уменьшело закидывание ссылок
	// Однако количество настроек может лекго дорасти до нескольких десятков (на все воля дизайнеров) и их пришлось бы разделять
	[CreateAssetMenu(menuName = "TopDown/Character/CharacterSettings")]
	public class CharacterSettings : ScriptableObject
	{
		[SerializeField]
		private float speed;

		[SerializeField]
		private float acceleration;

		[SerializeField]
		private float angularSpeed;

		[SerializeField]
		private int tasksCount;

		public float Speed => speed;
		public float Acceleration => acceleration;
		public float AngularSpeed => angularSpeed;
		public int TasksCount => tasksCount;
	}
}