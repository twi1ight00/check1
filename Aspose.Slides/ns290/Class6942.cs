using ns284;
using ns301;

namespace ns290;

internal class Class6942 : Interface351
{
	public Enum946 imethod_0(Class6845 box)
	{
		Class6892.smethod_0(box, "box");
		if (box.InnerBoxes.Count == 0)
		{
			return Enum946.const_1;
		}
		Class6844 box2 = box.InnerBoxes[0];
		return imethod_1(box2);
	}

	public Enum946 imethod_1(Class6844 box)
	{
		Class6892.smethod_0(box, "box");
		switch (box.Style.Display)
		{
		case Enum952.const_15:
			return Enum946.const_2;
		default:
			return Enum946.const_1;
		case Enum952.const_1:
		case Enum952.const_2:
		case Enum952.const_5:
			return Enum946.const_1;
		case Enum952.const_0:
		case Enum952.const_4:
		case Enum952.const_6:
			return Enum946.const_0;
		}
	}

	public Enum946 imethod_2(Interface329 style)
	{
		Class6892.smethod_0(style, "style");
		switch (style.Display)
		{
		case Enum952.const_15:
			return Enum946.const_2;
		default:
			return Enum946.const_1;
		case Enum952.const_1:
		case Enum952.const_2:
		case Enum952.const_5:
			return Enum946.const_1;
		case Enum952.const_0:
		case Enum952.const_4:
		case Enum952.const_6:
			return Enum946.const_0;
		}
	}

	public Class6849 imethod_4(Class6844 box)
	{
		Class6892.smethod_0(box, "box");
		if (box is Class6849 result)
		{
			return result;
		}
		if (box.Parent != null && box.Parent is Class6845)
		{
			Class6845 @class = box.Parent as Class6845;
			while (!(@class is Class6849) && @class.Parent != null)
			{
				if (@class.Parent is Class6845)
				{
					@class = @class.Parent as Class6845;
					continue;
				}
				throw new Exception70();
			}
			return @class as Class6849;
		}
		throw new Exception70();
	}

	public Class6845 imethod_5(Class6844 box)
	{
		Class6892.smethod_0(box, "box");
		if (box.Parent == null)
		{
			return box as Class6845;
		}
		if (!(box.Parent is Class6845))
		{
			throw new Exception70();
		}
		Class6845 @class = box.Parent as Class6845;
		bool flag = imethod_6(@class);
		while (!flag && @class.Parent != null)
		{
			if (@class.Parent is Class6845)
			{
				@class = @class.Parent as Class6845;
				flag = imethod_6(@class);
				continue;
			}
			throw new Exception70();
		}
		return @class;
	}

	public bool imethod_6(Class6844 box)
	{
		Class6892.smethod_0(box, "box");
		if (box.Style.Position != Enum956.const_3 && box.Style.Position != Enum956.const_1)
		{
			return box.Style.Position == Enum956.const_2;
		}
		return true;
	}

	public bool imethod_7(Class6844 box)
	{
		Class6892.smethod_0(box, "box");
		if (box.Style.Position != Enum956.const_1 && box.Style.Position != Enum956.const_2)
		{
			return box.Style.Float == Enum954.const_0;
		}
		return false;
	}

	public Class6845 imethod_3(Class6844 box)
	{
		Class6892.smethod_0(box, "box");
		Class6845 result = box as Class6845;
		if (box is Class6853)
		{
			return result;
		}
		Enum946 @enum = imethod_1(box);
		if (@enum == Enum946.const_1)
		{
			return result;
		}
		if (box.Parent == null)
		{
			return result;
		}
		if (!(box.Parent is Class6845))
		{
			throw new Exception70();
		}
		Class6845 @class = box.Parent as Class6845;
		Enum946 enum2 = imethod_1(@class);
		while (enum2 != Enum946.const_1 && @class.Parent != null)
		{
			if (@class.Parent is Class6845)
			{
				@class = @class.Parent as Class6845;
				enum2 = imethod_1(@class);
				continue;
			}
			throw new Exception70();
		}
		return @class;
	}

	public Enum945 imethod_8(Class6844 box, Class6845 container)
	{
		Class6892.smethod_0(box, "box");
		Class6892.smethod_0(container, "container");
		Enum945 @enum = Enum945.const_0;
		Enum945 enum2 = Enum945.const_0;
		float num = imethod_9(container);
		float num2 = imethod_10(container);
		if (num < box.OuterBound.Width)
		{
			@enum = Enum945.const_2;
		}
		if (num2 < box.OuterBound.Height)
		{
			enum2 = Enum945.const_1;
		}
		if (@enum == enum2)
		{
			return @enum;
		}
		if (@enum == Enum945.const_2)
		{
			if (enum2 == Enum945.const_1)
			{
				return Enum945.const_3;
			}
			return @enum;
		}
		if (enum2 == Enum945.const_1)
		{
			return Enum945.const_1;
		}
		return Enum945.const_0;
	}

	public float imethod_9(Class6845 container)
	{
		Class6892.smethod_0(container, "container");
		float num = container.InnerBound.Width;
		for (int i = 0; i < container.InnerBoxes.Count; i++)
		{
			Class6844 box = container.InnerBoxes[i];
			num -= method_0(box);
		}
		return num;
	}

	public float imethod_10(Class6845 container)
	{
		Class6892.smethod_0(container, "container");
		float num = container.InnerBound.Height;
		if (container.InnerBoxes.Count > 0)
		{
			Class6844 @class = container.InnerBoxes[container.InnerBoxes.Count - 1];
			num -= @class.Location.Y + @class.OuterBound.Height;
		}
		return num;
	}

