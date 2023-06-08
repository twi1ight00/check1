using System;
using System.Collections;
using System.Drawing;
using ns161;
using ns164;
using ns166;
using ns167;
using ns168;
using ns169;

namespace ns163;

internal class Class4747 : Class4743
{
	private readonly Stack stack_0 = new Stack();

	private Enum668 enum668_0;

	internal Class4747(Class4743 next, Class4750 context)
		: base(next, context)
	{
	}

	internal Class4747(Class4750 context)
		: base(new Class4749(context), context)
	{
	}

	internal override bool vmethod_0(Class4779 node)
	{
		bool flag = false;
		Class4781 @class = node as Class4781;
		enum668_0 = Enum668.const_0;
		if (@class != null)
		{
			flag = method_0(@class);
		}
		if (!flag)
		{
			flag = base.vmethod_0(node);
		}
		else if (node.Parent != null)
		{
			Class4743.smethod_0(node, class4750_0);
		}
		return flag;
	}

	private bool method_0(Class4781 node)
	{
		node.Flush();
		if (node.BoundingGraphics.Count != 0)
		{
			return method_1(node);
		}
		return method_5(node);
	}

	private bool method_1(Class4781 node)
	{
		bool flag = true;
		method_7(smethod_3(node), smethod_4(node), method_6(node));
		if (smethod_2(node))
		{
			flag = method_2(node);
		}
		else if (node.BoundingGraphics.IsColumn)
		{
			for (int i = 0; i < node.BoundingGraphics.Count; i++)
			{
				method_9(node.BoundingGraphics[i].BoundingBox.Height);
				method_11(node.BoundingGraphics[i].BoundingBox.Width, node.BoundingGraphics[i].HasBoundary);
				flag &= method_0((Class4781)node.BoundingGraphics[i].TextContainer);
				method_12();
				method_10();
				if (!flag)
				{
					break;
				}
			}
		}
		else
		{
			method_9(node.BoundingGraphics[0].BoundingBox.Height);
			for (int j = 0; j < node.BoundingGraphics.Count; j++)
			{
				method_11(node.BoundingGraphics[j].BoundingBox.Width, node.BoundingGraphics[j].HasBoundary);
				flag &= method_0((Class4781)node.BoundingGraphics[j].TextContainer);
				method_12();
				if (!flag)
				{
					break;
				}
			}
			method_10();
		}
		method_8();
		return flag;
	}

	private bool method_2(Class4781 node)
	{
		bool result = true;
		if (node.BoundingGraphics.IsColumn)
		{
			return method_3(node, result);
		}
		return method_4(node, result);
	}

	private bool method_3(Class4781 node, bool result)
	{
		for (int i = 0; i < node.BoundingGraphics.Count; i++)
		{
			method_9(node.BoundingGraphics[i].BoundingBox.Height);
			if (node.BoundingGraphics[i].Count != 0)
			{
				for (int j = 0; j < node.BoundingGraphics[i].Count; j++)
				{
					method_11(node.BoundingGraphics[i][j].BoundingBox.Width, node.BoundingGraphics[i][j].HasBoundary);
					result &= method_5((Class4781)node.BoundingGraphics[i][j].TextContainer);
					method_12();
					if (!result)
					{
						break;
					}
				}
			}
			else
			{
				method_11(node.BoundingGraphics[i].BoundingBox.Width, node.BoundingGraphics[i].HasBoundary);
				result &= method_5((Class4781)node.BoundingGraphics[i].TextContainer);
				method_12();
			}
			method_10();
			if (!result)
			{
				break;
			}
		}
		return result;
	}

