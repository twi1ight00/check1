using System.Reflection;

namespace AutoMapper.Impl;

public class ValueTypePropertyAccessor : PropertyGetter, IMemberAccessor, IMemberGetter, IMemberResolver, IValueResolver
{
	private readonly MethodInfo _lateBoundPropertySet;

	private readonly bool _hasSetter;

	public bool HasSetter => _hasSetter;

	public ValueTypePropertyAccessor(PropertyInfo propertyInfo)
		: base(propertyInfo)
	{
		MethodInfo setMethod = propertyInfo.GetSetMethod(nonPublic: true);
		_hasSetter = (object)setMethod != null;
		if (_hasSetter)
		{
			_lateBoundPropertySet = setMethod;
		}
	}

	public void SetValue(object destination, object value)
	{
		_lateBoundPropertySet.Invoke(destination, new object[1] { value });
	}
}
