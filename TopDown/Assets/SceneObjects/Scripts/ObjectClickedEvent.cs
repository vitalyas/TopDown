using UnityEngine;

namespace TopDown.Game
{
	public struct ObjectClickedEvent
	{
		public readonly Vector2 ClickPositionOnScreen;

		public ObjectClickedEvent(Vector2 clickPositionOnScreen)
		{
			ClickPositionOnScreen = clickPositionOnScreen;
		}
	}
}