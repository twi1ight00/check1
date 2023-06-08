using System;
using System.Drawing;
using ns171;
using ns176;
using ns187;

namespace ns198;

internal class Class5407
{
	private Interface224 interface224_0;

	private Interface172 interface172_0;

	private Size size_0;

	private RectangleF rectangleF_0;

	private Size size_1 = new Size(-1, -1);

	private bool bool_0;

	public Class5407(Interface224 props, Interface172 percentBaseContext, Size intrinsicSize)
	{
		interface224_0 = props;
		interface172_0 = percentBaseContext;
		size_0 = intrinsicSize;
		method_0();
	}

	protected void method_0()
	{
		int num = -1;
		int num2 = -1;
		Interface182 @interface = interface224_0.imethod_3().method_10(interface172_0).vmethod_0();
		if (@interface.imethod_0() != 9)
		{
			num = @interface.imethod_6(interface172_0);
		}
		@interface = interface224_0.imethod_3().method_8(interface172_0).vmethod_0();
		if (num == -1 && @interface.imethod_0() != 9)
		{
			num = @interface.imethod_6(interface172_0);
		}
		@interface = interface224_0.imethod_2().method_10(interface172_0).vmethod_0();
		if (@interface.imethod_0() != 9)
		{
			num2 = @interface.imethod_6(interface172_0);
		}
		@interface = interface224_0.imethod_2().method_8(interface172_0).vmethod_0();
		if (num2 == -1 && @interface.imethod_0() != 9)
		{
			num2 = @interface.imethod_6(interface172_0);
		}
		bool flag = false;
		int cwidth = -1;
		int cheight = -1;
		@interface = interface224_0.imethod_7();
		if (@interface.imethod_0() != 9)
		{
			switch (@interface.imethod_0())
			{
			default:
				cwidth = @interface.imethod_6(interface172_0);
				break;
			case 187:
				if (num2 != -1 && size_0.Width > num2)
				{
					cwidth = num2;
				}
				flag = true;
				break;
			case 188:
				if (num2 != -1 && size_0.Width < num2)
				{
					cwidth = num2;
				}
				flag = true;
				break;
			case 125:
				if (num2 != -1)
				{
					cwidth = num2;
				}
				flag = true;
				break;
			}
		}
		@interface = interface224_0.imethod_6();
		if (@interface.imethod_0() != 9)
		{
			switch (@interface.imethod_0())
			{
			default:
				cheight = @interface.imethod_6(interface172_0);
				break;
			case 187:
				if (num != -1 && size_0.Height > num)
				{
					cheight = num;
				}
				flag = true;
				break;
			case 188:
				if (num != -1 && size_0.Height < num)
				{
					cheight = num;
				}
				flag = true;
				break;
			case 125:
				if (num != -1)
				{
					cheight = num;
				}
				flag = true;
				break;
			}
		}
		Size defaultSize = ((!flag) ? size_0 : method_2(size_0));
		Size size = method_3(cwidth, cheight, defaultSize);
		cwidth = size.Width;
		cheight = size.Height;
		if (num2 == -1)
		{
			num2 = method_1(cwidth, interface224_0.imethod_2(), interface224_0.imethod_7());
		}
		if (num == -1)
		{
			num = method_1(cheight, interface224_0.imethod_3(), interface224_0.imethod_6());
		}
		bool_0 = false;
		switch (interface224_0.imethod_9())
		{
		case 57:
			bool_0 = true;
			break;
		case 42:
			if (cwidth > num2)
			{
			}
			bool_0 = true;
			break;
		}
		int x = method_4(num2, cwidth);
		int y = method_5(num, cheight);
		size_1 = new Size(num2, num);
		rectangleF_0 = new Rectangle(x, y, cwidth, cheight);
	}

	private int method_1(int extent, Class5045 range, Interface182 contextExtent)
	{
		bool flag = contextExtent.imethod_0() != 187;
		bool flag2 = contextExtent.imethod_0() != 188;
		Interface182 @interface = range.method_9(interface172_0).vmethod_0();
		if (@interface.imethod_0() != 9)
		{
			int num = @interface.imethod_6(interface172_0);
			if (num != -1 && flag2)
			{
				extent = Math.Min(extent, num);
			}
		}
		@interface = range.method_8(interface172_0).vmethod_0();
		if (@interface.imethod_0() != 9)
		{
			int num2 = @interface.imethod_6(interface172_0);
			if (num2 != -1 && flag)
			{
				extent = Math.Max(extent, num2);
			}
		}
		return extent;
	}

	private Size method_2(Size size)
	{
		Size result = new Size(size.Height, size.Width);
		int num = method_1(size.Width, interface224_0.imethod_2(), interface224_0.imethod_7());
		int num2 = method_1(size.Height, interface224_0.imethod_3(), interface224_0.imethod_6());
		int num3 = interface224_0.imethod_8();
		if (num3 == 154)
		{
			double num4 = (double)num / (double)size.Width;
			double num5 = (double)num2 / (double)size.Height;
			if (num4 < num5)
			{
				result.Width = num;
				result.Height = (int)(num4 * (double)size.Height);
			}
			else if (num4 > num5)
			{
				result.Width = (int)(num5 * (double)size.Width);
				result.Height = num2;
			}
		}
		else
		{
			result.Width = num;
			result.Height = num2;
		}
		return result;
	}

	private Size method_3(int cwidth, int cheight, Size defaultSize)
	{
		Size result = new Size(cwidth, cheight);
		int num = interface224_0.imethod_8();
		if (num == 154 || cwidth == -1 || cheight == -1)
		{
			if (cwidth == -1 && cheight == -1)
			{
				result.Width = defaultSize.Width;
				result.Height = defaultSize.Height;
			}
			else if (cwidth == -1)
			{
				if (defaultSize.Height == 0)
				{
					result.Width = 0;
				}
				else
				{
					result.Width = (int)((double)defaultSize.Width * (double)cheight / (double)defaultSize.Height);
				}
			}
			else if (cheight == -1)
			{
				if (defaultSize.Width == 0)
				{
					result.Height = 0;
				}
				else
				{
					result.Height = (int)((double)defaultSize.Height * (double)cwidth / (double)defaultSize.Width);
				}
			}
			else if (defaultSize.Width != 0 && defaultSize.Height != 0)
			{
				double num2 = (double)cwidth / (double)defaultSize.Width;
				double num3 = (double)cheight / (double)defaultSize.Height;
				if (num2 < num3)
				{
					result.Height = (int)(num2 * (double)defaultSize.Height);
				}
				else if (num2 > num3)
				{
					result.Width = (int)(num3 * (double)defaultSize.Width);
				}
			}
			else
			{
				result.Width = 0;
				result.Height = 0;
			}
		}
		return result;
	}

	public int method_4(int ipd, int cwidth)
	{
		int result = 0;
		switch (interface224_0.imethod_11())
		{
		case 39:
			result = ipd - cwidth;
			break;
		case 23:
			result = (ipd - cwidth) / 2;
			break;
		}
		return result;
	}

	public int method_5(int bpd, int cheight)
	{
		int result = 0;
		switch (interface224_0.imethod_10())
		{
		case 3:
			result = bpd - cheight;
			break;
		case 23:
			result = (bpd - cheight) / 2;
			break;
		}
		return result;
	}

	public RectangleF method_6()
	{
		return rectangleF_0;
	}

	public Size method_7()
	{
		return size_1;
	}

	public Size method_8()
	{
		return size_0;
	}

	public bool method_9()
	{
		return bool_0;
	}
}