	public float imethod_11(Class6845 container)
	{
		Class6892.smethod_0(container, "container");
		float num = 0f;
		for (int i = 0; i < container.InnerBoxes.Count; i++)
		{
			Class6844 @class = container.InnerBoxes[i];
			Class6850 class2 = @class as Class6850;
			Class6845 class3 = @class as Class6845;
			if (class2 != null && class2.OuterBound.Width > num)
			{
				num = class2.OuterBound.Width;
			}
			else if (class3 != null)
			{
				float num2 = imethod_11(class3);
				if (num2 > num)
				{
					num = num2;
				}
			}
		}
		return num;
	}

	public float imethod_12(Class6845 container)
	{
		Class6892.smethod_0(container, "container");
		float num = 0f;
		if (container is Class6846 && !container.Style.Width.IsAuto)
		{
			return Class6969.smethod_9(container.Style.Width, container.Parent.InnerBound.Width);
		}
		for (int i = 0; i < container.InnerBoxes.Count; i++)
		{
			Class6844 @class = container.InnerBoxes[i];
			if (@class is Class6845 container2)
			{
				float num2;
				if (@class.Style.Width.IsAuto)
				{
					num2 = imethod_12(container2);
				}
				else
				{
					Enum946 @enum = imethod_1(@class);
					num2 = ((@enum != Enum946.const_1) ? imethod_12(container2) : Class6969.smethod_9(@class.Style.Width, container.InnerBound.Width));
				}
				num2 += imethod_15(@class) + imethod_16(@class);
				if (num2 > num)
				{
					num = num2;
				}
			}
			else if (@class.OuterBound.Width > num)
			{
				num = @class.OuterBound.Width;
			}
		}
		return num;
	}

	public bool imethod_13(Class6844 box)
	{
		Class6892.smethod_0(box, "box");
		if (!(box is Class6845 @class))
		{
			return true;
		}
		if (@class.InnerBoxes.Count == 1)
		{
			return imethod_13(@class.InnerBoxes[0]);
		}
		bool flag = false;
		int num = 0;
		while (true)
		{
			if (num < @class.InnerBoxes.Count)
			{
				Class6844 class2 = @class.InnerBoxes[num];
				if (imethod_13(class2) && flag)
				{
					break;
				}
				if (class2 is Class6855 class3 && class3.IsSpaceBox)
				{
					flag = true;
				}
				num++;
				continue;
			}
			return true;
		}
		return false;
	}

	public bool imethod_14(Class6844 box)
	{
		Class6892.smethod_0(box, "box");
		if (box is Class6845 @class)
		{
			if (@class.InnerBoxes.Count > 1)
			{
				return false;
			}
			if (@class.InnerBoxes.Count == 1)
			{
				return imethod_14(@class.InnerBoxes[0]);
			}
		}
		return true;
	}

	private float method_0(Class6844 box)
	{
		Class6892.smethod_0(box, "box");
		if (!(box is Class6845 @class))
		{
			return box.OuterBound.Width;
		}
		float num = imethod_15(box) + imethod_16(box);
		if (box.Style.Width.IsAuto)
		{
			for (int i = 0; i < @class.InnerBoxes.Count; i++)
			{
				Class6844 box2 = @class.InnerBoxes[i];
				num += method_0(box2);
			}
		}
		else
		{
			num += Class6969.smethod_10(box.Style.Width);
		}
		return num;
	}

	public float imethod_15(Class6844 box)
	{
		Class6892.smethod_0(box, "box");
		float num = Class6969.smethod_10(box.Style.MarginLeft) + Class6969.smethod_10(box.Style.PaddingLeft);
		if (box.Style.BorderStyleLeft != 0)
		{
			num += Class6969.smethod_10(box.Style.BorderWidthLeft);
		}
		if (box.Style.BorderTableStyleLeft != 0)
		{
			num += Class6969.smethod_10(box.Style.BorderTableWidthLeft);
		}
		return num;
	}

	public float imethod_16(Class6844 box)
	{
		Class6892.smethod_0(box, "box");
		float num = Class6969.smethod_10(box.Style.MarginRight) + Class6969.smethod_10(box.Style.PaddingRight);
		if (box.Style.BorderStyleRight != 0)
		{
			num += Class6969.smethod_10(box.Style.BorderWidthRight);
		}
		return num;
	}

	public float imethod_17(Class6844 box)
	{
		Class6892.smethod_0(box, "box");
		float num = Class6969.smethod_10(box.Style.MarginBottom) + Class6969.smethod_10(box.Style.PaddingBottom);
		if (box.Style.BorderStyleBottom != 0)
		{
			num += Class6969.smethod_10(box.Style.BorderWidthBottom);
		}
		if (box.Style.BorderTableStyleBottom != 0)
		{
			num += Class6969.smethod_10(box.Style.BorderTableWidthBottom);
		}
		return num;
	}

	public float imethod_18(Class6844 box)
	{
		Class6892.smethod_0(box, "box");
		float num = Class6969.smethod_10(box.Style.MarginTop) + Class6969.smethod_10(box.Style.PaddingTop);
		if (box.Style.BorderStyleTop != 0)
		{
			num += Class6969.smethod_10(box.Style.BorderWidthTop);
		}
		if (box.Style.BorderTableStyleTop != 0)
		{
			num += Class6969.smethod_10(box.Style.BorderTableWidthTop);
		}
		return num;
	}
}
