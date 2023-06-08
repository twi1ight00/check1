using System;
using System.Drawing;
using Aspose.Words.Drawing;
using Aspose.Words.Fonts;
using Aspose.Words.Lists;
using Aspose.Words.Loading;
using Aspose.Words.Markup;
using x13f1efc79617a47b;
using x28925c9b27b37a46;
using x53eb9320ebbb8395;
using x79578da6a8a3ae37;
using xc76255e87e5986c6;

namespace Aspose.Words;

[JavaGenericArguments("CompositeNode<T>")]
[JavaGenericParameter("T extends Node")]
public abstract class DocumentBase : CompositeNode
{
	private Node xfdf7cee9be954b1a;

	private INodeChangingCallback xbb2e9d172ff9f152;

	private int x54fa7916bb243b13;

	private int xc702a68c9bd137da;

	private int x001518f4975bd9ae;

	private xf9a08b9e40cca9b8 x0f80df38a3b38b24;

	private x2f5330e0b9089bce x9682abdf1004128f;

	private FontInfoCollection xcf7aa3cc906cdb68;

	private StyleCollection x18c770831ef0bf38;

	private ListCollection xbc2e79ef0cee7243;

	private xdade2366eaa6f915 x6620bd3d0342c0f4;

	private VariableCollection x56377dd591e13601;

	private xe67988fee456098e x9b3bbf2c7b29b78d;

	private Shape xc688b5328f84d0a0;

	private IResourceLoadingCallback xe50b02df29e39a57;

	internal bool xe4ccd3ec7bc99ea4;

	public INodeChangingCallback NodeChangingCallback
	{
		get
		{
			return xbb2e9d172ff9f152;
		}
		set
		{
			xbb2e9d172ff9f152 = value;
		}
	}

	public IResourceLoadingCallback ResourceLoadingCallback
	{
		get
		{
			return xe50b02df29e39a57;
		}
		set
		{
			xe50b02df29e39a57 = value;
		}
	}

	internal int x19fe9dfc9a096408 => x54fa7916bb243b13;

	internal Node x01d8b78e1a402cbd => xfdf7cee9be954b1a;

	public FontInfoCollection FontInfos => xcf7aa3cc906cdb68;

	public StyleCollection Styles => x18c770831ef0bf38;

	public ListCollection Lists => xbc2e79ef0cee7243;

	internal xdade2366eaa6f915 xdade2366eaa6f915 => x6620bd3d0342c0f4;

	internal VariableCollection x8513e2047b99ae50 => x56377dd591e13601;

	internal xe67988fee456098e x245aa7750b4a8072 => x9b3bbf2c7b29b78d;

	public Shape BackgroundShape
	{
		get
		{
			return xc688b5328f84d0a0;
		}
		set
		{
			if (value != null)
			{
				if (value.Document != this)
				{
					throw new ArgumentException("The shape was created from a different document.");
				}
				if (value.ParentNode != null)
				{
					throw new ArgumentException("The shape is a child of another node.");
				}
				if (value.ShapeType != ShapeType.Rectangle)
				{
					throw new ArgumentException("Only a rectangle shape can be set as a document background.");
				}
			}
			xc688b5328f84d0a0 = value;
			x6620bd3d0342c0f4.x17bade2eb7f9764f.DisplayBackgroundShape = xc688b5328f84d0a0 != null;
		}
	}

	public Color PageColor
	{
		get
		{
			if (BackgroundShape == null)
			{
				return Color.Empty;
			}
			return BackgroundShape.FillColor;
		}
		set
		{
			BackgroundShape = new Shape(this, ShapeType.Rectangle);
			BackgroundShape.FillColor = value;
		}
	}

	internal x2f5330e0b9089bce x2f5330e0b9089bce
	{
		get
		{
			if (x9682abdf1004128f == null)
			{
				x9682abdf1004128f = new x2f5330e0b9089bce(this);
			}
			return x9682abdf1004128f;
		}
	}

