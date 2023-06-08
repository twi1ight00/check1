using System;
using System.Collections.Generic;
using ns56;

namespace ns8;

internal class Class837 : Class836
{
	private Class851 class851_0;

	private Class838 class838_1;

	private Class836 class836_1;

	private Class135 class135_0;

	private Class120 class120_0;

	private Class132 class132_0;

	private Class119 class119_0;

	private Dictionary<Enum305, double> dictionary_0;

	private Dictionary<Enum305, double> dictionary_1;

	private Dictionary<Enum305, double> dictionary_2;

	private Dictionary<Enum305, double> dictionary_3;

	private double double_0 = double.NaN;

	private double double_1 = double.NaN;

	private double double_2;

	public Class836 AssociatedWith => class836_1;

	public Class838 ConnectedWith
	{
		get
		{
			if (class838_1 == null)
			{
				class838_1 = new Class838();
			}
			return class838_1;
		}
	}

	public Class135 LayoutNode => class135_0;

	public Class851 ShapeContainer => class851_0;

	public Class837 Root
	{
		get
		{
			Class837 @class = this;
			while (@class.Parent != null)
			{
				@class = (Class837)@class.Parent;
			}
			return @class;
		}
	}

	public Class120 Algorithm
	{
		get
		{
			return class120_0;
		}
		set
		{
			class120_0 = value;
		}
	}

	public Class132 Constraints
	{
		get
		{
			return class132_0;
		}
		set
		{
			class132_0 = value;
		}
	}

	public Class119 Rules
	{
		get
		{
			return class119_0;
		}
		set
		{
			class119_0 = value;
		}
	}

	public double TextMaxWidth
	{
		get
		{
			double num = method_31(Enum305.const_62);
			if (!double.IsNaN(double_0) && double_0 < num)
			{
				num = double_0;
			}
			return num;
		}
		set
		{
			double_0 = value;
		}
	}

	public double TextMaxHeight
	{
		get
		{
			double num = method_31(Enum305.const_16);
			if (!double.IsNaN(double_1) && double_1 < num)
			{
				num = double_1;
			}
			return num;
		}
		set
		{
			double_1 = value;
		}
	}

	public Class837(Class837 parent, Class135 layoutNode, Class836 associated)
		: base(parent, layoutNode.method_5(associated))
	{
		class836_1 = associated;
		class135_0 = layoutNode;
		class851_0 = new Class851(this);
		class135_0.Points.Add(this);
		dictionary_0 = new Dictionary<Enum305, double>();
		dictionary_1 = new Dictionary<Enum305, double>();
		dictionary_3 = new Dictionary<Enum305, double>();
		dictionary_2 = new Dictionary<Enum305, double>();
	}

	public override void Print(string margin)
	{
		Console.WriteLine(margin + $"{LayoutNode}   W:{ShapeContainer.Width:00} ({method_30(Enum305.const_62):00})    H:{ShapeContainer.Height:00} ({method_30(Enum305.const_16):00})");
		foreach (Class836 child in base.Children)
		{
			_ = child;
		}
	}

	public override void vmethod_0(Class840 connections)
	{
		foreach (Class836 item in ConnectedWith)
		{
			connections.method_0(Enum330.const_2, item.DataPoint, base.DataPoint, class135_0.Tree.Target.LayoutIdInternal);
		}
		foreach (Class836 child in base.Children)
		{
			connections.method_0(Enum330.const_3, base.DataPoint, child.DataPoint, class135_0.Tree.Target.LayoutIdInternal);
			child.vmethod_0(connections);
		}
	}

	public double method_20(Enum305 type)
	{
		if (!dictionary_0.ContainsKey(type))
		{
			return 0.0;
		}
		return dictionary_0[type];
	}

	public void method_21(Enum305 type, double value)
	{
		if (!dictionary_2.ContainsKey(type))
		{
			dictionary_2.Add(type, value);
		}
		else if (Math.Abs(dictionary_2[type]) > Math.Abs(value))
		{
			dictionary_2[type] = value;
		}
		method_22(type, value);
	}

