using UnityEngine;
using UnityEngine.EventSystems;

namespace TopDown.Game
{
	public class ClickableObject : MonoBehaviour, IPointerDownHandler
	{
		public void OnPointerDown(PointerEventData eventData)
		{
			EventBus.Invoke(new ObjectClickedEvent(eventData.pressPosition));
		}
	}
}