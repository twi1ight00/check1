namespace Aspose.Words.Tables;

[JavaGenericArguments("NodeCollection<Table>")]
public class TableCollection : NodeCollection
{
	public new Table this[int index] => (Table)base[index];

	internal TableCollection(CompositeNode parent)
		: base(parent, NodeType.Table, isDeep: false)
	{
	}

	public new Table[] ToArray()
	{
		return (Table[])x8a2b4876a80a0afd().ToArray(typeof(Table));
	}
}
