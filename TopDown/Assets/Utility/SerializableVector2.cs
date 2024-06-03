using System;
using UnityEngine;

namespace TopDown.Utilities
{
	[Serializable]
	public class SerializableVector2
	{
		public float x;
		public float y;

		public SerializableVector2(Vector3 vector)
		{
			x = vector.x;
			y = vector.y;
		}

		public static implicit operator Vector2(SerializableVector2 vector)
		{
			if (vector == null)
				return Vector2.zero;
			return new Vector2(vector.x, vector.y);
		}
	}
}