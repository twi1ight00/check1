using System;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using x13f1efc79617a47b;
using x28925c9b27b37a46;
using x5794c252ba25e723;
using x6c95d9cf46ff5f25;

namespace Aspose.Words;

public class Border : x11e014059489ae95
{
	private const int xbb1c5a9c8041995b = 31;

	private const int xb5a99fa9616a578f = 31;

	private x0e9935be205598e7 xc454c03c23d4b4d9;

	private int x824f14e92de69876;

	private LineStyle x8001c24628d75f20;

	private int x63d304957e61360d;

	private x26d9ecb4bdf0456d x78e4acec873c7675 = x26d9ecb4bdf0456d.x45260ad4b94166f2;

	private int xcc90e70e24c6529e;

	private bool xf78e2d39ff927920;

	private bool x57e44a48db954d01;

	private string x43cc04205601f9c7;

	private string x74fb49f5adf29cac;

	private string xecdbc80736a31aa5;

	private static readonly Hashtable x2de42ed7716de792;

	private static readonly Hashtable xce921039b6ed7574;

	private static readonly Hashtable x6d36d0b4f2f696a8;

	private static readonly Hashtable x4e19e9f17854726a;

	private static readonly Hashtable xeb1a966c22da78d3;

	internal static readonly Border x45260ad4b94166f2;

	public LineStyle LineStyle
	{
		get
		{
			if (!xa157de8185757b11)
			{
				return x8001c24628d75f20;
			}
			return x144aa4462fe3ef7c.LineStyle;
		}
		set
		{
			xea38c993925dfec4();
			x8001c24628d75f20 = value;
			if (value == LineStyle.None)
			{
				LineWidth = 0.0;
			}
		}
	}

	public double LineWidth
	{
		get
		{
			if (xa157de8185757b11)
			{
				return x144aa4462fe3ef7c.LineWidth;
			}
			if (!xbca512cb9f5a451a)
			{
				return x4574ea26106f0edb.x30719d7103d96aa2(x63d304957e61360d);
			}
			return x63d304957e61360d;
		}
		set
		{
			x2c9fcc269cdca9d1(value, x9199ed88324d69ff: true);
		}
	}

	internal double x32e26c85d00febce
	{
		get
		{
			double lineWidth = LineWidth;
			if (lineWidth != 0.0 || !IsVisible)
			{
				return lineWidth;
			}
			return 0.25;
		}
	}

	internal bool xbca512cb9f5a451a => LineStyle >= (LineStyle)64;

	public bool IsVisible => LineStyle != LineStyle.None;

	internal float xeae235558dc44397 => xb556d1cd3d419a11(LineStyle, (float)x32e26c85d00febce);

	internal float x9f8e9e93501d1d42
	{
		get
		{
			if (IsVisible)
			{
				float num = xeae235558dc44397;
				if (Shadow)
				{
					num *= 2f;
				}
				return num + (float)DistanceFromText;
			}
			return 0f;
		}
	}

	public Color Color
	{
		get
		{
			return x63b1a7c31a962459.xc7656a130b2889c7();
		}
		set
		{
			x63b1a7c31a962459 = x26d9ecb4bdf0456d.xcd907c08c553c15c(value);
		}
	}

	internal x26d9ecb4bdf0456d x63b1a7c31a962459
	{
		get
		{
			if (!xa157de8185757b11)
			{
				return x78e4acec873c7675;
			}
			return x144aa4462fe3ef7c.x63b1a7c31a962459;
		}
		set
		{
			xea38c993925dfec4();
			x78e4acec873c7675 = value;
		}
	}

	public double DistanceFromText
	{
		get
		{
			if (!xa157de8185757b11)
			{
				return xcc90e70e24c6529e;
			}
			return x144aa4462fe3ef7c.DistanceFromText;
		}
		set
		{
			xa722e16a6e8b99ec(value, x9199ed88324d69ff: true);
		}
	}

