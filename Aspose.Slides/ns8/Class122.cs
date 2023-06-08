using System;
using System.Collections.Generic;
using Aspose.Slides;
using ns56;

namespace ns8;

internal class Class122 : Class120
{
	public override bool IsTwoDimensionShape => ConnectorParameter.Dimension == Enum124.const_1;

	private Class106 ConnectorParameter => (Class106)base.Parameter;

	public override bool vmethod_2(Class837 point)
	{
		point.ShapeContainer.Width = point.method_30(Enum305.const_62);
		point.ShapeContainer.Height = point.method_30(Enum305.const_16);
		return true;
	}

	public override void vmethod_3(Class837 point)
	{
		Class851[] array = method_11(point);
		Class851 @class = array[0];
		Class851 class2 = array[1];
		if (@class != null && class2 != null)
		{
			Struct47 @struct = method_8(point, @class, class2);
			point.method_28(Enum305.const_8, @struct.Distance);
			vmethod_7(point);
			double num = (point.method_23(Enum305.const_4) ? point.method_30(Enum305.const_4) : (@struct.Distance * 0.22));
			double num2 = (point.method_23(Enum305.const_15) ? point.method_30(Enum305.const_15) : (@struct.Distance * 0.25));
			GeometryShape autoShapeInternal = point.ShapeContainer.Shape.AutoShapeInternal;
			point.ShapeContainer.method_11(0.0);
			autoShapeInternal.RawFrameImpl.FlipH = NullableBool.NotDefined;
			autoShapeInternal.RawFrameImpl.FlipV = NullableBool.NotDefined;
			Class842 arrow = method_15(point, @struct, num, num2);
			Struct50 struct2 = Struct50.smethod_4(point.CustomLinearFactor, point.CustomNeighborLinearFactor);
			if (ConnectorParameter.Routing != 0 && ConnectorParameter.Routing != Enum125.const_1)
			{
				if (ConnectorParameter.Routing != Enum125.const_2 && ConnectorParameter.Routing != Enum125.const_3)
				{
					return;
				}
				double num3 = (point.method_23(Enum305.const_13) ? point.method_30(Enum305.const_13) : @struct.Distance);
				Struct45 arc = new Struct45(num3, @struct, num, num2, ConnectorParameter.Routing == Enum125.const_3);
				point.ShapeContainer.X = arc.Left;
				point.ShapeContainer.Y = arc.Top;
				point.ShapeContainer.Width = arc.Diameter;
				point.ShapeContainer.Height = arc.Diameter;
				if (ConnectorParameter.Dimension == Enum124.const_0)
				{
					autoShapeInternal.ShapeType = ShapeType.CurvedArc;
					autoShapeInternal.Adjustments[0].AngleValue = (float)arc.StartAngle;
					autoShapeInternal.Adjustments[1].AngleValue = (float)arc.EndAngle;
					if ((num3 > 0.0) ? ConnectorParameter.HasBeginningArrowhead : ConnectorParameter.HasEndingArrowhead)
					{
						point.ShapeContainer.BeginArrowheadStyle = LineArrowheadStyle.Open;
					}
					if ((num3 > 0.0) ? ConnectorParameter.HasEndingArrowhead : ConnectorParameter.HasBeginningArrowhead)
					{
						point.ShapeContainer.EndArrowheadStyle = LineArrowheadStyle.Open;
					}
				}
				else
				{
					Class843.smethod_1(autoShapeInternal, arc, arrow);
				}
				double diffX = struct2.Dx * point.ShapeContainer.Width;
				double diffY = struct2.Dy * point.ShapeContainer.Height;
				point.ShapeContainer.method_6(diffX, diffY);
				point.ShapeContainer.method_7(diffX, diffY);
				return;
			}
			point.ShapeContainer.X = @struct.X;
			point.ShapeContainer.Y = @struct.Y;
			Struct46[] array2;
			if (ConnectorParameter.Dimension == Enum124.const_1)
			{
				array2 = ((ConnectorParameter.Routing == Enum125.const_0) ? Class843.smethod_3(@struct, arrow) : new Struct46[1] { default(Struct46) });
			}
			else
			{
				array2 = ((ConnectorParameter.Routing != 0) ? Class843.smethod_2(point, @struct, @class, class2, ConnectorParameter.BendPoint) : new Struct46[2]
				{
					new Struct46(@struct.StartX, @struct.StartY),
					new Struct46(@struct.EndX, @struct.EndY)
				});
				Struct47 struct3 = new Struct47(array2[0].X, array2[0].Y, array2[1].X, array2[1].Y);
				Struct50 norm = struct3.Norm;
				ref Struct46 reference = ref array2[0];
				reference = new Struct46(array2[0].X - norm.Dx * Math.Min(num, struct3.Distance), array2[0].Y - norm.Dy * Math.Min(num, struct3.Distance));
				int num4 = array2.Length - 1;
				Struct47 struct4 = new Struct47(array2[num4].X, array2[num4].Y, array2[num4 - 1].X, array2[num4 - 1].Y);
				Struct50 norm2 = struct4.Norm;
				ref Struct46 reference2 = ref array2[num4];
				reference2 = new Struct46(array2[num4].X - norm2.Dx * Math.Min(num2, struct4.Distance), array2[num4].Y - norm2.Dy * Math.Min(num2, struct4.Distance));
				if (ConnectorParameter.HasBeginningArrowhead)
				{
					point.ShapeContainer.BeginArrowheadStyle = LineArrowheadStyle.Open;
				}
				if (ConnectorParameter.HasEndingArrowhead)
				{
					point.ShapeContainer.EndArrowheadStyle = LineArrowheadStyle.Open;
				}
			}
			Struct47 struct5 = Class843.smethod_4(array2);
			point.ShapeContainer.Width = struct5.Width;
			point.ShapeContainer.Height = struct5.Height;
			Class843.smethod_0(autoShapeInternal, new Struct46(@struct.X, @struct.Y), array2);
			double diffX2 = struct2.Dx * struct5.Width;
			double diffY2 = struct2.Dy * struct5.Height;
			point.ShapeContainer.method_6(diffX2, diffY2);
			point.ShapeContainer.method_7(diffX2, diffY2);
		}
		else
		{
			point.ShapeContainer.Shape.AutoShapeInternal.Hidden = true;
		}
	}

