using System;
using System.Collections;
using System.ComponentModel;
using Aspose;
using Aspose.Words;
using Aspose.Words.Drawing;
using Aspose.Words.Markup;
using x011d489fb9df7027;
using x13f1efc79617a47b;
using x28925c9b27b37a46;
using x53eb9320ebbb8395;
using x5f3520a4b31ea90f;
using x6c95d9cf46ff5f25;
using x79490184cecf12a1;
using x7c7a1dceb600404e;
using xf989f31a236ff98c;

namespace x1495530f35d79681;

internal abstract class xdfce7f4f687956d7 : xeb0b4eb7a8e9f591, x874ec168cb1feb74
{
	private readonly LoadOptions xd545ef71ef25db52;

	private readonly DocumentBase x232be220f517f721;

	private CompositeNode x4cbed795c600d582;

	private bool x99d7d1b2b3aa26cb;

	private readonly ArrayList x78b4c9d9b2bebe94 = new ArrayList();

	private readonly ArrayList xf85e10392e75539c = new ArrayList();

	private readonly ArrayList x5b2dbaa8757e69c5 = new ArrayList();

	private readonly Hashtable xc72ddcbcaca479e2 = new Hashtable();

	internal xc1b2bac943a0f541 xf0f66a68781cfaa5;

	internal xc1b2bac943a0f541 xe0ee6c8342da8f38;

	private readonly Hashtable x99f65b40d6ed2d43 = new Hashtable();

	private readonly Hashtable x7d27aedf612637da = new Hashtable();

	private readonly Hashtable x62b126bef465f48d = new Hashtable();

	private readonly Hashtable x32e8fa989ab52bff = new Hashtable();

	private readonly Hashtable x9a1f2a59ad254c56 = new Hashtable();

	private readonly x12d551e21425ffee x04562d8eb06323c7;

	private bool x84c818812e4873c2;

	private readonly Hashtable xfa521a7491a99fa8 = new Hashtable();

	[EditorBrowsable(EditorBrowsableState.Never)]
	public DocumentBase x2c8c6741422a1298 => x232be220f517f721;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public abstract x3c85359e1389ad43 x3bcd232d01c14846 { get; }

	internal abstract bool x099487305e4675db { get; }

	internal abstract bool x3ee7f4bad5fbb600 { get; }

	internal abstract bool x325f1926b78ae5cd { get; }

	internal CompositeNode x0547ea8ef1ef19b1
	{
		get
		{
			return x4cbed795c600d582;
		}
		set
		{
			x4cbed795c600d582 = value;
		}
	}

	internal bool xf41b717aaedc8265
	{
		get
		{
			return x99d7d1b2b3aa26cb;
		}
		set
		{
			x99d7d1b2b3aa26cb = value;
		}
	}

	internal Hashtable x6de0ddb682b657a1 => x7d27aedf612637da;

	internal Hashtable x02e97468984a6dfa => x62b126bef465f48d;

	internal Hashtable xd678422f2e2ad09e => x32e8fa989ab52bff;

	internal bool x936e45dfa3e35eb8
	{
		get
		{
			return x84c818812e4873c2;
		}
		set
		{
			x84c818812e4873c2 = value;
		}
	}

	internal LoadOptions x1e4394fcb6d34948 => xd545ef71ef25db52;

	protected xdfce7f4f687956d7(DocumentBase doc, LoadOptions loadOptions, WarningSource warningSource)
	{
		x232be220f517f721 = doc;
		x4cbed795c600d582 = doc;
		x04562d8eb06323c7 = new x12d551e21425ffee(loadOptions.WarningCallback, warningSource);
		xd545ef71ef25db52 = loadOptions;
	}

	protected void x7c0f41ccd8aba612()
	{
		x7c0f41ccd8aba612(xf85e10392e75539c);
		x7c0f41ccd8aba612(x5b2dbaa8757e69c5);
	}

	private static void x7c0f41ccd8aba612(ArrayList xb8d4ee4d8de67728)
	{
		if (xb8d4ee4d8de67728.Count != 0)
		{
			xb8d4ee4d8de67728.Sort(new x41d5513fb432c671());
			for (int i = 0; i < xb8d4ee4d8de67728.Count; i++)
			{
				ShapeBase shapeBase = (ShapeBase)xb8d4ee4d8de67728[i];
				shapeBase.ZOrder = i;
			}
		}
	}

