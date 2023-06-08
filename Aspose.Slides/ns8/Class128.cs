using System;
using System.Collections.Generic;
using ns56;

namespace ns8;

internal class Class128 : Class120
{
	private struct Struct51
	{
		private int int_0;

		private int int_1;

		private double double_0;

		private Struct48 struct48_0;

		public int Columns => int_0;

		public int Rows => int_1;

		public double Ratio => double_0;

		public double Width => struct48_0.Width * double_0;

		public double Height => struct48_0.Height * double_0;

		public Struct51(int columns, int rows, double ratio, Struct48 bounds)
		{
			int_0 = columns;
			int_1 = rows;
			double_0 = ratio;
			struct48_0 = bounds;
		}
	}

	private class Class845
	{
		private double double_0;

		private double double_1;

		private double double_2;

		private double double_3;

		private double double_4;

		private double double_5;

		private double double_6;

		private Class837 class837_0;

		private Class837 class837_1;

		public double X
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

		public double Y
		{
			get
			{
				return double_1;
			}
			set
			{
				double_1 = value;
			}
		}

		public double Width => double_3 * double_2;

		public double Height => double_4 * double_2;

		public double SiblingWidth => double_5 * double_2;

		public double SiblingHeight => double_6 * double_2;

		public Class837 Sibling => class837_0;

		public Class837 Node => class837_1;

		public Class845(Class837 sibling, Class837 node)
		{
			class837_1 = node;
			class837_0 = sibling;
			double_3 = node.ShapeContainer.Width;
			double_4 = node.ShapeContainer.Height;
			if (sibling != null)
			{
				double_5 = sibling.ShapeContainer.Width;
				double_6 = sibling.ShapeContainer.Height;
			}
			double_2 = 1.0;
		}

		public void method_0(double ratio)
		{
			double_2 = ratio;
		}

		public void method_1()
		{
			double_2 = 1.0;
		}

		public void method_2()
		{
			class837_1.method_24(double_2, Enum305.const_62, Enum305.const_16);
			if (class837_0 != null)
			{
				class837_0.method_24(double_2, Enum305.const_62, Enum305.const_16);
			}
		}
	}

	private Class111 SnakeParameter => (Class111)base.Parameter;

	public override bool vmethod_6(Enum305 type)
	{
		return type == Enum305.const_31;
	}

	public override bool vmethod_2(Class837 point)
	{
		List<Class845> list = new List<Class845>();
		foreach (Class837 child in point.Children)
		{
			if (child.AssociatedWith.Type == Enum337.const_1)
			{
				list.Add(new Class845(method_8(child, point.Children), child));
			}
		}
		if (list.Count != 0)
		{
			double space = point.method_30(Enum305.const_31);
			Struct48 canvas = new Struct48(point.method_30(Enum305.const_62), point.method_30(Enum305.const_16));
			if (SnakeParameter.IsFlowByRows)
			{
				canvas.Width = Math.Max(1.0, point.method_30(Enum305.const_62) - point.method_30(Enum305.const_4) - point.method_30(Enum305.const_15));
			}
			else
			{
				canvas.Height = Math.Max(1.0, point.method_30(Enum305.const_16) - point.method_30(Enum305.const_4) - point.method_30(Enum305.const_15));
			}
			Struct51 @struct = SnakeParameter.Breakpoint switch
			{
				Enum129.const_1 => method_10(list, canvas, space, point.method_30(Enum305.const_1)), 
				Enum129.const_2 => method_11(list, canvas, space, point.method_30(Enum305.const_1), Math.Max(1, SnakeParameter.BreakpointFixedValue)), 
				_ => method_9(list, canvas, space, point.method_30(Enum305.const_1)), 
			};
			point.ShapeContainer.Width = @struct.Width;
			point.ShapeContainer.Height = @struct.Height;
			if (SnakeParameter.IsFlowByRows)
			{
				point.ShapeContainer.AvailableWidth = Math.Max(1.0, point.method_30(Enum305.const_62) - point.method_30(Enum305.const_4) - point.method_30(Enum305.const_15));
				point.ShapeContainer.AvailableHeight = point.method_30(Enum305.const_16);
			}
			else
			{
				point.ShapeContainer.AvailableWidth = point.method_30(Enum305.const_62);
				point.ShapeContainer.AvailableHeight = Math.Max(1.0, point.method_30(Enum305.const_16) - point.method_30(Enum305.const_4) - point.method_30(Enum305.const_15));
			}
			Class120.smethod_8(point, SnakeParameter.HorizontalAlignment, SnakeParameter.VerticalAlignment);
			foreach (Class845 item in list)
			{
				item.Node.ShapeContainer.method_5(item.X, item.Y);
			}
			if (Class120.smethod_4(@struct.Ratio))
			{
				point.method_25(@struct.Ratio, Enum305.const_31);
				foreach (Class845 item2 in list)
				{
					item2.method_0(@struct.Ratio);
					item2.method_2();
				}
				point.method_26();
				return false;
			}
		}
		return true;
	}