	public void method_22(Enum305 type, double value)
	{
		if (dictionary_2.ContainsKey(type) && Math.Abs(dictionary_2[type]) < Math.Abs(value))
		{
			value = dictionary_2[type];
		}
		if (dictionary_0.ContainsKey(type))
		{
			dictionary_0[type] = value;
		}
		else
		{
			dictionary_0.Add(type, value);
		}
	}

	public bool method_23(Enum305 type)
	{
		return dictionary_0.ContainsKey(type);
	}

	public void method_24(double ratio, params Enum305[] types)
	{
		foreach (Enum305 type in types)
		{
			method_25(ratio, type);
		}
	}

	public void method_25(double ratio, Enum305 type)
	{
		if (ratio >= 1.0)
		{
			return;
		}
		Class105 @class = Algorithm.Parameter as Class105;
		bool flag;
		if (flag = @class != null && Class102.smethod_12(type))
		{
			if (@class.AspectRatio != 0.0)
			{
				method_29(Enum305.const_62, method_30(Enum305.const_62) * ratio);
				method_29(Enum305.const_16, method_30(Enum305.const_16) * ratio);
			}
			else
			{
				method_29(type, method_30(type) * ratio);
			}
		}
		else
		{
			method_29(type, type switch
			{
				Enum305.const_62 => ShapeContainer.Width / base.CustomScale.Dx, 
				Enum305.const_16 => ShapeContainer.Height / base.CustomScale.Dy, 
				_ => method_30(type), 
			} * ratio);
		}
		foreach (Class837 child in base.Children)
		{
			if (flag)
			{
				if (@class.AspectRatio != 0.0)
				{
					child.method_25(ratio, Enum305.const_62);
					child.method_25(ratio, Enum305.const_16);
					continue;
				}
				double num;
				double num2;
				if (type == Enum305.const_62)
				{
					num = Math.Min(ShapeContainer.Width * ratio, dictionary_3[Enum305.const_62]);
					num2 = child.ShapeContainer.Width / child.CustomScale.Dx;
				}
				else
				{
					num = Math.Min(ShapeContainer.Height * ratio, dictionary_3[Enum305.const_16]);
					num2 = child.ShapeContainer.Height / child.CustomScale.Dy;
				}
				double num3 = num / num2;
				if (num3 < 1.0)
				{
					child.method_25(Math.Max(ratio, num3), type);
				}
			}
			else
			{
				child.method_25(ratio, type);
			}
		}
	}

	public void method_26()
	{
		foreach (Class837 child in base.Children)
		{
			child.method_26();
		}
		foreach (Enum305 key in dictionary_3.Keys)
		{
			method_28(key, dictionary_3[key]);
		}
		dictionary_3.Clear();
	}

	public void method_27(Enum305 type, double value)
	{
		if (dictionary_2.ContainsKey(type) && Math.Abs(dictionary_2[type]) < Math.Abs(value))
		{
			value = dictionary_2[type];
		}
		if (!dictionary_1.ContainsKey(type))
		{
			dictionary_1.Add(type, value);
		}
		else
		{
			dictionary_1[type] = value;
		}
	}

	public void method_28(Enum305 type, double value)
	{
		if (!dictionary_2.ContainsKey(type))
		{
			dictionary_2.Add(type, value);
		}
		else if (Math.Abs(dictionary_2[type]) > Math.Abs(value))
		{
			dictionary_2[type] = value;
		}
		method_27(type, value);
	}

	private void method_29(Enum305 type, double value)
	{
		if (!dictionary_3.ContainsKey(type))
		{
			dictionary_3.Add(type, value);
		}
		else
		{
			dictionary_3[type] = value;
		}
	}

	public double method_30(Enum305 type)
	{
		double num = method_32(type);
		switch (type)
		{
		case Enum305.const_62:
			num *= base.CustomScale.Dx;
			break;
		case Enum305.const_16:
			num *= base.CustomScale.Dy;
			break;
		}
		return num;
	}

	public double method_31(Enum305 type)
	{
		if (!dictionary_2.ContainsKey(type))
		{
			return double.MaxValue;
		}
		return dictionary_2[type];
	}

