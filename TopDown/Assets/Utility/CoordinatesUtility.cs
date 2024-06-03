using UnityEngine;

namespace TopDown.Utilities
{
	public static class CoordinatesUtility
	{
		public static Vector3 ScreenCoordinatesToWorld(Vector2 screenPosition, Camera camera)
		{
			var ray = camera.ScreenPointToRay(screenPosition);
			Physics.Raycast(ray, out var hit);
			return hit.point;
		}
	}
}