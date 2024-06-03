using System;
using System.Collections.Generic;
using TopDown.Utilities;

namespace TopDown.Saves
{
	[Serializable]
	public class PlayerSaveModel
	{
		public SerializableVector3 position;
		public List<TaskSaveModel> tasks = new();
	}
}