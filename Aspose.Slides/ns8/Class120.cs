using System;
using System.Collections.Generic;
using Aspose.Slides;
using ns56;

namespace ns8;

internal abstract class Class120 : Class116
{
	private Class103 class103_0;

	private List<Class837> list_0;

	private Class135 class135_0;

	public Class103 Parameter => class103_0;

	public virtual bool HideLastTransition => false;

	public virtual bool IsTwoDimensionShape => true;

	public Class135 LayoutNode
	{
		get
		{
			if (class135_0 == null)
			{
				class135_0 = method_3<Class135>();
			}
			return class135_0;
		}
	}

	public List<Class837> Points
	{
		get
		{
			if (list_0 == null)
			{
				list_0 = new List<Class837>();
			}
			return list_0;
		}
	}

	public static Class120 smethod_3(Class2146 diagramNode)
	{
		Class120 @class = diagramNode.Type switch
		{
			Enum306.const_0 => new Class121(), 
			Enum306.const_1 => new Class122(), 
			Enum306.const_2 => new Class123(), 
			Enum306.const_3 => new Class124(), 
			Enum306.const_4 => new Class125(), 
			Enum306.const_5 => new Class126(), 
			Enum306.const_6 => new Class127(), 
			Enum306.const_7 => new Class128(), 
			Enum306.const_8 => new Class130(), 
			Enum306.const_9 => new Class129(), 
			_ => throw new PptxException("Unsuppotred SmartArt layout algorithm"), 
		};
		@class.class103_0 = Class103.smethod_0(diagramNode);
		return @class;
	}

	public abstract bool vmethod_2(Class837 point);

	public virtual void vmethod_3(Class837 point)
	{
	}

	public virtual bool vmethod_4(Class837 rootPresOf, Struct48 canvasSize)
	{
		double num = canvasSize.Width / rootPresOf.ShapeContainer.Width;
		double num2 = canvasSize.Height / rootPresOf.ShapeContainer.Height;
		foreach (Class837 child in rootPresOf.Children)
		{
			if (smethod_4(num))
			{
				child.method_25(Math.Min(1.0, num), Enum305.const_62);
			}
			if (smethod_4(num2))
			{
				child.method_25(Math.Min(1.0, num2), Enum305.const_16);
			}
		}
		if (!smethod_4(num))
		{
			return smethod_4(num2);
		}
		return true;
	}

	public virtual Struct50 vmethod_5(Class837 childNode)
	{
		Struct50 @struct = Struct50.smethod_4(childNode.CustomLinearFactor, childNode.CustomNeighborLinearFactor);
		Struct50 customScale = childNode.CustomScale;
		return new Struct50(@struct.Dx * (childNode.ShapeContainer.Width / customScale.Dx), @struct.Dy * (childNode.ShapeContainer.Height / customScale.Dy));
	}

	public virtual bool vmethod_6(Enum305 type)
	{
		return false;
	}

	public virtual void vmethod_7(Class837 point)
	{
		if (point.Constraints == null)
		{
			return;
		}
		Class117[] forSelfFromSelf = point.Constraints.ForSelfFromSelf;
		foreach (Class117 @class in forSelfFromSelf)
		{
			double num = point.method_35(@class);
			double num2 = point.method_32(@class.ReferencedType) * num;
			double second = point.method_20(@class.ReferencedType) * num;
			if (smethod_5(num2, second))
			{
				point.method_27(@class.Type, num2);
			}
		}
	}