	internal xf9a08b9e40cca9b8 xf9a08b9e40cca9b8
	{
		get
		{
			if (x0f80df38a3b38b24 == null)
			{
				x0f80df38a3b38b24 = new xf9a08b9e40cca9b8();
			}
			return x0f80df38a3b38b24;
		}
	}

	protected DocumentBase()
	{
		xfdf7cee9be954b1a = new x01d8b78e1a402cbd(this);
		xc702a68c9bd137da = 100000;
		xcf7aa3cc906cdb68 = new FontInfoCollection();
		x18c770831ef0bf38 = new StyleCollection(this);
		xbc2e79ef0cee7243 = new ListCollection(this);
		x6620bd3d0342c0f4 = new xdade2366eaa6f915();
		x56377dd591e13601 = new VariableCollection();
		x9b3bbf2c7b29b78d = new xe67988fee456098e();
	}

	internal override Node x8b61531c8ea35b85(bool x7a5f12b98e34a590, x15a33f6d96885286 xe870d6f33992ceb4)
	{
		DocumentBase documentBase = (DocumentBase)base.x8b61531c8ea35b85(x7a5f12b98e34a590, xe870d6f33992ceb4);
		documentBase.xfdf7cee9be954b1a = new x01d8b78e1a402cbd(documentBase);
		documentBase.xbb2e9d172ff9f152 = null;
		documentBase.x0f80df38a3b38b24 = null;
		documentBase.x9682abdf1004128f = null;
		documentBase.xcf7aa3cc906cdb68 = xcf7aa3cc906cdb68.x8b61531c8ea35b85();
		documentBase.x18c770831ef0bf38 = x18c770831ef0bf38.x8b61531c8ea35b85(documentBase);
		documentBase.xbc2e79ef0cee7243 = xbc2e79ef0cee7243.x8b61531c8ea35b85(documentBase, xe870d6f33992ceb4);
		documentBase.x6620bd3d0342c0f4 = x6620bd3d0342c0f4.x8b61531c8ea35b85();
		documentBase.x56377dd591e13601 = x56377dd591e13601.x8b61531c8ea35b85();
		documentBase.x9b3bbf2c7b29b78d = x9b3bbf2c7b29b78d.x8b61531c8ea35b85(documentBase, xe870d6f33992ceb4);
		if (xc688b5328f84d0a0 != null)
		{
			documentBase.xc688b5328f84d0a0 = (Shape)documentBase.xd25152ffa2656dfc(xc688b5328f84d0a0, xdd3cf019c39dff8d: true, xe870d6f33992ceb4);
		}
		if (x7a5f12b98e34a590)
		{
			xed3f721ecbd3cb87(documentBase);
		}
		return documentBase;
	}

	private void xed3f721ecbd3cb87(DocumentBase x363a1f6e92149df5)
	{
		NodeCollection childNodes = GetChildNodes(NodeType.StructuredDocumentTag, isDeep: true);
		if (childNodes.Count != 0)
		{
			NodeCollection childNodes2 = x363a1f6e92149df5.GetChildNodes(NodeType.StructuredDocumentTag, isDeep: true);
			for (int i = 0; i < childNodes2.Count; i++)
			{
				((StructuredDocumentTag)childNodes2[i]).xbf02a69b0d230435(((StructuredDocumentTag)childNodes[i]).Id);
			}
		}
	}

	public Node ImportNode(Node srcNode, bool isImportChildren)
	{
		return xd25152ffa2656dfc(srcNode, isImportChildren, ImportFormatMode.UseDestinationStyles, null);
	}

	internal Node xd25152ffa2656dfc(Node x1725b053e96f3d2c, bool xdd3cf019c39dff8d, x15a33f6d96885286 xe870d6f33992ceb4)
	{
		return xd25152ffa2656dfc(x1725b053e96f3d2c, xdd3cf019c39dff8d, ImportFormatMode.UseDestinationStyles, xe870d6f33992ceb4);
	}

