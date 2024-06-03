using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace TopDown.Saves
{
	// Не remote конечно, но надеюсь для тестового достаточно подмены реализации
	public class RemoteSaveLoader : ISaveLoader
	{
		private string filePath = Application.persistentDataPath + "/save.dat";

		public void Load()
		{
			LoadAsync().Forget();
		}

		public void Save(SaveModel saveModel)
		{
			SaveAsync(saveModel).Forget();
		}

		private async UniTask LoadAsync()
		{
			var saveModel = new SaveModel();

			if (File.Exists(filePath))
			{
				await UniTask.RunOnThreadPool(() =>
				{
					var formatter = new BinaryFormatter();
					using var stream = File.Open(filePath, FileMode.Open, FileAccess.Read);
					saveModel = (SaveModel)formatter.Deserialize(stream);
				});
			}

			EventBus.Invoke(new SaveLoadedEvent(saveModel));
		}

		private async UniTask SaveAsync(SaveModel saveModel)
		{
			var formatter = new BinaryFormatter();

			await UniTask.RunOnThreadPool(() =>
			{
				using var stream = File.Open(filePath, FileMode.OpenOrCreate, FileAccess.ReadWrite);
				formatter.Serialize(stream, saveModel);
			});
		}
	}
}