	public virtual bool vmethod_8(Class837 point)
	{
		bool flag = true;
		if (point.Constraints != null)
		{
			Class117[] forSelfFromChildren = point.Constraints.ForSelfFromChildren;
			foreach (Class117 @class in forSelfFromChildren)
			{
				Class837 class2 = @class.method_6(point);
				if (class2 == null || !smethod_9(class2))
				{
					continue;
				}
				double num = point.method_35(@class);
				double num2 = class2.method_33(@class.ReferencedType) * num;
				double second = class2.method_20(@class.ReferencedType) * num;
				if (smethod_5(num2, second))
				{
					double second2 = point.method_32(@class.Type);
					if (@class.Operator == Enum326.const_2 && smethod_5(num2, second2) && vmethod_6(@class.Type))
					{
						point.method_27(@class.Type, num2);
						flag &= point.method_32(@class.Type) != num2;
					}
				}
			}
		}
		return flag;
	}

	public virtual bool vmethod_9(Class837 point)
	{
		bool flag = true;
		if (point.Constraints != null)
		{
			Class114 @class = new Class114();
			Class117[] forChildren = point.Constraints.ForChildren;
			foreach (Class117 class2 in forChildren)
			{
				Class837 class3 = class2.method_6(point);
				if (class3 == null || !smethod_9(class3))
				{
					continue;
				}
				List<Class837> list = class2.method_5(point);
				foreach (Class837 item in list)
				{
					double num = point.method_35(class2);
					double num2 = class3.method_32(class2.ReferencedType) * num;
					double second = class3.method_20(class2.ReferencedType) * num;
					if (!smethod_5(num2, second))
					{
						continue;
					}
					double num3 = item.method_32(class2.Type);
					if (!smethod_5(num2, num3))
					{
						continue;
					}
					Class115 class4 = @class.method_0(item, class2.Type);
					bool flag2 = true;
					switch (class2.Operator)
					{
					default:
						if (class2.ReferencedForRel != Enum329.const_1 && (Math.Abs(num3) > Math.Abs(num2) || num3 == 0.0))
						{
							class4.method_2(num2);
							flag2 = true;
						}
						break;
					case Enum326.const_2:
						if (class3 != item)
						{
							class4.method_2(num2);
							flag2 = true;
						}
						break;
					case Enum326.const_3:
						if (num3 < num2)
						{
							flag2 = true;
						}
						class4.method_0(num2);
						break;
					case Enum326.const_4:
						if (num3 > num2)
						{
							flag2 = true;
						}
						class4.method_1(num2);
						break;
					}
					if (flag2 && class4.Value == num2)
					{
						item.method_27(class2.Type, class4.Value);
						flag &= item.method_32(class2.Type) != num2;
					}
				}
			}
		}
		return flag;
	}

	public bool method_5(Class837 point)
	{
		bool flag = true;
		if (point.Rules != null)
		{
			Class118[] minValues = point.Rules.MinValues;
			foreach (Class118 @class in minValues)
			{
				if (@class.Type != Enum305.const_23)
				{
					continue;
				}
				List<Class837> list = @class.method_5(point);
				foreach (Class837 item in list)
				{
					if (!(item.Algorithm is Class129 class2))
					{
						continue;
					}
					Class129.Struct53 @struct = class2.method_8(item, @class.Value, @class.Value);
					bool flag2 = !@struct.InvalidateAny;
					if (@struct.InvalidateAny)
					{
						Class129.Struct52 struct2 = Class129.smethod_13(item);
						if (@struct.bool_0 && struct2.Primary > 1.0)
						{
							item.method_28(Enum305.const_23, Class102.smethod_9(struct2.Primary - 1.0));
						}
						else if (@struct.bool_1 && struct2.Secondary > 1.0)
						{
							item.method_28(Enum305.const_28, Class102.smethod_9(struct2.Secondary - 1.0));
						}
						@struct = class2.method_8(item, @class.Value, @class.Value);
					}
					flag = flag && flag2;
				}
			}
		}
		return flag;
	}

