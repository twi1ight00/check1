namespace Aspose.Words;

[JavaGenericArguments("NodeCollection<Section>")]
public class SectionCollection : NodeCollection
{
	public new Section this[int index] => (Section)base[index];

	internal SectionCollection(CompositeNode parent)
		: base(parent, NodeType.Section, isDeep: false)
	{
	}

	public new Section[] ToArray()
	{
		return (Section[])x8a2b4876a80a0afd().ToArray(typeof(Section));
	}
}
