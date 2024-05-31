using UnityEngine;
using UnityEngine.AI;

namespace TopDown.Game.Character
{
	[RequireComponent(typeof(NavMeshAgent))]
	public class CharacterWalker : MonoBehaviour
	{
		private NavMeshAgent navMeshAgent;

		private void Awake()
		{
			navMeshAgent = GetComponent<NavMeshAgent>();
		}

		public void WalkTo(Vector3 position)
		{
			navMeshAgent.SetDestination(position);
		}

		private void OnEnable()
		{
			EventBus.Subscribe<ObjectClickedEvent>(OnFloorClicked);
		}

		private void OnDisable()
		{
			EventBus.Unsubscribe<ObjectClickedEvent>(OnFloorClicked);
		}

		private void OnFloorClicked(ObjectClickedEvent e)
		{
			var ray = Camera.main.ScreenPointToRay(e.ClickPositionOnScreen);
			Physics.Raycast(ray, out var hit);
			WalkTo(hit.point);
		}
	}
}