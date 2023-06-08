using System.Collections;
using Aspose.Words;
using Aspose.Words.Fields;
using xfbd1009a0cbb9842;

namespace x28925c9b27b37a46;

internal class x5d2f40ff59e92969
{
	private class x1ad896bfc36de6fb
	{
		internal Node x212ae880d15d2ed1;

		internal Node xb664a8c25c0c85cc;

		internal x1ad896bfc36de6fb(Node start, Node end)
		{
			x212ae880d15d2ed1 = start;
			xb664a8c25c0c85cc = end;
		}
	}

	private readonly Stack x871326a4605c4e8e = new Stack();

	private readonly ArrayList xf2635541db3fa704 = new ArrayList();

	private readonly ArrayList x9e1f69fa40dee261 = new ArrayList();

	private bool xe7cc8657048a54df => x871326a4605c4e8e.Count > 0;

	private x5d2f40ff59e92969()
	{
	}

	internal static x7e263f21a73a027a x21fa987632cd6917(x7e263f21a73a027a x9b10ace6509508c0, bool x29c774879be75f66)
	{
		if (x9b10ace6509508c0 == null)
		{
			return null;
		}
		xb56968f92e308c8a xb56968f92e308c8a2 = new xb56968f92e308c8a(x9b10ace6509508c0);
		x5d2f40ff59e92969 x5d2f40ff59e92970 = new x5d2f40ff59e92969();
		Node node = null;
		Node node2 = null;
		Node end = null;
		while (xb56968f92e308c8a2.x1ef2c3be187f37a2())
		{
			node = xb56968f92e308c8a2.x3387295f12854dfd;
			if (xc54a8bef3f4d5384(node, x29c774879be75f66))
			{
				continue;
			}
			switch (node.NodeType)
			{
			case NodeType.FieldStart:
				x5d2f40ff59e92970.xe0e68c1b48884a8c((FieldStart)node);
				continue;
			case NodeType.FieldSeparator:
				x5d2f40ff59e92970.x22ac2c766ffad352((FieldSeparator)node);
				continue;
			case NodeType.FieldEnd:
				x5d2f40ff59e92970.x221bac6efb19ed4e((FieldEnd)node);
				continue;
			}
			if (!x5d2f40ff59e92970.xe7cc8657048a54df)
			{
				end = node;
				if (node2 == null)
				{
					node2 = node;
				}
			}
		}
		x5d2f40ff59e92970.x45aed43ab4f2045c();
		x5d2f40ff59e92970.x7d2818d4cc5166aa(node);
		if (node2 == null)
		{
			return null;
		}
		return new x7e263f21a73a027a(node2, end);
	}

	internal static x7e263f21a73a027a x21fa987632cd6917(x7e263f21a73a027a x9b10ace6509508c0)
	{
		return x21fa987632cd6917(x9b10ace6509508c0, x29c774879be75f66: false);
	}

	private static bool xc54a8bef3f4d5384(Node xda5bf54deb817e37, bool x29c774879be75f66)
	{
		if (x29c774879be75f66)
		{
			return false;
		}
		return x4bdcc27337283a86(xda5bf54deb817e37);
	}

	private static bool x4bdcc27337283a86(Node xda5bf54deb817e37)
	{
		if (!(xda5bf54deb817e37 is FieldChar fieldChar))
		{
			return false;
		}
		switch (fieldChar.FieldType)
		{
		case FieldType.FieldGoToButton:
		case FieldType.FieldMacroButton:
		case FieldType.FieldAutoNumOutline:
		case FieldType.FieldAutoNumLegal:
		case FieldType.FieldAutoNum:
		case FieldType.FieldSymbol:
		case FieldType.FieldFormCheckBox:
		case FieldType.FieldFormDropDown:
		case FieldType.FieldListNum:
			return true;
		default:
			return false;
		}
	}

	private void xe0e68c1b48884a8c(FieldStart xa6315bf377f6364c)
	{
		x871326a4605c4e8e.Push(xa6315bf377f6364c);
	}

	private void x22ac2c766ffad352(FieldSeparator xed9a565596a6ae3f)
	{
		if (xe7cc8657048a54df)
		{
			FieldChar fieldChar = (FieldChar)x871326a4605c4e8e.Pop();
			if (fieldChar.NodeType == NodeType.FieldStart)
			{
				if (xe7cc8657048a54df)
				{
					x871326a4605c4e8e.Push(xed9a565596a6ae3f);
				}
				else if (x5c29822913be33c1.xb2cdffc8e47588c8(xed9a565596a6ae3f.FieldType))
				{
					x871326a4605c4e8e.Push(fieldChar);
				}
				else
				{
					x9e1f69fa40dee261.Add(new x1ad896bfc36de6fb(fieldChar, xed9a565596a6ae3f));
				}
			}
			else
			{
				x871326a4605c4e8e.Push(fieldChar);
			}
		}
		else
		{
			xf2635541db3fa704.Add(xed9a565596a6ae3f);
		}
	}

	private void x221bac6efb19ed4e(FieldEnd xc87e4e475724f9c3)
	{
		if (xe7cc8657048a54df)
		{
			FieldChar fieldChar = (FieldChar)x871326a4605c4e8e.Pop();
			if (fieldChar.NodeType == NodeType.FieldStart && !xe7cc8657048a54df)
			{
				x9e1f69fa40dee261.Add(new x1ad896bfc36de6fb(fieldChar, xc87e4e475724f9c3));
			}
		}
		else
		{
			xf2635541db3fa704.Add(xc87e4e475724f9c3);
		}
	}

	private void x7d2818d4cc5166aa(Node x0816239aeb5b0ebe)
	{
		if (xe7cc8657048a54df)
		{
			FieldChar x10aaa7cdfa38f;
			do
			{
				x10aaa7cdfa38f = (FieldChar)x871326a4605c4e8e.Pop();
			}
			while (x871326a4605c4e8e.Count > 0);
			x5699f8523a546a42.x52b190e626f65140(x10aaa7cdfa38f, x0816239aeb5b0ebe);
		}
	}

	private void x45aed43ab4f2045c()
	{
		foreach (Node item in xf2635541db3fa704)
		{
			item.Remove();
		}
		foreach (x1ad896bfc36de6fb item2 in x9e1f69fa40dee261)
		{
			x5699f8523a546a42.x52b190e626f65140(item2.x212ae880d15d2ed1, item2.xb664a8c25c0c85cc);
		}
	}
}
