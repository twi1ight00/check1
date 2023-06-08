using System;
using Aspose.Words.Tables;
using x28925c9b27b37a46;

namespace Aspose.Words;

public abstract class InlineStory : CompositeNode, xf5ecf429e74b1c04, xcf3b0f04424de818
{
	private xeedad81aaed42a76 xd0c44e5ae0011daa;

	private Font x83cd810ab70afec3;

	private ParagraphCollection x27eb3ed41aea96de;

	private TableCollection x14a2f87d74dbdad1;

	public abstract StoryType StoryType { get; }

	public Paragraph ParentParagraph => (Paragraph)GetAncestor(NodeType.Paragraph);

	public Paragraph FirstParagraph => (Paragraph)GetChild(NodeType.Paragraph, 0, isDeep: false);

	public Paragraph LastParagraph => (Paragraph)GetChild(NodeType.Paragraph, -1, isDeep: false);

	public ParagraphCollection Paragraphs
	{
		get
		{
			if (x27eb3ed41aea96de == null)
			{
				x27eb3ed41aea96de = new ParagraphCollection(this);
			}
			return x27eb3ed41aea96de;
		}
	}

	public TableCollection Tables
	{
		get
		{
			if (x14a2f87d74dbdad1 == null)
			{
				x14a2f87d74dbdad1 = new TableCollection(this);
			}
			return x14a2f87d74dbdad1;
		}
	}

	public bool IsInsertRevision => x684b09378db148f4.xdb80a3a0801e3e63(this);

	public bool IsDeleteRevision => x684b09378db148f4.xd779a54e74a3c346(this);

	public Font Font
	{
		get
		{
			if (x83cd810ab70afec3 == null)
			{
				x83cd810ab70afec3 = new Font(this, base.Document.Styles);
			}
			return x83cd810ab70afec3;
		}
	}

	internal xeedad81aaed42a76 xeedad81aaed42a76 => xd0c44e5ae0011daa;

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

	Paragraph xcf3b0f04424de818.x6b298f029e4a1f68 => ParentParagraph;

	DocumentBase xcf3b0f04424de818.x17d1cdafb1f5c088 => base.Document;

	int xf5ecf429e74b1c04.x5b8c6010012a5955 => xd0c44e5ae0011daa.xd44988f225497f3a;

	internal InlineStory(DocumentBase doc, xeedad81aaed42a76 runPr)
		: base(doc)
	{
		if (runPr == null)
		{
			throw new ArgumentNullException("runPr");
		}
		xd0c44e5ae0011daa = runPr;
	}

	internal void x39e7b5501cce0c51(xeedad81aaed42a76 x789564759d365819)
	{
		xd0c44e5ae0011daa = x789564759d365819;
	}

	internal override Node x8b61531c8ea35b85(bool x7a5f12b98e34a590, x15a33f6d96885286 xe870d6f33992ceb4)
	{
		InlineStory inlineStory = (InlineStory)base.x8b61531c8ea35b85(x7a5f12b98e34a590, xe870d6f33992ceb4);
		inlineStory.xd0c44e5ae0011daa = (xeedad81aaed42a76)xd0c44e5ae0011daa.x8b61531c8ea35b85();
		inlineStory.x83cd810ab70afec3 = null;
		inlineStory.x27eb3ed41aea96de = null;
		inlineStory.x14a2f87d74dbdad1 = null;
		return inlineStory;
	}

	public void EnsureMinimum()
	{
		xb7dbd7bb3ed97d5b.x9d7a28ea717302c8(this);
	}

	internal override bool x8a4414b7d9d4073f(Node x40e458b3a58f5782)
	{
		return x2b1ee3a87b36a988.xb6578aa94903986e(x40e458b3a58f5782);
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
}
