using System;
using UnityEngine;
using UnityEngine.Video;

namespace TopDown.Utilities
{
	[Serializable]
	public class SerializableVector3
	{
		public float x;
		public float y;
		public float z;

		public SerializableVector3(Vector3 vector)
		{
			x = vector.x;
			y = vector.y;
			z = vector.z;
		}

		public static implicit operator Vector3(SerializableVector3 vector)
		{
			if (vector == null)
				return Vector3.zero;
			return new Vector3(vector.x, vector.y, vector.z);
		}
	}
}