	public bool Shadow
	{
		get
		{
			if (!xa157de8185757b11)
			{
				return xf78e2d39ff927920;
			}
			return x144aa4462fe3ef7c.Shadow;
		}
		set
		{
			xea38c993925dfec4();
			xf78e2d39ff927920 = value;
		}
	}

	internal bool x227665e444fb500a
	{
		get
		{
			if (!xa157de8185757b11)
			{
				return x57e44a48db954d01;
			}
			return x144aa4462fe3ef7c.x227665e444fb500a;
		}
		set
		{
			xea38c993925dfec4();
			x57e44a48db954d01 = value;
		}
	}

	internal string x19119439284aead2
	{
		get
		{
			return x43cc04205601f9c7;
		}
		set
		{
			x43cc04205601f9c7 = value;
		}
	}

	internal string x545df332a972f97f
	{
		get
		{
			return x74fb49f5adf29cac;
		}
		set
		{
			x74fb49f5adf29cac = value;
		}
	}

	internal string xc7a5a1bef7198132
	{
		get
		{
			return xecdbc80736a31aa5;
		}
		set
		{
			xecdbc80736a31aa5 = value;
		}
	}

	internal int xab266ea415f07c09
	{
		get
		{
			return x63d304957e61360d;
		}
		set
		{
			x63d304957e61360d = value;
		}
	}

	internal int x1f2d5df87a5c4f81
	{
		get
		{
			return xcc90e70e24c6529e;
		}
		set
		{
			xcc90e70e24c6529e = value;
		}
	}

	internal int xd3369f817a5a99b6
	{
		get
		{
			float[] array = (float[])x6d36d0b4f2f696a8[LineStyle];
			if (array != null)
			{
				return array.Length;
			}
			return 1;
		}
	}

	private Border x144aa4462fe3ef7c => (Border)xc454c03c23d4b4d9.x3087b5fa67bcf3f4(x824f14e92de69876);

	[EditorBrowsable(EditorBrowsableState.Never)]
	public bool xc8ea2954a6825f32 => xa157de8185757b11;

	internal bool xa157de8185757b11 => xc454c03c23d4b4d9 != null;

	internal int x42c113aaa571f749
	{
		get
		{
			object obj = xeb1a966c22da78d3[LineStyle];
			if (obj == null)
			{
				return 0;
			}
			return (int)obj;
		}
	}

	internal int x64e2a404bc6b1659
	{
		get
		{
			if (LineStyle == LineStyle.Dot || LineStyle == LineStyle.DashLargeGap)
			{
				return 1;
			}
			return x42c113aaa571f749 * xab266ea415f07c09;
		}
	}

	private int x9a3df6eb8946d653 => Color.R + Color.B + 2 * Color.G;

	private int x02d0e8ac94bcd957 => Color.B + 2 * Color.G;

	private int xf31c4d8861e71588 => Color.G;

	internal Border()
	{
		ClearFormatting();
	}

	internal Border(LineStyle lineStyle, int rawLineWidth, x26d9ecb4bdf0456d color)
	{
		x8001c24628d75f20 = lineStyle;
		x63d304957e61360d = rawLineWidth;
		x78e4acec873c7675 = color;
	}

	internal Border(x0e9935be205598e7 parent, int key)
	{
		xc454c03c23d4b4d9 = parent;
		x824f14e92de69876 = key;
	}

	public void ClearFormatting()
	{
		xc454c03c23d4b4d9 = null;
		x8001c24628d75f20 = LineStyle.None;
		x63d304957e61360d = 0;
		x78e4acec873c7675 = x26d9ecb4bdf0456d.x45260ad4b94166f2;
		xcc90e70e24c6529e = 0;
		xf78e2d39ff927920 = false;
		x57e44a48db954d01 = false;
		x43cc04205601f9c7 = null;
		x74fb49f5adf29cac = null;
		xecdbc80736a31aa5 = null;
	}

	internal static bool xae56a19b8a07173b(LineStyle x26516bbd7ae94699, float xce90ee8e49859281)
	{
		if (x26516bbd7ae94699 != 0)
		{
			return xce90ee8e49859281 > 0f;
		}
		return false;
	}

