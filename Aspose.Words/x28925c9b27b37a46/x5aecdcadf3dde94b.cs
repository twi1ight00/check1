using Aspose;
using Aspose.Words;

namespace x28925c9b27b37a46;

internal class x5aecdcadf3dde94b : xb56968f92e308c8a
{
	private readonly DocumentVisitor x68b819d5180d96b4;

	private readonly xe83a6b069ec8efc2 x8e1a7bd0ad3bbd55;

	internal x5aecdcadf3dde94b(x7e263f21a73a027a range, DocumentVisitor visitor, xe83a6b069ec8efc2 modifier)
		: base(range)
	{
		x68b819d5180d96b4 = visitor;
		x8e1a7bd0ad3bbd55 = modifier;
	}

	internal void xc2b3e0605f4afe6a()
	{
		while (x1ef2c3be187f37a2())
		{
			if (!base.x3387295f12854dfd.IsComposite)
			{
				Node node = x64ae56857b252b27(x8e1a7bd0ad3bbd55, x457efc87f780f707: false);
				node.Accept(x68b819d5180d96b4);
			}
			else
			{
				((CompositeNode)base.x3387295f12854dfd).x2449520719b1e37e(x68b819d5180d96b4);
			}
		}
	}

	[JavaConvertCheckedExceptions]
	protected override void OnMoved(x92efcb0dc4970661 movement)
	{
		if (movement == x92efcb0dc4970661.x887a0c79ecbe5ee3)
		{
			((CompositeNode)base.x3387295f12854dfd).x3bbb475596fa1de1(x68b819d5180d96b4);
		}
	}
}
