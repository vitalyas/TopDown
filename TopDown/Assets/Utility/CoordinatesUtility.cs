using UnityEngine;

namespace TopDown.Utilities
{
	public static class CoordinatesUtility
	{
		public static Vector3 ScreenCoordinatesToWorld(Vector3 screenPosition)
		{
			var ray = Camera.main.ScreenPointToRay(screenPosition);
			Physics.Raycast(ray, out var hit);
			return hit.point;
		}
	}
}