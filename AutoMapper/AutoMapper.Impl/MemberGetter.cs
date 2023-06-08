using System;
using System.Reflection;
using AutoMapper.Internal;

namespace AutoMapper.Impl;

public abstract class MemberGetter : IMemberGetter, IMemberResolver, IValueResolver
{
	protected static readonly IDelegateFactory DelegateFactory = PlatformAdapter.Resolve<IDelegateFactory>();

	public abstract MemberInfo MemberInfo { get; }

	public abstract string Name { get; }

	public abstract Type MemberType { get; }

	public abstract object GetValue(object source);

	public ResolutionResult Resolve(ResolutionResult source)
	{
		if (source.Value != null)
		{
			return source.New(GetValue(source.Value), MemberType);
		}
		return source.New(source.Value, MemberType);
	}

	public abstract object[] GetCustomAttributes(Type attributeType, bool inherit);

	public abstract object[] GetCustomAttributes(bool inherit);

	public abstract bool IsDefined(Type attributeType, bool inherit);
}
