using System;
using System.Drawing;
using Aspose.XfaConverter.Elements;
using ns216;
using ns217;
using ns224;
using ns235;

namespace ns215;

internal class Class5926
{
	private Class5783 class5783_0;

	private bool bool_0;

	private SizeF sizeF_0 = SizeF.Empty;

	private SizeF sizeF_1 = SizeF.Empty;

	internal Class5926(Class5783 owner)
	{
		class5783_0 = owner;
	}

	public void method_0()
	{
		bool_0 = false;
	}

	private SizeF method_1()
	{
		float num = 0f;
		float num2 = 0f;
		Interface250 @interface = class5783_0 as Interface250;
		if (!sizeF_1.IsEmpty)
		{
			if (@interface.W == 0f)
			{
				num += sizeF_1.Width;
			}
			if (@interface.H == 0f)
			{
				num2 += sizeF_1.Height;
			}
		}
		if (!sizeF_0.IsEmpty)
		{
			if (@interface.W == 0f)
			{
				num += sizeF_0.Width;
			}
			if (@interface.H == 0f)
			{
				num2 = Math.Max(num2, sizeF_0.Height);
			}
		}
		return new SizeF((@interface.W == 0f) ? Math.Max(@interface.MinW, num) : @interface.W, (@interface.H == 0f) ? Math.Max(@interface.MinH, num2) : @interface.H);
	}

	public SizeF method_2()
	{
		if (bool_0)
		{
			return method_1();
		}
		bool_0 = true;
		Interface250 @interface = class5783_0 as Interface250;
		SizeF sizeF = new SizeF(@interface.W, @interface.H);
		SizeF sizeF2 = SizeF.Empty;
		Class5820 @class = class5783_0.method_6(Class5820.Tag) as Class5820;
		Class5829 margin = class5783_0.method_6(Class5829.Tag) as Class5829;
		Class5836 para = class5783_0.method_6(Class5836.Tag) as Class5836;
		if (class5783_0.method_6(Class5855.Tag) is Class5855 class2)
		{
			Class5798 class3 = (Class5798)class2.Nodes.method_3(Class5798.Tag);
			if (class3 != null)
			{
				sizeF2 = new SizeF(class3.Size, class3.Size);
			}
		}
		Class5796 class4 = class5783_0.method_6(Class5796.Tag) as Class5796;
		Class5889 class5 = null;
		Class5869 class6 = null;
		if (class4 != null)
		{
			if (class4.method_6(Class5893.Tag) is Class5893 class7)
			{
				class5 = class7.Nodes.method_3("text") as Class5889;
				if (class5 == null)
				{
					class6 = class7.Nodes.method_3("exData") as Class5869;
				}
				if (class5 != null || class6 != null)
				{
					Class5820 class8 = class4.method_6(Class5820.Tag) as Class5820;
					if (class8 == null)
					{
						class8 = @class;
					}
					Class5913 class9 = new Class5913();
					if (class8 != null)
					{
						class9.Add(Enum739.const_0, class8.Typeface);
						class9.Add(Enum739.const_1, class8.Size);
						class9.Add(Enum739.const_2, class8.Posture);
						class9.Add(Enum739.const_3, class8.Weight);
					}
					Class5829 margin2 = class4.method_6(Class5829.Tag) as Class5829;
					Class5836 class10 = class4.method_6(Class5836.Tag) as Class5836;
					if (class10 != null)
					{
						class9.Add(Enum739.const_18, class10.VAlign);
					}
					SizeF size = sizeF;
					if (!sizeF2.IsEmpty)
					{
						size = new SizeF(size.Width - sizeF2.Width, Math.Max(sizeF2.Height, size.Height));
					}
					switch (class4.Placement)
					{
					case XfaEnums.Enum691.const_0:
					case XfaEnums.Enum691.const_3:
						if (class4.Reserve != -1f)
						{
							size = new SizeF(class4.Reserve, size.Height);
						}
						break;
					case XfaEnums.Enum691.const_1:
					case XfaEnums.Enum691.const_4:
						if (class4.Reserve != -1f)
						{
							size = new SizeF(size.Width, class4.Reserve);
						}
						break;
					}
					Class5998 color = Class5998.class5998_7;
					if (class5783_0.method_0("#font.#fill.#color") is Class5800 class11)
					{
						color = class11.method_8();
					}
					Class5873 hyphenation = class5783_0.method_0("#para.#hyphenation") as Class5873;
					if (class5 != null)
					{
						sizeF_1 = class5.Initialize(class9, class10, margin2, new Class5927(size), color, hyphenation, class5783_0);
					}
					else
					{
						sizeF_1 = class6.Initialize(class9, class10, margin2, new Class5927(size), color, hyphenation, class5783_0);
					}
				}
			}
		}
		else if (class5783_0.method_6(Class5893.Tag) is Class5893 class12)
		{
			Class5998 color2 = Class5998.class5998_7;
			if (class5783_0.method_0("#font.#fill.#color") is Class5800 class13)
			{
				color2 = class13.method_8();
			}
			Class5873 hyphenation2 = class5783_0.method_0("#para.#hyphenation") as Class5873;
			class5 = class12.Nodes.method_3("text") as Class5889;
			if (class5 == null)
			{
				class6 = class12.Nodes.method_3("exData") as Class5869;
			}
			if (class5 != null || class6 != null)
			{
				Class5913 class14 = new Class5913();
				if (@class != null)
				{
					class14.Add(Enum739.const_0, @class.Typeface);
					class14.Add(Enum739.const_1, @class.Size);
					class14.Add(Enum739.const_2, @class.Posture);
					class14.Add(Enum739.const_3, @class.Weight);
				}
				if (class5 != null)
				{
					sizeF_1 = class5.Initialize(class14, para, margin, @interface, color2, hyphenation2, class5783_0);
				}
				else
				{
					sizeF_1 = class6.Initialize(class14, para, margin, @interface, color2, hyphenation2, class5783_0);
				}
			}
		}
		return method_1();
	}