	public override Struct50 vmethod_5(Class837 childNode)
	{
		return default(Struct50);
	}

	private Struct47 method_8(Class837 point, Class851 source, Class851 target)
	{
		Struct47 result = new Struct47(0.0, 0.0, double.MaxValue, double.MaxValue);
		Enum123[] beginningPoints = ConnectorParameter.BeginningPoints;
		foreach (Enum123 sourceType in beginningPoints)
		{
			Enum123[] endPoints = ConnectorParameter.EndPoints;
			foreach (Enum123 targetType in endPoints)
			{
				Struct47 @struct = method_9(point, source, target, sourceType, targetType);
				if (@struct.Distance < result.Distance)
				{
					result = @struct;
				}
			}
		}
		return result;
	}

	private Struct47 method_9(Class837 point, Class851 source, Class851 target, Enum123 sourceType, Enum123 targetType)
	{
		if (sourceType == Enum123.const_10 && targetType == Enum123.const_10)
		{
			Class851 shapeContainer = source.Target.Root.ShapeContainer;
			Struct47 @struct = new Struct47(shapeContainer.X, shapeContainer.Y, shapeContainer.X + shapeContainer.Width, shapeContainer.Y + shapeContainer.Height);
			double num = (point.method_23(Enum305.const_13) ? point.method_30(Enum305.const_13) : @struct.Distance);
			Struct46 center = Class851.smethod_0(source).Center;
			Struct46 center2 = Class851.smethod_0(target).Center;
			double angleInDegrees = new Struct47(@struct.Center, center).AngleInDegrees;
			double angleInDegrees2 = new Struct47(@struct.Center, center2).AngleInDegrees;
			double num2 = angleInDegrees2 - angleInDegrees;
			if (num2 < 0.0)
			{
				num2 = 360.0 + num2;
			}
			double num3 = 360.0 - angleInDegrees;
			angleInDegrees2 = num2 % 360.0;
			List<Struct46> list = method_16(@struct.Center, num / 2.0, Class851.smethod_0(source));
			List<Struct46> list2 = method_16(@struct.Center, num / 2.0, Class851.smethod_0(target));
			Struct46 struct2 = method_10(point, source, Enum123.const_4, new Struct46(target.X + target.Width / 2.0, target.Y + target.Height / 2.0));
			Struct46 struct3 = method_10(point, target, Enum123.const_4, new Struct46(source.X + source.Width / 2.0, source.Y + source.Height / 2.0));
			if (source.Target.DataPoint.PropertySet.CustRadScaleInc == 0 && source.Target.DataPoint.PropertySet.CustRadScaleRad == 0 && target.Target.DataPoint.PropertySet.CustRadScaleInc == 0 && target.Target.DataPoint.PropertySet.CustRadScaleRad == 0)
			{
				foreach (Struct46 item in list)
				{
					double num4 = (new Struct47(@struct.Center, item).AngleInDegrees + num3) % 360.0;
					if (angleInDegrees2 - num4 > -9.999999747378752E-06 && !(num4 < -9.999999747378752E-06))
					{
						struct2 = item;
						break;
					}
				}
				foreach (Struct46 item2 in list2)
				{
					double num5 = (new Struct47(@struct.Center, item2).AngleInDegrees + num3) % 360.0;
					if (angleInDegrees2 - num5 > -9.999999747378752E-06 && !(num5 < -9.999999747378752E-06))
					{
						struct3 = item2;
						break;
					}
				}
			}
			return new Struct47(struct2.X, struct2.Y, struct3.X, struct3.Y);
		}
		Struct46 target2 = method_10(point, source, sourceType, new Struct46(target.X + target.Width / 2.0, target.Y + target.Height / 2.0));
		Struct46 target3 = method_10(point, target, targetType, new Struct46(source.X + source.Width / 2.0, source.Y + source.Height / 2.0));
		Struct46 struct4 = method_10(point, source, sourceType, target3);
		Struct46 struct5 = method_10(point, target, targetType, target2);
		return new Struct47(struct4.X, struct4.Y, struct5.X, struct5.Y);
	}