	public double method_32(Enum305 type)
	{
		if (dictionary_1.ContainsKey(type))
		{
			return dictionary_1[type];
		}
		if (dictionary_0.ContainsKey(type))
		{
			return dictionary_0[type];
		}
		if (Class102.smethod_12(type))
		{
			if (type == Enum305.const_62 && ShapeContainer.Width != 0.0)
			{
				return ShapeContainer.Width;
			}
			if (type == Enum305.const_16 && ShapeContainer.Height != 0.0)
			{
				return ShapeContainer.Height;
			}
			Class837 @class = (Class837)base.Parent;
			if (@class.Algorithm is Class121)
			{
				return @class.method_33(type);
			}
			return 0.0;
		}
		return type switch
		{
			Enum305.const_9 => ShapeContainer.method_13(Enum135.const_0) + ShapeContainer.Width / 2.0, 
			Enum305.const_11 => ShapeContainer.method_13(Enum135.const_1) + ShapeContainer.Height / 2.0, 
			Enum305.const_2 => ShapeContainer.method_13(Enum135.const_1) + ShapeContainer.Height, 
			Enum305.const_33 => ShapeContainer.method_13(Enum135.const_1), 
			Enum305.const_25 => ShapeContainer.method_13(Enum135.const_0) + ShapeContainer.Width, 
			Enum305.const_19 => ShapeContainer.method_13(Enum135.const_0), 
			_ => 0.0, 
		};
	}

	public double method_33(Enum305 type)
	{
		if (class120_0.Parameter is Class105 @class && @class.AspectRatio != 0.0 && Class102.smethod_12(type))
		{
			Struct48 @struct = Class102.smethod_11(@class.AspectRatio, method_32(Enum305.const_62), method_32(Enum305.const_16));
			if (type != Enum305.const_62)
			{
				return @struct.Height;
			}
			return @struct.Width;
		}
		return method_32(type);
	}

	public double method_34(Enum305 type)
	{
		double result = double.NaN;
		if (class119_0 != null)
		{
			Class118[] minValues = class119_0.MinValues;
			foreach (Class118 @class in minValues)
			{
				if (@class.Type == type && @class.ForRel == Enum329.const_1)
				{
					return @class.Value;
				}
			}
		}
		return result;
	}

	public double method_35(Class117 constraint)
	{
		double factor = constraint.Factor;
		if (class119_0 != null)
		{
			Class118[] minFactors = class119_0.MinFactors;
			foreach (Class118 @class in minFactors)
			{
				if (@class.ForRel == constraint.ForRel && @class.ForName == constraint.ForName && @class.Type == constraint.Type && constraint.ReferencedForRel != Enum329.const_1 && @class.Factor < factor)
				{
					factor = @class.Factor;
				}
			}
		}
		return factor;
	}

	public List<Class837> method_36(Enum329 forRel, string forName, Enum332 pointType)
	{
		List<Class837> list = new List<Class837>();
		method_50(this, forRel, forName, pointType, list);
		return list;
	}

	public Class837 method_37(string connectedPointId)
	{
		foreach (Class837 child in base.Children)
		{
			foreach (Class836 item in child.ConnectedWith)
			{
				if (item.ModelId == connectedPointId)
				{
					return child;
				}
			}
			Class837 class2 = child.method_37(connectedPointId);
			if (class2 != null)
			{
				return class2;
			}
		}
		return null;
	}

	public Class837 method_38(string name, Class836 assosiated)
	{
		if (LayoutNode.Name == name && (AssociatedWith == assosiated || assosiated == null))
		{
			return this;
		}
		foreach (Class837 child in base.Children)
		{
			Class837 class2 = child.method_38(name, assosiated);
			if (class2 != null)
			{
				return class2;
			}
		}
		return null;
	}

	public List<Class837> method_39()
	{
		List<Class837> list = new List<Class837>();
		foreach (Class837 child in base.Children)
		{
			if (!(child.class120_0 is Class122))
			{
				list.Add(child);
			}
		}
		return list;
	}

	public void method_40()
	{
		double_2 = 0.0;
		ShapeContainer.method_9();
		foreach (Class837 child in base.Children)
		{
			child.method_40();
		}
	}

	public void method_41()
	{
		bool flag = method_47();
		while (!flag && !(double_2 >= 50.0))
		{
			method_46();
			flag = method_47();
			double_2 += 1.0;
		}
	}

