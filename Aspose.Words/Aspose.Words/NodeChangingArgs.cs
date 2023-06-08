namespace Aspose.Words;

public class NodeChangingArgs
{
	private Node x48154453a08515ea;

	private Node x0bf3392eadc7bb29;

	private Node x8d85fcf9f3170c42;

	private NodeChangingAction x567b7f75e416ff79;

	public Node Node => x48154453a08515ea;

	public Node OldParent => x0bf3392eadc7bb29;

	public Node NewParent => x8d85fcf9f3170c42;

	public NodeChangingAction Action => x567b7f75e416ff79;

	internal NodeChangingArgs(Node node, Node oldParent, Node newParent, NodeChangingAction action)
	{
		x48154453a08515ea = node;
		x0bf3392eadc7bb29 = oldParent;
		x8d85fcf9f3170c42 = newParent;
		x567b7f75e416ff79 = action;
	}
}
