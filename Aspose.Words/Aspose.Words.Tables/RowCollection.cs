namespace Aspose.Words.Tables;

[JavaGenericArguments("NodeCollection<Row>")]
public class RowCollection : NodeCollection
{
	public new Row this[int index] => (Row)base[index];

	internal RowCollection(CompositeNode parent)
		: base(parent, NodeType.Row, isDeep: false)
	{
	}

	public new Row[] ToArray()
	{
		return (Row[])x8a2b4876a80a0afd().ToArray(typeof(Row));
	}
}