	private bool method_4(Class4781 node, bool result)
	{
		if (node.BoundingGraphics[0].Count != 0)
		{
			for (int i = 0; i < node.BoundingGraphics[0].Count; i++)
			{
				method_9(node.BoundingGraphics[0][i].BoundingBox.Height);
				for (int j = 0; j < node.BoundingGraphics.Count; j++)
				{
					if (i < node.BoundingGraphics[j].Count)
					{
						method_11(node.BoundingGraphics[j][i].BoundingBox.Width, node.BoundingGraphics[j][i].HasBoundary);
						result &= method_5((Class4781)node.BoundingGraphics[j][i].TextContainer);
					}
					else
					{
						method_11(node.BoundingGraphics[j].BoundingBox.Width, node.BoundingGraphics[j].HasBoundary);
						result &= method_5((Class4781)node.BoundingGraphics[j].TextContainer);
					}
					method_12();
					if (!result)
					{
						break;
					}
				}
				method_10();
				if (!result)
				{
					break;
				}
			}
		}
		else
		{
			method_9(node.BoundingGraphics.BoundingBox.Height);
			float num = 0f;
			for (int k = 0; k < node.BoundingGraphics.Count; k++)
			{
				float num3;
				if (k == 0)
				{
					Class4779 parent = node.Parent;
					while (parent != null && !(parent is Class4781))
					{
						parent = parent.Parent;
					}
					float num2 = parent?.BoundingBox.Left ?? ((float)class4750_0.LastSection.Attributes[Enum670.const_2]);
					num3 = node.BoundingBox.Left - num2;
					if (num3 > 1f)
					{
						method_11(num3, hasBoundary: true);
						class4750_0.CurrentElement.Add(Class4743.smethod_1());
						method_12();
					}
				}
				Class4857 @class = node.BoundingGraphics[k];
				num3 = @class.BoundingBox.Width;
				if (@class.IsDummy)
				{
					num3 = ((!(num > num3)) ? (num3 - num) : 1f);
				}
				else
				{
					num = 4f;
					if (k + 1 != node.BoundingGraphics.Count)
					{
						Class4857 class2 = node.BoundingGraphics[k + 1];
						if (class2.IsDummy && class2.BoundingBox.Width > num)
						{
							num = class2.BoundingBox.Width - 1f;
						}
					}
					num3 += num;
				}
				method_11(num3, @class.HasBoundary);
				result &= method_5((Class4781)@class.TextContainer);
				method_12();
				if (!result)
				{
					break;
				}
			}
			method_10();
		}
		return result;
	}

	private bool method_5(Class4781 node)
	{
		bool result = false;
		bool flag = enum668_0 != Enum668.const_3;
		if (node.BoundingGraphics.Count != 0)
		{
			throw new ArgumentException("Please report exception.");
		}
		if (flag)
		{
			method_7(smethod_3(node), smethod_4(node), method_6(node));
			method_9(node.BoundingGraphics.BoundingBox.Height);
			method_11(node.BoundingGraphics.BoundingBox.Width, node.BoundingGraphics.HasBoundary);
		}
		if (node.ChildrenCount != 0)
		{
			if (node[0][0] is Class4782 @class)
			{
				if (!@class.method_21())
				{
					Class4846 class2 = new Class4846();
					foreach (Class4845 item in @class)
					{
						if (!class2.Contains(item))
						{
							if (!(result = base.vmethod_0(item.Value)))
							{
								Class4785 class4 = Class4804.smethod_4(@class);
								Class4804.smethod_1(@class, class2);
								class4.Parent = node;
								result = base.vmethod_0(class4);
							}
							class2.Add(item);
						}
					}
				}
				else
				{
					class4750_0.CurrentElement.Add(Class4743.smethod_1());
					result = true;
				}
			}
			else
			{
				foreach (Class4845 item2 in node)
				{
					result = base.vmethod_0(item2.Value);
				}
			}
		}
		else
		{
			result = true;
		}
		if (flag)
		{
			method_12();
			method_10();
			method_8();
		}
		return result;
	}

	private float method_6(Class4781 source)
	{
		float result = 0f;
		if (!(source.Parent is Class4781) && source.BigBrotherBoundary.Top - source.BoundingBox.Top == 0f && source.Parent != null)
		{
			result = source.Parent.method_0(new PointF(source.BoundingBox.Left, source.BoundingBox.Top), class4750_0.LeftMargin).Y - class4750_0.BottomOfLastElement;
		}
		return result;
	}

	private void method_7(Enum671 alignment, float leftIndent, float topMargin)
	{
		Class4759 @class = new Class4759();
		@class.Attributes.Add(Enum670.const_11, alignment);
		if (leftIndent > 0f)
		{
			@class.Attributes.Add(Enum670.const_2, leftIndent);
		}
		if (topMargin > 1f)
		{
			@class.Attributes.Add(Enum670.const_4, topMargin);
		}
		class4750_0.CurrentElement.Add(@class);
		stack_0.Push(class4750_0.CurrentElement);
		class4750_0.CurrentElement = @class;
		enum668_0 = Enum668.const_1;
	}