	public Node ImportNode(Node srcNode, bool isImportChildren, ImportFormatMode importFormatMode)
	{
		return xd25152ffa2656dfc(srcNode, isImportChildren, importFormatMode, null);
	}

	private Node xd25152ffa2656dfc(Node x1725b053e96f3d2c, bool xdd3cf019c39dff8d, ImportFormatMode xbddb8b51223ce9e8, x15a33f6d96885286 xe870d6f33992ceb4)
	{
		NodeImporter nodeImporter = new NodeImporter(x1725b053e96f3d2c.Document, this, xbddb8b51223ce9e8);
		return nodeImporter.xd25152ffa2656dfc(x1725b053e96f3d2c, xdd3cf019c39dff8d, xe870d6f33992ceb4);
	}

	internal NodeChangingArgs xaa5995fb46863e53(Node xda5bf54deb817e37, Node xcd6f49c153817575, Node x172b2505c0cd6218, NodeChangingAction xab8fe3cd8c5556fb)
	{
		x54fa7916bb243b13++;
		if (xbb2e9d172ff9f152 != null)
		{
			return new NodeChangingArgs(xda5bf54deb817e37, xcd6f49c153817575, x172b2505c0cd6218, xab8fe3cd8c5556fb);
		}
		return null;
	}

	[JavaConvertCheckedExceptions]
	internal void x9d5c03f243a200e9(NodeChangingArgs xce8d8c7e3c2c2426)
	{
		if (xbb2e9d172ff9f152 != null)
		{
			switch (xce8d8c7e3c2c2426.Action)
			{
			case NodeChangingAction.Insert:
				xbb2e9d172ff9f152.NodeInserting(xce8d8c7e3c2c2426);
				break;
			case NodeChangingAction.Remove:
				xbb2e9d172ff9f152.NodeRemoving(xce8d8c7e3c2c2426);
				break;
			default:
				throw new InvalidOperationException(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("iodgopkgipbhipihgpphlpgiponiojejjoljhockjnjkhnalpihlpmolbnfmhmmmbndnhmkncmbooliohhpoflgpelnpcmeaellahlcbdljbahac", 1958699923)));
			}
		}
	}

	[JavaConvertCheckedExceptions]
	internal void xea94cc1c9383f0e6(NodeChangingArgs xce8d8c7e3c2c2426)
	{
		if (xbb2e9d172ff9f152 != null)
		{
			switch (xce8d8c7e3c2c2426.Action)
			{
			case NodeChangingAction.Insert:
				xbb2e9d172ff9f152.NodeInserted(xce8d8c7e3c2c2426);
				break;
			case NodeChangingAction.Remove:
				xbb2e9d172ff9f152.NodeRemoved(xce8d8c7e3c2c2426);
				break;
			default:
				throw new InvalidOperationException(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("lijibkajljhjljojjjfkojmkcjdlbeklmibmkiimmhpmkhgncdnncheoehlokgcpehjpkgaafghabgoakbfbifmbhfdcfgkchfbdkfidgfpddbge", 603162934)));
			}
		}
	}

	internal int xc726a4cdc433ae49()
	{
		return xc702a68c9bd137da++;
	}

	internal void x49f94af7002e0485(int xbcea506a33cf9111)
	{
		xc702a68c9bd137da = xbcea506a33cf9111;
	}

	internal void x0ba7c95e7dd1304b()
	{
		x001518f4975bd9ae = 0;
	}

	internal int x8ef8795c4475a0e3()
	{
		return x001518f4975bd9ae++;
	}

	internal void xffc75a489655380b(Shape x5770cdefd8931aa9)
	{
		xc688b5328f84d0a0 = x5770cdefd8931aa9;
	}

	internal abstract x3dabda6865ed239d x9bb3f6e28fa55f34();
}
