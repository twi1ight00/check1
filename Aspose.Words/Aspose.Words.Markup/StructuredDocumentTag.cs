using System;
using System.Xml;
using Aspose.Words.BuildingBlocks;
using x28925c9b27b37a46;
using x53eb9320ebbb8395;
using x6c95d9cf46ff5f25;

namespace Aspose.Words.Markup;

public class StructuredDocumentTag : CompositeNode, x55997ac957018945
{
	internal const int xc281fbee312f0a20 = -1;

	private const string x2d3c889cb3d3c962 = "ListItems is only accessible for ComboBox or DropDownList SDT types.";

	private const string xff5280a0198a2536 = "DateDisplayLocale is only accessible for Date SDT type.";

	private const string xd24d42180bddc58a = "DateDisplayFormat is only accessible for Date SDT type.";

	private const string x060cbcce041ed8cc = "FullDate is only accessible for Date SDT type.";

	private const string x1821fa1cfdd1332a = "DateStorageFormat is only accessible for Date SDT type.";

	private const string xafba61e16d9efd6c = "CalendarType is only accessible for Date SDT type.";

	private const string xc8c3815e3319bc08 = "BuildingBlockType is only accessible for BuildingBlockGallery SDT type.";

	private const string x12c163d0dc09a564 = "BuildingBlockCategory is only accessible for BuildingBlockGallery SDT type.";

	private const string x88e80747c845278b = "Multiline is only accessible for Richtext and Plaintext SDT types.";

	private string x3fbe406c62095195;

	private readonly MarkupLevel xaabccab0c06d038b;

	private xce81d6edccc8b285 x8de82c6fb300e64b;

	private x3be06ee5a3bb124b xdd1dd893045d449a;

	private int xb7af9f1ce9822479;

	private bool x7800d85e7f74995f;

	private int x60adf410a9cceab0 = -1;

	private string xf7bbe199f47f234d = "";

	private bool xc42e23a244c374e2;

	private int x8e9e68c3d2f4dd7a;

	private string x1b3f1d3c6e265440 = "";

	private bool xfb802a40dd0af990;

	private xeedad81aaed42a76 xd2bb620c2dd1dc86;

	private xeedad81aaed42a76 xebb872331395e687;

	private BuildingBlock x18078bbe01c444ae;

	private bool x11c5e5ea0bac1636;

	private bool x746cfd7abc8fdfd1;

	private Font x0e940fbf79cbc44e;

	private Font x573c57c71f6a5746;

	public override NodeType NodeType => NodeType.StructuredDocumentTag;

	public BuildingBlock Placeholder => x18078bbe01c444ae;

	public string PlaceholderName
	{
		get
		{
			return x3fbe406c62095195;
		}
		set
		{
			x0d299f323d241756.x0aaaea7864a53f26(value, "value");
			x0d96312ab6b79c72(value);
			BuildingBlock buildingBlock = base.Document.x2f5330e0b9089bce.xe25c33c4a4a5dd49(this, x4a492b36640fb263: false);
			if (buildingBlock != null)
			{
				x18078bbe01c444ae = buildingBlock;
				if (IsShowingPlaceholderText || x748c99c08cdf7cb1 == null || !x748c99c08cdf7cb1.x22ab5dfa6f12e902())
				{
					RemoveAllChildren();
					xb267219cbd6be42f.x2fb01e788b713cac(this);
				}
				return;
			}
			throw new InvalidOperationException("BuildingBlock with such Name does not exist in the document glossary.");
		}
	}

	public MarkupLevel Level => xaabccab0c06d038b;

	public SdtType SdtType => x96381e70e1c51c6d.x3146d638ec378671;

	public int Id => x60adf410a9cceab0;

	public bool LockContentControl
	{
		get
		{
			return x11c5e5ea0bac1636;
		}
		set
		{
			x11c5e5ea0bac1636 = value;
		}
	}

	public bool LockContents
	{
		get
		{
			return x746cfd7abc8fdfd1;
		}
		set
		{
			x746cfd7abc8fdfd1 = value;
		}
	}

	public bool IsShowingPlaceholderText
	{
		get
		{
			return xc42e23a244c374e2;
		}
		set
		{
			xc42e23a244c374e2 = value;
		}
	}

