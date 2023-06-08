using System.Collections;
using System.Drawing;
using System.Xml;
using Aspose.Words.Rendering;
using x011d489fb9df7027;
using x28925c9b27b37a46;
using x6c95d9cf46ff5f25;
using x996431aaaaf00543;
using xc76255e87e5986c6;
using xf84318f571847613;
using xf9a9481c3f63a419;

namespace Aspose.Words.Drawing;

public class DrawingML : Inline
{
	private readonly XmlDocument xb2195ee59266b90a;

	private readonly x40136e0b18d3d4d5 x7cda2ee9f5da2d7b;

	private xf7125312c7ee115c x017d3b59849466e1 = new xf7125312c7ee115c();

	private DrawingMLImageData xd97c5d950974bed3;

	private static readonly Hashtable xf2c93835da45ee8f;

	public override NodeType NodeType => NodeType.DrawingML;

	internal x3dabda6865ed239d xcedd71bf2230b51f => base.Document.x9bb3f6e28fa55f34();

	public string Name
	{
		get
		{
			return (string)x017d3b59849466e1.xfe91eeeafcb3026a(896);
		}
		set
		{
			x0d299f323d241756.x0aaaea7864a53f26(value, "value");
			x017d3b59849466e1.xae20093bed1e48a8(896, value);
		}
	}

	public string HRef
	{
		get
		{
			return (string)x017d3b59849466e1.xfe91eeeafcb3026a(898);
		}
		set
		{
			x0d299f323d241756.x0aaaea7864a53f26(value, "value");
			x017d3b59849466e1.xae20093bed1e48a8(898, value);
		}
	}

	public string Target
	{
		get
		{
			return (string)x017d3b59849466e1.xfe91eeeafcb3026a(4120);
		}
		set
		{
			x0d299f323d241756.x0aaaea7864a53f26(value, "value");
			x017d3b59849466e1.xae20093bed1e48a8(4120, value);
		}
	}

	public string ScreenTip
	{
		get
		{
			return (string)x017d3b59849466e1.xfe91eeeafcb3026a(909);
		}
		set
		{
			x0d299f323d241756.x0aaaea7864a53f26(value, "value");
			x017d3b59849466e1.xae20093bed1e48a8(909, value);
		}
	}

	public string AlternativeText
	{
		get
		{
			return (string)x017d3b59849466e1.xfe91eeeafcb3026a(897);
		}
		set
		{
			x0d299f323d241756.x0aaaea7864a53f26(value, "value");
			x017d3b59849466e1.xae20093bed1e48a8(897, value);
		}
	}

	public bool HasImage
	{
		get
		{
			if (CanHaveImage)
			{
				return ImageData.HasImage;
			}
			return false;
		}
	}

	public bool IsInline => xf7125312c7ee115c.xab6edfb47ff0b74c == WrapType.Inline;

	public bool CanHaveImage => true;

	public double Width
	{
		get
		{
			return (double)x017d3b59849466e1.xfe91eeeafcb3026a(4131);
		}
		set
		{
			x017d3b59849466e1.xae20093bed1e48a8(4131, value);
		}
	}

	public double Height
	{
		get
		{
			return (double)x017d3b59849466e1.xfe91eeeafcb3026a(4132);
		}
		set
		{
			x017d3b59849466e1.xae20093bed1e48a8(4132, value);
		}
	}

	public SizeF Size
	{
		get
		{
			return new SizeF((float)Width, (float)Height);
		}
		set
		{
			Width = value.Width;
			Height = value.Height;
		}
	}

	public DrawingMLImageData ImageData
	{
		get
		{
			if (!CanHaveImage)
			{
				return null;
			}
			if (xd97c5d950974bed3 == null)
			{
				Document document = base.Document as Document;
				xd97c5d950974bed3 = new DrawingMLImageData(this, document);
			}
			return xd97c5d950974bed3;
		}
	}

	internal bool x96e55b5d052d1279
	{
		get
		{
			return (bool)xf7125312c7ee115c.xfe91eeeafcb3026a(958);
		}
		set
		{
			xf7125312c7ee115c.xae20093bed1e48a8(958, value);
		}
	}

	internal double x027754ea63804113
	{
		get
		{
			return x4574ea26106f0edb.xa23e6b6c3169521d((int)xf7125312c7ee115c.xfe91eeeafcb3026a(901));
		}
		set
		{
			xf7125312c7ee115c.xae20093bed1e48a8(901, x4574ea26106f0edb.x3aa08882c9feaf96(value));
		}
	}

	internal double x4dc0360afcf78834
	{
		get
		{
			return x4574ea26106f0edb.xa23e6b6c3169521d((int)xf7125312c7ee115c.xfe91eeeafcb3026a(903));
		}
		set
		{
			xf7125312c7ee115c.xae20093bed1e48a8(903, x4574ea26106f0edb.x3aa08882c9feaf96(value));
		}
	}

	internal double xc9ee264fd8d7484e
	{
		get
		{
			return x4574ea26106f0edb.xa23e6b6c3169521d((int)xf7125312c7ee115c.xfe91eeeafcb3026a(900));
		}
		set
		{
			xf7125312c7ee115c.xae20093bed1e48a8(900, x4574ea26106f0edb.x3aa08882c9feaf96(value));
		}
	}

