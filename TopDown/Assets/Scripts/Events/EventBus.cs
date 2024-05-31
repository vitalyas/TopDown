using System;
using System.Collections.Generic;

namespace TopDown
{
	// Редкий случай пользы от синглтона.
	// Многим классам нужны события. 
	// Прокидывать зависимости на условного менеджера или еще хуже классов друг на друга выгядит плохим вариантом.
	// Особенно когда их сотни или тысячи.
	// При необходимости можно дополнить приоритетами вызовов, ожиданием событий или чисткой через определенный промежуток времени.
	
	public class EventBus
	{
		private static readonly EventBus instance = new();
		private readonly Dictionary<Type, List<object>> actionsDict = new();

		public static void Subscribe<T>(Action<T> action)
		{
			instance.SubscribeInternal(action);
		}

		public static void Invoke<T>(T args)
		{
			instance.InvokeInternal(args);
		}

		public static void Unsubscribe<T>(Action<T> action)
		{
			instance.UnsubscribeInternal(action);
		}

		private void SubscribeInternal<T>(Action<T> action)
		{
			if (actionsDict.TryGetValue(typeof(T), out var actionsList))
			{
				actionsList.Add(action);
			}
			else
			{
				actionsDict.Add(typeof(T), new List<object>() { action });
			}
		}

		private void InvokeInternal<T>(T args)
		{
			if (actionsDict.TryGetValue(typeof(T), out var actionsList))
			{
				foreach (var action in actionsList)
				{
					var callback = action as Action<T>;
					callback?.Invoke(args);
				}
			}
		}

		private void UnsubscribeInternal<T>(Action<T> action)
		{
			if (actionsDict.TryGetValue(typeof(T), out var actionsList))
			{
				actionsList.Remove(action);
			}
		}
	}
}