	public string Tag
	{
		get
		{
			return x1b3f1d3c6e265440;
		}
		set
		{
			x0d299f323d241756.x0aaaea7864a53f26(value, "value");
			x1b3f1d3c6e265440 = value;
		}
	}

	public Font ContentsFont
	{
		get
		{
			if (x0e940fbf79cbc44e == null)
			{
				x0e940fbf79cbc44e = new Font(xde86b50786169450, base.Document.Styles);
			}
			return x0e940fbf79cbc44e;
		}
	}

	public Font EndCharacterFont
	{
		get
		{
			if (x573c57c71f6a5746 == null)
			{
				x573c57c71f6a5746 = new Font(xa29d931f51e74fb3, base.Document.Styles);
			}
			return x573c57c71f6a5746;
		}
	}

	public bool IsTemporary
	{
		get
		{
			return xfb802a40dd0af990;
		}
		set
		{
			xfb802a40dd0af990 = value;
		}
	}

	public string Title
	{
		get
		{
			return xf7bbe199f47f234d;
		}
		set
		{
			x0d299f323d241756.x0aaaea7864a53f26(value, "value");
			xf7bbe199f47f234d = value;
		}
	}

	public SdtListItemCollection ListItems
	{
		get
		{
			xe0b89d98a08884e6();
			if (SdtType == SdtType.ComboBox || SdtType == SdtType.DropDownList)
			{
				return ((x0fc5347a41e2da70)x96381e70e1c51c6d).x883eea81d91d4029;
			}
			throw new InvalidOperationException("ListItems is only accessible for ComboBox or DropDownList SDT types.");
		}
	}

	public int DateDisplayLocale
	{
		get
		{
			xe0b89d98a08884e6();
			if (SdtType == SdtType.Date)
			{
				return ((xb195c94e6015d34a)x96381e70e1c51c6d).xc6c1e6f7d84e1707;
			}
			throw new InvalidOperationException("DateDisplayLocale is only accessible for Date SDT type.");
		}
		set
		{
			xe0b89d98a08884e6();
			if (SdtType == SdtType.Date)
			{
				((xb195c94e6015d34a)x96381e70e1c51c6d).xc6c1e6f7d84e1707 = value;
				return;
			}
			throw new InvalidOperationException("DateDisplayLocale is only accessible for Date SDT type.");
		}
	}

	public string DateDisplayFormat
	{
		get
		{
			xe0b89d98a08884e6();
			if (SdtType == SdtType.Date)
			{
				return ((xb195c94e6015d34a)x96381e70e1c51c6d).xacc0cf2788d5c15a;
			}
			throw new InvalidOperationException("DateDisplayFormat is only accessible for Date SDT type.");
		}
		set
		{
			x0d299f323d241756.x0aaaea7864a53f26(value, "value");
			xe0b89d98a08884e6();
			if (SdtType == SdtType.Date)
			{
				((xb195c94e6015d34a)x96381e70e1c51c6d).xacc0cf2788d5c15a = value;
				return;
			}
			throw new InvalidOperationException("DateDisplayFormat is only accessible for Date SDT type.");
		}
	}

	public DateTime FullDate
	{
		get
		{
			xe0b89d98a08884e6();
			if (SdtType == SdtType.Date)
			{
				return ((xb195c94e6015d34a)x96381e70e1c51c6d).x6bcf08208cc26627;
			}
			throw new InvalidOperationException("FullDate is only accessible for Date SDT type.");
		}
		set
		{
			xe0b89d98a08884e6();
			if (SdtType == SdtType.Date)
			{
				((xb195c94e6015d34a)x96381e70e1c51c6d).x6bcf08208cc26627 = value;
				return;
			}
			throw new InvalidOperationException("FullDate is only accessible for Date SDT type.");
		}
	}

	public SdtDateStorageFormat DateStorageFormat
	{
		get
		{
			xe0b89d98a08884e6();
			if (SdtType == SdtType.Date)
			{
				return ((xb195c94e6015d34a)x96381e70e1c51c6d).x234f6481bd6906d3;
			}
			throw new InvalidOperationException("DateStorageFormat is only accessible for Date SDT type.");
		}
		set
		{
			xe0b89d98a08884e6();
			if (SdtType == SdtType.Date)
			{
				((xb195c94e6015d34a)x96381e70e1c51c6d).x234f6481bd6906d3 = value;
				return;
			}
			throw new InvalidOperationException("DateStorageFormat is only accessible for Date SDT type.");
		}
	}

