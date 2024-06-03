using UnityEngine;

namespace TopDown.Saves
{
	public class LocalSaveLoader : ISaveLoader
	{
		private const string GAME_SAVE_KEY = "GameSave";

		public void Load()
		{
			var save = new SaveModel();
			if (PlayerPrefs.HasKey(GAME_SAVE_KEY))
			{
				var json = PlayerPrefs.GetString(GAME_SAVE_KEY);
				save = JsonUtility.FromJson<SaveModel>(json);
			}

			EventBus.Invoke(new SaveLoadedEvent(save));
		}

		public void Save(SaveModel saveModel)
		{
			var json = JsonUtility.ToJson(saveModel);
			PlayerPrefs.SetString(GAME_SAVE_KEY, json);
		}
	}
}