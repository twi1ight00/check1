using ns56;

namespace ns8;

internal class Class125 : Class120
{
	private Class109 HierarchyParameter => (Class109)base.Parameter;

	public override bool vmethod_6(Enum305 type)
	{
		if (type != Enum305.const_31)
		{
			return type == Enum305.const_1;
		}
		return true;
	}

	public override bool vmethod_2(Class837 point)
	{
		double num = point.method_30(Enum305.const_31);
		double alignmentOffset = point.method_30(Enum305.const_1);
		Class837 @class = ((point.Children.Count > 0) ? ((Class837)point.Children[0]) : null);
		if (@class != null)
		{
			Class837 class2 = ((point.Children.Count > 1) ? ((Class837)point.Children[1]) : null);
			Class837 class3 = ((point.Children.Count > 2) ? ((Class837)point.Children[2]) : null);
			Struct50 @struct = default(Struct50);
			Struct50 struct2 = method_8(@class, class2, num, alignmentOffset, isAssistantBranch: false);
			Struct50 struct3 = method_8(@class, class3, num, alignmentOffset, isAssistantBranch: true);
			double num2 = double.MaxValue;
			double num3 = double.MaxValue;
			if (class2 != null && smethod_11(class2))
			{
				if (num2 > struct2.Dx)
				{
					num2 = struct2.Dx;
				}
				if (num3 > struct2.Dy)
				{
					num3 = struct2.Dy;
				}
			}
			if (class3 != null && smethod_11(class3))
			{
				if (class2 != null)
				{
					switch (HierarchyParameter.HierarchyAlignment)
					{
					case Enum132.const_1:
						struct2 = new Struct50(struct2.Dx, struct2.Dy + class3.ShapeContainer.Height + num);
						break;
					case Enum132.const_2:
						struct2 = new Struct50(struct2.Dx, struct2.Dy - class3.ShapeContainer.Height - num);
						break;
					case Enum132.const_3:
						struct2 = new Struct50(struct2.Dx + num + class3.ShapeContainer.Width, struct2.Dy);
						break;
					case Enum132.const_4:
						struct2 = new Struct50(struct2.Dx - num - class3.ShapeContainer.Width, struct2.Dy);
						break;
					}
					if (num2 > struct2.Dx)
					{
						num2 = struct2.Dx;
					}
					if (num3 > struct2.Dy)
					{
						num3 = struct2.Dy;
					}
				}
				if (num2 > struct3.Dx)
				{
					num2 = struct3.Dx;
				}
				if (num3 > struct3.Dy)
				{
					num3 = struct3.Dy;
				}
			}
			if (num2 > @struct.Dx)
			{
				num2 = @struct.Dx;
			}
			if (num3 > @struct.Dy)
			{
				num3 = @struct.Dy;
			}
			@class.ShapeContainer.method_6(@struct.Dx - num2, @struct.Dy - num3);
			class2?.ShapeContainer.method_6(struct2.Dx - num2, struct2.Dy - num3);
			class3?.ShapeContainer.method_6(struct3.Dx - num2, struct3.Dy - num3);
		}
		point.ShapeContainer.method_12();
		return true;
	}

	private Struct50 method_8(Class837 root, Class837 child, double space, double alignmentOffset, bool isAssistantBranch)
	{
		double dx = 0.0;
		double dy = 0.0;
		if (root != null && child != null && smethod_11(root) && smethod_11(child))
		{
			bool flag = HierarchyParameter.HierarchyAlignment == Enum132.const_1 || HierarchyParameter.HierarchyAlignment == Enum132.const_2;
			switch (HierarchyParameter.HierarchyAlignment)
			{
			case Enum132.const_1:
				dy = root.ShapeContainer.Height + space;
				break;
			case Enum132.const_2:
				dy = 0.0 - child.ShapeContainer.Height - space;
				break;
			case Enum132.const_3:
				dx = root.ShapeContainer.Width + space;
				break;
			case Enum132.const_4:
				dx = 0.0 - child.ShapeContainer.Width - space;
				break;
			}
			if (isAssistantBranch)
			{
				Struct50 @struct = smethod_10(root, child);
				if (flag)
				{
					dx = @struct.Dx;
				}
				else
				{
					dy = @struct.Dy;
				}
			}
			else
			{
				switch (HierarchyParameter.HierarchySecondAlignment)
				{
				case Enum131.const_0:
					dy = root.ShapeContainer.Height * alignmentOffset;
					break;
				case Enum131.const_1:
					dy = root.ShapeContainer.Height - (child.ShapeContainer.Height + root.ShapeContainer.Height * alignmentOffset);
					break;
				case Enum131.const_2:
					dx = root.ShapeContainer.Width * alignmentOffset;
					break;
				case Enum131.const_3:
					dx = 0.0 - (child.ShapeContainer.Width - root.ShapeContainer.Width) - root.ShapeContainer.Width * alignmentOffset;
					break;
				case Enum131.const_4:
				{
					Struct50 struct3 = smethod_10(root, child);
					if (struct3.Length > 0.0)
					{
						if (flag)
						{
							dx = struct3.Dx;
						}
						else
						{
							dy = struct3.Dy;
						}
						break;
					}
					Struct47 struct4 = new Struct47(child.ShapeContainer.method_3());
					if (flag)
					{
						dx = child.ShapeContainer.X - struct4.X + (root.ShapeContainer.Width - struct4.Width) / 2.0;
					}
					else
					{
						dy = child.ShapeContainer.Y - struct4.Y + (root.ShapeContainer.Height - struct4.Height) / 2.0;
					}
					break;
				}
				case Enum131.const_5:
				{
					Struct50 struct2 = smethod_10(root, child);
					if (struct2.Length > 0.0)
					{
						if (flag)
						{
							dx = struct2.Dx;
						}
						else
						{
							dy = struct2.Dy;
						}
					}
					else if (flag)
					{
						dx = (root.ShapeContainer.Width - child.ShapeContainer.Width) / 2.0;
					}
					else
					{
						dy = (root.ShapeContainer.Height - child.ShapeContainer.Height) / 2.0;
					}
					break;
				}
				}
			}
		}
		return new Struct50(dx, dy);
	}

	private static Struct50 smethod_10(Class837 root, Class837 child)
	{
		Class124 @class = child.Algorithm as Class124;
		double num = child.ShapeContainer.method_13(Enum135.const_4);
		double num2 = child.ShapeContainer.method_13(Enum135.const_5);
		if (@class != null && (num != 0.0 || num2 != 0.0))
		{
			return new Struct50(root.ShapeContainer.Width / 2.0 - num, root.ShapeContainer.Height / 2.0 - num2);
		}
		return default(Struct50);
	}

	private static bool smethod_11(Class837 point)
	{
		if (point.method_49())
		{
			return true;
		}
		return point.Children.Count > 0;
	}
}
