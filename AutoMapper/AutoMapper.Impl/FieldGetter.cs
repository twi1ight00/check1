using System;
using System.Reflection;

namespace AutoMapper.Impl;

public class FieldGetter : MemberGetter
{
	private readonly FieldInfo _fieldInfo;

	private readonly string _name;

	private readonly Type _memberType;

	private readonly LateBoundFieldGet _lateBoundFieldGet;

	public override MemberInfo MemberInfo => _fieldInfo;

	public override string Name => _name;

	public override Type MemberType => _memberType;

	public FieldGetter(FieldInfo fieldInfo)
	{
		_fieldInfo = fieldInfo;
		_name = fieldInfo.Name;
		_memberType = fieldInfo.FieldType;
		_lateBoundFieldGet = MemberGetter.DelegateFactory.CreateGet(fieldInfo);
	}

	public override object GetValue(object source)
	{
		return _lateBoundFieldGet(source);
	}

	public bool Equals(FieldGetter other)
	{
		if (object.ReferenceEquals(null, other))
		{
			return false;
		}
		if (object.ReferenceEquals(this, other))
		{
			return true;
		}
		return object.Equals(other._fieldInfo, _fieldInfo);
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
		if ((object)obj.GetType() != typeof(FieldGetter))
		{
			return false;
		}
		return Equals((FieldGetter)obj);
	}

	public override int GetHashCode()
	{
		return _fieldInfo.GetHashCode();
	}

	public override object[] GetCustomAttributes(Type attributeType, bool inherit)
	{
		return _fieldInfo.GetCustomAttributes(attributeType, inherit);
	}

	public override object[] GetCustomAttributes(bool inherit)
	{
		return _fieldInfo.GetCustomAttributes(inherit);
	}

	public override bool IsDefined(Type attributeType, bool inherit)
	{
		return _fieldInfo.IsDefined(attributeType, inherit);
	}
}
