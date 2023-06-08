using System;
using System.Collections;
using System.Drawing;
using System.Runtime.CompilerServices;
using ns3;

namespace ns31;

internal class Class800 : Interface19
{
	private Class806 class806_0;

	private Class810 class810_0;

	private double double_0;

	private Enum68 enum68_0;

	private IList ilist_0 = new ArrayList();

	private IList ilist_1 = new ArrayList();

	private Enum69 enum69_0;

	private bool bool_0;

	private bool bool_1 = true;

	internal IList ilist_2 = new ArrayList();

	public Interface25 Border => class806_0;

	public double Amount
	{
		get
		{
			return double_0;
		}
		set
		{
			double_0 = value;
		}
	}

	public Enum68 DisplayType
	{
		get
		{
			return enum68_0;
		}
		set
		{
			enum68_0 = value;
		}
	}

	public Enum69 Type
	{
		get
		{
			return enum69_0;
		}
		set
		{
			enum69_0 = value;
		}
	}

	public IList MinusValue => ilist_0;

	public IList PlusValue => ilist_1;

	public bool ShowMarkerTTop => bool_1;

	internal void method_0(PointF pointF_0, float float_0, float float_1)
	{
		Struct16 @struct = new Struct16(pointF_0, float_0, float_1);
		ilist_2.Add(@struct);
	}

	public Class800(Class787 class787_0, Class810 class810_1)
	{
		class806_0 = new Class806(class787_0);
		class810_0 = class810_1;
		double_0 = 0.0;
		enum68_0 = Enum68.const_2;
		enum69_0 = Enum69.const_1;
		bool_0 = true;
	}

	[SpecialName]
	internal Class806 method_1()
	{
		return class806_0;
	}

	[SpecialName]
	public bool vmethod_0()
	{
		return bool_0;
	}

	[SpecialName]
	public void imethod_0(bool bool_2)
	{
		bool_0 = bool_2;
	}

	public void imethod_1(object[] object_0)
	{
		foreach (object value in object_0)
		{
			ilist_0.Add(value);
		}
	}

	public void imethod_2(object[] object_0)
	{
		foreach (object value in object_0)
		{
			ilist_1.Add(value);
		}
	}

	internal double method_2(object object_0)
	{
		if (object_0 == null)
		{
			return 0.0;
		}
		TypeCode typeCode = System.Type.GetTypeCode(object_0.GetType());
		if (typeCode != TypeCode.Boolean && typeCode != TypeCode.Int32 && typeCode != TypeCode.Double)
		{
			return 0.0;
		}
		return Convert.ToDouble(object_0);
	}
}