	private Struct46 method_10(Class837 point, Class851 source, Enum123 type, Struct46 target)
	{
		switch (type)
		{
		default:
			return default(Struct46);
		case Enum123.const_0:
			if (source.Shape != null && source.Shape.ShapeType == ShapeType.Ellipse)
			{
				return Class102.smethod_18(Class851.smethod_0(source), target);
			}
			return Class102.smethod_17(Class851.smethod_0(source), target);
		case Enum123.const_1:
			return new Struct46(source.X + source.Width / 2.0, source.Y + source.Height);
		case Enum123.const_2:
			return new Struct46(source.X, source.Y + source.Height);
		case Enum123.const_3:
			return new Struct46(source.X + source.Width, source.Y + source.Height);
		case Enum123.const_4:
			return new Struct46(source.X + source.Width / 2.0, source.Y + source.Height / 2.0);
		case Enum123.const_5:
			return new Struct46(source.X, source.Y + source.Height / 2.0);
		case Enum123.const_6:
			return new Struct46(source.X + source.Width, source.Y + source.Height / 2.0);
		case Enum123.const_7:
			return new Struct46(source.X + source.Width / 2.0, source.Y);
		case Enum123.const_8:
			return new Struct46(source.X, source.Y);
		case Enum123.const_9:
			return new Struct46(source.X + source.Width, source.Y);
		}
	}

	private Class851[] method_11(Class837 point)
	{
		Class851 @class = null;
		Class851 class2 = null;
		if (!string.IsNullOrEmpty(ConnectorParameter.SourceNode))
		{
			Class837 class3 = method_14(point, ConnectorParameter.SourceNode);
			if (class3 != null)
			{
				@class = class3.ShapeContainer;
			}
		}
		if (@class == null && point.AssociatedWith.Type == Enum337.const_5)
		{
			@class = ((point.AssociatedWith.Parent.Type != Enum337.const_3) ? point.Root.method_37(point.AssociatedWith.Parent.ModelId).ShapeContainer : point.Root.ShapeContainer);
		}
		if (@class == null)
		{
			Class836 class4 = point.AssociatedWith.method_2();
			Class837 class5 = (Class837)point.Previous;
			if (class5 == null && point.Parent != null)
			{
				class5 = (Class837)point.Parent.Children[point.Parent.Children.Count - 1];
			}
			while (class5 != null && class5 != point)
			{
				if (class5.AssociatedWith != class4 || class5.ConnectedWith.Count <= 0)
				{
					class5 = (Class837)class5.Previous;
					if (class5 == null && point.Parent != null)
					{
						class5 = (Class837)point.Parent.Children[point.Parent.Children.Count - 1];
					}
					continue;
				}
				@class = class5.ShapeContainer;
				break;
			}
		}
		if (!string.IsNullOrEmpty(ConnectorParameter.DestionationNode))
		{
			Class837 class6 = method_13(point, ConnectorParameter.DestionationNode);
			if (class6 != null)
			{
				class2 = class6.ShapeContainer;
			}
		}
		if (class2 == null)
		{
			Class837 class7 = (Class837)point.Next;
			if (class7 == null && point.Parent != null)
			{
				class7 = (Class837)point.Parent.Children[0];
			}
			while (class7 != null && class7 != point)
			{
				Class837 class8 = method_12(class7);
				if (class8 == null)
				{
					class7 = (Class837)class7.Next;
					if (class7 == null && point.Parent != null)
					{
						class7 = (Class837)point.Parent.Children[0];
					}
					continue;
				}
				class2 = class8.ShapeContainer;
				break;
			}
		}
		return new Class851[2] { @class, class2 };
	}

