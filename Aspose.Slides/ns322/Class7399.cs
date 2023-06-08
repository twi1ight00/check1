using System;

namespace ns322;

internal class Class7399 : Class7398
{
	private object object_0;

	public override string _Class => "Object";

	public override string Type => "object";

	public override object Value
	{
		get
		{
			return object_0;
		}
		set
		{
			object_0 = value;
		}
	}

	public override Class7397 vmethod_0(Class7397 index)
	{
		return this[index];
	}

	internal override Class7397 vmethod_1(Interface401 global)
	{
		if (Value != null && !(Value is IComparable))
		{
			return global.StringClass.method_5(Value.ToString());
		}
		switch (Convert.GetTypeCode(Value))
		{
		case TypeCode.Boolean:
			return global.BooleanClass.method_4((bool)Value);
		case TypeCode.SByte:
		case TypeCode.Byte:
		case TypeCode.Int16:
		case TypeCode.UInt16:
		case TypeCode.Int32:
		case TypeCode.UInt32:
		case TypeCode.Int64:
		case TypeCode.UInt64:
		case TypeCode.Single:
		case TypeCode.Double:
		case TypeCode.Decimal:
			return global.NumberClass.method_4(Convert.ToDouble(Value));
		case TypeCode.DateTime:
			return global.DateClass.method_5((DateTime)Value);
		default:
			return Class7437.class7437_0;
		case TypeCode.Object:
		case TypeCode.Char:
		case TypeCode.String:
			return global.StringClass.method_5(Value.ToString());
		}
	}

	public override bool vmethod_2()
	{
		if (Value != null && !(Value is IConvertible))
		{
			return true;
		}
		switch (Convert.GetTypeCode(Value))
		{
		case TypeCode.Object:
			return Convert.ToBoolean(Value);
		case TypeCode.Boolean:
			return (bool)Value;
		case TypeCode.SByte:
		case TypeCode.Byte:
		case TypeCode.Int16:
		case TypeCode.UInt16:
		case TypeCode.Int32:
		case TypeCode.UInt32:
		case TypeCode.Int64:
		case TypeCode.UInt64:
		case TypeCode.Single:
		case TypeCode.Double:
		case TypeCode.Decimal:
			return Class7434.smethod_0(Convert.ToDouble(Value));
		case TypeCode.DateTime:
			return Class7434.smethod_0(Class7429.smethod_0((DateTime)Value));
		default:
			return true;
		case TypeCode.Char:
		case TypeCode.String:
			return Class7436.smethod_0((string)Value);
		}
	}

	public override double vmethod_3()
	{
		if (Value == null)
		{
			return 0.0;
		}
		if (!(Value is IConvertible))
		{
			return double.NaN;
		}
		switch (Convert.GetTypeCode(Value))
		{
		case TypeCode.DateTime:
			return Class7429.smethod_0((DateTime)Value);
		default:
			return Convert.ToDouble(Value);
		case TypeCode.Boolean:
			return Class7428.smethod_0((bool)Value);
		case TypeCode.Char:
		case TypeCode.String:
			return Class7436.smethod_1((string)Value);
		}
	}

	public override string ToString()
	{
		if (object_0 == null)
		{
			return null;
		}
		if (object_0 is IConvertible)
		{
			return Convert.ToString(Value);
		}
		return object_0.ToString();
	}

	public Class7399()
	{
	}

	public Class7399(object value, Class7399 prototype)
		: base(prototype)
	{
		object_0 = value;
	}

	public Class7399(Class7399 prototype)
		: base(prototype)
	{
	}
}
