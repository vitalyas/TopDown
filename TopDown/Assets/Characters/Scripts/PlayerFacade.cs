using TopDown.Game.Character.Tasks;
using TopDown.Saves;
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
		private SaveProvider saveProvider;

		[Inject]
		private void Construct(CharacterSettings playerSettings,
			CharacterWalker characterWalker,
			Camera camera,
			SaveProvider saveProvider)
		{
			characterTaskQueue = new CharacterTaskQueue(playerSettings.TasksCount);
			this.characterWalker = characterWalker;
			this.camera = camera;
			this.saveProvider = saveProvider;
			transform.position = saveProvider.GetSaveModel().playerSaveModel.position;

			foreach(var taskSave in saveProvider.GetSaveModel().playerSaveModel.tasks)
				characterTaskQueue.Enqueue(new CharacterTaskWalk(characterWalker, CoordinatesUtility.ScreenCoordinatesToWorld(taskSave.position, camera)));
		}

		private void OnEnable()
		{
			EventBus.Subscribe<PlayButtonPressedEvent>(OnPlayButtonPressed);
			EventBus.Subscribe<CharacterTaskCompletedEvent>(OnTaskCompleted);
			EventBus.Subscribe<ObjectClickedEvent>(OnFloorClicked);
			EventBus.Subscribe<GameExitButtonPressedEvent>(OnExitButtonClicked);
		}

		private void OnDisable()
		{
			EventBus.Unsubscribe<PlayButtonPressedEvent>(OnPlayButtonPressed);
			EventBus.Unsubscribe<CharacterTaskCompletedEvent>(OnTaskCompleted);
			EventBus.Unsubscribe<ObjectClickedEvent>(OnFloorClicked);
			EventBus.Unsubscribe<GameExitButtonPressedEvent>(OnExitButtonClicked);
		}

		private void OnFloorClicked(ObjectClickedEvent e)
		{
			saveProvider.GetSaveModel().playerSaveModel.tasks.Add(new TaskSaveModel { position = new SerializableVector2(e.ClickPositionOnScreen) });
			saveProvider.Save();
			characterTaskQueue.Enqueue(new CharacterTaskWalk(characterWalker, CoordinatesUtility.ScreenCoordinatesToWorld(e.ClickPositionOnScreen, camera)));
			characterTaskQueue.TryStart();
		}

		private void OnExitButtonClicked(GameExitButtonPressedEvent e)
		{
			saveProvider.GetSaveModel().playerSaveModel.position = new SerializableVector3(transform.position);
			saveProvider.Save();
			characterTaskQueue.Stop();
		}

		private void OnTaskCompleted(CharacterTaskCompletedEvent e)
		{
			saveProvider.GetSaveModel().playerSaveModel.position = new SerializableVector3(transform.position);
			if(saveProvider.GetSaveModel().playerSaveModel.tasks.Count > 0)
				saveProvider.GetSaveModel().playerSaveModel.tasks.RemoveAt(0);
			saveProvider.Save();
		}

		private void OnPlayButtonPressed(PlayButtonPressedEvent e)
		{
			characterTaskQueue.TryStart();
		}
	}
}