using System;

namespace ns322;

internal class Class7378 : Class7361
{
	private object object_0;

	private TypeCode typeCode_0;

	public object Value => object_0;

	public TypeCode TypeCode => typeCode_0;

	public override void vmethod_0(Interface395 visitor)
	{
		visitor.imethod_33(this);
	}

	public override string ToString()
	{
		return Value.ToString();
	}

	public Class7378(object value, TypeCode typeCode)
	{
		object_0 = value;
		typeCode_0 = typeCode;
	}
}
