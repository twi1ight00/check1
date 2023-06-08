using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using ns301;

namespace ns290;

internal class Class6919 : Interface340
{
	private readonly Interface351 interface351_0;

	private readonly Interface341 interface341_0;

	private float float_0;

	public Class6919(Interface351 boxInfo, Interface341 blockSplitter)
	{
		Class6892.smethod_0(boxInfo, "boxInfo");
		Class6892.smethod_0(blockSplitter, "blockSplitter");
		interface351_0 = boxInfo;
		interface341_0 = blockSplitter;
	}

	public Class6844 imethod_0(Class6844 box, Class6845 container)
	{
		Class6892.smethod_0(container, "container");
		Class6892.smethod_0(box, "box");
		Enum945 @enum = interface351_0.imethod_8(box, container);
		switch (@enum)
		{
		default:
			throw new ArgumentOutOfRangeException(string.Format(CultureInfo.InvariantCulture, "The isFit is out of range: {0}", new object[1] { @enum }));
		case Enum945.const_0:
		case Enum945.const_2:
			method_5(box, container);
			return null;
		case Enum945.const_1:
		case Enum945.const_3:
			if (interface351_0.imethod_14(box) && container.InnerBoxes.Count == 0)
			{
				method_5(box, container);
				return null;
			}
			return method_0(box, container);
		}
	}

	private Class6844 method_0(Class6844 box, Class6845 container)
	{
		Class6892.smethod_0(container, "container");
		Class6892.smethod_0(box, "box");
		Enum945 @enum = interface351_0.imethod_8(box, container);
		switch (@enum)
		{
		default:
			throw new ArgumentOutOfRangeException(string.Format(CultureInfo.InvariantCulture, "The isFit is out of range: {0}", new object[1] { @enum }));
		case Enum945.const_0:
		case Enum945.const_2:
			method_5(box, container);
			return null;
		case Enum945.const_1:
		case Enum945.const_3:
			if (box is Class6854 container2)
			{
				return method_2(container2, container);
			}
			if (box is Class6853 container3)
			{
				return method_3(container3, container);
			}
			if (box is Class6851 container4)
			{
				return method_4(container4, container);
			}
			return method_1(box, container);
		}
	}

	private Class6844 method_1(Class6844 box, Class6845 parentContainer)
	{
		if (box is Class6845 @class && !(box is Class6850))
		{
			float height = interface351_0.imethod_10(parentContainer);
			IList list = interface341_0.imethod_0(@class, height);
			Class6845 class2 = (Class6845)list[0];
			Class6845 class3 = (Class6845)list[1];
			Class6844 result = null;
			bool flag = false;
			float num = float_0;
			for (int i = 0; i < @class.InnerBoxes.Count; i++)
			{
				Class6844 class4 = @class.InnerBoxes[i];
				if (!flag)
				{
					Class6844 class5 = method_0(class4, class2);
					if (class5 != null)
					{
						if (class2.InnerBoxes.Count > 0)
						{
							float height2 = class2.Size.Height;
							smethod_0(class2);
							float num2 = height2 - class2.Size.Height;
							class5.Size = new SizeF(class5.Size.Width, class5.Size.Height + num2);
							class5.Location = new PointF(class5.Location.X, class5.Location.Y - num2);
						}
						float_0 = class5.Location.Y;
						flag = true;
						method_5(class5, class3);
						result = class3;
					}
				}
				else
				{
					method_5(class4, class3);
				}
			}
			float_0 = num;
			if (class2 != null && class2.InnerBoxes.Count > 0)
			{
				method_5(class2, parentContainer);
			}
			return result;
		}
		return box;
	}

