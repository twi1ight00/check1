using System;
using System.Collections;
using System.Drawing;
using System.Text;
using x5794c252ba25e723;
using x6c95d9cf46ff5f25;

namespace x1c8faa688b1f0b0c;

internal class xcc8c7739d82c63ba : x4fdf549af9de6b97, x0c06161ccb9341e4
{
	private object x1b3f1d3c6e265440;

	private readonly xe39d06eee35dd23d x83cd810ab70afec3;

	private readonly x26d9ecb4bdf0456d x78e4acec873c7675;

	private readonly x26d9ecb4bdf0456d x0c4ecde7726cdb5f;

	private PointF x831916008bfc3ed7 = PointF.Empty;

	private SizeF x3b77a41bd57164d6 = SizeF.Empty;

	private string xed4a7b1500064e12;

	private x54366fa5f75a02f7 x06b983e52d670ed8;

	private xab391c46ff9a0a38 xa8548d289a49a30a;

	private xa702b771604efc86 xcbb1563eca0c21f2;

	private readonly float x419ed89d9f867ae4;

	private readonly bool x84f71da965c5d226;

	public xe39d06eee35dd23d xc2d4efc42998d87b => x83cd810ab70afec3;

	public x26d9ecb4bdf0456d x9b41425268471380 => x78e4acec873c7675;

	public x26d9ecb4bdf0456d xf09329ffe2ab2695 => x0c4ecde7726cdb5f;

	public PointF xc22eade24b085d91
	{
		get
		{
			return x831916008bfc3ed7;
		}
		set
		{
			x831916008bfc3ed7 = value;
		}
	}

	public virtual string Text => xed4a7b1500064e12;

	public string x3af5c144cbdd1fc1
	{
		get
		{
			if (x84f71da965c5d226)
			{
				ArrayList arrayList = new ArrayList();
				foreach (int item in new x115139807e6482f7(xed4a7b1500064e12))
				{
					arrayList.Add(item);
				}
				arrayList.Reverse();
				StringBuilder stringBuilder = new StringBuilder();
				foreach (int item2 in arrayList)
				{
					stringBuilder.Append(xdf3a1f89dca325a3.x251dbcb3221739c5(item2));
				}
				return stringBuilder.ToString();
			}
			return xed4a7b1500064e12;
		}
	}

	public x54366fa5f75a02f7 x52dde376accdec7d
	{
		get
		{
			return x06b983e52d670ed8;
		}
		set
		{
			x06b983e52d670ed8 = value;
		}
	}

	public xab391c46ff9a0a38 x0e1bf8242ad10272
	{
		get
		{
			return xa8548d289a49a30a;
		}
		set
		{
			xa8548d289a49a30a = value;
		}
	}

	public PointF xab07b26048f600ba => new PointF(x72d92bd1aff02e37, xe360b1885d8d4a41);

	public SizeF x437e3b626c0fdd43
	{
		get
		{
			return x3b77a41bd57164d6;
		}
		set
		{
			x3b77a41bd57164d6 = value;
		}
	}

	public float xe360b1885d8d4a41 => x831916008bfc3ed7.Y - x83cd810ab70afec3.xd9ac1486133b5a4e;

	public float x9bcb07e204e30218 => x831916008bfc3ed7.Y + x83cd810ab70afec3.x6b0006bdae665f50;

	public float x72d92bd1aff02e37 => x831916008bfc3ed7.X;

	public xa702b771604efc86 xc9bcfb2d9630b0c7
	{
		get
		{
			return xcbb1563eca0c21f2;
		}
		set
		{
			xcbb1563eca0c21f2 = value;
		}
	}

	public float x1ba361c106a805aa => x419ed89d9f867ae4;

	public RectangleF x6ae4612a8469678e => new RectangleF(x72d92bd1aff02e37, xe360b1885d8d4a41, x437e3b626c0fdd43.Width, x437e3b626c0fdd43.Height);

	public object xd229d86af0f16fb0
	{
		get
		{
			return x1b3f1d3c6e265440;
		}
		set
		{
			x1b3f1d3c6e265440 = value;
		}
	}

