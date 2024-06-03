using TopDown.Game.Character.Tasks;
using TopDown.Utilities;
using UnityEngine;
using Zenject;

namespace TopDown.Game.Character
{
	public class PlayerFacade : MonoBehaviour
	{
		private CharacterTaskQueue characterTaskQueue;
		private CharacterWalker characterWalker;
		new private Camera camera;

		[Inject]
		private void Construct(CharacterSettings playerSettings,
			CharacterWalker characterWalker,
			Camera camera)
		{
			characterTaskQueue = new CharacterTaskQueue(playerSettings.TasksCount);
			this.characterWalker = characterWalker;
			this.camera = camera;
		}

		private void OnEnable()
		{
			EventBus.Subscribe<ObjectClickedEvent>(OnFloorClicked);
			EventBus.Subscribe<GameExitButtonPressedEvent>(OnExitButtonClicked);
		}

		private void OnDisable()
		{
			EventBus.Unsubscribe<ObjectClickedEvent>(OnFloorClicked);
			EventBus.Unsubscribe<GameExitButtonPressedEvent>(OnExitButtonClicked);
		}

		private void OnFloorClicked(ObjectClickedEvent e)
		{
			characterTaskQueue.Enqueue(new CharacterTaskWalk(characterWalker, CoordinatesUtility.ScreenCoordinatesToWorld(e.ClickPositionOnScreen, camera)));
			characterTaskQueue.TryStart();
		}

		private void OnExitButtonClicked(GameExitButtonPressedEvent e)
		{
			characterTaskQueue.Stop();
		}
	}
}