	internal void x3b83679cceee1fab(double xce90ee8e49859281)
	{
		x2c9fcc269cdca9d1(xce90ee8e49859281, x9199ed88324d69ff: false);
	}

	private void x2c9fcc269cdca9d1(double xce90ee8e49859281, bool x9199ed88324d69ff)
	{
		double num = x15e971129fd80714.xe193c76ba76a5afc(xce90ee8e49859281, 0.0, 31.0);
		if (num != xce90ee8e49859281 && x9199ed88324d69ff)
		{
			throw new ArgumentOutOfRangeException("lineWidth");
		}
		xea38c993925dfec4();
		xab266ea415f07c09 = (xbca512cb9f5a451a ? x15e971129fd80714.x43fcc3f62534530b(num) : x4574ea26106f0edb.xf4847d1e065c74fb(num));
		if (num > 0.0 && LineStyle == LineStyle.None)
		{
			LineStyle = LineStyle.Single;
		}
	}

	internal void xd0ddb5dfe7e0d9df(double x40390ac90cd57a02)
	{
		xa722e16a6e8b99ec(x40390ac90cd57a02, x9199ed88324d69ff: false);
	}

	private void xa722e16a6e8b99ec(double x40390ac90cd57a02, bool x9199ed88324d69ff)
	{
		if (x40390ac90cd57a02 < 0.0)
		{
			if (x9199ed88324d69ff)
			{
				throw new ArgumentOutOfRangeException("distanceFromText");
			}
			x40390ac90cd57a02 = 0.0;
		}
		else if (x40390ac90cd57a02 > 31.0)
		{
			if (x9199ed88324d69ff)
			{
				throw new ArgumentOutOfRangeException("distanceFromText");
			}
			x40390ac90cd57a02 = 31.0;
		}
		xea38c993925dfec4();
		x1f2d5df87a5c4f81 = (int)x40390ac90cd57a02;
	}

	internal bool Equals(Border rhs)
	{
		if (object.ReferenceEquals(null, rhs))
		{
			return false;
		}
		if (object.ReferenceEquals(this, rhs))
		{
			return true;
		}
		if (LineStyle == rhs.LineStyle && LineWidth == rhs.LineWidth && x63b1a7c31a962459.Equals(rhs.x63b1a7c31a962459) && DistanceFromText == rhs.DistanceFromText && x227665e444fb500a == rhs.x227665e444fb500a && Shadow == rhs.Shadow && x19119439284aead2 == rhs.x19119439284aead2 && x545df332a972f97f == rhs.x545df332a972f97f)
		{
			return xc7a5a1bef7198132 == rhs.xc7a5a1bef7198132;
		}
		return false;
	}

	public override bool Equals(object obj)
	{
		if (object.ReferenceEquals(null, obj))
		{
			return false;
		}
		if (object.ReferenceEquals(this, obj))
		{
			return true;
		}
		if (obj.GetType() != typeof(Border))
		{
			return false;
		}
		return Equals((Border)obj);
	}

	public override int GetHashCode()
	{
		int num = (int)x8001c24628d75f20;
		num = (num * 397) ^ x63d304957e61360d;
		num = (num * 397) ^ ((x78e4acec873c7675 != null) ? x78e4acec873c7675.GetHashCode() : 0);
		num = (num * 397) ^ xcc90e70e24c6529e;
		num = (num * 397) ^ xf78e2d39ff927920.GetHashCode();
		num = (num * 397) ^ x57e44a48db954d01.GetHashCode();
		num = (num * 397) ^ ((x43cc04205601f9c7 != null) ? x43cc04205601f9c7.GetHashCode() : 0);
		num = (num * 397) ^ ((x74fb49f5adf29cac != null) ? x74fb49f5adf29cac.GetHashCode() : 0);
		return (num * 397) ^ ((xecdbc80736a31aa5 != null) ? xecdbc80736a31aa5.GetHashCode() : 0);
	}