	public xcc8c7739d82c63ba(xe39d06eee35dd23d font, x845d6a068e0b03c5 brush, RectangleF bounds, string text, float charSpace)
		: this(font, (brush is xc020fa2f5133cba8) ? ((xc020fa2f5133cba8)brush).x9b41425268471380 : x26d9ecb4bdf0456d.x89fffa2751fdecbe, x26d9ecb4bdf0456d.x45260ad4b94166f2, new PointF(bounds.X, bounds.Y + font.xd9ac1486133b5a4e), text, bounds.Size, charSpace)
	{
	}

	public xcc8c7739d82c63ba(xe39d06eee35dd23d font, x845d6a068e0b03c5 brush, PointF origin, string text, float charSpace)
		: this(font, (brush is xc020fa2f5133cba8) ? ((xc020fa2f5133cba8)brush).x9b41425268471380 : x26d9ecb4bdf0456d.x89fffa2751fdecbe, x26d9ecb4bdf0456d.x45260ad4b94166f2, origin, text, charSpace)
	{
	}

	public xcc8c7739d82c63ba(xe39d06eee35dd23d font, x26d9ecb4bdf0456d color, x26d9ecb4bdf0456d outlineColor, PointF origin, string text, float charSpace)
		: this(font, color, outlineColor, origin, text, font.x6e21842ebf5f70df(text), charSpace, isRtlScript: false)
	{
	}

	public xcc8c7739d82c63ba(xe39d06eee35dd23d font, x26d9ecb4bdf0456d color, x26d9ecb4bdf0456d outlineColor, PointF origin, string text, SizeF size, float charSpace)
		: this(font, color, outlineColor, origin, text, size, charSpace, isRtlScript: false)
	{
	}

	public xcc8c7739d82c63ba(xe39d06eee35dd23d font, x26d9ecb4bdf0456d color, x26d9ecb4bdf0456d outlineColor, PointF origin, string text, SizeF size, float charSpace, bool isRtlScript)
	{
		if (font == null)
		{
			throw new ArgumentNullException("font");
		}
		if (color == null)
		{
			throw new ArgumentNullException("color");
		}
		if (outlineColor == null)
		{
			throw new ArgumentNullException("outlineColor");
		}
		if (text == null)
		{
			throw new ArgumentNullException("text");
		}
		x83cd810ab70afec3 = font;
		x78e4acec873c7675 = color;
		x0c4ecde7726cdb5f = outlineColor;
		x831916008bfc3ed7 = origin;
		xed4a7b1500064e12 = font.x29f65b3e7616f6b3.x839c39284cd04767(text);
		x3b77a41bd57164d6 = size;
		x419ed89d9f867ae4 = charSpace;
		x84f71da965c5d226 = isRtlScript;
	}

	public override void Accept(xf51865b83a7a0b3b visitor)
	{
		visitor.VisitGlyphs(this);
	}

	internal x54366fa5f75a02f7 xa9563a23c5ad1dd4()
	{
		x54366fa5f75a02f7 x54366fa5f75a02f = new x54366fa5f75a02f7();
		x54366fa5f75a02f.xce92de628aa023cf(xc22eade24b085d91.X, xc22eade24b085d91.Y);
		x54366fa5f75a02f.x490e30087768649f(new x54366fa5f75a02f7(1f, 0f, -0.34906584f, 1f, 0f, 0f));
		x54366fa5f75a02f.xce92de628aa023cf(0f - xc22eade24b085d91.X, 0f - xc22eade24b085d91.Y);
		return x54366fa5f75a02f;
	}

	public void x2037c969f8f81f97(string xb41faee6912a2313, float x9b0739496f8b5475)
	{
		xed4a7b1500064e12 += xb41faee6912a2313;
		x3b77a41bd57164d6 = new SizeF(x3b77a41bd57164d6.Width + x9b0739496f8b5475, x3b77a41bd57164d6.Height);
	}

	public void x49fcab67c4c06675()
	{
		xed4a7b1500064e12 = string.Empty;
		x3b77a41bd57164d6 = SizeF.Empty;
	}
}