	public SdtCalendarType CalendarType
	{
		get
		{
			xe0b89d98a08884e6();
			if (SdtType == SdtType.Date)
			{
				return ((xb195c94e6015d34a)x96381e70e1c51c6d).x85e0792106b8352f;
			}
			throw new InvalidOperationException("CalendarType is only accessible for Date SDT type.");
		}
		set
		{
			xe0b89d98a08884e6();
			if (SdtType == SdtType.Date)
			{
				((xb195c94e6015d34a)x96381e70e1c51c6d).x85e0792106b8352f = value;
				return;
			}
			throw new InvalidOperationException("CalendarType is only accessible for Date SDT type.");
		}
	}

	public string BuildingBlockGallery
	{
		get
		{
			xe0b89d98a08884e6();
			if (SdtType == SdtType.BuildingBlockGallery)
			{
				return ((x6e0d00b0fad00507)x96381e70e1c51c6d).x6be6ad959e27836b;
			}
			throw new InvalidOperationException("BuildingBlockType is only accessible for BuildingBlockGallery SDT type.");
		}
		set
		{
			x0d299f323d241756.x0aaaea7864a53f26(value, "value");
			xe0b89d98a08884e6();
			if (SdtType == SdtType.BuildingBlockGallery)
			{
				((x6e0d00b0fad00507)x96381e70e1c51c6d).x6be6ad959e27836b = value;
				return;
			}
			throw new InvalidOperationException("BuildingBlockType is only accessible for BuildingBlockGallery SDT type.");
		}
	}

	public string BuildingBlockCategory
	{
		get
		{
			xe0b89d98a08884e6();
			if (SdtType == SdtType.BuildingBlockGallery)
			{
				return ((x6e0d00b0fad00507)x96381e70e1c51c6d).x1c33ce3f46fa62fa;
			}
			throw new InvalidOperationException("BuildingBlockCategory is only accessible for BuildingBlockGallery SDT type.");
		}
		set
		{
			x0d299f323d241756.x0aaaea7864a53f26(value, "value");
			xe0b89d98a08884e6();
			if (SdtType == SdtType.BuildingBlockGallery)
			{
				((x6e0d00b0fad00507)x96381e70e1c51c6d).x1c33ce3f46fa62fa = value;
				return;
			}
			throw new InvalidOperationException("BuildingBlockCategory is only accessible for BuildingBlockGallery SDT type.");
		}
	}

	public bool Multiline
	{
		get
		{
			xe0b89d98a08884e6();
			if (SdtType == SdtType.RichText || SdtType == SdtType.PlainText)
			{
				return ((x4687977089abc632)x96381e70e1c51c6d).xe3ccff5629a1e888;
			}
			throw new InvalidOperationException("Multiline is only accessible for Richtext and Plaintext SDT types.");
		}
		set
		{
			xe0b89d98a08884e6();
			if (SdtType == SdtType.RichText || SdtType == SdtType.PlainText)
			{
				((x4687977089abc632)x96381e70e1c51c6d).xe3ccff5629a1e888 = value;
				return;
			}
			throw new InvalidOperationException("Multiline is only accessible for Richtext and Plaintext SDT types.");
		}
	}

	internal int xe9605a4bea014f21
	{
		get
		{
			return xb7af9f1ce9822479;
		}
		set
		{
			xb7af9f1ce9822479 = value;
			x7800d85e7f74995f = true;
		}
	}

	internal bool x377ed475ed97f896 => x7800d85e7f74995f;

	internal int x55d53b8223729bb7
	{
		get
		{
			return x8e9e68c3d2f4dd7a;
		}
		set
		{
			x8e9e68c3d2f4dd7a = value;
		}
	}

	internal xeedad81aaed42a76 xde86b50786169450 => xd2bb620c2dd1dc86;

	internal xeedad81aaed42a76 xa29d931f51e74fb3 => xebb872331395e687;

	internal x3be06ee5a3bb124b x748c99c08cdf7cb1
	{
		get
		{
			return xdd1dd893045d449a;
		}
		set
		{
			xdd1dd893045d449a = value;
		}
	}

	internal xce81d6edccc8b285 x96381e70e1c51c6d
	{
		get
		{
			return x8de82c6fb300e64b;
		}
		set
		{
			x8de82c6fb300e64b = value;
		}
	}

