using System;
using System.Collections.Generic;
using ns56;

namespace ns8;

internal class Class117 : Class116, IComparable<Class117>
{
	public Enum305 Type => ConstraintData.Type;

	public Enum329 ForRel => ConstraintData.For;

	public string ForName => ConstraintData.ForName;

	public Enum332 PointType => ConstraintData.PtType;

	public Enum329 ReferencedForRel => ConstraintData.RefFor;

	public Enum305 ReferencedType => ConstraintData.RefType;

	public string ReferencedForName => ConstraintData.RefForName;

	public Enum332 ReferencedPointType => ConstraintData.RefPtType;

	public double Value
	{
		get
		{
			double num = ConstraintData.Val;
			if (Type != Enum305.const_24 && Type != 0)
			{
				num = Class102.smethod_9(num);
			}
			return num;
		}
	}

	public double Factor => ConstraintData.Fact;

	public Enum326 Operator => ConstraintData.Op;

	private Class2156 ConstraintData => (Class2156)base.DataNode;

	public Class117(Class2156 elementData)
	{
	}

	public List<Class837> method_5(Class837 root)
	{
		return root.method_36(ConstraintData.For, ConstraintData.ForName, ConstraintData.PtType);
	}

	public Class837 method_6(Class837 root)
	{
		List<Class837> list = method_7(root);
		if (list.Count > 0)
		{
			return list[0];
		}
		return null;
	}

	public List<Class837> method_7(Class837 root)
	{
		return root.method_36(ConstraintData.RefFor, ConstraintData.RefForName, ConstraintData.RefPtType);
	}

	public override string ToString()
	{
		return string.Format("type='{0}' for='{1}'{2}{3}{4}{5}{6}{7}{8}{9}", Type, ForRel, (ForName != "") ? $" forName='{ForName}'" : "", (PointType != Enum332.const_1) ? $" ptType='{PointType}'" : "", (ReferencedType != Enum305.const_22) ? $" refType='{ReferencedType}'" : "", (ReferencedForRel != Enum329.const_1) ? $" refFor='{ReferencedForRel}'" : "", (ReferencedForName != "") ? $" refForName='{ReferencedForName}'" : "", (ReferencedPointType != Enum332.const_1) ? $" refPtType='{ReferencedPointType}'" : "", (Value != 0.0) ? $" val='{Value}'" : "", (Operator != 0) ? $" op='{Operator}'" : "");
	}

	public int CompareTo(Class117 other)
	{
		int num = smethod_3(this);
		int num2 = smethod_3(other);
		if (num < num2)
		{
			return -1;
		}
		if (num == num2)
		{
			return 0;
		}
		return 1;
	}

	private static int smethod_3(Class117 item)
	{
		return item.Operator switch
		{
			Enum326.const_2 => 1, 
			Enum326.const_3 => 3, 
			Enum326.const_4 => 2, 
			_ => 0, 
		};
	}
}
