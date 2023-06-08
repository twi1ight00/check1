using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using Aspose.Words.Rendering;
using x011d489fb9df7027;
using x13f1efc79617a47b;
using x28925c9b27b37a46;
using x6c95d9cf46ff5f25;
using x7c7a1dceb600404e;
using xf9a9481c3f63a419;

namespace Aspose.Words.Drawing;

public abstract class ShapeBase : CompositeNode, xf5ecf429e74b1c04, xcf3b0f04424de818, x7b71245a33212e76
{
	internal const int x96b794cd305272ec = 1024;

	internal const int x99486c91d08e66c6 = 1024;

	private int x56ecdaaf4ea2da97;

	private xf7125312c7ee115c x017d3b59849466e1 = new xf7125312c7ee115c();

	private xeedad81aaed42a76 xd0c44e5ae0011daa = new xeedad81aaed42a76();

	private x036de9c7a451eb39 x4d70fd5aa8f107be;

	private Font x154caea24cfa721a;

	internal static double x006c15aca3bb2b06 = 1584.0;

	internal static double x64038d11c73313f5 = 0.75;

	Paragraph xcf3b0f04424de818.x6b298f029e4a1f68 => ParentParagraph;

	DocumentBase xcf3b0f04424de818.x17d1cdafb1f5c088 => base.Document;

	int xf5ecf429e74b1c04.x5b8c6010012a5955 => xd0c44e5ae0011daa.xd44988f225497f3a;

	internal int xea1e81378298fa81
	{
		get
		{
			return (int)xfc928672852cc4c4(4124);
		}
		set
		{
			x0817d5cde9e19bf6(4124, value);
		}
	}

	public ShapeType ShapeType => (ShapeType)x017d3b59849466e1.xfe91eeeafcb3026a(4155);

	public bool IsGroup => ShapeType == ShapeType.Group;

	public bool IsImage => ShapeType == ShapeType.Image;

	internal bool x917b07206b752ba4 => ShapeType == ShapeType.OleObject;

	internal bool xa8228c6215bc2643 => ShapeType == ShapeType.OleControl;

	internal bool xa170cce2bc40bdf5
	{
		get
		{
			if (!x917b07206b752ba4)
			{
				return xa8228c6215bc2643;
			}
			return true;
		}
	}

	public bool IsHorizontalRule => (bool)xfc928672852cc4c4(948);

	internal bool xdbcc1aacec52b0fa => (bool)xfc928672852cc4c4(946);

	public bool IsWordArt => (bool)xfc928672852cc4c4(241);

	public bool CanHaveImage
	{
		get
		{
			ShapeType shapeType = ShapeType;
			if (shapeType == ShapeType.Group)
			{
				return false;
			}
			return true;
		}
	}

	internal bool x3d318285d887cd3a
	{
		get
		{
			if (!IsImage && !xa170cce2bc40bdf5 && !IsHorizontalRule && !IsWordArt)
			{
				return !x5abc6039e2a71e21;
			}
			return false;
		}
	}

	private bool x5abc6039e2a71e21 => ShapeType == ShapeType.CustomShape;

	internal bool xac9731dd322f2036
	{
		get
		{
			if (IsInline)
			{
				return x3d318285d887cd3a;
			}
			return false;
		}
	}

	internal bool x8934557a18f73b70
	{
		get
		{
			return (bool)xfc928672852cc4c4(4123);
		}
		set
		{
			if (value)
			{
				x0817d5cde9e19bf6(4123, true);
			}
		}
	}

	internal bool xd06a0f106e67d743
	{
		get
		{
			return (bool)xfc928672852cc4c4(945);
		}
		set
		{
			x0817d5cde9e19bf6(945, value);
		}
	}

	public double Left
	{
		get
		{
			return (double)xfc928672852cc4c4(4129);
		}
		set
		{
			x0817d5cde9e19bf6(4129, value);
		}
	}

	public double Top
	{
		get
		{
			return (double)xfc928672852cc4c4(4130);
		}
		set
		{
			x0817d5cde9e19bf6(4130, value);
		}
	}

	public double Right => Left + Width;

	public double Bottom => Top + Height;

	public double Width
	{
		get
		{
			return (double)xfc928672852cc4c4(4131);
		}
		set
		{
			xaf2be96d8c7ab7f4(value, x9199ed88324d69ff: true);
		}
	}

	public double Height
	{
		get
		{
			return (double)xfc928672852cc4c4(4132);
		}
		set
		{
			xb4985fedae542f10(value, x9199ed88324d69ff: true);
		}
	}

	[ComVisible(false)]
	public RectangleF Bounds
	{
		get
		{
			return new RectangleF((float)Left, (float)Top, (float)Width, (float)Height);
		}
		set
		{
			Left = value.Left;
			Top = value.Top;
			Width = value.Width;
			Height = value.Height;
		}
	}