	private Class837 method_8(Class837 node, Class838 siblings)
	{
		if (node.AssociatedWith.Type == Enum337.const_1)
		{
			Class836 next = node.AssociatedWith.Next;
			if (next != null)
			{
				foreach (Class837 sibling in siblings)
				{
					if (sibling.AssociatedWith == next)
					{
						return sibling;
					}
				}
			}
		}
		return null;
	}

	private Struct51 method_9(List<Class845> children, Struct48 canvas, double space, double offset)
	{
		int num = 1;
		int num2 = 1;
		double num3 = 1.0;
		int num4 = children.Count;
		while (num4 > 0)
		{
			num4 = children.Count - 1;
			num = 1;
			num2 = 1;
			if (num3 != 1.0)
			{
				foreach (Class845 child in children)
				{
					child.method_0(num3);
				}
			}
			double space2 = space * num3;
			Struct48 @struct = method_13(children, num, num2, space2, offset);
			if (SnakeParameter.IsFlowByRows)
			{
				while (num4 > 0 && !(@struct.Width > canvas.Width))
				{
					@struct = method_13(children, num, num2 + 1, space2, offset);
					if (@struct.Width <= canvas.Width)
					{
						num2++;
						num4--;
					}
				}
				while (num4 > 0 && !(@struct.Height > canvas.Height))
				{
					@struct = method_13(children, num + 1, num2, space2, offset);
					if (@struct.Height <= canvas.Height)
					{
						num++;
						num4 -= num2;
					}
				}
			}
			else
			{
				while (num4 > 0 && !(@struct.Height > canvas.Height))
				{
					@struct = method_13(children, num + 1, num2, space2, offset);
					if (@struct.Height <= canvas.Height)
					{
						num++;
						num4--;
					}
				}
				while (num4 > 0 && !(@struct.Width > canvas.Width))
				{
					@struct = method_13(children, num, num2 + 1, space2, offset);
					if (@struct.Width <= canvas.Width)
					{
						num2++;
						num4 -= num;
					}
				}
			}
			if (num4 > 0)
			{
				Struct48 struct2 = method_13(children, num, num2 + 1, space2, offset);
				Struct48 struct3 = method_13(children, num + 1, num2, space2, offset);
				double val = Math.Min(canvas.Height / struct3.Height, canvas.Width / struct3.Width);
				double val2 = Math.Min(canvas.Height / struct2.Height, canvas.Width / struct2.Width);
				num3 *= Math.Max(val, val2);
			}
		}
		foreach (Class845 child2 in children)
		{
			child2.method_1();
		}
		return method_12(children, num, num2, space, offset, canvas);
	}

	private Struct51 method_10(List<Class845> children, Struct48 canvas, double space, double offset)
	{
		int num = 1;
		int num2 = 1;
		while (num * num2 < children.Count)
		{
			if (SnakeParameter.IsFlowByRows)
			{
				if (num2 > num)
				{
					num++;
				}
				else
				{
					num2++;
				}
			}
			else if (num > num2)
			{
				num2++;
			}
			else
			{
				num++;
			}
		}
		return method_12(children, num, num2, space, offset, canvas);
	}

	private Struct51 method_11(List<Class845> children, Struct48 canvas, double space, double offset, int value)
	{
		int num = Math.Min(value, children.Count);
		int num2 = (int)Math.Ceiling((double)children.Count / (double)value);
		int rowsCount = (SnakeParameter.IsFlowByRows ? num2 : num);
		int columnsCount = (SnakeParameter.IsFlowByRows ? num : num2);
		return method_12(children, rowsCount, columnsCount, space, offset, canvas);
	}

	private Struct51 method_12(List<Class845> children, int rowsCount, int columnsCount, double space, double offset, Struct48 canvas)
	{
		Struct48 bounds = method_13(children, rowsCount, columnsCount, space, offset);
		double ratio = Math.Min(1.0, Math.Min(canvas.Height / bounds.Height, canvas.Width / bounds.Width));
		return new Struct51(columnsCount, rowsCount, ratio, bounds);
	}

	private Struct48 method_13(List<Class845> children, int rows, int columns, double space, double offset)
	{
		if (SnakeParameter.IsCentred)
		{
			offset = 0.0;
		}
		if (SnakeParameter.IsFlowByRows)
		{
			return method_14(children, rows, columns, space, offset * (children[0].Width + children[0].SiblingWidth));
		}
		return method_15(children, rows, columns, space, offset * (children[0].Height + children[0].SiblingHeight));
	}