	public bool method_6(Class837 point)
	{
		bool result = true;
		if (point.Constraints != null)
		{
			Class117[] equalizers = point.Constraints.Equalizers;
			foreach (Class117 @class in equalizers)
			{
				if (@class.Type != Enum305.const_23)
				{
					continue;
				}
				double num = double.NaN;
				List<Class837> list = @class.method_5(point);
				foreach (Class837 item in list)
				{
					if (item.Algorithm is Class129 && item.ShapeContainer.HasText)
					{
						double num2 = item.method_32(@class.Type);
						if (double.IsNaN(num) || num > num2)
						{
							num = num2;
						}
					}
				}
				if (double.IsNaN(num))
				{
					continue;
				}
				foreach (Class837 item2 in list)
				{
					if (item2.Algorithm is Class129 && item2.ShapeContainer.HasText)
					{
						double num3 = item2.method_32(@class.Type);
						if (num < num3 && smethod_5(num3, num))
						{
							item2.method_27(@class.Type, num);
							result = false;
						}
					}
				}
			}
		}
		return result;
	}

	private double method_7(Class837 refPoint, Class117 constraint)
	{
		if (!Class102.smethod_12(constraint.Type) && Class102.smethod_12(constraint.ReferencedType))
		{
			double result = ((refPoint.ShapeContainer.Width != 0.0) ? refPoint.ShapeContainer.Width : refPoint.method_32(Enum305.const_62));
			double result2 = ((refPoint.ShapeContainer.Height != 0.0) ? refPoint.ShapeContainer.Height : refPoint.method_32(Enum305.const_16));
			if (constraint.ReferencedType != Enum305.const_62)
			{
				return result2;
			}
			return result;
		}
		return refPoint.method_32(constraint.ReferencedType);
	}

	public override string ToString()
	{
		string text = ((LayoutNode != null) ? LayoutNode.Name : string.Empty);
		return GetType().Name + " - " + text;
	}

	protected static bool smethod_4(double ratio)
	{
		return ratio < 0.9999;
	}

	protected static bool smethod_5(double first, double second)
	{
		if (first == 0.0 && second == 0.0)
		{
			return false;
		}
		first = Math.Abs(first);
		second = Math.Abs(second);
		return smethod_4(Math.Min(first, second) / Math.Max(first, second));
	}

	protected static Struct50 smethod_6(Struct48 available, Struct48 actual, Enum120 horizontalAlignment, Enum121 verticalAlignment)
	{
		double dx = 0.0;
		double dy = 0.0;
		if (available.Width > actual.Width)
		{
			switch (horizontalAlignment)
			{
			case Enum120.const_2:
				dx = (available.Width - actual.Width) / 2.0;
				break;
			case Enum120.const_3:
				dx = available.Width - actual.Width;
				break;
			}
		}
		if (available.Height > actual.Height)
		{
			switch (verticalAlignment)
			{
			case Enum121.const_2:
				dy = (available.Height - actual.Height) / 2.0;
				break;
			case Enum121.const_3:
				dy = available.Height - actual.Height;
				break;
			}
		}
		return new Struct50(dx, dy);
	}

	protected static Struct50 smethod_7(Class837 point, Enum120 horizontalAlignment, Enum121 verticalAlignment)
	{
		Struct48 actual = new Struct48(point.ShapeContainer.Width, point.ShapeContainer.Height);
		Struct48 available = new Struct48(point.ShapeContainer.AvailableWidth, point.ShapeContainer.AvailableHeight);
		return smethod_6(available, actual, horizontalAlignment, verticalAlignment);
	}

	protected static void smethod_8(Class837 container, Enum120 horizontalAlignment, Enum121 verticalAlignment)
	{
		Struct50 @struct = smethod_7(container, horizontalAlignment, verticalAlignment);
		container.ShapeContainer.method_5(@struct.Dx, @struct.Dy);
	}

	private static bool smethod_9(Class837 point)
	{
		if (point.method_49())
		{
			return true;
		}
		if (point.Children.Count > 0 && point.ShapeContainer.Width != 0.0)
		{
			return point.ShapeContainer.Height != 0.0;
		}
		return false;
	}
}