	internal byte[] x622213a14a0645f2(byte[] xd51805873913cebb)
	{
		Guid guid = x66cdafe77e7aa42b.x8341ba999ffebb91(xd51805873913cebb);
		if (!x9a1f2a59ad254c56.ContainsKey(guid))
		{
			x9a1f2a59ad254c56.Add(guid, xd51805873913cebb);
			return xd51805873913cebb;
		}
		return (byte[])x9a1f2a59ad254c56[guid];
	}

	internal void x490834a62c46f14d(CompositeNode x1abafc112c220cac)
	{
		x4cbed795c600d582.xdf7453d9fdf3f262(x1abafc112c220cac);
		x4cbed795c600d582 = x1abafc112c220cac;
	}

	internal void xf5b0b9b6ff7ac462(NodeType x1a523190ff9254e6)
	{
		if (x4cbed795c600d582.NodeType != x1a523190ff9254e6)
		{
			throw new InvalidOperationException(string.Format(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("mecnchjnfgaoobhokgoooffpfbmpagdaofkaafbboeibgapbmegcdfncnpddjeldmeceiejebppendhfbdofioegidmglddhnckhpbbihohignoiipfjicnjnbekpalkkaclibjlgaamcahmllnmdbfnfmlnpadopkjoooapophpkpopdkfahomamodbookbhjbcpoicckpclogdjjnd", 1365168647)), x1a523190ff9254e6, x4cbed795c600d582.NodeType));
		}
		if (x4cbed795c600d582.NodeType == NodeType.Body)
		{
			x40ce2efaa88ee6d5(((Body)x4cbed795c600d582).LastParagraph);
		}
		x4cbed795c600d582 = x4cbed795c600d582.ParentNode;
	}

	internal void x8c81feb19d9adb77(Node xda5bf54deb817e37)
	{
		if (x4cbed795c600d582.x8a4414b7d9d4073f(xda5bf54deb817e37))
		{
			x1fa9148f6731ff24(xda5bf54deb817e37);
		}
		else
		{
			x78b4c9d9b2bebe94.Add(xda5bf54deb817e37);
		}
	}

	internal void x58bdab3825959912()
	{
		x40ce2efaa88ee6d5((Paragraph)x4cbed795c600d582);
	}

	private void x40ce2efaa88ee6d5(Paragraph x41baca1d6c0c2e8e)
	{
		if (x41baca1d6c0c2e8e == null)
		{
			x41baca1d6c0c2e8e = new Paragraph(x2c8c6741422a1298);
			x4cbed795c600d582.AppendChild(x41baca1d6c0c2e8e);
		}
		foreach (Node item in x78b4c9d9b2bebe94)
		{
			x41baca1d6c0c2e8e.xdf7453d9fdf3f262(item);
		}
		x78b4c9d9b2bebe94.Clear();
	}

	internal void x1fa9148f6731ff24(Node xda5bf54deb817e37)
	{
		x4a3d790f43378811(x4cbed795c600d582, xda5bf54deb817e37, x4cbed795c600d582.LastChild);
	}

	internal void xbe11e60379d74111(CompositeNode xb6a159a84cb992d6, Node x40e458b3a58f5782, Node xff5adbb92d63bf52)
	{
		xb7524c43b8d645a5(xb6a159a84cb992d6, x40e458b3a58f5782, xff5adbb92d63bf52, x7f43f79506f73a73: false);
	}

	internal void x4a3d790f43378811(CompositeNode xb6a159a84cb992d6, Node x40e458b3a58f5782, Node xff5adbb92d63bf52)
	{
		xb7524c43b8d645a5(xb6a159a84cb992d6, x40e458b3a58f5782, xff5adbb92d63bf52, x7f43f79506f73a73: true);
	}

	private void xb7524c43b8d645a5(CompositeNode xb6a159a84cb992d6, Node x40e458b3a58f5782, Node xff5adbb92d63bf52, bool x7f43f79506f73a73)
	{
		if (x7f43f79506f73a73)
		{
			if (xff5adbb92d63bf52 == xb6a159a84cb992d6.LastChild)
			{
				xb6a159a84cb992d6.xdf7453d9fdf3f262(x40e458b3a58f5782);
			}
			else
			{
				xb6a159a84cb992d6.InsertAfter(x40e458b3a58f5782, xff5adbb92d63bf52);
			}
		}
		else
		{
			xb6a159a84cb992d6.InsertBefore(x40e458b3a58f5782, xff5adbb92d63bf52);
		}
		if (x40e458b3a58f5782 is xcf3b0f04424de818 xcf3b0f04424de)
		{
			xeedad81aaed42a76 xc87649c48f7756d = xcf3b0f04424de.xc87649c48f7756d2;
			if (xe0ee6c8342da8f38 != null)
			{
				xc87649c48f7756d.x83da691dd3d974a6 = xe0ee6c8342da8f38;
			}
			if (xf0f66a68781cfaa5 != null)
			{
				xc87649c48f7756d.x18bb4aa7903ffced = xf0f66a68781cfaa5;
			}
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public int xc9b7340b035562c6(object x1bd44401d685915c, int x81d973eeafae2be3)
	{
		object obj = x99f65b40d6ed2d43[x1bd44401d685915c];
		if (obj == null)
		{
			return x81d973eeafae2be3;
		}
		return (int)obj;
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public void x214a3d715a732d1d(object x1bd44401d685915c, int xddd12ddd8b1e4a90)
	{
		x99f65b40d6ed2d43[x1bd44401d685915c] = xddd12ddd8b1e4a90;
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	[JavaThrows(true)]
	public abstract xd142dcacd7ddc9dd x36eb835297f7b346(string xeaf1b27180c0557b);

	[JavaThrows(true)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public abstract byte[] x7b29fad09d9101c5(string x50a18ad2656e7181);

	[EditorBrowsable(EditorBrowsableState.Never)]
	public abstract string x052a6c2e603b1662(string xc06e652f250a3786);

	[EditorBrowsable(EditorBrowsableState.Never)]
	public abstract bool x3d21050b1e731250(string x50a18ad2656e7181);

	[EditorBrowsable(EditorBrowsableState.Never)]
	public void xdc421ae00841d163(ShapeBase x5770cdefd8931aa9)
	{
		if (x99d7d1b2b3aa26cb)
		{
			xf85e10392e75539c.Add(x5770cdefd8931aa9);
		}
		else
		{
			x5b2dbaa8757e69c5.Add(x5770cdefd8931aa9);
		}
	}

	private void x30f0948efad368b5(string xcd113e16773803b2, ShapeBase x5770cdefd8931aa9)
	{
		xc72ddcbcaca479e2[xcd113e16773803b2] = x5770cdefd8931aa9;
	}

	void x874ec168cb1feb74.xcec152c2d57a278d(string xcd113e16773803b2, ShapeBase x5770cdefd8931aa9)
	{
		//ILSpy generated this explicit interface implementation from .override directive in x30f0948efad368b5
		this.x30f0948efad368b5(xcd113e16773803b2, x5770cdefd8931aa9);
	}

	private ShapeBase x862550830d04c0d4(string xcd113e16773803b2)
	{
		return (ShapeBase)xc72ddcbcaca479e2[xcd113e16773803b2];
	}

	ShapeBase x874ec168cb1feb74.x5b35a0b873aef5ad(string xcd113e16773803b2)
	{
		//ILSpy generated this explicit interface implementation from .override directive in x862550830d04c0d4
		return this.x862550830d04c0d4(xcd113e16773803b2);
	}

	private void xa2e9a3e1b9b26e0b(string xeaf1b27180c0557b, xf7125312c7ee115c xa5e8b8b5991a4e1d)
	{
		if (x0d299f323d241756.x5959bccb67bbf051(xeaf1b27180c0557b))
		{
			xfa521a7491a99fa8[xeaf1b27180c0557b] = xa5e8b8b5991a4e1d;
		}
	}

	void x874ec168cb1feb74.xedd58b27cf69c58d(string xeaf1b27180c0557b, xf7125312c7ee115c xa5e8b8b5991a4e1d)
	{
		//ILSpy generated this explicit interface implementation from .override directive in xa2e9a3e1b9b26e0b
		this.xa2e9a3e1b9b26e0b(xeaf1b27180c0557b, xa5e8b8b5991a4e1d);
	}

	private xf7125312c7ee115c xcb3a738d9781d395(string xeaf1b27180c0557b)
	{
		if (xeaf1b27180c0557b.StartsWith("#"))
		{
			xeaf1b27180c0557b = xeaf1b27180c0557b.Substring(1);
		}
		if (!x0d299f323d241756.x5959bccb67bbf051(xeaf1b27180c0557b))
		{
			return null;
		}
		return (xf7125312c7ee115c)xfa521a7491a99fa8[xeaf1b27180c0557b];
	}

	xf7125312c7ee115c x874ec168cb1feb74.xc49bc34e8c134250(string xeaf1b27180c0557b)
	{
		//ILSpy generated this explicit interface implementation from .override directive in xcb3a738d9781d395
		return this.xcb3a738d9781d395(xeaf1b27180c0557b);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	[JavaThrows(true)]
	public abstract void x2b6e606d842be5f3();

	[JavaThrows(true)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public abstract void x7a60e084fa9fb0e3(ShapeBase x5770cdefd8931aa9);

	internal abstract Footnote x3e5f4bed8c6ef7e6(FootnoteType xd3526c7313d75391, int xeaf1b27180c0557b);

	internal abstract void x2587cb0fe9d7f086(Comment x77c5a31ec0891f38);

	internal abstract Comment x8acb911280b864de(int xeaf1b27180c0557b);

	[JavaThrows(true)]
	internal abstract x9ea8b270a83f04a0 x663a863d790eefe8(string xc06e652f250a3786);

	internal abstract x9ea8b270a83f04a0 xc8ab4e294c74831b();

	internal abstract x9ea8b270a83f04a0 x5f81a20b8dd0c3a7(x9ea8b270a83f04a0 xe134235b3526fa75);

	internal void xbbf9a1ead81dd3a1(WarningType x9f91de645a9fe01a, WarningSource x337e217cb3ba0627, string xc2358fbac7da3d45)
	{
		if (xd545ef71ef25db52.WarningCallback != null)
		{
			xd545ef71ef25db52.WarningCallback.Warning(new WarningInfo(x9f91de645a9fe01a, x337e217cb3ba0627, xc2358fbac7da3d45));
		}
	}

	internal void x3dc950453374051a(string xc2358fbac7da3d45)
	{
		xbbf9a1ead81dd3a1(WarningType.UnexpectedContent, WarningSource.Nrx, xc2358fbac7da3d45);
	}

	internal void x25bdcca0c7a07e03(x55997ac957018945 x04137a6fd0e2d03c)
	{
		if (x04137a6fd0e2d03c.x57b60ae60739c9b5 == MarkupLevel.Inline)
		{
			x490834a62c46f14d((CompositeNode)x04137a6fd0e2d03c);
		}
		else
		{
			x04562d8eb06323c7.xc0c75e3447cb93ab(x04137a6fd0e2d03c);
		}
	}

	internal void xeb67d0521107425b(CompositeNode xda5bf54deb817e37)
	{
		x04562d8eb06323c7.xbf41e930a525aba9(xda5bf54deb817e37);
	}

	internal void xee59bcd855a217ab(x55997ac957018945 x04137a6fd0e2d03c, Paragraph xe45dd4634d9e5851)
	{
		if (x04137a6fd0e2d03c.x57b60ae60739c9b5 == MarkupLevel.Inline)
		{
			xf5b0b9b6ff7ac462(((Node)x04137a6fd0e2d03c).NodeType);
		}
		else
		{
			x04562d8eb06323c7.x8d4abec08bebbd61(xe45dd4634d9e5851);
		}
	}

	internal void x45d3b2f1461cff3e()
	{
		x04562d8eb06323c7.x79f7fd8368ae8a71();
	}
}
