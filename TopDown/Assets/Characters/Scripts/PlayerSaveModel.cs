using System;
using System.Collections.Generic;
using UnityEngine;

namespace TopDown.Saves
{
	[Serializable]
	public class PlayerSaveModel
	{
		public Vector3 position;
		public List<TaskSaveModel> tasks = new();
	}
}