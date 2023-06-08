using System;
using System.Collections;
using x28925c9b27b37a46;
using xc76255e87e5986c6;

namespace Aspose.Words.BuildingBlocks;

[JavaGenericArguments("DocumentBase<BuildingBlock>")]
public class GlossaryDocument : DocumentBase
{
	private BuildingBlockCollection x44f0dd9159fe99d2;

	public override NodeType NodeType => NodeType.GlossaryDocument;

	public BuildingBlockCollection BuildingBlocks
	{
		get
		{
			if (x44f0dd9159fe99d2 == null)
			{
				x44f0dd9159fe99d2 = new BuildingBlockCollection(this);
			}
			return x44f0dd9159fe99d2;
		}
	}

	public BuildingBlock FirstBuildingBlock => (BuildingBlock)GetChild(NodeType.BuildingBlock, 0, isDeep: false);

	public BuildingBlock LastBuildingBlock => (BuildingBlock)GetChild(NodeType.BuildingBlock, -1, isDeep: false);

	internal override x3dabda6865ed239d x9bb3f6e28fa55f34()
	{
		return null;
	}

	public override bool Accept(DocumentVisitor visitor)
	{
		return xf7ae36cd24e0b11c(visitor);
	}

	internal override VisitorAction x2449520719b1e37e(DocumentVisitor x672ff13faf031f3d)
	{
		return x672ff13faf031f3d.VisitGlossaryDocumentStart(this);
	}

	internal override VisitorAction x3bbb475596fa1de1(DocumentVisitor x672ff13faf031f3d)
	{
		return x672ff13faf031f3d.VisitGlossaryDocumentEnd(this);
	}

	internal override bool x8a4414b7d9d4073f(Node x40e458b3a58f5782)
	{
		return x40e458b3a58f5782.NodeType == NodeType.BuildingBlock;
	}

	internal override Node x8b61531c8ea35b85(bool x7a5f12b98e34a590, x15a33f6d96885286 xe870d6f33992ceb4)
	{
		GlossaryDocument glossaryDocument = (GlossaryDocument)base.x8b61531c8ea35b85(x7a5f12b98e34a590, xe870d6f33992ceb4);
		glossaryDocument.x44f0dd9159fe99d2 = null;
		return glossaryDocument;
	}

	public BuildingBlock GetBuildingBlock(BuildingBlockGallery gallery, string category, string name)
	{
		IEnumerator enumerator = GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				BuildingBlock buildingBlock = (BuildingBlock)enumerator.Current;
				if (buildingBlock.Gallery == gallery && (category == null || buildingBlock.Category == category) && buildingBlock.Name == name)
				{
					return buildingBlock;
				}
			}
		}
		finally
		{
			IDisposable disposable = enumerator as IDisposable;
			if (disposable != null)
			{
				disposable.Dispose();
			}
		}
		return null;
	}
}
