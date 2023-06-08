using System;
using System.Collections;
using System.Drawing;
using System.IO;
using x1c8faa688b1f0b0c;
using x5f3520a4b31ea90f;
using x66dd9eaee57cfba4;
using x6c95d9cf46ff5f25;
using xeb665d1aeef09d64;

namespace xc7ce8a6a920f8012;

internal class x34b34bf589d8ec1e
{
	private xf62f848e5d3ba660 x83d0f75f3858e3a4;

	private x5a224cf027b1ffd9 x9b287b671d592594;

	private short x4f42947183db5ba4 = 300;

	private Hashtable x9ee620a4e6847a49 = new Hashtable();

	private Hashtable xc0d087858ac2d6fc = new Hashtable();

	private Hashtable x7056611584e138d9 = new Hashtable();

	private Hashtable x4bd039d469a1155d = new Hashtable();

	private ArrayList x4f6190ffbf116eda = new ArrayList();

	private xc21f590a19daad27 x2d6df7514a3346cc;

	private int xcf5b72d791cd3067;

	private x70ca3c35e6c78936 xf946812819fdb8f4;

	private x6b1a899052c71a60 xb3b059ed47f146e4;

	public xf62f848e5d3ba660 x73979cef1002ed01 => x83d0f75f3858e3a4;

	public x5a224cf027b1ffd9 x5aa326f374b3d0ef => x9b287b671d592594;

	public ArrayList x09ed8d79c4ca4609 => x4f6190ffbf116eda;

	public xc21f590a19daad27 x5c96e27b059805fe => x2d6df7514a3346cc;

	public int x380e1d313f1dca54 => xcf5b72d791cd3067;

	public x6b1a899052c71a60 x568b8b069e73c3db => xb3b059ed47f146e4;

	public Hashtable xeafe18c850ae3127 => x4bd039d469a1155d;

	public x70ca3c35e6c78936 x93e68a44438355fd => xf946812819fdb8f4;

	public x34b34bf589d8ec1e(Stream stream, xf62f848e5d3ba660 options)
	{
		x9b287b671d592594 = new x5a224cf027b1ffd9(stream);
		x83d0f75f3858e3a4 = options;
		xf946812819fdb8f4 = new x70ca3c35e6c78936(x83d0f75f3858e3a4.x6b12d92d6782ee94);
	}

	public void x804b2039ae4e9b33(short x57e45291137f27ef, SizeF x278780fb19a87271)
	{
		x2d6df7514a3346cc = new xc21f590a19daad27(this, x57e45291137f27ef, x278780fb19a87271);
	}

	public void xa0cf4a18229be519(xfaa0b71704009335 xec8279a43bbc1566)
	{
		x2d6df7514a3346cc.x12acf473349bbd57(xec8279a43bbc1566);
		x4f6190ffbf116eda.Add(x2d6df7514a3346cc);
		xcf5b72d791cd3067++;
	}

	public bool x90d89bab6f61ec78(x6b1a899052c71a60 x26094932cf7a9139)
	{
		return x9ee620a4e6847a49[x26094932cf7a9139] != null;
	}

	public short x4a59854a1bae262a(x6b1a899052c71a60 x26094932cf7a9139)
	{
		object obj = x9ee620a4e6847a49[x26094932cf7a9139];
		if (obj != null)
		{
			return (short)obj;
		}
		short num = xa315ee2085b502cf();
		x9ee620a4e6847a49[x26094932cf7a9139] = num;
		return num;
	}

	public x6ba9063ea0f44561 x5fa376febd884803(x6b1a899052c71a60 x26094932cf7a9139)
	{
		short num = x4a59854a1bae262a(x26094932cf7a9139);
		x6ba9063ea0f44561 x6ba9063ea0f44562 = (x6ba9063ea0f44561)xc0d087858ac2d6fc[num];
		if (x6ba9063ea0f44562 == null)
		{
			x6ba9063ea0f44562 = new x6ba9063ea0f44561(x26094932cf7a9139);
			x6ba9063ea0f44562.x27872d02dfb99793(" ");
			xc0d087858ac2d6fc[num] = x6ba9063ea0f44562;
		}
		return x6ba9063ea0f44562;
	}

	public bool xcacc5caa945df72d(byte[] x43e181e083db6cdf)
	{
		return x7056611584e138d9[x66cdafe77e7aa42b.x8341ba999ffebb91(x43e181e083db6cdf)] != null;
	}

	public short xf41382d350a87348(byte[] x43e181e083db6cdf)
	{
		Guid guid = x66cdafe77e7aa42b.x8341ba999ffebb91(x43e181e083db6cdf);
		object obj = x7056611584e138d9[guid];
		if (obj != null)
		{
			return (short)obj;
		}
		short num = xa315ee2085b502cf();
		x7056611584e138d9[guid] = num;
		return num;
	}