	MarkupLevel x55997ac957018945.x67996c0046b4bd57 => Level;

	public StructuredDocumentTag(DocumentBase doc, SdtType type, MarkupLevel level)
		: this(doc, level)
	{
		x96381e70e1c51c6d = xebcf83b00134300b(type, level);
		x52bf05a9b2550eec();
		xb267219cbd6be42f.x2fb01e788b713cac(this);
		x60adf410a9cceab0 = doc.xf9a08b9e40cca9b8.x762f71769b5ed1cc();
	}

	internal StructuredDocumentTag(DocumentBase doc, MarkupLevel level)
		: base(doc)
	{
		xaabccab0c06d038b = level;
		x8de82c6fb300e64b = new x875e6f50a68b1b44();
		xd2bb620c2dd1dc86 = new xeedad81aaed42a76();
		xebb872331395e687 = new xeedad81aaed42a76();
	}

	internal override Node x8b61531c8ea35b85(bool x7a5f12b98e34a590, x15a33f6d96885286 xe870d6f33992ceb4)
	{
		StructuredDocumentTag structuredDocumentTag = (StructuredDocumentTag)base.x8b61531c8ea35b85(x7a5f12b98e34a590, xe870d6f33992ceb4);
		structuredDocumentTag.x8de82c6fb300e64b = x8de82c6fb300e64b.x8b61531c8ea35b85();
		structuredDocumentTag.xd2bb620c2dd1dc86 = (xeedad81aaed42a76)xd2bb620c2dd1dc86.x8b61531c8ea35b85();
		structuredDocumentTag.xebb872331395e687 = (xeedad81aaed42a76)xebb872331395e687.x8b61531c8ea35b85();
		if (x18078bbe01c444ae != null)
		{
			structuredDocumentTag.x18078bbe01c444ae = x18078bbe01c444ae;
		}
		if (x60adf410a9cceab0 != -1)
		{
			structuredDocumentTag.x60adf410a9cceab0 = structuredDocumentTag.Document.xf9a08b9e40cca9b8.x7342ae654ad15c7a(x60adf410a9cceab0);
		}
		if (xdd1dd893045d449a != null)
		{
			structuredDocumentTag.xdd1dd893045d449a = xdd1dd893045d449a.x8b61531c8ea35b85();
		}
		structuredDocumentTag.x0e940fbf79cbc44e = null;
		return structuredDocumentTag;
	}

	public void RemoveSelfOnly()
	{
		x24c3f69f192a9d2b();
	}

	public override bool Accept(DocumentVisitor visitor)
	{
		return xf7ae36cd24e0b11c(visitor);
	}

	internal override VisitorAction x2449520719b1e37e(DocumentVisitor x672ff13faf031f3d)
	{
		return x672ff13faf031f3d.VisitStructuredDocumentTagStart(this);
	}

	internal override VisitorAction x3bbb475596fa1de1(DocumentVisitor x672ff13faf031f3d)
	{
		return x672ff13faf031f3d.VisitStructuredDocumentTagEnd(this);
	}

	internal override bool x8a4414b7d9d4073f(Node x40e458b3a58f5782)
	{
		return x2b1ee3a87b36a988.x7a452479f1ce15c7(this, x40e458b3a58f5782);
	}

	internal void x626c3c1ff90f6f44()
	{
		if (x60adf410a9cceab0 == -1)
		{
			x60adf410a9cceab0 = base.Document.xf9a08b9e40cca9b8.x762f71769b5ed1cc();
		}
	}

	internal void xbf02a69b0d230435(int xeaf1b27180c0557b)
	{
		x60adf410a9cceab0 = base.Document.xf9a08b9e40cca9b8.x7342ae654ad15c7a(xeaf1b27180c0557b);
	}

	internal void x3c0af6fbd91b1638(bool x2e5cc5728d3cf72d)
	{
		if ((x2e5cc5728d3cf72d || x18078bbe01c444ae == null) && x0d299f323d241756.x5959bccb67bbf051(PlaceholderName))
		{
			x18078bbe01c444ae = base.Document.x2f5330e0b9089bce.xe25c33c4a4a5dd49(this, x4a492b36640fb263: true);
		}
		base.Document.x2f5330e0b9089bce.xdad4105ec91aae57(this);
	}

