using System.Threading;
using Cysharp.Threading.Tasks;

namespace TopDown.Game.Character.Tasks
{
	public interface ICharacterTask
	{
		// Задачи персонажа могут быть любыми
		// Пойти к точке, потанцевать, открыть сундук, построить ракету
		// Тут все зависит от фантазии дизайнеров, логику можно описать практически любую
		UniTask Execute(CancellationToken cancellationToken);
	}
}