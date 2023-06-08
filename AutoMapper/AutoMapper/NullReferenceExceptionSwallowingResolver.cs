using System;

namespace AutoMapper;

public class NullReferenceExceptionSwallowingResolver : IMemberResolver, IValueResolver
{
	private readonly IMemberResolver _inner;

	public Type MemberType => _inner.MemberType;

	public NullReferenceExceptionSwallowingResolver(IMemberResolver inner)
	{
		_inner = inner;
	}

	public ResolutionResult Resolve(ResolutionResult source)
	{
		try
		{
			return _inner.Resolve(source);
		}
		catch (NullReferenceException)
		{
			return source.New(null, MemberType);
		}
	}
}
