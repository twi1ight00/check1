namespace Aspose.Words;

[JavaGenericArguments("NodeCollection<Run>")]
public class RunCollection : NodeCollection
{
	public new Run this[int index] => (Run)base[index];

	internal RunCollection(CompositeNode parent)
		: base(parent, NodeType.Run, isDeep: false)
	{
	}

	public new Run[] ToArray()
	{
		return (Run[])x8a2b4876a80a0afd().ToArray(typeof(Run));
	}
}