	private Class6844 method_2(Class6854 container, Class6845 parentContainer)
	{
		float height = interface351_0.imethod_10(parentContainer);
		IList list = interface341_0.imethod_0(container, height);
		Class6845 @class = (Class6845)list[0];
		Class6845 class2 = (Class6845)list[1];
		Class6844 result = null;
		float num = float_0;
		List<Class6844> list2 = new List<Class6844>();
		for (int i = 0; i < container.InnerBoxes.Count; i++)
		{
			Class6844 box = container.InnerBoxes[i];
			Class6844 class3 = method_0(box, @class);
			if (class3 != null)
			{
				list2.Add(class3);
				if (@class.InnerBoxes.Count > 0)
				{
					float height2 = @class.Size.Height;
					smethod_0(@class);
					float num2 = height2 - @class.Size.Height;
					class3.Size = new SizeF(class3.Size.Width, class3.Size.Height + num2);
					class3.Location = new PointF(class3.Location.X, class3.Location.Y - num2);
				}
				float_0 = 0f;
				method_5(class3, class2);
			}
		}
		float_0 = num;
		if (@class != null && @class.InnerBoxes.Count > 0)
		{
			method_5(@class, parentContainer);
		}
		if (list2.Count > 0)
		{
			for (int j = 0; j < list2.Count; j++)
			{
				Class6844 class4 = list2[j];
				container.InnerBoxes.Add(class4);
				class4.Location = new PointF(class4.Location.X, 0f);
				class4.Parent = container;
			}
			result = class2;
		}
		return result;
	}

	private Class6844 method_3(Class6853 container, Class6845 parentContainer)
	{
		Class6845 @class = new Class6845(null);
		@class.Size = parentContainer.Size;
		float height = interface351_0.imethod_10(@class);
		IList list = interface341_0.imethod_0(container, height);
		Class6845 class2 = (Class6845)list[0];
		Class6845 class3 = (Class6845)list[1];
		Class6844 result = null;
		bool flag = false;
		float num = float_0;
		for (int i = 0; i < container.InnerBoxes.Count; i++)
		{
			Class6844 class4 = container.InnerBoxes[i];
			if (!flag)
			{
				Class6844 class5 = method_0(class4, class2);
				if (class5 != null)
				{
					if (class2.InnerBoxes.Count > 0)
					{
						float height2 = class2.Size.Height;
						smethod_0(class2);
						float num2 = height2 - class2.Size.Height;
						class5.Size = new SizeF(class5.Size.Width, class5.Size.Height + num2);
						class5.Location = new PointF(class5.Location.X, class5.Location.Y - num2);
					}
					float_0 = class5.Location.Y;
					flag = true;
					method_5(class5, class3);
					result = class3;
				}
			}
			else
			{
				method_5(class4, class3);
			}
		}
		float_0 = num;
		if (class2 != null && class2.InnerBoxes.Count > 0)
		{
			method_5(class2, parentContainer);
		}
		return result;
	}

	private Class6844 method_4(Class6851 container, Class6845 parentContainer)
	{
		float height = interface351_0.imethod_10(parentContainer);
		IList list = interface341_0.imethod_0(container, height);
		Class6845 @class = (Class6845)list[0];
		Class6845 class2 = (Class6845)list[1];
		Class6844 result = null;
		float num = float_0;
		List<Class6844> list2 = new List<Class6844>();
		for (int i = 0; i < container.InnerBoxes.Count; i++)
		{
			Class6844 box = container.InnerBoxes[i];
			Class6844 class3 = method_0(box, @class);
			if (class3 != null)
			{
				list2.Add(class3);
				if (@class.InnerBoxes.Count > 0)
				{
					float height2 = @class.Size.Height;
					smethod_0(@class);
					float num2 = height2 - @class.Size.Height;
					class3.Size = new SizeF(class3.Size.Width, class3.Size.Height + num2);
					class3.Location = new PointF(class3.Location.X, class3.Location.Y - num2);
				}
				float_0 = 0f;
				method_5(class3, class2);
			}
		}
		float_0 = num;
		if (@class != null && @class.InnerBoxes.Count > 0)
		{
			method_5(@class, parentContainer);
		}
		if (list2.Count > 0)
		{
			for (int j = 0; j < list2.Count; j++)
			{
				Class6844 class4 = list2[j];
				container.InnerBoxes.Add(class4);
				class4.Location = new PointF(class4.Location.X, 0f);
				class4.Parent = container;
			}
			result = class2;
		}
		return result;
	}

	private static void smethod_0(Class6845 container)
	{
		if (container.InnerBoxes.Count >= 1)
		{
			Class6844 @class = container.InnerBoxes[container.InnerBoxes.Count - 1];
			float height = @class.Location.Y + @class.OuterBound.Height;
			container.Size = new SizeF(container.Size.Width, height);
		}
	}

	private void method_5(Class6844 innerBox, Class6845 container)
	{
		container.InnerBoxes.Add(innerBox);
		innerBox.Location = new PointF(innerBox.Location.X, innerBox.Location.Y - float_0);
		innerBox.Parent = container;
	}
}
