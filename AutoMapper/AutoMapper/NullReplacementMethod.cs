namespace AutoMapper;

public class NullReplacementMethod : IValueResolver
{
	private readonly object _nullSubstitute;

	public NullReplacementMethod(object nullSubstitute)
	{
		_nullSubstitute = nullSubstitute;
	}

	public ResolutionResult Resolve(ResolutionResult source)
	{
		if (_nullSubstitute == null)
		{
			return source;
		}
		if (source.Value != null)
		{
			return source;
		}
		return source.New(_nullSubstitute);
	}
}
