using System.Drawing;
using ns224;
using ns271;

namespace ns235;

internal class Class6210 : Class6205
{
	private const int int_0 = 0;

	private string string_3 = string.Empty;

	private string string_4 = string.Empty;

	private SizeF sizeF_0 = SizeF.Empty;

	private bool bool_3;

	private int int_1;

	private Class5998 class5998_0 = Class5998.class5998_7;

	private Class5999 class5999_0 = class5999_1;

	private static readonly Class5999 class5999_1;

	private bool bool_4;

	private float float_1;

	public bool IsRichText
	{
		get
		{
			return bool_3;
		}
		set
		{
			bool_3 = value;
		}
	}

	public int MaxLength
	{
		get
		{
			return int_1;
		}
		set
		{
			int_1 = value;
		}
	}

	public string Value
	{
		get
		{
			return string_3;
		}
		set
		{
			string_3 = value;
		}
	}

	public string PlainText
	{
		get
		{
			if (bool_3)
			{
				return string_4;
			}
			return string_3;
		}
		set
		{
			if (bool_3)
			{
				string_4 = value;
			}
			else
			{
				string_3 = value;
			}
		}
	}

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

	public Class5998 FontColor
	{
		get
		{
			return class5998_0;
		}
		set
		{
			class5998_0 = value;
		}
	}

	public override RectangleF BoundingBox => new RectangleF(base.Origin, Size);

	public float LineHeight
	{
		get
		{
			return float_1;
		}
		set
		{
			float_1 = value;
		}
	}

	public bool IsMultiline
	{
		get
		{
			return bool_4;
		}
		set
		{
			bool_4 = value;
		}
	}

	public Class6210(PointF origin, string name, SizeF size, bool isRichText)
		: base(new PointF(origin.X - 1.75f, origin.Y), name)
	{
		sizeF_0 = new SizeF(size.Width + 3.5f, size.Height);
		bool_3 = isRichText;
	}

	public Class6210()
	{
	}

	public override void vmethod_0(Class6176 visitor)
	{
		visitor.vmethod_14(this);
	}

	static Class6210()
	{
		class5999_1 = Class6652.Instance.method_1("Times New Roman", 12f, FontStyle.Regular);
	}
}
