using System;
using x28925c9b27b37a46;
using x6c95d9cf46ff5f25;

namespace Aspose.Words.BuildingBlocks;

public class BuildingBlock : CompositeNode
{
	private string xc61ff88f1f98652d = "(Empty Name)";

	private bool x675c2c3192f1aef9;

	private Guid x2e368c44c54c3e9a = Guid.Empty;

	private string x82cab886de347dba = "";

	private BuildingBlockGallery x591c720dcb177b64;

	private string x8d8226994d810517 = "(Empty Category)";

	private BuildingBlockBehavior x35e72f2c72e2d650;

	private string x5d9fbd9603e9dee5 = "";

	private BuildingBlockType xf263b01e2956834c;

	private SectionCollection x91b4b3c73382cdb1;

	public override NodeType NodeType => NodeType.BuildingBlock;

	public SectionCollection Sections
	{
		get
		{
			if (x91b4b3c73382cdb1 == null)
			{
				x91b4b3c73382cdb1 = new SectionCollection(this);
			}
			return x91b4b3c73382cdb1;
		}
	}

	public Section FirstSection => (Section)GetChild(NodeType.Section, 0, isDeep: false);

	public Section LastSection => (Section)GetChild(NodeType.Section, -1, isDeep: false);

	public string Name
	{
		get
		{
			return xc61ff88f1f98652d;
		}
		set
		{
			x0d299f323d241756.x48501aec8e48c869(value, "name");
			xc61ff88f1f98652d = value;
		}
	}

	internal bool xd448af18fed11a9d
	{
		get
		{
			return x675c2c3192f1aef9;
		}
		set
		{
			x675c2c3192f1aef9 = value;
		}
	}

	public Guid Guid
	{
		get
		{
			return x2e368c44c54c3e9a;
		}
		set
		{
			x2e368c44c54c3e9a = value;
		}
	}

	public string Description
	{
		get
		{
			return x82cab886de347dba;
		}
		set
		{
			x0d299f323d241756.x0aaaea7864a53f26(value, "description");
			x82cab886de347dba = value;
		}
	}

	public BuildingBlockGallery Gallery
	{
		get
		{
			return x591c720dcb177b64;
		}
		set
		{
			x591c720dcb177b64 = value;
		}
	}

	public string Category
	{
		get
		{
			return x8d8226994d810517;
		}
		set
		{
			x0d299f323d241756.x48501aec8e48c869(value, "category");
			x8d8226994d810517 = value;
		}
	}

	public BuildingBlockBehavior Behavior
	{
		get
		{
			return x35e72f2c72e2d650;
		}
		set
		{
			x35e72f2c72e2d650 = value;
		}
	}

	internal string xfe2178c1f916f36c
	{
		get
		{
			return x5d9fbd9603e9dee5;
		}
		set
		{
			x0d299f323d241756.x0aaaea7864a53f26(value, "style");
			x5d9fbd9603e9dee5 = value;
		}
	}

	public BuildingBlockType Type
	{
		get
		{
			return xf263b01e2956834c;
		}
		set
		{
			xf263b01e2956834c = value;
		}
	}

	public BuildingBlock(GlossaryDocument glossaryDoc)
		: base(glossaryDoc)
	{
	}

	public override bool Accept(DocumentVisitor visitor)
	{
		return xf7ae36cd24e0b11c(visitor);
	}

	internal override VisitorAction x2449520719b1e37e(DocumentVisitor x672ff13faf031f3d)
	{
		return x672ff13faf031f3d.VisitBuildingBlockStart(this);
	}

	internal override VisitorAction x3bbb475596fa1de1(DocumentVisitor x672ff13faf031f3d)
	{
		return x672ff13faf031f3d.VisitBuildingBlockEnd(this);
	}

	internal override Node x8b61531c8ea35b85(bool x7a5f12b98e34a590, x15a33f6d96885286 xe870d6f33992ceb4)
	{
		BuildingBlock buildingBlock = (BuildingBlock)base.x8b61531c8ea35b85(x7a5f12b98e34a590, xe870d6f33992ceb4);
		buildingBlock.x91b4b3c73382cdb1 = null;
		return buildingBlock;
	}

	internal override bool x8a4414b7d9d4073f(Node x40e458b3a58f5782)
	{
		return x40e458b3a58f5782.NodeType == NodeType.Section;
	}

	internal void x4c5dd7b882032b8b(string xc15bd84e01929885)
	{
		if (x0d299f323d241756.x5959bccb67bbf051(xc15bd84e01929885))
		{
			xc61ff88f1f98652d = xc15bd84e01929885;
		}
	}

	internal void x40796a31263666b8(string x6f02b6a80bf6b36f)
	{
		if (x0d299f323d241756.x5959bccb67bbf051(x6f02b6a80bf6b36f))
		{
			x8d8226994d810517 = x6f02b6a80bf6b36f;
		}
	}
}
