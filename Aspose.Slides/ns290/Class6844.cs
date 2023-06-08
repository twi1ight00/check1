using System;
using System.Collections;
using System.Drawing;
using ns284;
using ns301;

namespace ns290;

internal abstract class Class6844 : ICloneable
{
	private Class6844 class6844_0;

	private PointF pointF_0;

	private SizeF sizeF_0;

	private Interface329 interface329_0;

	private string string_0;

	private Interface356 interface356_0;

	public float float_0;

	public float float_1;

	public float float_2;

	public virtual Interface329 Style
	{
		get
		{
			return interface329_0;
		}
		set
		{
			interface329_0 = value;
		}
	}

	public PointF Location
	{
		get
		{
			return pointF_0;
		}
		set
		{
			pointF_0 = value;
		}
	}

	public Interface356 Link
	{
		get
		{
			return interface356_0;
		}
		set
		{
			interface356_0 = value;
		}
	}

	public SizeF Size
	{
		get
		{
			return sizeF_0;
		}
		set
		{
			sizeF_0 = value;
		}
	}

	public Class6844 Parent
	{
		get
		{
			return class6844_0;
		}
		set
		{
			class6844_0 = value;
		}
	}

	public string Tag
	{
		get
		{
			return string_0;
		}
		set
		{
			string_0 = value;
		}
	}

	internal virtual RectangleF OuterBound
	{
		get
		{
			float num = Class6969.smethod_10(Style.MarginRight) + Class6969.smethod_10(Style.PaddingRight) + Class6969.smethod_10(Style.PaddingLeft) + Class6969.smethod_10(Style.MarginLeft);
			if (Style.BorderStyleRight != 0)
			{
				num += Class6969.smethod_10(Style.BorderWidthRight);
			}
			if (Style.BorderStyleLeft != 0)
			{
				num += Class6969.smethod_10(Style.BorderWidthLeft);
			}
			if (Style.BorderTableStyleRight != 0)
			{
				num += Class6969.smethod_10(Style.BorderTableWidthRight);
			}
			if (Style.BorderTableStyleLeft != 0)
			{
				num += Class6969.smethod_10(Style.BorderTableWidthLeft);
			}
			float num2 = Class6969.smethod_10(Style.MarginTop) + Class6969.smethod_10(Style.PaddingTop) + Class6969.smethod_10(Style.PaddingBottom) + Class6969.smethod_10(Style.MarginBottom);
			if (Style.BorderStyleBottom != 0)
			{
				num2 += Class6969.smethod_10(Style.BorderWidthBottom);
			}
			if (Style.BorderStyleTop != 0)
			{
				num2 += Class6969.smethod_10(Style.BorderWidthTop);
			}
			if (Style.BorderTableStyleBottom != 0)
			{
				num2 += Class6969.smethod_10(Style.BorderTableWidthBottom);
			}
			if (Style.BorderTableStyleTop != 0)
			{
				num2 += Class6969.smethod_10(Style.BorderTableWidthTop);
			}
			SizeF size = Size + new SizeF(num, num2);
			return new RectangleF(Location, size);
		}
	}

	public virtual RectangleF InnerBound
	{
		get
		{
			float num = Class6969.smethod_10(Style.MarginLeft) + Class6969.smethod_10(Style.PaddingLeft);
			float num2 = Class6969.smethod_10(Style.MarginTop) + Class6969.smethod_10(Style.PaddingTop);
			if (Style.BorderStyleLeft != 0)
			{
				num += Class6969.smethod_10(Style.BorderWidthLeft);
			}
			if (Style.BorderStyleTop != 0)
			{
				num2 += Class6969.smethod_10(Style.BorderWidthTop);
			}
			if (Style.BorderTableStyleLeft != 0)
			{
				num += Class6969.smethod_10(Style.BorderTableWidthLeft);
			}
			if (Style.BorderTableStyleTop != 0)
			{
				num2 += Class6969.smethod_10(Style.BorderTableWidthTop);
			}
			PointF location = Location + new SizeF(num, num2);
			return new RectangleF(location, Size);
		}
	}

	internal virtual RectangleF PaddingBound
	{
		get
		{
			float num = Class6969.smethod_10(Style.MarginLeft);
			float num2 = Class6969.smethod_10(Style.MarginTop);
			if (Style.BorderStyleLeft != 0)
			{
				num += Class6969.smethod_10(Style.BorderWidthLeft);
			}
			if (Style.BorderStyleTop != 0)
			{
				num2 += Class6969.smethod_10(Style.BorderWidthTop);
			}
			float width = Class6969.smethod_10(Style.PaddingLeft) + Size.Width + Class6969.smethod_10(Style.PaddingRight);
			float height = Class6969.smethod_10(Style.PaddingTop) + Size.Height + Class6969.smethod_10(Style.PaddingBottom);
			PointF location = Location + new SizeF(num, num2);
			return new RectangleF(location, new SizeF(width, height));
		}
	}

	public virtual RectangleF BorderBound
	{
		get
		{
			float width = Class6969.smethod_10(Style.MarginLeft);
			float height = Class6969.smethod_10(Style.MarginTop);
			float num = Class6969.smethod_10(Style.PaddingLeft) + Size.Width + Class6969.smethod_10(Style.PaddingRight);
			float num2 = Class6969.smethod_10(Style.PaddingTop) + Size.Height + Class6969.smethod_10(Style.PaddingBottom);
			if (Style.BorderStyleRight != 0)
			{
				num += Class6969.smethod_10(Style.BorderWidthRight);
			}
			if (Style.BorderStyleLeft != 0)
			{
				num += Class6969.smethod_10(Style.BorderWidthLeft);
			}
			if (Style.BorderStyleBottom != 0)
			{
				num2 += Class6969.smethod_10(Style.BorderWidthBottom);
			}
			if (Style.BorderStyleTop != 0)
			{
				num2 += Class6969.smethod_10(Style.BorderWidthTop);
			}
			if (Style.BorderTableStyleRight != 0)
			{
				num += Class6969.smethod_10(Style.BorderTableWidthRight);
			}
			if (Style.BorderTableStyleLeft != 0)
			{
				num += Class6969.smethod_10(Style.BorderTableWidthLeft);
			}
			if (Style.BorderTableStyleBottom != 0)
			{
				num2 += Class6969.smethod_10(Style.BorderTableWidthBottom);
			}
			if (Style.BorderTableStyleTop != 0)
			{
				num2 += Class6969.smethod_10(Style.BorderTableWidthTop);
			}
			PointF location = Location + new SizeF(width, height);
			return new RectangleF(location, new SizeF(num, num2));
		}
	}

	protected Class6844(Class6844 parent)
	{
		Parent = parent;
		interface329_0 = new Class6897();
	}

	public abstract void vmethod_0(Interface332 visitor, bool boxType, ref Hashtable pageSet);

	public abstract object Clone();
}
