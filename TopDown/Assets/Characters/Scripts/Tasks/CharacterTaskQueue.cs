using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;

namespace TopDown.Game.Character.Tasks
{
	public class CharacterTaskQueue
	{
		private readonly Queue<ICharacterTask> characterTasks = new();
		private readonly int maxTasksCount;
		private bool isStarted;
		private CancellationTokenSource cancellationTokenSource;

		public CharacterTaskQueue(int maxTasksCount)
		{
			this.maxTasksCount = maxTasksCount;
		}

		public void Enqueue(ICharacterTask characterTask)
		{
			if (characterTasks.Count <= maxTasksCount)
			{
				characterTasks.Enqueue(characterTask);
			}
		}

		private async UniTask StartTasks()
		{
			cancellationTokenSource = new CancellationTokenSource();

			while (characterTasks.Count > 0)
			{
				var task = characterTasks.Dequeue();
				await task.Execute(cancellationTokenSource.Token);
			}

			cancellationTokenSource.Dispose();
			cancellationTokenSource = null;
			isStarted = false;
		}

		public void TryStart()
		{
			if (!isStarted)
			{
				isStarted = true;
				StartTasks().Forget();
			}
		}

		public void Stop()
		{
			if (isStarted)
			{
				cancellationTokenSource.Cancel();
			}
		}
	}
}