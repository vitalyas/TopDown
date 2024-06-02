using UnityEngine;
using UnityEngine.AI;
using Zenject;

namespace TopDown.Game.Character
{
	[RequireComponent(typeof(NavMeshAgent))]
	public class CharacterWalker : MonoBehaviour
	{
		private NavMeshAgent navMeshAgent;

		[Inject]
		private void Construct(CharacterSettings characterSettings,
			NavMeshAgent navMeshAgent)
		{
			this.navMeshAgent = navMeshAgent;
			navMeshAgent.speed = characterSettings.Speed;
			navMeshAgent.acceleration = characterSettings.Acceleration;
			navMeshAgent.angularSpeed = characterSettings.AngularSpeed;
		}

		public void WalkTo(Vector3 position)
		{
			navMeshAgent.SetDestination(position);
		}

		public bool IsWalking()
		{
			if (navMeshAgent.remainingDistance > navMeshAgent.stoppingDistance)
				return true;
			
			return false;
		}
	}
}