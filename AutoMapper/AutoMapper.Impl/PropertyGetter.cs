using System;
using System.Reflection;

namespace AutoMapper.Impl;

public class PropertyGetter : MemberGetter
{
	private readonly PropertyInfo _propertyInfo;

	private readonly string _name;

	private readonly Type _memberType;

	private readonly LateBoundPropertyGet _lateBoundPropertyGet;

	public override MemberInfo MemberInfo => _propertyInfo;

	public override string Name => _name;

	public override Type MemberType => _memberType;

	public PropertyGetter(PropertyInfo propertyInfo)
	{
		_propertyInfo = propertyInfo;
		_name = _propertyInfo.Name;
		_memberType = _propertyInfo.PropertyType;
		if ((object)_propertyInfo.GetGetMethod(nonPublic: true) != null)
		{
			_lateBoundPropertyGet = MemberGetter.DelegateFactory.CreateGet(propertyInfo);
			return;
		}
		_lateBoundPropertyGet = (object src) => null;
	}

	public override object GetValue(object source)
	{
		return _lateBoundPropertyGet(source);
	}

	public override object[] GetCustomAttributes(Type attributeType, bool inherit)
	{
		return _propertyInfo.GetCustomAttributes(attributeType, inherit);
	}

	public override object[] GetCustomAttributes(bool inherit)
	{
		return _propertyInfo.GetCustomAttributes(inherit);
	}

	public override bool IsDefined(Type attributeType, bool inherit)
	{
		return _propertyInfo.IsDefined(attributeType, inherit);
	}

	public bool Equals(PropertyGetter other)
	{
		if (object.ReferenceEquals(null, other))
		{
			return false;
		}
		if (object.ReferenceEquals(this, other))
		{
			return true;
		}
		return object.Equals(other._propertyInfo, _propertyInfo);
	}

	public override bool Equals(object obj)
	{
		if (object.ReferenceEquals(null, obj))
		{
			return false;
		}
		if (object.ReferenceEquals(this, obj))
		{
			return true;
		}
		if ((object)obj.GetType() != typeof(PropertyGetter))
		{
			return false;
		}
		return Equals((PropertyGetter)obj);
	}

	public override int GetHashCode()
	{
		return _propertyInfo.GetHashCode();
	}
}
