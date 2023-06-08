using System;
using System.Collections;
using System.Drawing;
using System.Runtime.CompilerServices;
using ns3;

namespace ns33;

internal class Class834 : Interface19
{
	private Class844 class844_0;

	private double double_0;

	private Enum68 enum68_0;

	private IList ilist_0 = new ArrayList();

	private IList ilist_1 = new ArrayList();

	private Enum69 enum69_0;

	private bool bool_0;

	private bool bool_1 = true;

	private Class840 class840_0;

	internal IList ilist_2 = new ArrayList();

	public Interface25 Border => class840_0;

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
		Struct42 @struct = new Struct42(pointF_0, float_0, float_1);
		ilist_2.Add(@struct);
	}

	public Class834(Class821 class821_0, Class844 class844_1)
	{
		class840_0 = new Class840(class821_0, Enum57.const_18);
		class844_0 = class844_1;
		double_0 = 0.0;
		enum68_0 = Enum68.const_2;
		enum69_0 = Enum69.const_1;
		bool_0 = true;
	}

	[SpecialName]
	internal Class840 method_1()
	{
		return class840_0;
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
