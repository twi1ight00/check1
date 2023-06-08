namespace Aspose.Words;

public interface INodeChangingCallback
{
	[JavaThrows(true)]
	void NodeInserting(NodeChangingArgs args);

	[JavaThrows(true)]
	void NodeInserted(NodeChangingArgs args);

	[JavaThrows(true)]
	void NodeRemoving(NodeChangingArgs args);

	[JavaThrows(true)]
	void NodeRemoved(NodeChangingArgs args);
}
