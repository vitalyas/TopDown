using TopDown;
using UnityEngine;
using UnityEngine.UI;

public class GameExitButton : MonoBehaviour
{
	private Button button;

	private void Awake()
	{
		button = GetComponent<Button>();
		button.onClick.AddListener(() => EventBus.Invoke(new GameExitButtonPressedEvent()));
	}
}
