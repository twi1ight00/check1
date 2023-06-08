namespace System.Data.Entity.Internal;

/// <summary>
///     Adapted from <see cref="T:System.Lazy`1" /> to allow the initializer to take an input object and
///     to retry initialization if it has previously failed.
/// </summary>
/// <remarks>
///     This class can only be used to initialize reference types that will not be null when
///     initialized.
/// </remarks>
/// <typeparam name="TInput">The type of the input.</typeparam>
/// <typeparam name="TResult">The type of the result.</typeparam>
internal class RetryLazy<TInput, TResult> where TResult : class
{
	private readonly object _lock = new object();

	private Func<TInput, TResult> _valueFactory;

	private TResult _value;

	/// <summary>
	///     Initializes a new instance of the <see cref="T:System.Data.Entity.Internal.RetryLazy`2" /> class.
	/// </summary>
	/// <param name="valueFactory">The value factory.</param>
	public RetryLazy(Func<TInput, TResult> valueFactory)
	{
		_valueFactory = valueFactory;
	}

	/// <summary>
	///     Gets the value, possibly by running the initializer if it has not been run before or
	///     if all previous times it ran resulted in exceptions.
	/// </summary>
	/// <param name="input">The input to the initializer; ignored if initialization has already succeeded.</param>
	/// <returns>The initialized object.</returns>
	public TResult GetValue(TInput input)
	{
		lock (_lock)
		{
			if (_value == null)
			{
				Func<TInput, TResult> valueFactory = _valueFactory;
				try
				{
					_valueFactory = null;
					_value = valueFactory(input);
				}
				catch (Exception)
				{
					_valueFactory = valueFactory;
					throw;
				}
			}
			return _value;
		}
	}
}
