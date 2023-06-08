using System.Collections.Generic;
using System.Drawing;
using ns224;
using ns271;

namespace ns235;

internal class Class6209 : Class6205
{
	private int int_0;

	private List<string> list_0;

	private Class5999 class5999_0 = class5999_1;

	private SizeF sizeF_0 = SizeF.Empty;

	private static readonly Class5999 class5999_1;

	public Class5999 DefaultFont
	{
		get
		{
			return class5999_0;
		}
		set
		{
			class5999_0 = value;
		}
	}

	public List<string> Items
	{
		get
		{
			return list_0;
		}
		set
		{
			list_0 = value;
		}
	}

	public int Value
	{
		get
		{
			return int_0;
		}
		set
		{
			int_0 = value;
		}
	}

	public override RectangleF BoundingBox
	{
		get
		{
			if (!sizeF_0.IsEmpty)
			{
				return new RectangleF(base.Origin, sizeF_0);
			}
			float num = class5999_0.SizePoints;
			float num2 = class5999_0.SizePoints;
			for (int i = 0; i < list_0.Count; i++)
			{
				string text = list_0[i];
				SizeF sizeF = class5999_0.method_4(text);
				if (sizeF.Width > num)
				{
					num = sizeF.Width;
				}
				if (sizeF.Height > num2)
				{
					num2 = sizeF.Height;
				}
			}
			return new RectangleF(base.Origin, new SizeF(num + 3.5f, num2));
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

	public Class6209(PointF origin, string name, List<string> items, int defValue)
		: base(new PointF(origin.X - 1.75f, origin.Y), name)
	{
		list_0 = items;
		int_0 = defValue;
	}

	public Class6209()
	{
	}

	public override void vmethod_0(Class6176 visitor)
	{
		visitor.vmethod_16(this);
	}

	static Class6209()
	{
		class5999_1 = Class6652.Instance.method_1("Times New Roman", 12f, FontStyle.Regular);
	}
}
