using System;
using System.Reflection;

namespace AutoMapper.Impl;

public class MethodGetter : MemberGetter
{
	private readonly MethodInfo _methodInfo;

	private readonly string _name;

	private readonly Type _memberType;

	private readonly LateBoundMethod _lateBoundMethod;

	public override MemberInfo MemberInfo => _methodInfo;

	public override string Name => _name;

	public override Type MemberType => _memberType;

	public MethodGetter(MethodInfo methodInfo)
	{
		_methodInfo = methodInfo;
		_name = _methodInfo.Name;
		_memberType = _methodInfo.ReturnType;
		_lateBoundMethod = MemberGetter.DelegateFactory.CreateGet(methodInfo);
	}

	public override object GetValue(object source)
	{
		if ((object)_memberType != null)
		{
			return _lateBoundMethod(source, new object[0]);
		}
		return null;
	}

	public override object[] GetCustomAttributes(Type attributeType, bool inherit)
	{
		return _methodInfo.GetCustomAttributes(attributeType, inherit);
	}

	public override object[] GetCustomAttributes(bool inherit)
	{
		return _methodInfo.GetCustomAttributes(inherit);
	}

	public override bool IsDefined(Type attributeType, bool inherit)
	{
		return _methodInfo.IsDefined(attributeType, inherit);
	}

	public bool Equals(MethodGetter other)
	{
		if (object.ReferenceEquals(null, other))
		{
			return false;
		}
		if (object.ReferenceEquals(this, other))
		{
			return true;
		}
		return object.Equals(other._methodInfo, _methodInfo);
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
		if ((object)obj.GetType() != typeof(MethodGetter))
		{
			return false;
		}
		return Equals((MethodGetter)obj);
	}

	public override int GetHashCode()
	{
		return _methodInfo.GetHashCode();
	}
}
