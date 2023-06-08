using System;
using System.Drawing.Drawing2D;

namespace ns224;

internal class Class6003
{
	private static readonly float[] float_0 = new float[2] { 3f, 1f };

	private static readonly float[] float_1 = new float[4] { 3f, 1f, 1f, 1f };

	private static readonly float[] float_2 = new float[6] { 3f, 1f, 1f, 1f, 1f, 1f };

	private static readonly float[] float_3 = new float[2] { 1f, 1f };

	private static readonly float[] float_4 = new float[0];

	private Enum747 enum747_0;

	private Class5990 class5990_0;

	private float[] float_5 = float_4;

	private DashCap dashCap_0;

	private float float_6;

	private float[] float_7 = float_4;

	private DashStyle dashStyle_0;

	private LineCap lineCap_0;

	private LineJoin lineJoin_0;

	private float float_8 = 10f;

	private LineCap lineCap_1;

	private float float_9 = 1f;

	public Enum747 Alignment
	{
		get
		{
			return enum747_0;
		}
		set
		{
			enum747_0 = value;
		}
	}

	public float Width
	{
		get
		{
			return float_9;
		}
		set
		{
			float_9 = value;
		}
	}

	public LineCap StartCap
	{
		get
		{
			return lineCap_1;
		}
		set
		{
			lineCap_1 = value;
		}
	}

	public LineCap EndCap
	{
		get
		{
			return lineCap_0;
		}
		set
		{
			lineCap_0 = value;
		}
	}

	public LineJoin LineJoin
	{
		get
		{
			return lineJoin_0;
		}
		set
		{
			lineJoin_0 = value;
		}
	}

	public Class5990 Brush
	{
		get
		{
			return class5990_0;
		}
		set
		{
			class5990_0 = value;
		}
	}

	public float MiterLimit
	{
		get
		{
			return float_8;
		}
		set
		{
			float_8 = value;
		}
	}

	public float DashOffset
	{
		get
		{
			return float_6;
		}
		set
		{
			float_6 = value;
		}
	}

	public DashCap DashCap
	{
		get
		{
			return dashCap_0;
		}
		set
		{
			dashCap_0 = value;
		}
	}

	public DashStyle DashStyle
	{
		get
		{
			return dashStyle_0;
		}
		set
		{
			dashStyle_0 = value;
			switch (dashStyle_0)
			{
			default:
				throw new ArgumentException("Unknown dash style.");
			case DashStyle.Solid:
				float_7 = float_4;
				break;
			case DashStyle.Dash:
				float_7 = float_0;
				break;
			case DashStyle.Dot:
				float_7 = float_3;
				break;
			case DashStyle.DashDot:
				float_7 = float_1;
				break;
			case DashStyle.DashDotDot:
				float_7 = float_2;
				break;
			case DashStyle.Custom:
				break;
			}
		}
	}

	public float[] DashPattern
	{
		get
		{
			return float_7;
		}
		set
		{
			if (value == null)
			{
				throw new ArgumentNullException("value");
			}
			float_7 = value;
			dashStyle_0 = DashStyle.Custom;
		}
	}

	public float[] CompoundArray
	{
		get
		{
			return float_5;
		}
		set
		{
			if (value == null)
			{
				throw new ArgumentNullException("value");
			}
			float_5 = value;
		}
	}

	public Class6003(Class5998 color)
		: this(color, 1f)
	{
	}

	public Class6003(Class5998 color, float width)
		: this(new Class5997(color), width)
	{
	}

	public Class6003(Class5990 brush)
		: this(brush, 1f)
	{
	}

	public Class6003(Class5990 brush, float width)
	{
		if (brush == null)
		{
			throw new ArgumentNullException("brush");
		}
		class5990_0 = brush;
		float_9 = width;
	}

	public Class6003 method_0()
	{
		return (Class6003)MemberwiseClone();
	}
}