	internal bool x229288b0b89d0435(Border xd6efc2d6e891a521)
	{
		if (IsVisible)
		{
			return Equals(xd6efc2d6e891a521);
		}
		return false;
	}

	internal bool xbb00692c5619e346(Border xd6efc2d6e891a521)
	{
		return x20561d598948197d(LineStyle, xd6efc2d6e891a521.LineStyle);
	}

	internal static bool x20561d598948197d(LineStyle x0a2e35ea64126fc4, LineStyle x239e9a657bf55529)
	{
		if (x4e19e9f17854726a.ContainsKey(x0a2e35ea64126fc4) && (LineStyle)x4e19e9f17854726a[x0a2e35ea64126fc4] == x239e9a657bf55529)
		{
			return true;
		}
		if (x4e19e9f17854726a.ContainsKey(x239e9a657bf55529) && (LineStyle)x4e19e9f17854726a[x239e9a657bf55529] == x0a2e35ea64126fc4)
		{
			return true;
		}
		return false;
	}

	internal bool x137369e7499e07e8(Border xd6efc2d6e891a521, out bool x4d04c2c9440c8a3d)
	{
		if (!IsVisible || xd3369f817a5a99b6 == 1)
		{
			x4d04c2c9440c8a3d = false;
			return false;
		}
		x4d04c2c9440c8a3d = xbb00692c5619e346(xd6efc2d6e891a521);
		if ((LineStyle == xd6efc2d6e891a521.LineStyle || x4d04c2c9440c8a3d) && LineWidth == xd6efc2d6e891a521.LineWidth)
		{
			return x227665e444fb500a == xd6efc2d6e891a521.x227665e444fb500a;
		}
		return false;
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	private x11e014059489ae95 xa9c9dc40c97ccfd0()
	{
		return x8b61531c8ea35b85();
	}

	x11e014059489ae95 x11e014059489ae95.xcc4933610939ad04()
	{
		//ILSpy generated this explicit interface implementation from .override directive in xa9c9dc40c97ccfd0
		return this.xa9c9dc40c97ccfd0();
	}

	internal Border x8b61531c8ea35b85()
	{
		if (xa157de8185757b11)
		{
			throw new InvalidOperationException(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("ciejnjljhkckekjkckalekhlneolnifmdjmmdjdnpikndiboldiojhpodigpcdnpiheakhlabhcblgjbfhacjghcbhocpffdlfmdebdecfkecgbfpfifkfpfoeggeengefehaflhodcieaji", 940414015)));
		}
		return (Border)MemberwiseClone();
	}

	private void xea38c993925dfec4()
	{
		if (xa157de8185757b11)
		{
			xd9641c81aa48bd0d(x144aa4462fe3ef7c);
			xc454c03c23d4b4d9 = null;
		}
	}

	private void xd9641c81aa48bd0d(Border x50a18ad2656e7181)
	{
		if (x50a18ad2656e7181 == null)
		{
			throw new ArgumentNullException("src");
		}
		x824f14e92de69876 = x50a18ad2656e7181.x824f14e92de69876;
		x8001c24628d75f20 = x50a18ad2656e7181.LineStyle;
		x63d304957e61360d = x50a18ad2656e7181.xab266ea415f07c09;
		x78e4acec873c7675 = x50a18ad2656e7181.x63b1a7c31a962459;
		xcc90e70e24c6529e = x50a18ad2656e7181.x1f2d5df87a5c4f81;
		xf78e2d39ff927920 = x50a18ad2656e7181.Shadow;
		x57e44a48db954d01 = x50a18ad2656e7181.x227665e444fb500a;
		x43cc04205601f9c7 = x50a18ad2656e7181.x19119439284aead2;
		x74fb49f5adf29cac = x50a18ad2656e7181.x545df332a972f97f;
		xecdbc80736a31aa5 = x50a18ad2656e7181.xc7a5a1bef7198132;
	}

