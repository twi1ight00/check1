using System.Reflection;

namespace AutoMapper.Impl;

public class PropertyAccessor : PropertyGetter, IMemberAccessor, IMemberGetter, IMemberResolver, IValueResolver
{
	private readonly LateBoundPropertySet _lateBoundPropertySet;

	private readonly bool _hasSetter;

	public bool HasSetter => _hasSetter;

	public PropertyAccessor(PropertyInfo propertyInfo)
		: base(propertyInfo)
	{
		_hasSetter = (object)propertyInfo.GetSetMethod(nonPublic: true) != null;
		if (_hasSetter)
		{
			_lateBoundPropertySet = MemberGetter.DelegateFactory.CreateSet(propertyInfo);
		}
	}

	public virtual void SetValue(object destination, object value)
	{
		_lateBoundPropertySet(destination, value);
	}
}
