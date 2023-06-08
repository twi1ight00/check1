using System;

namespace AutoMapper;

public class DelegateBasedResolver<TSource, TMember> : IMemberResolver, IValueResolver
{
	private readonly Func<TSource, TMember> _method;

	public Type MemberType => typeof(TMember);

	public DelegateBasedResolver(Func<TSource, TMember> method)
	{
		_method = method;
	}

	public ResolutionResult Resolve(ResolutionResult source)
	{
		if (source.Value != null && !(source.Value is TSource))
		{
			throw new ArgumentException(string.Concat("Expected obj to be of type ", typeof(TSource), " but was ", source.Value.GetType()));
		}
		TMember val = _method((TSource)source.Value);
		return source.New(val, MemberType);
	}
}
public class DelegateBasedResolver<TSource> : IValueResolver
{
	private readonly Func<TSource, object> _method;

	public DelegateBasedResolver(Func<TSource, object> method)
	{
		_method = method;
	}

	public ResolutionResult Resolve(ResolutionResult source)
	{
		if (source.Value != null && !(source.Value is TSource))
		{
			throw new ArgumentException(string.Concat("Expected obj to be of type ", typeof(TSource), " but was ", source.Value.GetType()));
		}
		object value = _method((TSource)source.Value);
		return source.New(value);
	}
}