	internal void method_3(Class5912 builder, PointF pos, SizeF size)
	{
		Class5855 @class = class5783_0.method_6(Class5855.Tag) as Class5855;
		Interface253 @interface = null;
		if (@class != null)
		{
			foreach (Class5781 item in @class.Nodes.List)
			{
				@interface = item as Interface253;
				if (@interface != null)
				{
					break;
				}
			}
			if (@interface != null)
			{
				method_4(@interface, builder, pos, size);
				return;
			}
		}
		method_4(@interface, builder, pos, size);
		if (class5783_0.method_6(Class5893.Tag) is Class5893 class2 && class2.Nodes.method_3(Class5874.Tag) is Class5874 class3)
		{
			class3.method_6(builder, pos, size);
		}
	}

	internal void method_4(Interface253 control, Class5912 builder, PointF pos, SizeF size)
	{
		Class6213 @class = new Class6213();
		Class5829 class2 = class5783_0.method_6(Class5829.Tag) as Class5829;
		float num = 0f;
		float num2 = 0f;
		float num3 = 0f;
		float num4 = 0f;
		method_7(@class, pos, size);
		method_5(@class, pos, size);
		method_6(@class, pos, size);
		Class5796 class3 = class5783_0.method_6(Class5796.Tag) as Class5796;
		if (class3 != null)
		{
			switch (class3.Placement)
			{
			case XfaEnums.Enum691.const_0:
				num = pos.X;
				if (class2 != null)
				{
					num += class2.LeftInset;
				}
				num += 1E-06f;
				break;
			case XfaEnums.Enum691.const_1:
				num4 = pos.Y + size.Height - sizeF_1.Height;
				if (class2 != null)
				{
					num4 -= class2.BottomInset;
				}
				num4 += 1E-06f;
				break;
			case XfaEnums.Enum691.const_3:
				num2 = pos.X + size.Width - sizeF_1.Width;
				if (class2 != null)
				{
					num2 -= class2.RightInset;
				}
				num2 += 1E-06f;
				break;
			case XfaEnums.Enum691.const_4:
				num3 = pos.Y;
				if (class2 != null)
				{
					num3 += class2.TopInset;
				}
				num3 += 1E-06f;
				break;
			}
		}
		Class5836 class4 = class5783_0.method_6(Class5836.Tag) as Class5836;
		float num5 = pos.X;
		float num6 = pos.Y;
		float num7 = pos.X;
		float num8 = pos.Y;
		if (control is Class5799 || control is Class5889 || control is Class5798)
		{
			SizeF sizeF = size;
			if (control is Class5798 class5)
			{
				sizeF = new SizeF(class5.Size, class5.Size);
			}
			float num9 = 0f;
			float num10 = 0f;
			float num11 = 0f;
			float num12 = 0f;
			if (class2 != null && class3 != null)
			{
				num9 = class2.TopInset;
				num10 = class2.BottomInset;
				num11 = class2.LeftInset;
				num12 = class2.RightInset;
			}
			if (class4 != null)
			{
				switch (class4.VAlign)
				{
				case XfaEnums.Enum720.const_0:
					if (num4 != 0f)
					{
						num8 += num9;
					}
					else if (num3 != 0f)
					{
						num8 = num3 + sizeF_1.Height;
					}
					else
					{
						num6 = (num8 += num9);
					}
					break;
				case XfaEnums.Enum720.const_1:
					if (num4 != 0f)
					{
						num8 = num4 - sizeF.Height;
						break;
					}
					if (num3 != 0f)
					{
						num8 = num3 + sizeF_1.Height;
						break;
					}
					num8 += size.Height - sizeF.Height;
					num6 += size.Height - sizeF_1.Height;
					num8 -= num10;
					num6 -= num10;
					break;
				case XfaEnums.Enum720.const_2:
					if (num4 != 0f)
					{
						num8 += size.Height / 2f - (sizeF_1.Height - sizeF.Height) / 2f;
						break;
					}
					if (num3 != 0f)
					{
						num8 += sizeF_1.Height + size.Height / 2f - (sizeF_1.Height - sizeF.Height) / 2f;
						break;
					}
					num8 += size.Height / 2f - sizeF.Height / 2f;
					num6 += size.Height / 2f - sizeF_1.Height / 2f;
					break;
				}
				switch (class4.HAlign)
				{
				case XfaEnums.Enum719.const_0:
					if (num != 0f)
					{
						num7 = num + sizeF_1.Width;
						break;
					}
					if (num2 != 0f)
					{
						num7 += num11;
						break;
					}
					num5 += num11;
					num7 += num11;
					break;
				case XfaEnums.Enum719.const_1:
					if (num != 0f)
					{
						num7 += sizeF_1.Width + size.Width / 2f - (sizeF_1.Width - sizeF.Width) / 2f;
						break;
					}
					if (num2 != 0f)
					{
						num7 += size.Width / 2f - (sizeF_1.Width - sizeF.Width) / 2f;
						break;
					}
					num7 += size.Width / 2f - sizeF_1.Width / 2f;
					num5 += size.Width / 2f - sizeF.Width / 2f;
					break;
				case XfaEnums.Enum719.const_2:
				case XfaEnums.Enum719.const_3:
				case XfaEnums.Enum719.const_4:
					if (num != 0f)
					{
						num7 = num + sizeF_1.Width;
						break;
					}
					if (num2 != 0f)
					{
						num7 += num11;
						break;
					}
					num5 += num11;
					num7 += num11;
					break;
				case XfaEnums.Enum719.const_5:
					if (num != 0f)
					{
						num7 += size.Width - sizeF.Width;
						num7 -= num12;
						break;
					}
					if (num2 != 0f)
					{
						num7 = num2 - sizeF.Width;
						break;
					}
					num5 += size.Width - sizeF_1.Width;
					num7 += size.Width - sizeF.Width;
					num7 -= num12;
					num5 -= num12;
					break;
				}
			}
			else
			{
				if (num != 0f)
				{
					num7 = num + sizeF_1.Width;
				}
				else if (num2 != 0f)
				{
					num7 += num11;
				}
				else
				{
					num5 += num11;
					num7 += num11;
				}
				if (num4 != 0f)
				{
					num8 += num9;
				}
				else if (num3 != 0f)
				{
					num8 = num3 + sizeF_1.Height;
				}
				else
				{
					num6 = (num8 += num9);
				}
			}
		}
		Class6213 class6 = null;
		if (class3 != null)
		{
			Class5893 value = class3.method_6(Class5893.Tag) as Class5893;
			Class6213 class7 = smethod_0(size, num4, num, num2, num3, num6, num5, value);
			if (class7 != null)
			{
				@class.Add(class7);
			}
		}
		else
		{
			Class5893 value = class5783_0.method_6(Class5893.Tag) as Class5893;
			class6 = smethod_0(size, num4, num, num2, num3, num6, num5, value);
		}
		if (control != null)
		{
			if (control is Class5799)
			{
				size = new SizeF(size.Width - num7 + pos.X, size.Height);
			}
			control.imethod_0(@class, class6, builder, new PointF(num7, num8), size);
		}
		else
		{
			builder.method_5(@class);
			if (class6 != null)
			{
				builder.method_5(class6);
			}
		}
	}

