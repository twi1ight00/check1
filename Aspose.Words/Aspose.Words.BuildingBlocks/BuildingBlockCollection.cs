namespace Aspose.Words.BuildingBlocks;

[JavaGenericArguments("NodeCollection<BuildingBlock>")]
public class BuildingBlockCollection : NodeCollection
{
	public new BuildingBlock this[int index] => (BuildingBlock)base[index];

	internal BuildingBlockCollection(GlossaryDocument parent)
		: base(parent, NodeType.BuildingBlock, isDeep: false)
	{
	}

	public new BuildingBlock[] ToArray()
	{
		return (BuildingBlock[])x8a2b4876a80a0afd().ToArray(typeof(BuildingBlock));
	}
}
