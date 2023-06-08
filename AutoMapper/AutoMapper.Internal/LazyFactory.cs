using System;
using System.Threading;

namespace AutoMapper.Internal;

public static class LazyFactory
{
	private sealed class LazyImpl<T> : ILazy<T> where T : class
	{
		private readonly object _lockObj = new object();

		private readonly Func<T> _valueFactory;

		private bool _isDelegateInvoked;

		private T m_value;

		public T Value
		{
			get
			{
				if (!_isDelegateInvoked)
				{
					T value = _valueFactory();
					Interlocked.CompareExchange(ref m_value, value, null);
					bool flag = false;
					try
					{
						Monitor.Enter(_lockObj);
						flag = true;
						_isDelegateInvoked = true;
					}
					finally
					{
						if (flag)
						{
							Monitor.Exit(_lockObj);
						}
					}
				}
				return m_value;
			}
		}

		public LazyImpl(Func<T> valueFactory)
		{
			_valueFactory = valueFactory;
		}
	}

	public static ILazy<T> Create<T>(Func<T> valueFactory) where T : class
	{
		return new LazyImpl<T>(valueFactory);
	}
}