	public void x94f739530d38cc0a(x9a66d03de2ff27e1 xa490ad5ef1682691)
	{
		string text = xdc68e82bbfd95fd9(xa490ad5ef1682691.xc22eade24b085d91);
		x4bd039d469a1155d[xa490ad5ef1682691.x759aa16c2016a289] = text;
		int x9b6007a17b33a42b = x83d0f75f3858e3a4.x9b6007a17b33a42b;
		if (x9b6007a17b33a42b > 0 && !xa490ad5ef1682691.x4b8f3649c1a3071c)
		{
			xf946812819fdb8f4.xdac50776b1d359d8(x9b6007a17b33a42b, xa490ad5ef1682691.x759aa16c2016a289, text);
		}
	}

	public void xdac50776b1d359d8(x2e5b68a308682b82 xccb63ca5f63dc470)
	{
		string x2cde75ecfbc26b0b = xdc68e82bbfd95fd9(xccb63ca5f63dc470.xc22eade24b085d91);
		int xcaedf7c40a4ec = x83d0f75f3858e3a4.xcaedf7c40a4ec358;
		if (xccb63ca5f63dc470.x504f3d4040b356d7 < xcaedf7c40a4ec)
		{
			xf946812819fdb8f4.xdac50776b1d359d8(xccb63ca5f63dc470.x504f3d4040b356d7, xccb63ca5f63dc470.x238bf167ccfdd282, x2cde75ecfbc26b0b);
		}
	}

	public void x887ee4cb0bd0448c()
	{
		xb3b059ed47f146e4 = x9d888f53892d94df.x9834ddb0e0bd5996.FetchTTFont(x83d0f75f3858e3a4.x76c3b8e27e953ad6, FontStyle.Regular, "Arial");
		x6ba9063ea0f44561 xb1561dfd709a9b5a = x5fa376febd884803(xb3b059ed47f146e4);
		x8715446a20d93e6f(x83d0f75f3858e3a4.x6a8a9f2ff4fc1d0f, xb1561dfd709a9b5a);
		x8715446a20d93e6f(x83d0f75f3858e3a4.xe1db7b892c589ded, xb1561dfd709a9b5a);
		x8715446a20d93e6f(x83d0f75f3858e3a4.x29d60fe32b323b87, xb1561dfd709a9b5a);
	}

	public short xa315ee2085b502cf()
	{
		return ++x4f42947183db5ba4;
	}

	public void x304b6d4b7f054ae1(bool x2d4c735f4e46f7c0)
	{
		if (x2d4c735f4e46f7c0)
		{
			x5d2a005e0aeac7cc x5d2a005e0aeac7cc2 = new x5d2a005e0aeac7cc(this);
			x5d2a005e0aeac7cc2.x31eb6524f38f9495(xb3b059ed47f146e4);
			xfb017adec00dd0bb xfb017adec00dd0bb2 = new xfb017adec00dd0bb(this);
			xfb017adec00dd0bb2.x508813524f81e22d();
			x5aa326f374b3d0ef.x4eadf767e5f91a38(xf066f1f57515a14c.xcb09e66e779b210e, 0);
		}
		for (int i = 0; i < x4f6190ffbf116eda.Count; i++)
		{
			xc21f590a19daad27 xc21f590a19daad28 = (xc21f590a19daad27)x4f6190ffbf116eda[i];
			xc21f590a19daad28.x6210059f049f0d48(i, x2d4c735f4e46f7c0);
		}
	}

	internal void xbbf9a1ead81dd3a1(x6d058fdf61831c39 x9f91de645a9fe01a, string xc2358fbac7da3d45)
	{
		x83d0f75f3858e3a4.x4d2cf6c77ee521cd().xbbf9a1ead81dd3a1(x9f91de645a9fe01a, x3959df40367ac8a3.xffe454f29a855c10, xc2358fbac7da3d45);
	}

	private static void x8715446a20d93e6f(Hashtable xd22d3a4d6b8ee462, x6ba9063ea0f44561 xb1561dfd709a9b5a)
	{
		foreach (string value in xd22d3a4d6b8ee462.Values)
		{
			xb1561dfd709a9b5a.x27872d02dfb99793(value);
		}
	}

	private string xdc68e82bbfd95fd9(PointF x9c3c185e7046dc72)
	{
		return $"bookmark://internal?page={xcf5b72d791cd3067}&x={x4574ea26106f0edb.x88bf16f2386d633e(x9c3c185e7046dc72.X)}&y={x4574ea26106f0edb.x88bf16f2386d633e(x9c3c185e7046dc72.Y)}";
	}
}
