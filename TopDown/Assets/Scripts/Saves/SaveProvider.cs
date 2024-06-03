namespace TopDown.Saves
{
	public class SaveProvider
	{
		private SaveModel saveModel;
		private readonly ISaveLoader saveLoader;

		public SaveProvider(ISaveLoader saveLoader)
		{
			this.saveLoader = saveLoader;
			// Живет пока не закрыть игру, отписка не нужна
			EventBus.Subscribe<SaveLoadedEvent>(OnSaveLoaded);
		}

		public SaveModel GetSaveModel()
		{
			return saveModel;
		}

		public void Save()
		{
			saveLoader.Save(saveModel);
		}

		private void OnSaveLoaded(SaveLoadedEvent e)
		{
			saveModel = e.saveModel;
		}
	}
}