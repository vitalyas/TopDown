namespace TopDown.Saves
{
	public interface ISaveLoader
	{
		void Load();
		void Save(SaveModel saveModel);
	}
}