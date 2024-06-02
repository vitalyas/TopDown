using TopDown;
using UnityEngine;

public class UiFacade : MonoBehaviour
{
	[SerializeField]
	private GameObject menuUi;
	[SerializeField]
	private GameObject gameUi;

	public void ShowMenu()
	{
		gameUi.SetActive(false);
		menuUi.SetActive(true);	
	}

	public void ShowGame()
	{
		gameUi.SetActive(true);
		menuUi.SetActive(false);
	}

	private void OnPlayPressed(PlayButtonPressedEvent e)
	{
		ShowGame();
	}

	private void OnExitPressed(GameExitButtonPressedEvent e)
	{
		ShowMenu();
	}

	private void OnEnable()
	{
		ShowMenu();
		EventBus.Subscribe<PlayButtonPressedEvent>(OnPlayPressed);
		EventBus.Subscribe<GameExitButtonPressedEvent>(OnExitPressed);
	}

	private void OnDisable()
	{
		EventBus.Unsubscribe<PlayButtonPressedEvent>(OnPlayPressed);
		EventBus.Unsubscribe<GameExitButtonPressedEvent>(OnExitPressed);
	}
}