	private void method_8()
	{
		class4750_0.CurrentElement = (Class4755)stack_0.Pop();
		enum668_0 = Enum668.const_0;
	}

	private void method_9(float height)
	{
		Class4758 @class = new Class4758(Class4817.smethod_0(height, class4750_0.LastSection.PageSize.Height));
		class4750_0.CurrentElement.Add(@class);
		stack_0.Push(class4750_0.CurrentElement);
		class4750_0.CurrentElement = @class;
		enum668_0 = Enum668.const_2;
	}

	private void method_10()
	{
		class4750_0.CurrentElement = (Class4755)stack_0.Pop();
		enum668_0 = Enum668.const_1;
	}

	private void method_11(float width, bool hasBoundary)
	{
		float width2 = Class4817.smethod_0(width, class4750_0.LastSection.PageSize.Width);
		Class4757 @class = (hasBoundary ? new Class4757(width2, drawBorders: true) : new Class4757(width2, drawBorders: false));
		class4750_0.CurrentElement.Add(@class);
		stack_0.Push(class4750_0.CurrentElement);
		class4750_0.CurrentElement = @class;
		enum668_0 = Enum668.const_3;
	}

	private void method_12()
	{
		class4750_0.CurrentElement = (Class4755)stack_0.Pop();
		enum668_0 = Enum668.const_2;
	}

	private static bool smethod_2(Class4781 node)
	{
		bool flag = true;
		int num = -1;
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < node.BoundingGraphics.Count; i++)
		{
			if (num == -1)
			{
				num = node.BoundingGraphics[i].Count;
				for (int j = 0; j < node.BoundingGraphics[i].Count - 1; j++)
				{
					arrayList.Add(node.BoundingGraphics.IsColumn ? node.BoundingGraphics[i][j].Right.Start.X : node.BoundingGraphics[i][j].Bottom.Start.Y);
				}
				continue;
			}
			if (node.BoundingGraphics[i].Count == 0 || num == node.BoundingGraphics[i].Count)
			{
				for (int k = 0; k < node.BoundingGraphics[i].Count - 1; k++)
				{
					float num2 = (node.BoundingGraphics.IsColumn ? node.BoundingGraphics[i][k].Right.Start.X : node.BoundingGraphics[i][k].Bottom.Start.Y);
					if (!Class4797.smethod_2(num2, (float)arrayList[k]))
					{
						flag = false;
						break;
					}
				}
				continue;
			}
			flag = false;
			break;
		}
		if (flag)
		{
			for (int l = 0; l < node.BoundingGraphics.Count; l++)
			{
				for (int m = 0; m < node.BoundingGraphics[l].Count; m++)
				{
					if (node.BoundingGraphics[l][m].Count != 0)
					{
						flag = false;
						break;
					}
				}
			}
		}
		return flag;
	}

	private static Enum671 smethod_3(Class4781 source)
	{
		Enum671 result = Enum671.const_1;
		if (source.Parent != null && !source.Parent.BoundingBox.IsEmpty)
		{
			ArrayList arrayList = new ArrayList(3);
			arrayList.Add((double)Math.Abs(source.BigBrotherBoundary.Left - source.Parent.BoundingBox.Left));
			arrayList.Add((double)Math.Abs(source.BigBrotherBoundary.Right - source.Parent.BoundingBox.Right));
			arrayList.Add((double)Math.Abs(Class4817.smethod_2(source.BigBrotherBoundary).X - Class4817.smethod_2(source.Parent.BoundingBox).X));
			Class4812.smethod_4(arrayList, out var index);
			result = index switch
			{
				0 => Enum671.const_0, 
				1 => Enum671.const_2, 
				2 => Enum671.const_1, 
				_ => throw new ArgumentOutOfRangeException("index", "Please report exception"), 
			};
		}
		return result;
	}

	private static float smethod_4(Class4781 source)
	{
		return source.BoundingBox.Left - source.BigBrotherBoundary.Left;
	}
}