	internal static float[] xfddcf003f8c48200(LineStyle x26516bbd7ae94699, float xce90ee8e49859281)
	{
		float[] array = (float[])x2de42ed7716de792[x26516bbd7ae94699];
		if (array == null)
		{
			return null;
		}
		float[] array2 = (float[])array.Clone();
		for (int i = 0; i < array2.Length; i++)
		{
			array2[i] *= xce90ee8e49859281;
		}
		return array2;
	}

	internal static float x14904ff985c7b8c1(LineStyle x26516bbd7ae94699, float xce90ee8e49859281)
	{
		return (float)xce921039b6ed7574[x26516bbd7ae94699];
	}

	internal static float[] x7528558668744d84(LineStyle x26516bbd7ae94699, float xce90ee8e49859281)
	{
		float[] array = (float[])x6d36d0b4f2f696a8[x26516bbd7ae94699];
		if (array == null)
		{
			return new float[1] { xce90ee8e49859281 };
		}
		float[] array2 = (float[])array.Clone();
		for (int i = 0; i < array2.Length; i++)
		{
			if (array2[i] >= 0f)
			{
				array2[i] *= xce90ee8e49859281;
			}
			else
			{
				array2[i] = System.Math.Abs(array2[i]);
			}
		}
		return array2;
	}

	internal static int x3c7682f9fe27d986(LineStyle x26516bbd7ae94699)
	{
		float[] array = (float[])x6d36d0b4f2f696a8[x26516bbd7ae94699];
		if (array != null)
		{
			return array.Length;
		}
		return 1;
	}

	internal static float xb556d1cd3d419a11(LineStyle x26516bbd7ae94699, float xce90ee8e49859281)
	{
		switch (x26516bbd7ae94699)
		{
		case LineStyle.None:
			return 0f;
		case LineStyle.Single:
		case LineStyle.Dot:
		case LineStyle.DashLargeGap:
		case LineStyle.DotDash:
		case LineStyle.DotDotDash:
		case LineStyle.DashSmallGap:
			return xce90ee8e49859281;
		case LineStyle.Double:
		case LineStyle.Triple:
		case LineStyle.ThinThickSmallGap:
		case LineStyle.ThickThinSmallGap:
		case LineStyle.ThinThickThinSmallGap:
		case LineStyle.ThinThickMediumGap:
		case LineStyle.ThickThinMediumGap:
		case LineStyle.ThinThickThinMediumGap:
		case LineStyle.ThinThickLargeGap:
		case LineStyle.ThickThinLargeGap:
		case LineStyle.ThinThickThinLargeGap:
		case LineStyle.Emboss3D:
		case LineStyle.Engrave3D:
		{
			float[] array = x7528558668744d84(x26516bbd7ae94699, xce90ee8e49859281);
			float num = 0f;
			float[] array2 = array;
			foreach (float num2 in array2)
			{
				num += num2;
			}
			return num;
		}
		case LineStyle.Thick:
		case LineStyle.Hairline:
			return 0.75f;
		case LineStyle.Wave:
			return 2.5f * xce90ee8e49859281;
		case LineStyle.DoubleWave:
			return 6.75f * xce90ee8e49859281;
		case LineStyle.DashDotStroker:
		case LineStyle.Outset:
			return xce90ee8e49859281;
		default:
			return xce90ee8e49859281;
		}
	}