	[ComVisible(false)]
	public RectangleF BoundsInPoints => xdd95551ca745bb85(Bounds);

	public SizeF SizeInPoints => BoundsInPoints.Size;

	internal SizeF x437e3b626c0fdd43 => new SizeF((float)Width, (float)Height);

	internal double x0fbf7f648b7e48b0 => Width / 2.0;

	internal double x2672ae16e797c0d7 => Height / 2.0;

	internal object x0f209d8e3c8948a0 => x048513c924d75f6b(1986);

	internal object xa4ddcd2df465f613 => x048513c924d75f6b(1987);

	internal object x19ae50b424c96078 => x048513c924d75f6b(1984);

	internal object xf0474d98e6c9a7ce => x048513c924d75f6b(1985);

	internal x8307b3d797c38a81 x8307b3d797c38a81 => (x8307b3d797c38a81)xfc928672852cc4c4(1988);

	internal xc51d0ca9388f31bd xc51d0ca9388f31bd => (xc51d0ca9388f31bd)xfc928672852cc4c4(1989);

	public FlipOrientation FlipOrientation
	{
		get
		{
			return (FlipOrientation)xfc928672852cc4c4(4096);
		}
		set
		{
			x0817d5cde9e19bf6(4096, value);
		}
	}

	public RelativeHorizontalPosition RelativeHorizontalPosition
	{
		get
		{
			return (RelativeHorizontalPosition)xfc928672852cc4c4(912);
		}
		set
		{
			x0817d5cde9e19bf6(912, value);
		}
	}

	public RelativeVerticalPosition RelativeVerticalPosition
	{
		get
		{
			return (RelativeVerticalPosition)xfc928672852cc4c4(914);
		}
		set
		{
			x0817d5cde9e19bf6(914, value);
		}
	}

	public HorizontalAlignment HorizontalAlignment
	{
		get
		{
			return (HorizontalAlignment)xfc928672852cc4c4(911);
		}
		set
		{
			x0817d5cde9e19bf6(911, value);
		}
	}

	public VerticalAlignment VerticalAlignment
	{
		get
		{
			return (VerticalAlignment)xfc928672852cc4c4(913);
		}
		set
		{
			x0817d5cde9e19bf6(913, value);
		}
	}

	public WrapType WrapType
	{
		get
		{
			return (WrapType)xfc928672852cc4c4(4097);
		}
		set
		{
			x0817d5cde9e19bf6(4097, value);
		}
	}

	public WrapSide WrapSide
	{
		get
		{
			return (WrapSide)xfc928672852cc4c4(4098);
		}
		set
		{
			x0817d5cde9e19bf6(4098, value);
		}
	}

	public bool AnchorLocked
	{
		get
		{
			return (bool)xfc928672852cc4c4(4099);
		}
		set
		{
			x0817d5cde9e19bf6(4099, value);
		}
	}

	public bool AllowOverlap
	{
		get
		{
			return (bool)xfc928672852cc4c4(950);
		}
		set
		{
			x0817d5cde9e19bf6(950, value);
		}
	}

	internal bool x87119342b85a2a43
	{
		get
		{
			return (bool)xfc928672852cc4c4(944);
		}
		set
		{
			x0817d5cde9e19bf6(944, value);
		}
	}

	public bool BehindText
	{
		get
		{
			return (bool)xfc928672852cc4c4(954);
		}
		set
		{
			x0817d5cde9e19bf6(954, value);
		}
	}

	public double DistanceTop
	{
		get
		{
			return x4574ea26106f0edb.xa23e6b6c3169521d((int)xfc928672852cc4c4(901));
		}
		set
		{
			x0817d5cde9e19bf6(901, x4574ea26106f0edb.x3aa08882c9feaf96(value));
		}
	}

	public double DistanceBottom
	{
		get
		{
			return x4574ea26106f0edb.xa23e6b6c3169521d((int)xfc928672852cc4c4(903));
		}
		set
		{
			x0817d5cde9e19bf6(903, x4574ea26106f0edb.x3aa08882c9feaf96(value));
		}
	}

	public double DistanceLeft
	{
		get
		{
			return x4574ea26106f0edb.xa23e6b6c3169521d((int)xfc928672852cc4c4(900));
		}
		set
		{
			x0817d5cde9e19bf6(900, x4574ea26106f0edb.x3aa08882c9feaf96(value));
		}
	}

	public double DistanceRight
	{
		get
		{
			return x4574ea26106f0edb.xa23e6b6c3169521d((int)xfc928672852cc4c4(902));
		}
		set
		{
			x0817d5cde9e19bf6(902, x4574ea26106f0edb.x3aa08882c9feaf96(value));
		}
	}

