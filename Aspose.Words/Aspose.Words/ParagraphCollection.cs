namespace Aspose.Words;

[JavaGenericArguments("NodeCollection<Paragraph>")]
public class ParagraphCollection : NodeCollection
{
	public new Paragraph this[int index] => (Paragraph)base[index];

	internal ParagraphCollection(CompositeNode parent)
		: base(parent, NodeType.Paragraph, isDeep: false)
	{
	}

	public new Paragraph[] ToArray()
	{
		return (Paragraph[])x8a2b4876a80a0afd().ToArray(typeof(Paragraph));
	}
}
