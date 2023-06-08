using System.Text;
using Aspose.Words;
using Aspose.Words.Fields;

namespace x28925c9b27b37a46;

internal class x9f265cdf86e37e15 : xb56968f92e308c8a
{
	private readonly bool xfa8d1184b8d25e4e;

	private readonly StringBuilder x800085dd555f7711 = new StringBuilder();

	private int xafc4b914f07c2d11;

	private bool x991897f13cf6aadc
	{
		get
		{
			if (xafc4b914f07c2d11 > 0)
			{
				return true;
			}
			switch (base.x3387295f12854dfd.NodeType)
			{
			case NodeType.FieldStart:
			case NodeType.FieldSeparator:
			case NodeType.FieldEnd:
				return xfa8d1184b8d25e4e;
			default:
				return false;
			}
		}
	}

	private x9f265cdf86e37e15(Node start, bool isIncludeStart, Node end, bool isIncludeEnd, bool isFieldResultMode)
		: this(new x7e263f21a73a027a(start, isIncludeStart, end, isIncludeEnd), isFieldResultMode)
	{
	}

	private x9f265cdf86e37e15(x7e263f21a73a027a range, bool isFieldResultMode)
		: base(range)
	{
		xfa8d1184b8d25e4e = isFieldResultMode;
	}

	internal static string x633d57e35b6715a4(x7e263f21a73a027a x9b10ace6509508c0)
	{
		x9f265cdf86e37e15 x9f265cdf86e37e16 = new x9f265cdf86e37e15(x9b10ace6509508c0, isFieldResultMode: false);
		return x9f265cdf86e37e16.x633d57e35b6715a4();
	}

	internal static string x633d57e35b6715a4(Node x10aaa7cdfa38f254, Node xca09b6c2b5b18485)
	{
		return x633d57e35b6715a4(x10aaa7cdfa38f254, x579197826ce035a3: true, xca09b6c2b5b18485, x230d76aa903b832a: true);
	}

	internal static string x633d57e35b6715a4(Node x10aaa7cdfa38f254, bool x579197826ce035a3, Node xca09b6c2b5b18485, bool x230d76aa903b832a)
	{
		return x633d57e35b6715a4(x10aaa7cdfa38f254, x579197826ce035a3, xca09b6c2b5b18485, x230d76aa903b832a, x39abdfb3e1bf0b2a: false);
	}

	internal static string x633d57e35b6715a4(Node x10aaa7cdfa38f254, bool x579197826ce035a3, Node xca09b6c2b5b18485, bool x230d76aa903b832a, bool x39abdfb3e1bf0b2a)
	{
		x9f265cdf86e37e15 x9f265cdf86e37e16 = new x9f265cdf86e37e15(x10aaa7cdfa38f254, x579197826ce035a3, xca09b6c2b5b18485, x230d76aa903b832a, x39abdfb3e1bf0b2a);
		return x9f265cdf86e37e16.x633d57e35b6715a4();
	}

	private string x633d57e35b6715a4()
	{
		while (x1ef2c3be187f37a2())
		{
			xc134d34d30cdbfb3();
			if (x991897f13cf6aadc)
			{
				continue;
			}
			if (base.x3387295f12854dfd.IsComposite)
			{
				CompositeNode compositeNode = (CompositeNode)base.x3387295f12854dfd;
				if (!compositeNode.HasChildNodes)
				{
					x800085dd555f7711.Append(compositeNode.x0598f184f69953c1());
				}
			}
			else
			{
				x800085dd555f7711.Append(base.x3387295f12854dfd.GetText());
			}
		}
		return x800085dd555f7711.ToString();
	}

	protected override void OnMoved(x92efcb0dc4970661 movement)
	{
		if (movement == x92efcb0dc4970661.x887a0c79ecbe5ee3)
		{
			x800085dd555f7711.Append(((CompositeNode)base.x3387295f12854dfd).x0598f184f69953c1());
		}
	}

	private void xc134d34d30cdbfb3()
	{
		if (!xfa8d1184b8d25e4e)
		{
			return;
		}
		switch (base.x3387295f12854dfd.NodeType)
		{
		case NodeType.FieldStart:
			x75be698bf0c3a5c5();
			break;
		case NodeType.FieldSeparator:
			x45277e5380a187db();
			break;
		case NodeType.FieldEnd:
			if (!((FieldEnd)base.x3387295f12854dfd).HasSeparator)
			{
				x45277e5380a187db();
			}
			break;
		}
	}

	private void x75be698bf0c3a5c5()
	{
		xafc4b914f07c2d11++;
	}

	private void x45277e5380a187db()
	{
		xafc4b914f07c2d11--;
	}
}
