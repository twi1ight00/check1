using System.Reflection;

namespace AutoMapper.Impl;

public class FieldAccessor : FieldGetter, IMemberAccessor, IMemberGetter, IMemberResolver, IValueResolver
{
	private readonly LateBoundFieldSet _lateBoundFieldSet;

	public FieldAccessor(FieldInfo fieldInfo)
		: base(fieldInfo)
	{
		_lateBoundFieldSet = MemberGetter.DelegateFactory.CreateSet(fieldInfo);
	}

	public void SetValue(object destination, object value)
	{
		_lateBoundFieldSet(destination, value);
	}
}
