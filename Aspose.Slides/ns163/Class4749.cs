using System;
using System.Collections;
using System.Drawing;
using ns161;
using ns164;
using ns166;
using ns167;
using ns169;
using ns234;

namespace ns163;

internal class Class4749 : Class4743
{
	private bool bool_0;

	private bool bool_1;

	private Class4755 class4755_0;

	private Class4785 class4785_0;

	internal bool IsRelativePositionForImages
	{
		set
		{
			bool_1 = value;
		}
	}

	internal Class4749(Class4743 next, Class4750 context)
		: base(next, context)
	{
	}

	internal Class4749(Class4750 context)
		: this(null, context)
	{
	}

	internal override bool vmethod_0(Class4779 node)
	{
		bool result;
		if ((result = method_0(node, out class4755_0)) && bool_0)
		{
			class4750_0.CurrentElement.Add(class4755_0);
		}
		return result;
	}

	internal bool method_0(Class4779 node, out Class4755 recognizedEl)
	{
		recognizedEl = null;
		bool result = true;
		if (smethod_6(node))
		{
			if (node is Class4784 @class)
			{
				Class4785 class2 = new Class4785();
				class2.Parent = node.Parent;
				foreach (Class4845 item in @class)
				{
					class2.Add(item.Value);
				}
				return method_0(class2, out recognizedEl);
			}
			Class4785 class4 = (Class4785)node;
			class4.Flush();
			Class4767 allAttributes = method_4(class4);
			recognizedEl = new Class4762(allAttributes);
			class4755_0 = recognizedEl;
			ArrayList runCandidates = method_3(class4);
			method_1(runCandidates, ref recognizedEl);
			bool_0 = true;
		}
		else if (smethod_7(node))
		{
			method_2((Class4790)node, ref recognizedEl);
			bool_0 = true;
		}
		else
		{
			result = base.vmethod_0(node);
			bool_0 = false;
		}
		return result;
	}

	private static Class4767 smethod_2(Class4790 pict)
	{
		double[] array = new double[3];
		bool found = false;
		Class4779 @class = Class4804.smethod_3(pict, ref found);
		array[0] = Math.Abs(pict.BoundingBox.Left - @class.BoundingBox.Left);
		array[1] = Math.Abs(pict.BoundingBox.Right - @class.BoundingBox.Right);
		array[2] = Math.Abs(pict.GeometricCenter.X - @class.GeometricCenter.X);
		Class4812.smethod_5(array, out var index);
		Enum671 @enum = index switch
		{
			0 => Enum671.const_0, 
			1 => Enum671.const_2, 
			2 => Enum671.const_1, 
			_ => throw new InvalidOperationException("Please report exception."), 
		};
		Class4767 class2 = new Class4767();
		class2.Add(Enum670.const_11, @enum);
		return class2;
	}

	private static bool smethod_3(Class4779 node)
	{
		if (node.Parent is Class4782)
		{
			return !((Class4782)node.Parent).IsColumnwise;
		}
		return false;
	}

	private void method_1(ArrayList runCandidates, ref Class4755 recognizedEl)
	{
		Class4847 @class = null;
		Class4847 class2 = null;
		float delta = 0f;
		Class4762 formattedParagraph = recognizedEl as Class4762;
		for (int i = 0; i < runCandidates.Count; i++)
		{
			if (runCandidates[i] is Class4847 class3)
			{
				smethod_4(class3, formattedParagraph);
				if (@class != null)
				{
					if (@class.Text.IndexOf("\r") == -1 && class3.method_0(@class) && ((Class4860.Instance.Options.UserAgent != Enum678.const_1 && !Class4860.Instance.Options.UseNewTextBoxRecognitionAlgorithm) || Class4860.Instance.Options.Mode != 0) && (Class4860.Instance.Options.UserAgent != 0 || Class4860.Instance.Options.Mode != Enum676.const_1))
					{
						@class.Text += class3.Text;
						continue;
					}
					Class4765 child = smethod_5(@class);
					class4755_0.Add(child);
					class2 = @class;
					@class = class3;
				}
				else
				{
					class2 = @class;
					@class = class3;
				}
			}
			else
			{
				if (@class != null)
				{
					recognizedEl.Add(smethod_5(@class));
					@class = null;
				}
				if (runCandidates[i] is Class4790 picture)
				{
					method_2(picture, ref recognizedEl);
				}
			}
		}
		if (@class == null)
		{
			return;
		}
		if (class2 != null)
		{
			ArrayList tabsPosArray = new ArrayList();
			string text = @class.method_2(class2.BoundingBox.Right, -1f, ref delta, tabsPosArray, 0f, Enum676.const_0);
			if (text == " ")
			{
				@class.Text = text + @class.Text;
			}
		}
		Class4765 child2 = smethod_5(@class);
		recognizedEl.Add(child2);
	}

