using TopDown;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class PlayButton : MonoBehaviour
{
	private Button button;

	private void Awake()
	{
		button = GetComponent<Button>();
		button.onClick.AddListener(() => EventBus.Invoke(new PlayButtonPressedEvent()));
	}
}
