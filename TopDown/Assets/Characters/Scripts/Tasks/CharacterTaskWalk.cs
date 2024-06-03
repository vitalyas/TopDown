using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace TopDown.Game.Character.Tasks
{
	public class CharacterTaskWalk : ICharacterTask
	{
		private readonly CharacterWalker characterWalker;
		private readonly Vector3 walkPosition;

		public CharacterTaskWalk(CharacterWalker characterWalker, Vector3 walkPosition)
		{
			this.characterWalker = characterWalker;
			this.walkPosition = walkPosition;
		}

		public async UniTask Execute(CancellationToken cancellationToken)
		{
			characterWalker.WalkTo(walkPosition);
			cancellationToken.Register(Stop);

			while (characterWalker.IsWalking())
			{
				if (!cancellationToken.IsCancellationRequested)
				{
					await UniTask.DelayFrame(1, cancellationToken: cancellationToken);
					EventBus.Invoke(new CharacterTaskCompletedEvent());
				}
			}
		}

		private void Stop()
		{
			characterWalker.Stop();
		}
	}
}