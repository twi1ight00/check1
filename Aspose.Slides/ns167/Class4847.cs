using System;
using System.Collections;
using System.Drawing;
using System.Text;
using ns161;
using ns166;
using ns224;
using ns235;
using ns271;

namespace ns167;

internal class Class4847
{
	private class Class4848 : IComparer
	{
		public int Compare(object a, object b)
		{
			Class4847 @class = a as Class4847;
			Class4847 class2 = b as Class4847;
			float num = 0f;
			float num2 = 0f;
			if (@class != null && class2 != null)
			{
				num = @class.OffsetX;
				num2 = class2.OffsetX;
			}
			else
			{
				if (@class == null)
				{
					if (!(a is Class4790 class3))
					{
						throw new ArgumentException("Please report exception. TextLine flow output failed.");
					}
					num = class3.BoundingBox.X;
				}
				else
				{
					num = @class.OffsetX;
				}
				if (class2 == null)
				{
					if (!(b is Class4790 class4))
					{
						throw new ArgumentException("Please report exception. TextLine flow output failed.");
					}
					num2 = class4.BoundingBox.X;
				}
				else
				{
					num2 = class2.OffsetX;
				}
			}
			if (Class4778.smethod_0(num, num2))
			{
				return 0;
			}
			if (num < num2)
			{
				return -1;
			}
			return 1;
		}
	}

	private SizeF sizeF_0 = SizeF.Empty;

	private ArrayList arrayList_0 = new ArrayList();

	internal string string_0;

	private bool bool_0;

	private Class4786.Class4849 class4849_0;

	private string string_1;

	private float float_0;

	private Enum674 enum674_0;

	private float float_1;

	private string string_2;

	private Class5999 class5999_0;

	private Enum672 enum672_0;

	private RectangleF rectangleF_0;

	private Class5998 class5998_0;

	private Class6270 class6270_0;

	private float float_2;

	private float float_3;

	public bool IsInvisible
	{
		get
		{
			return bool_0;
		}
		set
		{
			bool_0 = value;
		}
	}

	public ArrayList TabsPosArray => arrayList_0;

	internal Class4786.Class4849 LineRef => class4849_0;

	internal float WordSpacing
	{
		get
		{
			return float_2;
		}
		set
		{
			float_2 = value;
		}
	}

	internal string Text
	{
		get
		{
			return string_1;
		}
		set
		{
			string_1 = value;
		}
	}

	internal float OffsetX => float_0;

	internal Enum674 Type => enum674_0;

	internal float FontSize
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

	internal string FontFace => string_2;

	internal Class5999 Font => class5999_0;

	internal Enum672 Style => enum672_0;

	internal RectangleF BoundingBox => rectangleF_0;

	internal Class5998 Color => class5998_0;

	public SizeF ActualSize
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

	internal Class6270 Hyperlink
	{
		get
		{
			return class6270_0;
		}
		set
		{
			class6270_0 = value;
		}
	}

	public float LetterSpacing
	{
		get
		{
			return float_3;
		}
		set
		{
			float_3 = value;
		}
	}

	internal Class4847(Class4791 piece, Enum674 type)
	{
		string_1 = piece.Text;
		string_0 = piece.method_2().Id;
		float_0 = piece.Origin.X;
		enum674_0 = type;
		class4849_0 = piece.LineRef;
		class5999_0 = piece.Font;
		rectangleF_0 = piece.BoundingBox;
		class5998_0 = piece.Color;
		class6270_0 = piece.method_2().Hyperlink;
		bool_0 = piece.IsInvisible;
		sizeF_0 = piece.Font.method_4(piece.Text);
		if (sizeF_0.Width > rectangleF_0.Size.Width)
		{
			sizeF_0 = rectangleF_0.Size;
		}
	}

	internal bool method_0(object otherEl)
	{
		if (otherEl is Class4847 @class)
		{
			if (!method_1(@class))
			{
				return false;
			}
			if (Class4860.Instance.Options.UserAgent == Enum678.const_1 && Class4860.Instance.Options.Mode == Enum676.const_0)
			{
				return Class6270.Equals(Hyperlink, @class.Hyperlink);
			}
			if (Hyperlink == null)
			{
				return @class.Hyperlink == null;
			}
			return false;
		}
		return false;
	}

	internal bool method_1(Class4847 el)
	{
		if (Type == el.Type && Class4844.smethod_0(Font, el.Font) && FontSize == el.FontSize && FontFace == el.FontFace && Style == el.Style && class5998_0 == el.class5998_0)
		{
			return IsInvisible == el.IsInvisible;
		}
		return false;
	}

	internal static IComparer smethod_0()
	{
		return new Class4848();
	}

	internal string method_2(float boundary, float blockRightBoundary, ref float delta, ArrayList tabsPosArray, float firstOffset, Enum676 mode)
	{
		StringBuilder stringBuilder = new StringBuilder();
		float num = OffsetX - boundary;
		float num2 = method_3();
		if (num / num2 > 0.6f && (delta + num) / num2 > 0.6f)
		{
			num += delta;
			delta = 0f;
		}
		double num3 = num / num2;
		if (num3 > 2.0 && mode != 0)
		{
			tabsPosArray.Add(new float[3]
			{
				OffsetX,
				OffsetX - firstOffset,
				(float)num3
			});
			delta = 0f;
			return "\t";
		}
		int num4 = 0;
		if (num3 > 0.6000000238418579)
		{
			int num5 = (int)Math.Floor(num3);
			num4 = ((blockRightBoundary != -1f) ? ((!(num3 - (double)num5 > 0.6000000238418579) || num2 * (float)(num5 + 1) + OffsetX + ActualSize.Width >= blockRightBoundary) ? num5 : (num5 + 1)) : ((num3 - (double)num5 > 0.6000000238418579) ? (num5 + 1) : num5));
			for (int i = 0; i < num4; i++)
			{
				stringBuilder.Append(' ');
			}
		}
		if (num > 0f)
		{
			delta -= (float)num4 * num2 - num;
		}
		return stringBuilder.ToString();
	}

	internal float method_3()
	{
		FontStyle fontStyle = FontStyle.Regular;
		if ((Style & Enum672.flag_2) == Enum672.flag_2)
		{
			fontStyle |= FontStyle.Bold;
		}
		if ((Style & Enum672.flag_3) == Enum672.flag_3)
		{
			fontStyle |= FontStyle.Italic;
		}
		Class5999 @class = ((class5999_0 != null) ? class5999_0 : Class6652.Instance.method_1(FontFace, FontSize, fontStyle));
		return @class.method_4(" ").Width;
	}
}