	public void method_42()
	{
		foreach (Class837 child in base.Children)
		{
			Struct50 wanted = class120_0.vmethod_5(child);
			if (wanted.Dx != 0.0 || wanted.Dy != 0.0)
			{
				wanted = child.method_52(wanted);
				child.ShapeContainer.method_6(wanted.Dx, wanted.Dy);
				child.ShapeContainer.method_7(wanted.Dx, wanted.Dy);
			}
		}
		foreach (Class837 child2 in base.Children)
		{
			child2.method_42();
		}
	}

	public void method_43()
	{
		class120_0.vmethod_3(this);
		foreach (Class837 child in base.Children)
		{
			child.method_43();
		}
	}

	public void method_44()
	{
		ShapeContainer.method_8();
		foreach (Class837 child in base.Children)
		{
			child.method_44();
		}
	}

	public void method_45()
	{
		method_46();
		method_41();
	}

	private void method_46()
	{
		method_44();
		Stack<Class837> stack = new Stack<Class837>();
		method_51(stack);
		while (stack.Count != 0)
		{
			stack.Pop().method_41();
		}
	}

	private bool method_47()
	{
		class120_0.vmethod_7(this);
		while (!class120_0.method_5(this))
		{
			class120_0.vmethod_9(this);
			method_46();
		}
		if (!class120_0.method_6(this))
		{
			class120_0.vmethod_9(this);
			method_46();
		}
		if (!class120_0.vmethod_9(this))
		{
			method_46();
		}
		bool flag;
		if (flag = (flag = class120_0.vmethod_2(this)) & class120_0.vmethod_9(this))
		{
			flag = class120_0.vmethod_8(this);
		}
		return flag;
	}

	public Enum134 method_48(Class135 layoutNode)
	{
		return layoutNode.method_7(Enum118.const_7, this) switch
		{
			"std" => Enum134.const_3, 
			"r" => Enum134.const_1, 
			"l" => Enum134.const_0, 
			_ => Enum134.const_4, 
		};
	}

	public bool method_49()
	{
		if (class851_0.Shape != null && (class120_0 is Class129 || (class120_0 is Class130 && !class851_0.IsHidden)) && class851_0.Width != 0.0)
		{
			return class851_0.Height != 0.0;
		}
		return false;
	}

	public override string ToString()
	{
		return Algorithm.ToString();
	}

	private void method_50(Class837 root, Enum329 forRel, string forName, Enum332 pointType, List<Class837> output)
	{
		switch (forRel)
		{
		case Enum329.const_1:
			output.Add(root);
			return;
		case Enum329.const_0:
			return;
		}
		foreach (Class837 child in root.Children)
		{
			if (forName == child.LayoutNode.Name)
			{
				output.Add(child);
			}
			else if (string.IsNullOrEmpty(forName))
			{
				bool flag;
				if (!(flag = pointType == Enum332.const_1))
				{
					foreach (Class836 item in child.ConnectedWith)
					{
						if (item.method_1(item.Type, pointType))
						{
							flag = true;
						}
					}
				}
				if (flag)
				{
					output.Add(child);
				}
			}
			if (forRel == Enum329.const_3)
			{
				method_50(child, forRel, forName, pointType, output);
			}
		}
	}

	private void method_51(Stack<Class837> output)
	{
		foreach (Class837 child in base.Children)
		{
			output.Push(child);
		}
		foreach (Class837 child2 in base.Children)
		{
			child2.method_51(output);
		}
	}

	private Struct50 method_52(Struct50 wanted)
	{
		double num = wanted.Dx;
		double num2 = wanted.Dy;
		Struct48 targetSize = LayoutNode.Tree.TargetSize;
		double num3 = ShapeContainer.X + wanted.Dx;
		double num4 = num3 + ShapeContainer.Width;
		if (num3 < 0.0)
		{
			num -= num3;
		}
		else if (num4 > targetSize.Width)
		{
			num -= num4 - targetSize.Width;
		}
		double num5 = ShapeContainer.Y + wanted.Dy;
		double num6 = num5 + ShapeContainer.Height;
		if (num5 < 0.0)
		{
			num2 -= num5;
		}
		else if (num6 > targetSize.Height)
		{
			num2 -= num6 - targetSize.Height;
		}
		return new Struct50(num, num2);
	}
}
