using System.Drawing;
using System.Text;

namespace x4f4df92b75ba3b67;

internal abstract class xba2f911354958a68 : x264ba3b7aca691be
{
	private readonly FontStyle xb9ee3d806943bac4;

	private string xa04ad047ed7ee2b0;

	protected readonly x6abbea4951acbffd x9ee491ab5579b9fc;

	private readonly xcb3d00e64f2216e5 xfcd01e1d46e15910;

	public bool xda4c813a32b9109b
	{
		get
		{
			if ((xb9ee3d806943bac4 & FontStyle.Italic) != 0)
			{
				return !x25998da3963930e9.x29f65b3e7616f6b3.xb65ca9637cc40782;
			}
			return false;
		}
	}

	public bool x30c7b3201d032345
	{
		get
		{
			if ((xb9ee3d806943bac4 & FontStyle.Bold) != 0)
			{
				return !x25998da3963930e9.x29f65b3e7616f6b3.xa143daf3bef8b339;
			}
			return false;
		}
	}

	public string xd47a98a7600d6b65 => xa04ad047ed7ee2b0;

	public int xc9f7bec53c29c691 => -xf716fdaf41b2c8ab(x25998da3963930e9.x29f65b3e7616f6b3.xc9f7bec53c29c691);

	public int x3f80ed349f729542 => xf716fdaf41b2c8ab(x25998da3963930e9.x29f65b3e7616f6b3.x3f80ed349f729542);

	public int x912ee4c8583acc0f => xf716fdaf41b2c8ab(x25998da3963930e9.x29f65b3e7616f6b3.x912ee4c8583acc0f);

	public int x586b7652ac7cefe0
	{
		get
		{
			int num = 0;
			num |= 0x20;
			num |= (((x25998da3963930e9.x29f65b3e7616f6b3.xfe2178c1f916f36c & FontStyle.Italic) != 0) ? 64 : 0);
			return num | (((x25998da3963930e9.x29f65b3e7616f6b3.xfe2178c1f916f36c & FontStyle.Bold) != 0) ? 262144 : 0);
		}
	}

	public RectangleF x3560592fd0c9f0ea => new RectangleF(xf716fdaf41b2c8ab(x25998da3963930e9.x29f65b3e7616f6b3.x9462c8df936efa39), xf716fdaf41b2c8ab(x25998da3963930e9.x29f65b3e7616f6b3.x5b051452efe1bbe3), xf716fdaf41b2c8ab(x25998da3963930e9.x29f65b3e7616f6b3.x11f73230b9b436a7 - x25998da3963930e9.x29f65b3e7616f6b3.x9462c8df936efa39), xf716fdaf41b2c8ab(x25998da3963930e9.x29f65b3e7616f6b3.xbed6b6abe5a7fcce - x25998da3963930e9.x29f65b3e7616f6b3.x5b051452efe1bbe3));

	public float xb874556d20cb64ce => x25998da3963930e9.x29f65b3e7616f6b3.xb874556d20cb64ce;

	internal override x3499f937de5622bc x41c71fb0a8629935 => x3499f937de5622bc.xc2d4efc42998d87b;

	internal xcb3d00e64f2216e5 x25998da3963930e9 => xfcd01e1d46e15910;

	protected xba2f911354958a68(x4882ae789be6e2ef context, FontStyle requestedStyle, x6abbea4951acbffd encoding, xcb3d00e64f2216e5 fontData)
		: base(context)
	{
		x9ee491ab5579b9fc = encoding;
		xfcd01e1d46e15910 = fontData;
		xb9ee3d806943bac4 = requestedStyle;
		xd854f7888f79bee8();
	}

	protected override string GenerateResourceName()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("F");
		string text = $"{base.xea1e81378298fa81:D5}";
		for (int i = 0; i < text.Length; i++)
		{
			stringBuilder.Append((char)(text[i] + 17));
		}
		return stringBuilder.ToString();
	}

	public virtual bool WriteText(string text, xcd769e39c0788209 writer)
	{
		bool result = xfcd01e1d46e15910.xd116716bb9acc746(text);
		x9ee491ab5579b9fc.WriteText(text, writer);
		return result;
	}

	internal static int xf716fdaf41b2c8ab(int xbcea506a33cf9111, int xcb0ea7d30675ed7c)
	{
		return xbcea506a33cf9111 * 1000 / xcb0ea7d30675ed7c;
	}

	internal int xf716fdaf41b2c8ab(int xbcea506a33cf9111)
	{
		return xf716fdaf41b2c8ab(xbcea506a33cf9111, x25998da3963930e9.x29f65b3e7616f6b3.xa25a0348a20dc6ca);
	}

	protected void xd854f7888f79bee8()
	{
		StringBuilder stringBuilder = new StringBuilder();
		if (!x8cedcaa9a62c6e39.x73979cef1002ed01.x977582846a207e5e && x25998da3963930e9.xc668392aa770aaef)
		{
			stringBuilder.Append(x46b079bd0553f90a);
			stringBuilder.Append("+");
		}
		stringBuilder.Append(xedc5399ed07a266f());
		if (x30c7b3201d032345 && xda4c813a32b9109b)
		{
			stringBuilder.Append(",BoldItalic");
		}
		else if (x30c7b3201d032345)
		{
			stringBuilder.Append(",Bold");
		}
		else if (xda4c813a32b9109b)
		{
			stringBuilder.Append(",Italic");
		}
		xa04ad047ed7ee2b0 = stringBuilder.Replace(" ", "#20").ToString();
	}

	private string xedc5399ed07a266f()
	{
		string text = x25998da3963930e9.x29f65b3e7616f6b3.x964cee665f40df64;
		if (text == null)
		{
			text = x25998da3963930e9.x29f65b3e7616f6b3.x0a4b32fbe2e5933b;
		}
		return text;
	}
}