	internal static Border x1daeb1be8fb55a2f(Border x19218ffab70283ef, Border xe7ebe10fa44d8d49)
	{
		if (x19218ffab70283ef == null)
		{
			return xe7ebe10fa44d8d49;
		}
		if (xe7ebe10fa44d8d49 == null)
		{
			return x19218ffab70283ef;
		}
		if (x19218ffab70283ef.x64e2a404bc6b1659 != xe7ebe10fa44d8d49.x64e2a404bc6b1659)
		{
			if (x19218ffab70283ef.x64e2a404bc6b1659 <= xe7ebe10fa44d8d49.x64e2a404bc6b1659)
			{
				return xe7ebe10fa44d8d49;
			}
			return x19218ffab70283ef;
		}
		int num = x19218ffab70283ef.x42c113aaa571f749;
		int num2 = xe7ebe10fa44d8d49.x42c113aaa571f749;
		if (num != num2)
		{
			if (num <= num2)
			{
				return xe7ebe10fa44d8d49;
			}
			return x19218ffab70283ef;
		}
		int num3 = x19218ffab70283ef.x9a3df6eb8946d653;
		int num4 = xe7ebe10fa44d8d49.x9a3df6eb8946d653;
		if (num3 != num4)
		{
			if (num3 >= num4)
			{
				return xe7ebe10fa44d8d49;
			}
			return x19218ffab70283ef;
		}
		num3 = x19218ffab70283ef.x02d0e8ac94bcd957;
		num4 = xe7ebe10fa44d8d49.x02d0e8ac94bcd957;
		if (num3 != num4)
		{
			if (num3 >= num4)
			{
				return xe7ebe10fa44d8d49;
			}
			return x19218ffab70283ef;
		}
		if (x19218ffab70283ef.xf31c4d8861e71588 > xe7ebe10fa44d8d49.xf31c4d8861e71588)
		{
			return xe7ebe10fa44d8d49;
		}
		return x19218ffab70283ef;
	}

