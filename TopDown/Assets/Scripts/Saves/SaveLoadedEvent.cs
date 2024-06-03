namespace TopDown.Saves
{
	public struct SaveLoadedEvent
	{
		public SaveModel saveModel;

		public SaveLoadedEvent(SaveModel saveModel)
		{
			this.saveModel = saveModel;
		}
	}
}