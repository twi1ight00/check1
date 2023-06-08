namespace Aspose.Words.Tables;

[JavaGenericArguments("NodeCollection<Cell>")]
public class CellCollection : NodeCollection
{
	public new Cell this[int index] => (Cell)base[index];

	internal CellCollection(CompositeNode parent)
		: base(parent, NodeType.Cell, isDeep: false)
	{
	}

	public new Cell[] ToArray()
	{
		return (Cell[])x8a2b4876a80a0afd().ToArray(typeof(Cell));
	}
}