	static Border()
	{
		x45260ad4b94166f2 = new Border();
		x2de42ed7716de792 = new Hashtable();
		x2de42ed7716de792.Add(LineStyle.Dot, new float[2] { 1f, 1f });
		x2de42ed7716de792.Add(LineStyle.DashSmallGap, new float[2] { 4f, 1f });
		x2de42ed7716de792.Add(LineStyle.DashLargeGap, new float[2] { 4f, 4f });
		x2de42ed7716de792.Add(LineStyle.DotDash, new float[4] { 7f, 3f, 3f, 3f });
		x2de42ed7716de792.Add(LineStyle.DotDotDash, new float[6] { 6f, 2f, 2f, 2f, 2f, 2f });
		xce921039b6ed7574 = new Hashtable();
		xce921039b6ed7574.Add(LineStyle.Dot, 2f);
		xce921039b6ed7574.Add(LineStyle.DashSmallGap, 5f);
		xce921039b6ed7574.Add(LineStyle.DashLargeGap, 8f);
		xce921039b6ed7574.Add(LineStyle.DotDash, 16f);
		xce921039b6ed7574.Add(LineStyle.DotDotDash, 16f);
		x6d36d0b4f2f696a8 = new Hashtable();
		x6d36d0b4f2f696a8.Add(LineStyle.Double, new float[3] { 1f, 1f, 1f });
		x6d36d0b4f2f696a8.Add(LineStyle.Triple, new float[5] { 1f, 1f, 1f, 1f, 1f });
		x6d36d0b4f2f696a8.Add(LineStyle.ThinThickSmallGap, new float[3] { 1f, -0.75f, -0.75f });
		x6d36d0b4f2f696a8.Add(LineStyle.ThickThinSmallGap, new float[3] { -0.75f, -0.75f, 1f });
		x6d36d0b4f2f696a8.Add(LineStyle.ThinThickMediumGap, new float[3] { 1f, 0.5f, 0.5f });
		x6d36d0b4f2f696a8.Add(LineStyle.ThickThinMediumGap, new float[3] { 0.5f, 0.5f, 1f });
		x6d36d0b4f2f696a8.Add(LineStyle.ThinThickLargeGap, new float[3] { -1.5f, 1f, -0.75f });
		x6d36d0b4f2f696a8.Add(LineStyle.ThickThinLargeGap, new float[3] { -0.75f, 1f, -1.5f });
		x6d36d0b4f2f696a8.Add(LineStyle.ThinThickThinSmallGap, new float[5] { -0.75f, -0.75f, 1f, -0.75f, -0.75f });
		x6d36d0b4f2f696a8.Add(LineStyle.ThinThickThinMediumGap, new float[5] { 0.5f, 0.5f, 1f, 0.5f, 0.5f });
		x6d36d0b4f2f696a8.Add(LineStyle.ThinThickThinLargeGap, new float[5] { -0.75f, 1f, -1.5f, 1f, -0.75f });
		x6d36d0b4f2f696a8.Add(LineStyle.Emboss3D, new float[5] { 0.25f, 0f, 1f, 0f, 0.25f });
		x6d36d0b4f2f696a8.Add(LineStyle.Engrave3D, new float[5] { 0.25f, 0f, 1f, 0f, 0.25f });
		x4e19e9f17854726a = new Hashtable();
		x4e19e9f17854726a.Add(LineStyle.ThinThickSmallGap, LineStyle.ThickThinSmallGap);
		x4e19e9f17854726a.Add(LineStyle.ThinThickMediumGap, LineStyle.ThickThinMediumGap);
		x4e19e9f17854726a.Add(LineStyle.ThinThickLargeGap, LineStyle.ThickThinLargeGap);
		xeb1a966c22da78d3 = new Hashtable(27);
		xeb1a966c22da78d3.Add(LineStyle.Single, 1);
		xeb1a966c22da78d3.Add(LineStyle.Thick, 2);
		xeb1a966c22da78d3.Add(LineStyle.Double, 3);
		xeb1a966c22da78d3.Add(LineStyle.Dot, 4);
		xeb1a966c22da78d3.Add(LineStyle.DashLargeGap, 5);
		xeb1a966c22da78d3.Add(LineStyle.DotDash, 8);
		xeb1a966c22da78d3.Add(LineStyle.DotDotDash, 9);
		xeb1a966c22da78d3.Add(LineStyle.Triple, 10);
		xeb1a966c22da78d3.Add(LineStyle.ThinThickSmallGap, 11);
		xeb1a966c22da78d3.Add(LineStyle.ThickThinSmallGap, 12);
		xeb1a966c22da78d3.Add(LineStyle.ThinThickThinSmallGap, 13);
		xeb1a966c22da78d3.Add(LineStyle.ThinThickMediumGap, 14);
		xeb1a966c22da78d3.Add(LineStyle.ThickThinMediumGap, 15);
		xeb1a966c22da78d3.Add(LineStyle.ThinThickThinMediumGap, 16);
		xeb1a966c22da78d3.Add(LineStyle.ThinThickLargeGap, 17);
		xeb1a966c22da78d3.Add(LineStyle.ThickThinLargeGap, 18);
		xeb1a966c22da78d3.Add(LineStyle.ThinThickThinLargeGap, 19);
		xeb1a966c22da78d3.Add(LineStyle.Wave, 20);
		xeb1a966c22da78d3.Add(LineStyle.DoubleWave, 21);
		xeb1a966c22da78d3.Add(LineStyle.DashSmallGap, 22);
		xeb1a966c22da78d3.Add(LineStyle.DashDotStroker, 23);
		xeb1a966c22da78d3.Add(LineStyle.Emboss3D, 24);
		xeb1a966c22da78d3.Add(LineStyle.Engrave3D, 25);
		xeb1a966c22da78d3.Add(LineStyle.Outset, 26);
		xeb1a966c22da78d3.Add(LineStyle.Inset, 27);
		xeb1a966c22da78d3.Add(LineStyle.None, 0);
		xeb1a966c22da78d3.Add(LineStyle.Hairline, 1);
	}

	internal bool x27d7528a28faeec8()
	{
		if (LineStyle >= LineStyle.None)
		{
			return LineStyle <= LineStyle.Inset;
		}
		return false;
	}

	[Conditional("ASPOSE_EDITOR")]
	internal static void xa38d8176588e85f3(params object[] xcd31b50c43a96e21)
	{
	}

	[Conditional("ASPOSE_EDITOR")]
	internal static void xf98205bfc3387b55(params object[] xcd31b50c43a96e21)
	{
	}
}