	internal void x0d96312ab6b79c72(string xbcea506a33cf9111)
	{
		if (x0d299f323d241756.x5959bccb67bbf051(xbcea506a33cf9111))
		{
			x3fbe406c62095195 = xbcea506a33cf9111;
		}
	}

	internal bool xfb009d7bb278ad02(CustomXmlPartCollection x361132de876f4a8c)
	{
		if (IsShowingPlaceholderText || x748c99c08cdf7cb1 == null)
		{
			return true;
		}
		if (!x748c99c08cdf7cb1.x22ab5dfa6f12e902())
		{
			return false;
		}
		if (SdtType == SdtType.PlainText)
		{
			XmlNode xmlNode = x748c99c08cdf7cb1.x68190b5ec24229fb(x361132de876f4a8c);
			if (xmlNode != null)
			{
				Run xd1d55a56253db2df = new Run(base.Document, xb873ed12a78a6060(xmlNode.InnerText));
				xb267219cbd6be42f.x5c752e32f2d4a6b2(this, xd1d55a56253db2df);
				return true;
			}
		}
		return false;
	}

	private static string xb873ed12a78a6060(string xcdaeea7afaf570ff)
	{
		string text = xcdaeea7afaf570ff.Replace(ControlChar.CrLf, ControlChar.LineBreak);
		text = text.Replace(ControlChar.Cr, ControlChar.LineBreak);
		return text.Replace(ControlChar.Lf, ControlChar.LineBreak);
	}

	internal static bool x996b78484d021395(SdtType x43163d22e8cd5a71)
	{
		switch (x43163d22e8cd5a71)
		{
		case SdtType.DropDownList:
		case SdtType.ComboBox:
		case SdtType.Date:
		case SdtType.BuildingBlockGallery:
		case SdtType.Group:
		case SdtType.Picture:
		case SdtType.RichText:
		case SdtType.PlainText:
			return true;
		default:
			return false;
		}
	}

	internal static bool xe7ce050b9946cbb5(SdtType x43163d22e8cd5a71, MarkupLevel x66bbd7ed8c65740d)
	{
		switch (x66bbd7ed8c65740d)
		{
		case MarkupLevel.Inline:
		case MarkupLevel.Block:
		case MarkupLevel.Cell:
			return true;
		case MarkupLevel.Row:
			return x43163d22e8cd5a71 == SdtType.RichText;
		default:
			throw new ArgumentOutOfRangeException("level");
		}
	}

	private void x52bf05a9b2550eec()
	{
		BuildingBlock buildingBlock = base.Document.x2f5330e0b9089bce.xd6c4b819de3488c3(SdtType);
		if (buildingBlock != null)
		{
			x18078bbe01c444ae = buildingBlock;
			x3fbe406c62095195 = buildingBlock.Name;
			if (xaabccab0c06d038b != MarkupLevel.Row)
			{
				xc42e23a244c374e2 = true;
			}
		}
	}

	private void xe0b89d98a08884e6()
	{
		if (x96381e70e1c51c6d == null)
		{
			throw new InvalidOperationException("Please report exception.");
		}
	}

	private static xce81d6edccc8b285 xebcf83b00134300b(SdtType x43163d22e8cd5a71, MarkupLevel x66bbd7ed8c65740d)
	{
		if (!x996b78484d021395(x43163d22e8cd5a71))
		{
			throw new ArgumentException("Creation of such SdtType is not allowed.");
		}
		if (!xe7ce050b9946cbb5(x43163d22e8cd5a71, x66bbd7ed8c65740d))
		{
			throw new ArgumentException("Can not create such SdtType at this level.");
		}
		return x43163d22e8cd5a71 switch
		{
			SdtType.DropDownList => new xb59ded127e0eafce(), 
			SdtType.ComboBox => new x1ea8d6b9e917c175(), 
			SdtType.Date => new xb195c94e6015d34a(), 
			SdtType.BuildingBlockGallery => new x86a25242dc4d43f0(), 
			SdtType.Group => new xf8b4c2a1a627a484(), 
			SdtType.Picture => new x5f69b4c1ace6e16f(), 
			SdtType.RichText => new x4687977089abc632(isRichText: true), 
			SdtType.PlainText => new x4687977089abc632(isRichText: false), 
			_ => throw new ArgumentOutOfRangeException("type"), 
		};
	}
}