	internal double xb5465b18223f6375
	{
		get
		{
			return x4574ea26106f0edb.xa23e6b6c3169521d((int)xf7125312c7ee115c.xfe91eeeafcb3026a(902));
		}
		set
		{
			xf7125312c7ee115c.xae20093bed1e48a8(902, x4574ea26106f0edb.x3aa08882c9feaf96(value));
		}
	}

	internal bool xed344a170caf7ac3
	{
		get
		{
			return (bool)xf7125312c7ee115c.xfe91eeeafcb3026a(950);
		}
		set
		{
			xf7125312c7ee115c.xae20093bed1e48a8(950, value);
		}
	}

	internal bool xcabd529f9ea6048f => x413efea55c489fa5("/a:graphic/a:graphicData/pic:pic");

	internal bool x11deaa09f5931767 => x413efea55c489fa5("/a:graphic/a:graphicData/c:chart");

	internal XmlDocument xb327816528e8798b => xb2195ee59266b90a;

	internal x40136e0b18d3d4d5 x169b8a3bc8f77f64 => x7cda2ee9f5da2d7b;

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

	internal DrawingML(DocumentBase doc, XmlDocument xmlDoc, x40136e0b18d3d4d5 relatedDatas)
		: this(doc, new xeedad81aaed42a76(), xmlDoc, relatedDatas)
	{
	}

	internal DrawingML(DocumentBase doc, xeedad81aaed42a76 runPr, XmlDocument xmlDoc, x40136e0b18d3d4d5 relatedDataCollection)
		: base(doc, runPr)
	{
		xb2195ee59266b90a = xmlDoc;
		x7cda2ee9f5da2d7b = relatedDataCollection;
	}

	public override bool Accept(DocumentVisitor visitor)
	{
		return Node.x9708eba393e07242(visitor.VisitDrawingML(this));
	}

	internal override Node x8b61531c8ea35b85(bool x7a5f12b98e34a590, x15a33f6d96885286 xe870d6f33992ceb4)
	{
		XmlDocument xmlDocument = (XmlDocument)xb2195ee59266b90a.CloneNode(deep: true);
		XmlElement xmlElement = x8f22b0507bb6c621.x52e89e22b9173f4b(xmlDocument);
		DrawingML drawingML;
		if (xmlElement != null)
		{
			x40136e0b18d3d4d5 x40136e0b18d3d4d = new x40136e0b18d3d4d5(xmlElement);
			x40136e0b18d3d4d.xe97ce3351aad63f5();
			x40136e0b18d3d4d.xa5f609130a1a7eae();
			x5645a78cb658cd2d x5645a78cb658cd2d = x7cda2ee9f5da2d7b.x0d19c72f250ee399();
			if (x5645a78cb658cd2d != null && x5645a78cb658cd2d.xd2f68ee6f47e9dfb != null)
			{
				x40136e0b18d3d4d.x234394dd74461915((byte[])x5645a78cb658cd2d.xd2f68ee6f47e9dfb);
			}
			x5645a78cb658cd2d x5645a78cb658cd2d2 = x7cda2ee9f5da2d7b.x400d7e7d70bfb599();
			if (x5645a78cb658cd2d2 != null && x5645a78cb658cd2d2.xd2f68ee6f47e9dfb != null)
			{
				x40136e0b18d3d4d.x82669cb9f7dd9f94((string)x5645a78cb658cd2d2.xd2f68ee6f47e9dfb);
			}
			drawingML = new DrawingML(base.Document, (xeedad81aaed42a76)base.xeedad81aaed42a76.x8b61531c8ea35b85(), xmlDocument, x40136e0b18d3d4d);
			xe870d6f33992ceb4?.xcc01c1f2f17c1af0(this, drawingML);
		}
		else
		{
			drawingML = (DrawingML)base.x8b61531c8ea35b85(x7a5f12b98e34a590, xe870d6f33992ceb4);
		}
		drawingML.x017d3b59849466e1 = (xf7125312c7ee115c)x017d3b59849466e1.x8b61531c8ea35b85();
		return drawingML;
	}

	public ShapeRenderer GetShapeRenderer()
	{
		return new ShapeRenderer(this);
	}

	internal x1709225c4bd1ed83 xaf782602efcbdda1()
	{
		return new xb6433c109db8791a(this);
	}

	private bool x413efea55c489fa5(string x7e81152f4b5e4c64)
	{
		return xd165c26d81eb4a1e.x478a82deb55cde7c(xb2195ee59266b90a.DocumentElement, x7e81152f4b5e4c64, xf2c93835da45ee8f).Count == 1;
	}

	static DrawingML()
	{
		xf2c93835da45ee8f = new Hashtable();
		xf2c93835da45ee8f["a"] = "http://schemas.openxmlformats.org/drawingml/2006/main";
		xf2c93835da45ee8f["pic"] = "http://schemas.openxmlformats.org/drawingml/2006/picture";
		xf2c93835da45ee8f["c"] = "http://schemas.openxmlformats.org/drawingml/2006/chart";
		xf2c93835da45ee8f["lc"] = "http://schemas.openxmlformats.org/drawingml/2006/lockedCanvas";
	}
}