	public bool IsInline => WrapType == WrapType.Inline;

	public int ZOrder
	{
		get
		{
			return (int)xfc928672852cc4c4(4154);
		}
		set
		{
			x0817d5cde9e19bf6(4154, value);
		}
	}

	internal int x2dacf7fcd96fee63
	{
		get
		{
			return x56ecdaaf4ea2da97;
		}
		set
		{
			x56ecdaaf4ea2da97 = value;
		}
	}

	internal x036de9c7a451eb39 x036de9c7a451eb39
	{
		get
		{
			if (x4d70fd5aa8f107be == null)
			{
				x4d70fd5aa8f107be = new x036de9c7a451eb39(this);
			}
			return x4d70fd5aa8f107be;
		}
	}

	public double Rotation
	{
		get
		{
			return x4574ea26106f0edb.x97ab502db0c0e5c2((int)xfc928672852cc4c4(4));
		}
		set
		{
			x0817d5cde9e19bf6(4, x4574ea26106f0edb.x091b250f00534aae(value));
		}
	}

	public Point CoordOrigin
	{
		get
		{
			return new Point(x06c65daad0c0656c, x399bb78ac51a4081);
		}
		set
		{
			x06c65daad0c0656c = value.X;
			x399bb78ac51a4081 = value.Y;
		}
	}

	internal int x06c65daad0c0656c
	{
		get
		{
			return (int)xfc928672852cc4c4(4125);
		}
		set
		{
			x0817d5cde9e19bf6(4125, value);
		}
	}

	internal int x399bb78ac51a4081
	{
		get
		{
			return (int)xfc928672852cc4c4(4126);
		}
		set
		{
			x0817d5cde9e19bf6(4126, value);
		}
	}

