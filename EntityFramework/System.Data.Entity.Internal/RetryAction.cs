namespace System.Data.Entity.Internal;

/// <summary>
///     Adapted from <see cref="T:System.Lazy`1" /> to allow the initializer to take an input object and
///     to do one-time initialization that only has side-effects and doesn't return a value.
/// </summary>
/// <typeparam name="TInput">The type of the input.</typeparam>
internal class RetryAction<TInput>
{
	private readonly object _lock = new object();

	private Action<TInput> _action;

	/// <summary>
	///     Initializes a new instance of the <see cref="T:System.Data.Entity.Internal.RetryAction`1" /> class.
	/// </summary>
	/// <param name="action">The action.</param>
	public RetryAction(Action<TInput> action)
	{
		_action = action;
	}

	/// <summary>
	///     Performs the action unless it has already been successfully performed before.
	/// </summary>
	/// <param name="input">The input to the action; ignored if the action has already succeeded.</param>
	public void PerformAction(TInput input)
	{
		lock (_lock)
		{
			if (_action != null)
			{
				Action<TInput> action = _action;
				_action = null;
				try
				{
					action(input);
					return;
				}
				catch (Exception)
				{
					_action = action;
					throw;
				}
			}
		}
	}
}