	private static void smethod_4(Class4847 part, Class4762 formattedParagraph)
	{
		if (part.TabsPosArray.Count > 0 && formattedParagraph != null)
		{
			if (!formattedParagraph.Attributes.method_0(Enum670.const_25))
			{
				formattedParagraph.Attributes.Add(Enum670.const_25, new ArrayList());
			}
			((ArrayList)formattedParagraph.Attributes[Enum670.const_25]).AddRange(part.TabsPosArray);
		}
	}

	private void method_2(Class4790 picture, ref Class4755 el)
	{
		Class4761 @class = new Class4761(picture, !smethod_3(picture), bool_1, picture.IsBehindText, smethod_2(picture));
		if (el == null)
		{
			el = @class;
		}
		else
		{
			el.Add(@class);
		}
		bool found = false;
		Class4779 class2 = Class4804.smethod_3(picture, ref found);
		PointF pointF = class2.method_0(new PointF(picture.BoundingBox.Left, picture.BoundingBox.Bottom), class4750_0.LeftMargin);
		class4750_0.BottomOfLastElement = pointF.Y;
	}

	private static Class4765 smethod_5(Class4847 curPart)
	{
		Class4767 @class = new Class4767();
		@class.Add(Enum670.const_23, curPart.Font);
		@class.Add(Enum670.const_21, Class6153.smethod_0(curPart.Color));
		@class.Add(Enum670.const_27, curPart.Type);
		@class.Add(Enum670.const_28, curPart.WordSpacing);
		@class.Add(Enum670.const_29, curPart.LetterSpacing);
		@class.Add(Enum670.const_30, curPart.string_0);
		@class.Add(Enum670.const_31, curPart.IsInvisible);
		return new Class4765(curPart.Text, @class, curPart.Hyperlink);
	}