	private static Class6213 smethod_0(SizeF size, float cyb, float cxl, float cxr, float cyt, float y, float x, Class5893 value)
	{
		Class6213 @class = null;
		if (value != null)
		{
			@class = new Class6213();
			PointF pos = new PointF((cxl != 0f) ? cxl : ((cxr != 0f) ? cxr : x), (cyt != 0f) ? cyt : ((cyb != 0f) ? cyb : y));
			if (value.Nodes.method_3("text") is Class5889 class2)
			{
				class2.method_6(@class, pos, size);
			}
			else if (value.Nodes.method_3("exData") is Class5869 class3)
			{
				class3.method_6(@class, pos, size);
			}
		}
		return @class;
	}

	private void method_5(Class6213 canvas, PointF pos, SizeF size)
	{
		Class5842 @class = class5783_0.method_6(Class5842.Tag) as Class5842;
		if (@class == null && class5783_0.method_6(Class5893.Tag) is Class5893 class2)
		{
			@class = class2.Nodes.method_3(Class5842.Tag) as Class5842;
		}
		@class?.method_8(canvas, pos, size);
	}

	private void method_6(Class6213 canvas, PointF pos, SizeF size)
	{
		Class5826 @class = class5783_0.method_6(Class5826.Tag) as Class5826;
		if (@class == null && class5783_0.method_6(Class5893.Tag) is Class5893 class2)
		{
			@class = class2.Nodes.method_3(Class5826.Tag) as Class5826;
		}
		@class?.method_8(canvas, pos, size);
	}

	private void method_7(Class6213 canvas, PointF pos, SizeF size)
	{
		if (class5783_0.method_6(Class5790.Tag) is Class5790 @class)
		{
			@class.method_8(canvas, pos, size);
		}
	}
}