	public Size CoordSize
	{
		get
		{
			return new Size(x133d653c1b9b01f2, xc97e136f0019c237);
		}
		set
		{
			if (value.Width <= 0 || value.Height <= 0)
			{
				throw new ArgumentOutOfRangeException("value", string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("ggbmgiimhhpmchgnkhnnlceolgloehcpbhjpbhaaaghacgoaegfbefmbegdccfkckabdkfidefpdcegebeneaeefipkfiecgldjgjeahbdhhjonhjcfiecmiocdjlckjjcbklcikenokdbgldbnllmdmeblmkacnfbjncbaomlgonaooopepeplpopcankjajpabjphbekobgofcpomcapddjnkdbobecjiedopelngfjinfaoegimlgcnchmmjhiiai", 1522123034)));
			}
			x0ac950b592cc7720(value);
		}
	}

	internal int x133d653c1b9b01f2 => (int)xfc928672852cc4c4(4127);

	internal int xc97e136f0019c237 => (int)xfc928672852cc4c4(4128);

	public string ScreenTip
	{
		get
		{
			return (string)xfc928672852cc4c4(909);
		}
		set
		{
			x0d299f323d241756.x0aaaea7864a53f26(value, "value");
			x0817d5cde9e19bf6(909, value);
		}
	}

	public string HRef
	{
		get
		{
			return (string)xfc928672852cc4c4(898);
		}
		set
		{
			x0d299f323d241756.x0aaaea7864a53f26(value, "value");
			x0817d5cde9e19bf6(898, value);
		}
	}

	internal double xb494f7568f103233
	{
		get
		{
			double num = 0.0;
			Node node = this;
			do
			{
				num += ((ShapeBase)node).Rotation;
				node = node.ParentNode;
			}
			while (node != null && node.NodeType == NodeType.GroupShape);
			return num;
		}
	}

	internal bool xbfc952aeef7fd0d5 => x0d299f323d241756.x5959bccb67bbf051(HRef);

	internal bool xe415f17cf389e946
	{
		get
		{
			if (IsInline && xbfc952aeef7fd0d5)
			{
				if (!IsImage)
				{
					return x917b07206b752ba4;
				}
				return true;
			}
			return false;
		}
	}

	internal string x8edafc3cf6e5431a => x0d4d45882065c63e.xc8c8ca56669559a3(HRef);

	internal string xffd5ab6c569c488d => x0d4d45882065c63e.x358b45b4ddbfa57c(HRef);

	public string Target
	{
		get
		{
			return (string)xfc928672852cc4c4(4120);
		}
		set
		{
			x0d299f323d241756.x0aaaea7864a53f26(value, "value");
			x0817d5cde9e19bf6(4120, value);
		}
	}

	public string AlternativeText
	{
		get
		{
			return (string)xfc928672852cc4c4(897);
		}
		set
		{
			x0d299f323d241756.x0aaaea7864a53f26(value, "value");
			x0817d5cde9e19bf6(897, value);
		}
	}

	internal xf7125312c7ee115c xf7125312c7ee115c
	{
		get
		{
			return x017d3b59849466e1;
		}
		set
		{
			x017d3b59849466e1 = value;
		}
	}

	internal xeedad81aaed42a76 xeedad81aaed42a76
	{
		get
		{
			return xd0c44e5ae0011daa;
		}
		set
		{
			xd0c44e5ae0011daa = value;
		}
	}

	xeedad81aaed42a76 xcf3b0f04424de818.x2f8bb6c2cbd66330
	{
		get
		{
			return xd0c44e5ae0011daa;
		}
		set
		{
			xd0c44e5ae0011daa = value;
		}
	}

	public Font Font
	{
		get
		{
			if (x154caea24cfa721a == null)
			{
				x154caea24cfa721a = new Font(this, base.Document.Styles);
			}
			return x154caea24cfa721a;
		}
	}

	internal x5b865d49b2c8440d x5b865d49b2c8440d
	{
		get
		{
			return (x5b865d49b2c8440d)xfc928672852cc4c4(771);
		}
		set
		{
			x0817d5cde9e19bf6(771, value);
		}
	}

	internal bool x6dcbdae8b4f7f447 => x5b865d49b2c8440d != x5b865d49b2c8440d.x4d0b9d4447ba7566;

	internal int xc95ed8e8690eb564
	{
		get
		{
			return (int)xfc928672852cc4c4(128);
		}
		set
		{
			x0817d5cde9e19bf6(128, value);
		}
	}

	internal int xdf3d5f8941ea27a6
	{
		get
		{
			return (int)xfc928672852cc4c4(138);
		}
		set
		{
			x0817d5cde9e19bf6(138, value);
		}
	}

	public bool IsTopLevel
	{
		get
		{
			if (base.ParentNode != null)
			{
				return base.ParentNode.NodeType != NodeType.GroupShape;
			}
			return true;
		}
	}

	public Paragraph ParentParagraph => base.ParentNode as Paragraph;

	public bool IsInsertRevision => x684b09378db148f4.xdb80a3a0801e3e63(this);

	public bool IsDeleteRevision => x684b09378db148f4.xd779a54e74a3c346(this);

	public string Name
	{
		get
		{
			return (string)xfc928672852cc4c4(896);
		}
		set
		{
			x0d299f323d241756.x0aaaea7864a53f26(value, "value");
			x0817d5cde9e19bf6(896, value);
		}
	}

	internal bool x96e55b5d052d1279
	{
		get
		{
			return (bool)xfc928672852cc4c4(958);
		}
		set
		{
			x0817d5cde9e19bf6(958, value);
		}
	}

	internal bool x895b1223bcc162ac => (bool)xfc928672852cc4c4(1983);

	internal byte[] xded2c9c41054f4dd => (byte[])x048513c924d75f6b(1792);

	internal bool x04253a50feaae58a => (bool)xfc928672852cc4c4(1855);

	public ShapeRenderer GetShapeRenderer()
	{
		return new ShapeRenderer(this);
	}

	internal bool x133a5347d32dce7a()
	{
		if (NodeType == NodeType.Shape)
		{
			return base.HasChildNodes;
		}
		foreach (Shape childNode in GetChildNodes(NodeType.Shape, isDeep: true))
		{
			if (childNode.HasChildNodes)
			{
				return true;
			}
		}
		return false;
	}

	internal bool xa4281603feb56c8c()
	{
		return GetChildNodes(NodeType.FieldStart, isDeep: true).Count > 0;
	}

	protected ShapeBase(DocumentBase doc)
		: base(doc)
	{
		if (doc != null)
		{
			xea1e81378298fa81 = doc.xc726a4cdc433ae49();
		}
	}

	internal void x88d1b78392d1a0ab(ShapeType x02f2ab213025de6d)
	{
		x0817d5cde9e19bf6(4155, x02f2ab213025de6d);
	}

	internal override Node x8b61531c8ea35b85(bool x7a5f12b98e34a590, x15a33f6d96885286 xe870d6f33992ceb4)
	{
		ShapeBase shapeBase = (ShapeBase)base.x8b61531c8ea35b85(x7a5f12b98e34a590, xe870d6f33992ceb4);
		shapeBase.x017d3b59849466e1 = (xf7125312c7ee115c)x017d3b59849466e1.x8b61531c8ea35b85();
		shapeBase.xd0c44e5ae0011daa = (xeedad81aaed42a76)xd0c44e5ae0011daa.x8b61531c8ea35b85();
		shapeBase.x4d70fd5aa8f107be = null;
		shapeBase.x154caea24cfa721a = null;
		return shapeBase;
	}

	internal xeedad81aaed42a76 x856218fd0771d379(xecac24b19ed3a2b7 xebf45bdcaa1fd1e1)
	{
		return x684b09378db148f4.x856218fd0771d379(this, xebf45bdcaa1fd1e1);
	}

	private xeedad81aaed42a76 x91e3a7c2f71688fa(xecac24b19ed3a2b7 xebf45bdcaa1fd1e1)
	{
		return x684b09378db148f4.x856218fd0771d379(this, xebf45bdcaa1fd1e1);
	}

	xeedad81aaed42a76 xcf3b0f04424de818.x75cbc81364d91526(xecac24b19ed3a2b7 xebf45bdcaa1fd1e1)
	{
		//ILSpy generated this explicit interface implementation from .override directive in x91e3a7c2f71688fa
		return this.x91e3a7c2f71688fa(xebf45bdcaa1fd1e1);
	}

	private object x93e461c176ca1e50(int x6cc530a2cd983862)
	{
		return xd0c44e5ae0011daa.xf7866f89640a29a3(x6cc530a2cd983862);
	}

	object xf5ecf429e74b1c04.x9bd0b4c41657450b(int x6cc530a2cd983862)
	{
		//ILSpy generated this explicit interface implementation from .override directive in x93e461c176ca1e50
		return this.x93e461c176ca1e50(x6cc530a2cd983862);
	}

	private void x9939815f86bdcfc3(int xc0c4c459c6ccbd00, out int xba08ce632055a1d9, out object xbcea506a33cf9111)
	{
		xba08ce632055a1d9 = xd0c44e5ae0011daa.xf15263674eb297bb(xc0c4c459c6ccbd00);
		xbcea506a33cf9111 = xd0c44e5ae0011daa.x6d3720b962bd3112(xc0c4c459c6ccbd00);
	}

	void xf5ecf429e74b1c04.x16b3a875e7cc38ed(int xc0c4c459c6ccbd00, out int xba08ce632055a1d9, out object xbcea506a33cf9111)
	{
		//ILSpy generated this explicit interface implementation from .override directive in x9939815f86bdcfc3
		this.x9939815f86bdcfc3(xc0c4c459c6ccbd00, out xba08ce632055a1d9, out xbcea506a33cf9111);
	}

	private object xa49e661f5cc91e49(int x6cc530a2cd983862)
	{
		return x684b09378db148f4.xdafa1f94b023b665(this, x6cc530a2cd983862);
	}

	object xf5ecf429e74b1c04.x2685f947206319cf(int x6cc530a2cd983862)
	{
		//ILSpy generated this explicit interface implementation from .override directive in xa49e661f5cc91e49
		return this.xa49e661f5cc91e49(x6cc530a2cd983862);
	}

	private void x09376e92b9e1f394(int x6cc530a2cd983862, object xbcea506a33cf9111)
	{
		xd0c44e5ae0011daa.xae20093bed1e48a8(x6cc530a2cd983862, xbcea506a33cf9111);
	}

	void xf5ecf429e74b1c04.xd00aa8389522ce53(int x6cc530a2cd983862, object xbcea506a33cf9111)
	{
		//ILSpy generated this explicit interface implementation from .override directive in x09376e92b9e1f394
		this.x09376e92b9e1f394(x6cc530a2cd983862, xbcea506a33cf9111);
	}

	private void x69045f836de92891()
	{
		xd0c44e5ae0011daa.ClearAttrs();
	}

	void xf5ecf429e74b1c04.xe80983f2918b2568()
	{
		//ILSpy generated this explicit interface implementation from .override directive in x69045f836de92891
		this.x69045f836de92891();
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public object x048513c924d75f6b(int xba08ce632055a1d9)
	{
		return x017d3b59849466e1.xf7866f89640a29a3(xba08ce632055a1d9);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public object x21ab6fa9997bd6d3(int xba08ce632055a1d9)
	{
		xf7125312c7ee115c xf7125312c7ee115c = x6f6338c074d2d794.xc49bc34e8c134250(ShapeType);
		if (xf7125312c7ee115c != null)
		{
			return xf7125312c7ee115c.xfe91eeeafcb3026a(xba08ce632055a1d9);
		}
		return xf7125312c7ee115c.x0095b789d636f3ae(xba08ce632055a1d9);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public object xfc928672852cc4c4(int xba08ce632055a1d9)
	{
		object obj = x048513c924d75f6b(xba08ce632055a1d9);
		if (obj == null)
		{
			return x21ab6fa9997bd6d3(xba08ce632055a1d9);
		}
		return obj;
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public void x0817d5cde9e19bf6(int xba08ce632055a1d9, object xbcea506a33cf9111)
	{
		x017d3b59849466e1.xae20093bed1e48a8(xba08ce632055a1d9, xbcea506a33cf9111);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public void xf26165853f0b9b77(int xba08ce632055a1d9)
	{
		x017d3b59849466e1.x52b190e626f65140(xba08ce632055a1d9);
	}

	internal void x2a1d93e8568f66ed(double x9b0739496f8b5475, double x4d5aabc7a55b12ba)
	{
		if (x0d321a5002eeb445(x9b0739496f8b5475, x4d5aabc7a55b12ba))
		{
			double num = 0.0;
			double num2 = 0.0;
			Shape shape = (Shape)GetAncestor(NodeType.Shape);
			if (shape != null)
			{
				num = shape.Width;
				num2 = shape.Height;
			}
			else
			{
				Section section = (Section)GetAncestor(NodeType.Section);
				if (section != null)
				{
					PageSetup pageSetup = section.PageSetup;
					num = pageSetup.PageWidth - pageSetup.LeftMargin - pageSetup.RightMargin;
					num2 = pageSetup.PageHeight - pageSetup.TopMargin - pageSetup.BottomMargin;
				}
			}
			double num3 = x9b0739496f8b5475 / num;
			double num4 = x4d5aabc7a55b12ba / num2;
			if (num3 > num4)
			{
				num2 *= num4 / num3;
			}
			else
			{
				num *= num3 / num4;
			}
			xf524ccc95fe8e714(num);
			x404ab2fc377ad1ed(num2);
		}
		else
		{
			xf524ccc95fe8e714(x9b0739496f8b5475);
			x404ab2fc377ad1ed(x4d5aabc7a55b12ba);
		}
	}

	private bool x0d321a5002eeb445(double x9b0739496f8b5475, double x4d5aabc7a55b12ba)
	{
		if (base.ParentNode != null)
		{
			if (!(x9b0739496f8b5475 > x006c15aca3bb2b06))
			{
				return x4d5aabc7a55b12ba > x006c15aca3bb2b06;
			}
			return true;
		}
		return false;
	}

	internal void xf524ccc95fe8e714(double xbcea506a33cf9111)
	{
		xaf2be96d8c7ab7f4(xbcea506a33cf9111, x9199ed88324d69ff: false);
	}

	private void xaf2be96d8c7ab7f4(double xbcea506a33cf9111, bool x9199ed88324d69ff)
	{
		x0817d5cde9e19bf6(4131, x5a62e47e2d256568(xbcea506a33cf9111, x9199ed88324d69ff, "width"));
	}

	internal void x404ab2fc377ad1ed(double xbcea506a33cf9111)
	{
		xb4985fedae542f10(xbcea506a33cf9111, x9199ed88324d69ff: false);
	}

	private void xb4985fedae542f10(double xbcea506a33cf9111, bool x9199ed88324d69ff)
	{
		x0817d5cde9e19bf6(4132, x5a62e47e2d256568(xbcea506a33cf9111, x9199ed88324d69ff, "height"));
	}

	internal void x6315bc3d24476fb0()
	{
		xf524ccc95fe8e714(Width);
		x404ab2fc377ad1ed(Height);
	}

	private double x5a62e47e2d256568(double xbcea506a33cf9111, bool x9199ed88324d69ff, string x7c472d761b51a543)
	{
		if (xbcea506a33cf9111 < 0.0)
		{
			if (x9199ed88324d69ff)
			{
				throw new ArgumentOutOfRangeException("value", string.Format(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("pdimbfpmhegndfnnfeeonpkoffcphajpbfaabpgabdoamcfbgdmbdddcbdkcddbdmnhdlbpdlbgednmembefcblfnbcgkbjgempgfbhhgaohmpeigamiflcjcmjjnlak", 572704748)), x7c472d761b51a543));
			}
			return 0.0;
		}
		if (xbcea506a33cf9111 > x006c15aca3bb2b06 && IsTopLevel)
		{
			if (base.ParentNode == null)
			{
				return xbcea506a33cf9111;
			}
			if (x9199ed88324d69ff)
			{
				throw new ArgumentOutOfRangeException("value", string.Format(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("lmgpnnnpdneapnlabncbjijbboacdjhcnnocnhfdnlmdildecmkeplbfnlifplpfiggghknghkehpflhdkcilkjiljajejhjekojcjfkmjmkhedlijkljibmphimjipmidgnajnndeeomilomccpjhjpfhaamghaogoabhfbngmbfcdc", 2053240440)), x7c472d761b51a543, xca004f56614e2431.xcaaeec2e96b2cecc(x006c15aca3bb2b06)));
			}
			return x64038d11c73313f5;
		}
		return xbcea506a33cf9111;
	}

	public PointF LocalToParent(PointF value)
	{
		value = new PointF(value.X - (float)CoordOrigin.X, value.Y - (float)CoordOrigin.Y);
		value = new PointF((float)((double)value.X * (Width / (double)CoordSize.Width)), (float)((double)value.Y * (Height / (double)CoordSize.Height)));
		value = new PointF(value.X + (float)Left, value.Y + (float)Top);
		return value;
	}

	internal bool x345365647af5db37()
	{
		x08d932077485c285[] array = (x08d932077485c285[])xf7125312c7ee115c.xf7866f89640a29a3(325);
		if (ShapeType == ShapeType.NonPrimitive && x15e971129fd80714.x5ab3b42bd288ad29(Width) && x15e971129fd80714.x5ab3b42bd288ad29(Height) && array != null)
		{
			return array.Length > 0;
		}
		return false;
	}

	internal void xdfdf94b7f842e919()
	{
		x08d932077485c285[] array = (x08d932077485c285[])xf7125312c7ee115c.xf7866f89640a29a3(325);
		PointF[] array2 = x3fd0128b66a7a61a(array);
		if (array2 != null)
		{
			RectangleF rectangleF = x37d2d88f96f87b47.x37b1dbbad6246778(array2);
			Width = x4574ea26106f0edb.x0e1fdb362561ddb2(rectangleF.Width);
			Height = x4574ea26106f0edb.x0e1fdb362561ddb2(rectangleF.Height);
			Left = x4574ea26106f0edb.x0e1fdb362561ddb2(rectangleF.X);
			Top = x4574ea26106f0edb.x0e1fdb362561ddb2(rectangleF.Y);
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = new x08d932077485c285(array[i].x8df91a2f90079e88.xd2f68ee6f47e9dfb - (int)rectangleF.X, array[i].xc821290d7ecc08bf.xd2f68ee6f47e9dfb - (int)rectangleF.Y);
			}
			x0817d5cde9e19bf6(325, array);
		}
	}

	internal void x4ad54dc2280f4b6f()
	{
		if (IsHorizontalRule && xf7125312c7ee115c.x263d579af1d0d43f(917))
		{
			x404ab2fc377ad1ed(x4574ea26106f0edb.x0e1fdb362561ddb2((int)x048513c924d75f6b(917)));
			xf26165853f0b9b77(917);
		}
	}

	private static PointF[] x3fd0128b66a7a61a(x08d932077485c285[] x70e44fe84dd46cf1)
	{
		if (x70e44fe84dd46cf1 != null && x70e44fe84dd46cf1.Length > 0)
		{
			PointF[] array = new PointF[x70e44fe84dd46cf1.Length];
			for (int i = 0; i < x70e44fe84dd46cf1.Length; i++)
			{
				x08d932077485c285 x08d932077485c = x70e44fe84dd46cf1[i];
				ref PointF reference = ref array[i];
				reference = new PointF(x08d932077485c.x8df91a2f90079e88.xd2f68ee6f47e9dfb, x08d932077485c.xc821290d7ecc08bf.xd2f68ee6f47e9dfb);
			}
			return array;
		}
		return null;
	}

	internal PointF x19cd1409c300dd76(PointF xbcea506a33cf9111)
	{
		CompositeNode parentNode = base.ParentNode;
		while (parentNode is ShapeBase)
		{
			xbcea506a33cf9111 = ((ShapeBase)parentNode).LocalToParent(xbcea506a33cf9111);
			parentNode = parentNode.ParentNode;
		}
		return xbcea506a33cf9111;
	}

	internal RectangleF xdd95551ca745bb85(RectangleF x26545669838eb36e)
	{
		PointF pointF = x19cd1409c300dd76(x26545669838eb36e.Location);
		PointF pointF2 = x19cd1409c300dd76(new PointF(x26545669838eb36e.Right, x26545669838eb36e.Bottom));
		return new RectangleF(pointF.X, pointF.Y, pointF2.X - pointF.X, pointF2.Y - pointF.Y);
	}

	internal void x983fb06bfa0c608a()
	{
		if (IsTopLevel)
		{
			Section section = (Section)GetAncestor(NodeType.Section);
			if (section != null)
			{
				PageSetup pageSetup = section.PageSetup;
				xdc3ff5a567d613c7(pageSetup);
				x3c18b6df8ef16d6b(pageSetup);
				x7eeafa6e52ae797f(pageSetup);
				xe6994d3180528efb(pageSetup);
			}
		}
	}

	private void xdc3ff5a567d613c7(PageSetup xaa066f9e98b59c33)
	{
		object obj = x0f209d8e3c8948a0;
		if (obj != null)
		{
			double num = (double)(int)obj / 1000.0;
			switch (RelativeHorizontalPosition)
			{
			case RelativeHorizontalPosition.Margin:
				Left = (double)xaa066f9e98b59c33.x887b872a95caaab5 * num;
				break;
			case RelativeHorizontalPosition.Page:
				Left = xaa066f9e98b59c33.PageWidth * num;
				break;
			case RelativeHorizontalPosition.LeftMargin:
			case RelativeHorizontalPosition.OutsideMargin:
				Left = xaa066f9e98b59c33.LeftMargin * num;
				break;
			case RelativeHorizontalPosition.RightMargin:
			case RelativeHorizontalPosition.InsideMargin:
				Left = xaa066f9e98b59c33.RightMargin * num;
				break;
			case RelativeHorizontalPosition.Column:
			case RelativeHorizontalPosition.Character:
				break;
			}
		}
	}

	private void x3c18b6df8ef16d6b(PageSetup xaa066f9e98b59c33)
	{
		object obj = xa4ddcd2df465f613;
		if (obj != null)
		{
			double num = (double)(int)obj / 1000.0;
			switch (RelativeVerticalPosition)
			{
			case RelativeVerticalPosition.Margin:
				Top = (double)xaa066f9e98b59c33.xbcd477821fdbd81b * num;
				break;
			case RelativeVerticalPosition.Page:
				Top = xaa066f9e98b59c33.PageHeight * num;
				break;
			case RelativeVerticalPosition.TopMargin:
			case RelativeVerticalPosition.InsideMargin:
			case RelativeVerticalPosition.OutsideMargin:
				Top = xaa066f9e98b59c33.TopMargin * num;
				break;
			case RelativeVerticalPosition.BottomMargin:
				Top = xaa066f9e98b59c33.BottomMargin * num;
				break;
			case RelativeVerticalPosition.Paragraph:
			case RelativeVerticalPosition.Line:
				break;
			}
		}
	}

	private void x7eeafa6e52ae797f(PageSetup xaa066f9e98b59c33)
	{
		object obj = x19ae50b424c96078;
		if (obj == null)
		{
			return;
		}
		double num = (double)(int)obj / 1000.0;
		if (!(num <= 0.0))
		{
			switch (x8307b3d797c38a81)
			{
			case x8307b3d797c38a81.x6545d1f2c1b77773:
				Width = (double)xaa066f9e98b59c33.x887b872a95caaab5 * num;
				break;
			case x8307b3d797c38a81.xa65184d44a47025b:
				Width = xaa066f9e98b59c33.PageWidth * num;
				break;
			case x8307b3d797c38a81.xc8a7b7ce5c5279ee:
			case x8307b3d797c38a81.x83872bdc36afd363:
				Width = xaa066f9e98b59c33.LeftMargin * num;
				break;
			case x8307b3d797c38a81.x3fa6fa3075fd558f:
			case x8307b3d797c38a81.xb4c1522a4ff754c9:
				Width = xaa066f9e98b59c33.RightMargin * num;
				break;
			}
		}
	}

	private void xe6994d3180528efb(PageSetup xaa066f9e98b59c33)
	{
		object obj = xf0474d98e6c9a7ce;
		if (obj == null)
		{
			return;
		}
		double num = (double)(int)obj / 1000.0;
		if (!(num <= 0.0))
		{
			switch (xc51d0ca9388f31bd)
			{
			case xc51d0ca9388f31bd.x6545d1f2c1b77773:
				Height = (double)xaa066f9e98b59c33.xbcd477821fdbd81b * num;
				break;
			case xc51d0ca9388f31bd.xa65184d44a47025b:
				Height = xaa066f9e98b59c33.PageHeight * num;
				break;
			case xc51d0ca9388f31bd.xc07fe3840d9e6d76:
			case xc51d0ca9388f31bd.xb4c1522a4ff754c9:
			case xc51d0ca9388f31bd.x83872bdc36afd363:
				Height = xaa066f9e98b59c33.TopMargin * num;
				break;
			case xc51d0ca9388f31bd.x65011a5ae8c64a43:
				Height = xaa066f9e98b59c33.BottomMargin * num;
				break;
			}
		}
	}

	internal void x0ac950b592cc7720(Size xbcea506a33cf9111)
	{
		xfe47e26e3b236632(xbcea506a33cf9111.Width);
		x27bd4aa4cf0ce1aa(xbcea506a33cf9111.Height);
	}

	internal void xfe47e26e3b236632(int x9b0739496f8b5475)
	{
		x5d3537c0c5e90d27(4127, x9b0739496f8b5475);
	}

	internal void x27bd4aa4cf0ce1aa(int xbcea506a33cf9111)
	{
		x5d3537c0c5e90d27(4128, xbcea506a33cf9111);
	}

	private void x5d3537c0c5e90d27(int xba08ce632055a1d9, int xbcea506a33cf9111)
	{
		if (xbcea506a33cf9111 <= 0)
		{
			xbcea506a33cf9111 = (int)x21ab6fa9997bd6d3(xba08ce632055a1d9);
		}
		x0817d5cde9e19bf6(xba08ce632055a1d9, xbcea506a33cf9111);
	}
}
