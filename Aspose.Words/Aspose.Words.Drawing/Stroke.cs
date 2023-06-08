using System;
using System.Collections;
using System.Drawing;
using x011d489fb9df7027;
using x28925c9b27b37a46;
using x5794c252ba25e723;
using x6c95d9cf46ff5f25;

namespace Aspose.Words.Drawing;

public class Stroke
{
	private readonly x7b71245a33212e76 xc454c03c23d4b4d9;

	private static readonly Hashtable x2de42ed7716de792;

	public bool On
	{
		get
		{
			return (bool)xfe91eeeafcb3026a(508);
		}
		set
		{
			xae20093bed1e48a8(508, value);
		}
	}

	public double Weight
	{
		get
		{
			return x4574ea26106f0edb.xa23e6b6c3169521d((int)xfe91eeeafcb3026a(459));
		}
		set
		{
			if (value < 0.0)
			{
				throw new ArgumentOutOfRangeException("value");
			}
			xae20093bed1e48a8(459, x4574ea26106f0edb.x3aa08882c9feaf96(value));
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
			return (x26d9ecb4bdf0456d)xfe91eeeafcb3026a(448);
		}
		set
		{
			xae20093bed1e48a8(448, value);
		}
	}

	public Color Color2
	{
		get
		{
			return x5424d51d40e7c452.xc7656a130b2889c7();
		}
		set
		{
			x5424d51d40e7c452 = x26d9ecb4bdf0456d.xcd907c08c553c15c(value);
		}
	}

	internal x26d9ecb4bdf0456d x5424d51d40e7c452
	{
		get
		{
			return (x26d9ecb4bdf0456d)xfe91eeeafcb3026a(450);
		}
		set
		{
			xae20093bed1e48a8(450, value);
		}
	}

	internal x6d4b101fe08bc376 x6d4b101fe08bc376
	{
		get
		{
			return (x6d4b101fe08bc376)xfe91eeeafcb3026a(452);
		}
		set
		{
			xae20093bed1e48a8(452, value);
		}
	}

	public DashStyle DashStyle
	{
		get
		{
			return (DashStyle)xfe91eeeafcb3026a(462);
		}
		set
		{
			xae20093bed1e48a8(462, value);
		}
	}

	public JoinStyle JoinStyle
	{
		get
		{
			return (JoinStyle)xfe91eeeafcb3026a(470);
		}
		set
		{
			xae20093bed1e48a8(470, value);
		}
	}

	public EndCap EndCap
	{
		get
		{
			return (EndCap)xfe91eeeafcb3026a(471);
		}
		set
		{
			xae20093bed1e48a8(471, value);
		}
	}

	public ShapeLineStyle LineStyle
	{
		get
		{
			return (ShapeLineStyle)xfe91eeeafcb3026a(461);
		}
		set
		{
			xae20093bed1e48a8(461, value);
		}
	}

	public ArrowType StartArrowType
	{
		get
		{
			return (ArrowType)xfe91eeeafcb3026a(464);
		}
		set
		{
			xae20093bed1e48a8(464, value);
		}
	}

	public ArrowType EndArrowType
	{
		get
		{
			return (ArrowType)xfe91eeeafcb3026a(465);
		}
		set
		{
			xae20093bed1e48a8(465, value);
		}
	}

	public ArrowWidth StartArrowWidth
	{
		get
		{
			return (ArrowWidth)xfe91eeeafcb3026a(466);
		}
		set
		{
			xae20093bed1e48a8(466, value);
		}
	}

	public ArrowLength StartArrowLength
	{
		get
		{
			return (ArrowLength)xfe91eeeafcb3026a(467);
		}
		set
		{
			xae20093bed1e48a8(467, value);
		}
	}

	public ArrowWidth EndArrowWidth
	{
		get
		{
			return (ArrowWidth)xfe91eeeafcb3026a(468);
		}
		set
		{
			xae20093bed1e48a8(468, value);
		}
	}

	public ArrowLength EndArrowLength
	{
		get
		{
			return (ArrowLength)xfe91eeeafcb3026a(469);
		}
		set
		{
			xae20093bed1e48a8(469, value);
		}
	}

	public double Opacity
	{
		get
		{
			return x4574ea26106f0edb.x97ab502db0c0e5c2((int)xfe91eeeafcb3026a(449));
		}
		set
		{
			if (value < 0.0 || value > 1.0)
			{
				throw new ArgumentOutOfRangeException("value");
			}
			xae20093bed1e48a8(449, x4574ea26106f0edb.x091b250f00534aae(value));
		}
	}

	public byte[] ImageBytes => (byte[])xfe91eeeafcb3026a(4110);

	internal Stroke(x7b71245a33212e76 parent)
	{
		xc454c03c23d4b4d9 = parent;
	}

	internal static float[] xfddcf003f8c48200(DashStyle x0bde43e8666e4580, float xce90ee8e49859281)
	{
		float[] array = (float[])x2de42ed7716de792[x0bde43e8666e4580];
		if (array == null)
		{
			return null;
		}
		float[] array2 = new float[array.Length];
		array.CopyTo(array2, 0);
		for (int i = 0; i < array2.Length; i++)
		{
			array2[i] *= xce90ee8e49859281;
		}
		return array2;
	}

	private object xfe91eeeafcb3026a(int xba08ce632055a1d9)
	{
		return xc454c03c23d4b4d9.xfc928672852cc4c4(xba08ce632055a1d9);
	}

	private void xae20093bed1e48a8(int xba08ce632055a1d9, object xbcea506a33cf9111)
	{
		xc454c03c23d4b4d9.x0817d5cde9e19bf6(xba08ce632055a1d9, xbcea506a33cf9111);
	}

	static Stroke()
	{
		x2de42ed7716de792 = new Hashtable();
		x2de42ed7716de792.Add(DashStyle.ShortDash, new float[2] { 2f, 1f });
		x2de42ed7716de792.Add(DashStyle.ShortDot, new float[2] { 1f, 1f });
		x2de42ed7716de792.Add(DashStyle.ShortDashDot, new float[4] { 2f, 1f, 1f, 1f });
		x2de42ed7716de792.Add(DashStyle.ShortDashDotDot, new float[6] { 2f, 1f, 1f, 1f, 1f, 1f });
		x2de42ed7716de792.Add(DashStyle.Dot, new float[2] { 1f, 1f });
		x2de42ed7716de792.Add(DashStyle.Dash, new float[2] { 4f, 3f });
		x2de42ed7716de792.Add(DashStyle.LongDash, new float[2] { 7f, 3f });
		x2de42ed7716de792.Add(DashStyle.DashDot, new float[4] { 4f, 3f, 1f, 3f });
		x2de42ed7716de792.Add(DashStyle.LongDashDot, new float[4] { 7f, 3f, 1f, 3f });
		x2de42ed7716de792.Add(DashStyle.LongDashDotDot, new float[6] { 7f, 3f, 1f, 3f, 1f, 3f });
	}
}
