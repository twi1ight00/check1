using System;
using System.ComponentModel;
using x28925c9b27b37a46;

namespace Aspose.Words;

public class Section : CompositeNode, x38e21b53aa8148da
{
	private xfc72d4c9b765cad7 x13d0010792219ed4;

	private PageSetup x39f6a06ec4dcfb69;

	private HeaderFooterCollection x4446973d16330f32;

	public override NodeType NodeType => NodeType.Section;

	public Body Body => (Body)GetChild(NodeType.Body, 0, isDeep: false);

	public HeaderFooterCollection HeadersFooters
	{
		get
		{
			if (x4446973d16330f32 == null)
			{
				x4446973d16330f32 = new HeaderFooterCollection(this);
			}
			return x4446973d16330f32;
		}
	}

	public PageSetup PageSetup
	{
		get
		{
			if (x39f6a06ec4dcfb69 == null)
			{
				x39f6a06ec4dcfb69 = new PageSetup(this, base.Document.xdade2366eaa6f915);
			}
			return x39f6a06ec4dcfb69;
		}
	}

	public bool ProtectedForForms
	{
		get
		{
			return !PageSetup.x3f5233cee263582a;
		}
		set
		{
			PageSetup.x3f5233cee263582a = !value;
		}
	}

	internal xfc72d4c9b765cad7 xfc72d4c9b765cad7
	{
		get
		{
			return x13d0010792219ed4;
		}
		set
		{
			x13d0010792219ed4 = value;
		}
	}

	internal bool x59fc5ceeaaccb880 => base.ParentNode.FirstChild == this;

	public Section(DocumentBase doc)
		: this(doc, new xfc72d4c9b765cad7())
	{
	}

	internal Section(DocumentBase doc, xfc72d4c9b765cad7 sectPr)
		: base(doc)
	{
		x13d0010792219ed4 = sectPr;
	}

	public Section Clone()
	{
		return (Section)Clone(isCloneChildren: true);
	}

	internal override Node x8b61531c8ea35b85(bool x7a5f12b98e34a590, x15a33f6d96885286 xe870d6f33992ceb4)
	{
		Section section = (Section)base.x8b61531c8ea35b85(x7a5f12b98e34a590, xe870d6f33992ceb4);
		xfc72d4c9b765cad7 xfc72d4c9b765cad = (xfc72d4c9b765cad7)x13d0010792219ed4.x8b61531c8ea35b85();
		section.x13d0010792219ed4 = xfc72d4c9b765cad;
		section.x39f6a06ec4dcfb69 = null;
		section.x4446973d16330f32 = null;
		return section;
	}

	public override bool Accept(DocumentVisitor visitor)
	{
		return xf7ae36cd24e0b11c(visitor);
	}

	internal override VisitorAction x2449520719b1e37e(DocumentVisitor x672ff13faf031f3d)
	{
		return x672ff13faf031f3d.VisitSectionStart(this);
	}

	internal override VisitorAction x3bbb475596fa1de1(DocumentVisitor x672ff13faf031f3d)
	{
		return x672ff13faf031f3d.VisitSectionEnd(this);
	}

	public void PrependContent(Section sourceSection)
	{
		x5c752e32f2d4a6b2(sourceSection, x7f43f79506f73a73: false);
	}

	public void AppendContent(Section sourceSection)
	{
		x5c752e32f2d4a6b2(sourceSection, x7f43f79506f73a73: true);
	}

	public void ClearContent()
	{
		ClearHeadersFooters();
		Body.RemoveAllChildren();
		Body.EnsureMinimum();
	}

	public void ClearHeadersFooters()
	{
		for (Node node = base.FirstChild; node != null; node = node.NextSibling)
		{
			if (node.NodeType == NodeType.HeaderFooter)
			{
				((HeaderFooter)node).RemoveAllChildren();
			}
		}
	}

	public void DeleteHeaderFooterShapes()
	{
		for (Node node = base.FirstChild; node != null; node = node.NextSibling)
		{
			if (node.NodeType == NodeType.HeaderFooter)
			{
				((HeaderFooter)node).DeleteShapes();
			}
		}
	}

	public void EnsureMinimum()
	{
		Body body = Body;
		if (body == null)
		{
			body = (Body)AppendChild(new Body(base.Document));
		}
		body.EnsureMinimum();
	}

	internal Story xe5cdc2a3cec80364(StoryType xdbbf47b5e620c262)
	{
		for (Node node = base.FirstChild; node != null; node = node.NextSibling)
		{
			if (((Story)node).StoryType == xdbbf47b5e620c262)
			{
				return (Story)node;
			}
		}
		return null;
	}

	internal override bool x8a4414b7d9d4073f(Node x40e458b3a58f5782)
	{
		switch (x40e458b3a58f5782.NodeType)
		{
		case NodeType.Body:
		case NodeType.HeaderFooter:
		{
			StoryType storyType = ((Story)x40e458b3a58f5782).StoryType;
			return xe5cdc2a3cec80364(storyType) == null;
		}
		default:
			return false;
		}
	}

	private void x5c752e32f2d4a6b2(Section xcf7463ebe0d43a4f, bool x7f43f79506f73a73)
	{
		if (xcf7463ebe0d43a4f == null)
		{
			throw new ArgumentNullException("sourceSection");
		}
		Body body = xcf7463ebe0d43a4f.Body;
		if (body != null)
		{
			Body body2 = Body;
			if (body2 == null)
			{
				body2 = (Body)AppendChild(new Body(base.Document));
			}
			body = (Body)base.Document.ImportNode(body, isImportChildren: true);
			Node x22bff10c3dd1f70f = (x7f43f79506f73a73 ? body2.LastParagraph : null);
			body2.x2729186e1a0b4aeb(body.FirstChild, null, x22bff10c3dd1f70f);
		}
	}

	private object xa8520499885dda4d(int xba08ce632055a1d9)
	{
		return x13d0010792219ed4.xf7866f89640a29a3(xba08ce632055a1d9);
	}

	object x38e21b53aa8148da.xb25c0862ce36b53c(int xba08ce632055a1d9)
	{
		//ILSpy generated this explicit interface implementation from .override directive in xa8520499885dda4d
		return this.xa8520499885dda4d(xba08ce632055a1d9);
	}

	private object x3be9b7b90db67467(int xba08ce632055a1d9)
	{
		if (xba08ce632055a1d9 == 2600)
		{
			return base.Document.xdade2366eaa6f915.xc8949e68d489222b.xfe91eeeafcb3026a(xba08ce632055a1d9);
		}
		return xfc72d4c9b765cad7.x0095b789d636f3ae(xba08ce632055a1d9);
	}

	object x38e21b53aa8148da.xe5b82b9f0104471f(int xba08ce632055a1d9)
	{
		//ILSpy generated this explicit interface implementation from .override directive in x3be9b7b90db67467
		return this.x3be9b7b90db67467(xba08ce632055a1d9);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public void xa2dc0badd30e7585(int xba08ce632055a1d9, object xbcea506a33cf9111)
	{
		if (xba08ce632055a1d9 == 2600)
		{
			base.Document.xdade2366eaa6f915.xc8949e68d489222b.xae20093bed1e48a8(xba08ce632055a1d9, xbcea506a33cf9111);
		}
		else
		{
			x13d0010792219ed4.xae20093bed1e48a8(xba08ce632055a1d9, xbcea506a33cf9111);
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public void x6e641a758e328481()
	{
		x13d0010792219ed4.ClearAttrs();
	}
}
