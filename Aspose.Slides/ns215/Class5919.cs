using System;
using System.Drawing;
using Aspose.XfaConverter.Elements;
using ns216;

namespace ns215;

internal class Class5919 : Class5916
{
	private bool bool_3;

	public Class5919(Interface249 nativeObj)
		: base(nativeObj)
	{
	}

	internal void method_7(ref Class5916 commonLayout, Class5834 page)
	{
		foreach (Class5914 item in arrayList_0)
		{
			if (item.IsHidden)
			{
				continue;
			}
			if (!bool_3)
			{
				if (item is Class5916)
				{
					((Class5916)item).vmethod_3();
				}
				float num;
				float num2;
				switch (item.AnchorType)
				{
				case XfaEnums.Enum702.const_0:
					num = item.Pos.X;
					num2 = item.Pos.Y;
					break;
				case XfaEnums.Enum702.const_1:
					num = item.Pos.X - item.Size.Width / 2f;
					num2 = item.Pos.Y - item.Size.Height;
					break;
				case XfaEnums.Enum702.const_2:
					num = item.Pos.X;
					num2 = item.Pos.Y - item.Size.Height;
					break;
				case XfaEnums.Enum702.const_3:
					num = item.Pos.X - item.Size.Width;
					num2 = item.Pos.Y - item.Size.Height;
					break;
				case XfaEnums.Enum702.const_4:
					num = item.Pos.X - item.Size.Width / 2f;
					num2 = item.Pos.Y - item.Size.Height / 2f;
					break;
				case XfaEnums.Enum702.const_5:
					num = item.Pos.X;
					num2 = item.Pos.Y - item.Size.Height / 2f;
					break;
				case XfaEnums.Enum702.const_6:
					num = item.Pos.X - item.Size.Width;
					num2 = item.Pos.Y - item.Size.Height / 2f;
					break;
				case XfaEnums.Enum702.const_7:
					num = item.Pos.X - item.Size.Width / 2f;
					num2 = item.Pos.Y;
					break;
				case XfaEnums.Enum702.const_8:
					num = item.Pos.X - item.Size.Width;
					num2 = item.Pos.Y;
					break;
				default:
					throw new ArgumentException();
				}
				item.Pos = new PointF(class5829_0.LeftInset + num, class5829_0.TopInset + num2);
				if (num < 0f)
				{
					num = 0f;
				}
				if (num2 < 0f)
				{
					num2 = 0f;
				}
				if (float_0 < num + item.Size.Width)
				{
					float_0 = Math.Min(method_1(), num + item.Size.Width);
				}
				if (float_1 < num2 + item.Size.Height)
				{
					float_1 = Math.Min(method_2(), num2 + item.Size.Height);
				}
			}
			if (!(item is Class5915) || commonLayout == null)
			{
				continue;
			}
			if (commonLayout.Size.Height > item.Size.Height)
			{
				Class5914[] array = commonLayout.vmethod_2(item.Size.Height, page);
				if (array != null)
				{
					((Class5915)item).Layout = array[0] as Class5916;
					commonLayout = array[1] as Class5916;
				}
				else
				{
					((Class5915)item).Layout = commonLayout;
					commonLayout = null;
				}
			}
			else
			{
				((Class5915)item).Layout = commonLayout;
				commonLayout = null;
			}
		}
		if (!bool_3)
		{
			bool_3 = true;
		}
	}

	internal override void vmethod_3()
	{
		foreach (Class5914 item in arrayList_0)
		{
			if (item is Class5916)
			{
				((Class5916)item).vmethod_3();
			}
			float num;
			float num2;
			switch (item.AnchorType)
			{
			case XfaEnums.Enum702.const_0:
				num = item.Pos.X;
				num2 = item.Pos.Y;
				goto IL_028f;
			case XfaEnums.Enum702.const_1:
				num = item.Pos.X - item.Size.Width / 2f;
				num2 = item.Pos.Y - item.Size.Height;
				goto IL_028f;
			case XfaEnums.Enum702.const_2:
				num = item.Pos.X;
				num2 = item.Pos.Y - item.Size.Height;
				goto IL_028f;
			case XfaEnums.Enum702.const_3:
				num = item.Pos.X - item.Size.Width;
				num2 = item.Pos.Y - item.Size.Height;
				goto IL_028f;
			case XfaEnums.Enum702.const_4:
				num = item.Pos.X - item.Size.Width / 2f;
				num2 = item.Pos.Y - item.Size.Height / 2f;
				goto IL_028f;
			case XfaEnums.Enum702.const_5:
				num = item.Pos.X;
				num2 = item.Pos.Y - item.Size.Height / 2f;
				goto IL_028f;
			case XfaEnums.Enum702.const_6:
				num = item.Pos.X - item.Size.Width;
				num2 = item.Pos.Y - item.Size.Height / 2f;
				goto IL_028f;
			case XfaEnums.Enum702.const_7:
				num = item.Pos.X - item.Size.Width / 2f;
				num2 = item.Pos.Y;
				goto IL_028f;
			case XfaEnums.Enum702.const_8:
				num = item.Pos.X - item.Size.Width;
				num2 = item.Pos.Y;
				goto IL_028f;
			default:
				{
					throw new ArgumentException();
				}
				IL_028f:
				item.Pos = new PointF(class5829_0.LeftInset + num, class5829_0.TopInset + num2);
				if (num < 0f)
				{
					num = 0f;
				}
				if (num2 < 0f)
				{
					num2 = 0f;
				}
				if (float_0 < num + item.Size.Width)
				{
					float_0 = Math.Min(method_1(), num + item.Size.Width);
				}
				if (float_1 < num2 + item.Size.Height)
				{
					float_1 = Math.Min(method_2(), num2 + item.Size.Height);
				}
				break;
			}
		}
		method_0();
	}
}
