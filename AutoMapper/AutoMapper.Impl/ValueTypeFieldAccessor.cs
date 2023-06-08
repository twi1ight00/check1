using System.Reflection;

namespace AutoMapper.Impl;

public class ValueTypeFieldAccessor : FieldGetter, IMemberAccessor, IMemberGetter, IMemberResolver, IValueResolver
{
	private readonly FieldInfo _lateBoundFieldSet;

	public ValueTypeFieldAccessor(FieldInfo fieldInfo)
		: base(fieldInfo)
	{
		_lateBoundFieldSet = fieldInfo;
	}

	public void SetValue(object destination, object value)
	{
		_lateBoundFieldSet.SetValue(destination, value);
	}
}