	private Struct48 method_14(List<Class845> children, int rows, int columns, double space, double offset)
	{
		bool flag = SnakeParameter.Direction == Enum130.const_0 || SnakeParameter.Direction == Enum130.const_2;
		bool flag2 = SnakeParameter.Direction == Enum130.const_0 || SnakeParameter.Direction == Enum130.const_1;
		double num = 0.0;
		double num2 = 0.0;
		double num3 = 0.0;
		double num4 = 0.0;
		double num5 = 0.0;
		double num6 = double.MaxValue;
		double num7 = double.MaxValue;
		int num8 = 0;
		for (int i = 0; i < rows; i++)
		{
			if (num8 >= children.Count)
			{
				break;
			}
			bool flag3 = i % 2 == 0;
			bool flag4 = ((SnakeParameter.IsSameDirection || flag3) ? flag : (!flag));
			double num9 = 0.0;
			double num10 = 0.0;
			int startIndex = num8;
			for (int j = 0; j < columns; j++)
			{
				if (num8 >= children.Count)
				{
					break;
				}
				double num11 = children[num8].Width + ((j < columns - 1) ? children[num8].SiblingWidth : 0.0);
				num10 += num11;
				num9 = Math.Max(num9, children[num8].Height);
				children[num8].X = num4;
				children[num8].Y = num5;
				if (num4 < num6)
				{
					num6 = num4;
				}
				if (num5 < num7)
				{
					num7 = num5;
				}
				if (flag4)
				{
					num4 += num11;
				}
				else
				{
					if (j < columns - 1)
					{
						num4 -= children[num8].SiblingWidth;
					}
					if (num8 + 1 < children.Count)
					{
						num4 -= children[num8 + 1].Width;
					}
				}
				num8++;
			}
			method_16(children, startIndex, columns, num9);
			if (i != rows - 1)
			{
				num9 += space;
			}
			if (flag2)
			{
				num5 += num9;
			}
			else
			{
				if (i != rows - 1)
				{
					num5 -= space;
				}
				num5 -= smethod_10(children, num8, columns);
			}
			num2 += num9;
			if (num10 + num3 > num)
			{
				num = num10 + num3;
			}
			if (SnakeParameter.IsSameDirection)
			{
				num4 -= (flag4 ? num10 : (0.0 - num10));
			}
			else if (num8 < children.Count)
			{
				num4 -= (double)(flag4 ? 1 : (-1)) * children[num8].Width;
			}
			if (SnakeParameter.IsCentred)
			{
				int count = Math.Min(columns, children.Count - num8);
				double num12 = smethod_12(children, num8, count);
				double num13 = (double)(flag4 ? 1 : (-1)) * (num10 - num12) / 2.0;
				num4 += (SnakeParameter.IsSameDirection ? num13 : (0.0 - num13));
			}
			else
			{
				double num14 = (flag4 ? offset : (0.0 - offset));
				num4 += (SnakeParameter.IsSameDirection ? num14 : (0.0 - num14));
				num3 = ((!SnakeParameter.IsSameDirection) ? offset : (num3 + offset));
			}
		}
		foreach (Class845 child in children)
		{
			child.X -= num6;
			child.Y -= num7;
		}
		return new Struct48(num, num2);
	}