	private ArrayList method_3(Class4785 curBlock)
	{
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < curBlock.LineCount; i++)
		{
			Class4783 @class = curBlock[i];
			if (@class.ChildrenCount > 1)
			{
				@class.method_2(Enum673.const_3, isReverse: false);
			}
			for (int j = 0; j < @class.ChildrenCount; j++)
			{
				if (!(@class[j] is Class4784 class2))
				{
					if (@class[j] is Class4790 value)
					{
						arrayList.Add(value);
					}
					continue;
				}
				ArrayList arrayList2 = class2.method_41(class4750_0.enum676_0, curBlock.BoundingBox.Left, (class4750_0.enum676_0 == Enum676.const_0) ? (-1f) : curBlock.BoundingBox.Right);
				if (arrayList2.Count != 0)
				{
					if (arrayList2[arrayList2.Count - 1] is Class4847 class3 && i != curBlock.LineCount - 1)
					{
						class3.Text += ((!class4750_0.bool_0) ? ' ' : '\r');
					}
					arrayList.AddRange(arrayList2);
				}
			}
		}
		return arrayList;
	}

	private Class4767 method_4(Class4785 curBlock)
	{
		Class4767 @class = new Class4767();
		float getRealWidth = curBlock.GetRealWidth;
		bool flag = true;
		if (class4750_0.class4779_0 != null && curBlock.Parent != null && class4750_0.class4779_0.BoundingBox == curBlock.Parent.BoundingBox && class4750_0.class4779_0.Text == curBlock.Parent.Text)
		{
			flag = false;
		}
		else
		{
			class4785_0 = null;
		}
		Class4779 parent = curBlock.Parent;
		while (parent != null && parent.Parent is Class4781)
		{
			parent = parent.Parent;
		}
		if (flag && !(parent is Class4781))
		{
			@class.Add(Enum670.const_13, (class4750_0.enum676_0 == Enum676.const_0) ? curBlock.method_36() : curBlock.LineInterval);
		}
		else
		{
			float num = curBlock.LineInterval;
			float num2 = curBlock.method_36();
			@class.Add(Enum670.const_26, num2);
			if (class4750_0.enum676_0 == Enum676.const_0 && num < num2)
			{
				float num3 = num2 % num;
				float num4 = num3 - (float)Math.Floor(num3);
				num += (((double)num4 < 0.4) ? 0f : num4);
			}
			if (Class4860.Instance.Options.UserAgent == Enum678.const_0 && Class4860.Instance.Options.Mode == Enum676.const_0 && curBlock.LineCount == 1 && num2 < 10f && num / num2 >= 3f && parent is Class4785 class2 && class2.method_35(curBlock) == 0)
			{
				num += 10f - num2;
			}
			@class.Add(Enum670.const_13, num);
		}
		Enum671 alignment = curBlock.Alignment;
		@class.Add(Enum670.const_11, alignment);
		if (alignment == Enum671.const_3)
		{
			@class.Add(Enum670.const_6, curBlock.BoundingBox.Width);
		}
		PointF pointF = curBlock.Parent.method_0(new PointF(curBlock.BoundingBox.Left, curBlock.BoundingBox.Top), class4750_0.LeftMargin);
		float num5 = pointF.Y - class4750_0.BottomOfLastElement;
		if (flag)
		{
			if (parent is Class4781 && curBlock.ChildrenCount > 0)
			{
				float y = curBlock[0].BoundingBox.Y;
				Class4779 class4 = class4750_0.class4779_0;
				while (class4 != null && (!(class4.BoundingBox == parent.BoundingBox) || !(class4.Text == parent.Text)))
				{
					class4 = class4.Parent;
				}
				@class.Add(Enum670.const_4, (!(num5 > 1f) || class4 == null) ? (y - parent.BoundingBox.Y) : num5);
			}
			else
			{
				@class.Add(Enum670.const_4, (num5 < 0f) ? 0f : num5);
			}
		}
		else if (class4750_0.enum676_0 != 0)
		{
			@class.Add(Enum670.const_4, (num5 < 0f) ? 0f : num5);
		}
		class4750_0.class4779_0 = curBlock.Parent;
		if (class4750_0.CurrentElement.Attributes.method_0(Enum670.const_6) && pointF.X >= (float)class4750_0.CurrentElement.Attributes[Enum670.const_6])
		{
			pointF.X = 0f;
		}
		@class.Add(Enum670.const_2, pointF.X);
		PointF pointF2 = curBlock.Parent.method_0(new PointF(curBlock.BoundingBox.Right, curBlock.BoundingBox.Bottom), class4750_0.LeftMargin);
		if (curBlock.LineCount > 1 && !class4750_0.bool_0 && class4750_0.CurrentElement.Attributes.method_0(Enum670.const_6) && curBlock.Parent.BoundingBox.Width < (float)class4750_0.CurrentElement.Attributes[Enum670.const_6])
		{
			float num6 = curBlock.Parent.BoundingBox.Right - getRealWidth - curBlock.BoundingBox.X;
			@class.Add(Enum670.const_3, (num6 < 0f) ? 0f : num6);
		}
		float num7 = 1f + (curBlock.BoundingBox.Width / getRealWidth - 1f) / 5f;
		class4750_0.VerticalExpansion += curBlock.BoundingBox.Height - curBlock.BoundingBox.Height / num7;
		class4750_0.BottomOfLastElement = pointF2.Y;
		Class4779 value = curBlock.method_20(0, 0).Value;
		Class4784 class5 = value as Class4784;
		float num8 = 0f;
		if (class5 != null)
		{
			num8 = class5.method_36();
			RectangleF boundingBox;
			if (!class5.HasSubscript && !class5.HasSuperscript)
			{
				boundingBox = class5.BoundingBox;
			}
			else
			{
				Class4845 class6 = class5.method_33(0);
				boundingBox = class6.Value.BoundingBox;
				if ((Class4860.Instance.Options.UserAgent == Enum678.const_1 || Class4860.Instance.Options.UseNewTextBoxRecognitionAlgorithm) && Class4860.Instance.Options.Mode == Enum676.const_0)
				{
					boundingBox.X = class5.BoundingBox.X;
				}
			}
			float num9 = class4750_0.BottomOfLastElement - boundingBox.Top;
			float num10 = ((!(num9 > 0f) || num9 >= curBlock.FontSize) ? 0f : (class4750_0.BottomOfLastElement - boundingBox.Top));
			@class.Add(Enum670.const_1, boundingBox.Y + num10 - num8);
			@class.Add(Enum670.const_0, boundingBox.X);
			@class.Add(Enum670.const_7, boundingBox.Height + curBlock.FontSize * 1.5f);
		}
		class4785_0 = curBlock;
		return @class;
	}

	private static bool smethod_6(Class4779 node)
	{
		if (!(node is Class4785))
		{
			return node is Class4784;
		}
		return true;
	}

	private static bool smethod_7(Class4779 node)
	{
		return node is Class4790;
	}
}