	private Class837 method_12(Class837 point)
	{
		if (point.Algorithm is Class129 && point.ConnectedWith.Count > 0)
		{
			return point;
		}
		foreach (Class837 child in point.Children)
		{
			Class837 @class = method_12(child);
			if (@class != null)
			{
				return @class;
			}
		}
		return null;
	}

	private Class837 method_13(Class837 point, string layoutName)
	{
		Class836 assosiated = point.AssociatedWith.method_3();
		Class837 @class = point.method_38(layoutName, assosiated);
		if (@class != null)
		{
			return @class;
		}
		Class837 class2 = (Class837)point.Next;
		while (class2 != null && class2 != point)
		{
			@class = class2.method_38(layoutName, null);
			if (@class == null)
			{
				class2 = (Class837)class2.Next;
				if (class2 == null && point.Parent != null)
				{
					class2 = (Class837)point.Parent.Children[0];
				}
				continue;
			}
			return @class;
		}
		return point.Root.method_38(layoutName, assosiated);
	}

	private Class837 method_14(Class837 point, string layoutName)
	{
		Class836 assosiated = point.AssociatedWith.method_2();
		Class837 @class = point.method_38(layoutName, assosiated);
		if (@class != null)
		{
			return @class;
		}
		if (point.AssociatedWith.Type == Enum337.const_6)
		{
			Class837 class2 = (Class837)point.Previous;
			while (class2 != null)
			{
				@class = class2.method_38(layoutName, null);
				if (@class == null)
				{
					class2 = (Class837)class2.Previous;
					continue;
				}
				return @class;
			}
		}
		else
		{
			Class837 class3 = (Class837)point.Parent;
			while (class3 != null)
			{
				Class837 class4 = class3.method_38(layoutName, assosiated);
				if (class4 == null)
				{
					class3 = (Class837)class3.Parent;
					continue;
				}
				return class4;
			}
		}
		return point.Root.method_38(layoutName, assosiated);
	}

	private Class842 method_15(Class837 point, Struct47 bounds, double begPadding, double endPadding)
	{
		Class842 @class = new Class842();
		Struct50 norm = bounds.Norm;
		bounds = new Struct47(bounds.StartX - norm.Dx * begPadding, bounds.StartY - norm.Dy * begPadding, bounds.EndX + norm.Dx * endPadding, bounds.EndY + norm.Dy * endPadding);
		@class.Thickness = (point.method_23(Enum305.const_32) ? (point.method_30(Enum305.const_32) / 2.0) : (point.method_30(Enum305.const_16) * 0.3));
		if (point.method_23(Enum305.const_17))
		{
			@class.ArrowHeight = Math.Max(@class.Thickness, point.method_30(Enum305.const_17) / 2.0);
			if (ConnectorParameter.Routing == Enum125.const_3)
			{
				@class.ArrowHeight += @class.ArrowHeight - @class.Thickness;
			}
		}
		else
		{
			@class.ArrowHeight = Math.Max(@class.Thickness, point.method_30(Enum305.const_16) * ((ConnectorParameter.Routing == Enum125.const_0) ? 0.5 : 0.75));
		}
		if (point.method_23(Enum305.const_63))
		{
			@class.ArrowWidth = point.method_30(Enum305.const_63);
		}
		else
		{
			double num = Math.Max(0.0, point.method_30(Enum305.const_8) - begPadding - endPadding);
			double num2 = point.method_30(Enum305.const_16);
			@class.ArrowWidth = ((num2 != 0.0) ? Math.Min(num, num2) : num) * 0.5;
		}
		@class.HasBeginningArrowhead = ConnectorParameter.HasBeginningArrowhead;
		@class.HasEndingArrowhead = ConnectorParameter.HasEndingArrowhead;
		@class.BeginPadding = begPadding;
		@class.EndPadding = endPadding;
		return @class;
	}

	private List<Struct46> method_16(Struct46 center, double radius, Struct47 target)
	{
		List<Struct46> list = new List<Struct46>();
		Struct46[] array = target.method_1();
		Struct46 @struct = array[0];
		for (int i = 1; i <= array.Length; i++)
		{
			Struct46 struct2 = ((i < array.Length) ? array[i] : array[0]);
			if (Class102.smethod_4(center, radius, @struct, struct2, out var intersection))
			{
				list.Add(intersection);
			}
			if (Class102.smethod_4(center, radius, struct2, @struct, out intersection))
			{
				list.Add(intersection);
			}
			@struct = struct2;
		}
		return list;
	}
}