	private Struct48 method_15(List<Class845> children, int rows, int columns, double space, double offset)
	{
		bool flag = SnakeParameter.Direction == Enum130.const_0 || SnakeParameter.Direction == Enum130.const_2;
		bool flag2 = SnakeParameter.Direction == Enum130.const_0 || SnakeParameter.Direction == Enum130.const_1;
		double num = 0.0;
		double num2 = 0.0;
		double num3 = 0.0;
		double num4 = 0.0;
		double num5 = 0.0;
		double num6 = double.MaxValue;
		double num7 = double.MaxValue;
		int num8 = 0;
		for (int i = 0; i < columns; i++)
		{
			if (num8 >= children.Count)
			{
				break;
			}
			bool flag3 = i % 2 == 0;
			bool flag4 = ((SnakeParameter.IsSameDirection || flag3) ? flag2 : (!flag2));
			double num9 = 0.0;
			double num10 = 0.0;
			int startIndex = num8;
			for (int j = 0; j < rows; j++)
			{
				if (num8 >= children.Count)
				{
					break;
				}
				double num11 = children[num8].Height + ((j < rows - 1) ? children[num8].SiblingHeight : 0.0);
				num10 += num11;
				num9 = Math.Max(num9, children[num8].Width);
				children[num8].X = num4;
				children[num8].Y = num5;
				if (num4 < num6)
				{
					num6 = num4;
				}
				if (num5 < num7)
				{
					num7 = num5;
				}
				if (flag4)
				{
					num5 += num11;
				}
				else
				{
					if (j < rows - 1)
					{
						num5 -= children[num8].SiblingHeight;
					}
					if (num8 + 1 < children.Count)
					{
						num5 -= children[num8 + 1].Height;
					}
				}
				num8++;
			}
			method_17(children, startIndex, rows, num9);
			if (i != columns - 1)
			{
				num9 += space;
			}
			if (flag)
			{
				num4 += num9;
			}
			else
			{
				if (i != columns - 1)
				{
					num4 -= space;
				}
				num4 -= smethod_11(children, num8, columns);
			}
			num += num9;
			if (num10 + num3 > num2)
			{
				num2 = num10 + num3;
			}
			if (SnakeParameter.IsSameDirection)
			{
				num5 -= (flag4 ? num10 : (0.0 - num10));
			}
			else if (num8 < children.Count)
			{
				num5 -= (double)(flag4 ? 1 : (-1)) * children[num8].Height;
			}
			if (SnakeParameter.IsCentred)
			{
				int count = Math.Min(rows, children.Count - num8);
				double num12 = smethod_13(children, num8, count);
				double num13 = (double)(flag4 ? 1 : (-1)) * (num10 - num12) / 2.0;
				num5 += (SnakeParameter.IsSameDirection ? num13 : (0.0 - num13));
			}
			else
			{
				double num14 = (flag4 ? offset : (0.0 - offset));
				num5 += (SnakeParameter.IsSameDirection ? num14 : (0.0 - num14));
				num3 = ((!SnakeParameter.IsSameDirection) ? offset : (num3 + offset));
			}
		}
		foreach (Class845 child in children)
		{
			child.X -= num6;
			child.Y -= num7;
		}
		return new Struct48(num, num2);
	}

	private void method_16(List<Class845> children, int startIndex, int count, double rowHeight)
	{
		for (int i = 0; i < count; i++)
		{
			if (startIndex >= children.Count)
			{
				break;
			}
			double num = 0.0;
			if (SnakeParameter.VerticalNodeAlignment == Enum121.const_3)
			{
				num = rowHeight - children[startIndex].Height;
			}
			else if (SnakeParameter.VerticalNodeAlignment == Enum121.const_2)
			{
				num = (rowHeight - children[startIndex].Height) / 2.0;
			}
			children[startIndex].Y += num;
			startIndex++;
		}
	}

	private void method_17(List<Class845> children, int startIndex, int count, double columnWidth)
	{
		for (int i = 0; i < count; i++)
		{
			if (startIndex >= children.Count)
			{
				break;
			}
			double num = 0.0;
			if (SnakeParameter.HorizontalNodeAlignment == Enum120.const_3)
			{
				num = columnWidth - children[startIndex].Width;
			}
			else if (SnakeParameter.HorizontalNodeAlignment == Enum120.const_2)
			{
				num = (columnWidth - children[startIndex].Width) / 2.0;
			}
			children[startIndex].X += num;
			startIndex++;
		}
	}

	private static double smethod_10(List<Class845> children, int startIndex, int count)
	{
		double num = 0.0;
		for (int i = 0; i < count; i++)
		{
			if (startIndex >= children.Count)
			{
				break;
			}
			if (children[startIndex].Height > num)
			{
				num = children[startIndex].Height;
			}
			startIndex++;
		}
		return num;
	}

	private static double smethod_11(List<Class845> children, int startIndex, int count)
	{
		double num = 0.0;
		for (int i = 0; i < count; i++)
		{
			if (startIndex >= children.Count)
			{
				break;
			}
			if (children[startIndex].Width > num)
			{
				num = children[startIndex].Width;
			}
			startIndex++;
		}
		return num;
	}

	private static double smethod_12(List<Class845> children, int startIndex, int count)
	{
		double num = 0.0;
		for (int i = 0; i < count; i++)
		{
			if (startIndex >= children.Count)
			{
				break;
			}
			num += children[startIndex].Width + ((i < count - 1) ? children[startIndex].SiblingWidth : 0.0);
			startIndex++;
		}
		return num;
	}

	private static double smethod_13(List<Class845> children, int startIndex, int count)
	{
		double num = 0.0;
		for (int i = 0; i < count; i++)
		{
			if (startIndex >= children.Count)
			{
				break;
			}
			num += children[startIndex].Height + ((i < count - 1) ? children[startIndex].SiblingHeight : 0.0);
			startIndex++;
		}
		return num;
	}
}
