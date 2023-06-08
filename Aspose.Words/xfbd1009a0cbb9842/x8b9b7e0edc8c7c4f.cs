using System.Collections;
using Aspose.Words;
using Aspose.Words.Fields;
using xf9a9481c3f63a419;

namespace xfbd1009a0cbb9842;

internal abstract class x8b9b7e0edc8c7c4f
{
	private readonly x0a80b8c2d1e8cf13 x7945f37de10c46e0;

	private Node x8385ef52c4ad91bc;

	private Paragraph x97b8406beded8527;

	private Paragraph xfbafc9ec77be999c;

	private xae43baa874aa5b1a xc0f30b33b4e98ad1;

	private xae43baa874aa5b1a x331df821a883a75a;

	private bool x3e61945adbb4ad79;

	private int x2bc1e8c44eb8a932;

	private int xafc4b914f07c2d11;

	private bool x9393c5c8241bb3dd;

	private bool x991897f13cf6aadc => xafc4b914f07c2d11 > 0;

	protected xae43baa874aa5b1a xd420ac3415caa02b => xc0f30b33b4e98ad1;

	internal bool xbad74afa42d95f36
	{
		get
		{
			switch (xc0f30b33b4e98ad1)
			{
			case xae43baa874aa5b1a.xad455511c416e678:
				return true;
			case xae43baa874aa5b1a.x9b0bd1d441d7040b:
			case xae43baa874aa5b1a.x3e1feffd8ca6feb2:
			case xae43baa874aa5b1a.x43604484a3deae4f:
				return false;
			default:
				return false;
			}
		}
	}

	private bool x96fedc99ef2ac3ba
	{
		get
		{
			switch (xc0f30b33b4e98ad1)
			{
			case xae43baa874aa5b1a.x9b0bd1d441d7040b:
			case xae43baa874aa5b1a.x3e1feffd8ca6feb2:
			case xae43baa874aa5b1a.x43604484a3deae4f:
			case xae43baa874aa5b1a.xad455511c416e678:
				return true;
			default:
				return false;
			}
		}
	}

	protected int xb76ace4a8294b8d0 => x2bc1e8c44eb8a932;

	protected Node x4f6686d624d5dfe1 => x8385ef52c4ad91bc;

	protected Run x4092a781b3b7aab4 => (Run)x8385ef52c4ad91bc;

	internal bool x57909321c14995e1 => x8385ef52c4ad91bc != null;

	internal Paragraph x6b1ebac4b985013b => x97b8406beded8527;

	internal Paragraph xc4d960d0b07339fc => xfbafc9ec77be999c;

	protected bool x14af24c1e6f8f311 => x8385ef52c4ad91bc.NodeType == NodeType.Run;

	protected bool x273d95283e8fc8d2 => x8385ef52c4ad91bc.NodeType == NodeType.Paragraph;

	protected x8b9b7e0edc8c7c4f(IEnumerable resultNodes, Paragraph startParagraph)
	{
		x7945f37de10c46e0 = new x0a80b8c2d1e8cf13(resultNodes.GetEnumerator());
		x97b8406beded8527 = startParagraph;
	}

	internal virtual bool x47f176deff0d42e2()
	{
		if (x3e61945adbb4ad79)
		{
			return false;
		}
		if (x57909321c14995e1)
		{
			if (x273d95283e8fc8d2)
			{
				xfbafc9ec77be999c = x97b8406beded8527;
				x97b8406beded8527 = (Paragraph)x8385ef52c4ad91bc;
			}
			xc0f30b33b4e98ad1 = x331df821a883a75a;
			ApplyNext();
		}
		while (x1a079f08620864ed())
		{
			OnNextNode();
			switch (x8385ef52c4ad91bc.NodeType)
			{
			case NodeType.Run:
			{
				char c = x4092a781b3b7aab4.Text[x2bc1e8c44eb8a932];
				x331df821a883a75a = xbba05ab7f3313a07(c);
				if (x331df821a883a75a != xae43baa874aa5b1a.x9b0bd1d441d7040b)
				{
					x9393c5c8241bb3dd = false;
				}
				else if (char.IsDigit(c))
				{
					x9393c5c8241bb3dd = true;
				}
				if (x9a155718b08c5041())
				{
					OnNextChar(c);
					return true;
				}
				xc0f30b33b4e98ad1 = x331df821a883a75a;
				OnChar(c);
				break;
			}
			case NodeType.Paragraph:
				x331df821a883a75a = xae43baa874aa5b1a.xad455511c416e678;
				x9393c5c8241bb3dd = false;
				if (!x96fedc99ef2ac3ba)
				{
					return x47f176deff0d42e2();
				}
				return true;
			}
		}
		return x96fedc99ef2ac3ba;
	}

	private bool x1a079f08620864ed()
	{
		do
		{
			if (x57909321c14995e1 && x14af24c1e6f8f311 && x2bc1e8c44eb8a932 < x4092a781b3b7aab4.Text.Length)
			{
				x2bc1e8c44eb8a932++;
				continue;
			}
			if (x7945f37de10c46e0.x47f176deff0d42e2())
			{
				x8385ef52c4ad91bc = (Node)x7945f37de10c46e0.x35cfcea4890f4e7d;
				x2bc1e8c44eb8a932 = 0;
				x0f7bcd7d85e3201c(x8385ef52c4ad91bc);
				continue;
			}
			x3e61945adbb4ad79 = true;
			return false;
		}
		while (!x2228607caffd00ef());
		return true;
	}

	private xae43baa874aa5b1a xbba05ab7f3313a07(char x3c4da2980d043c95)
	{
		switch (x3c4da2980d043c95)
		{
		case '\u001e':
		case '\'':
		case '-':
		case '\u00a0':
			return xae43baa874aa5b1a.x9b0bd1d441d7040b;
		case ',':
		case '.':
			if (!x9393c5c8241bb3dd)
			{
				return xae43baa874aa5b1a.x43604484a3deae4f;
			}
			return xae43baa874aa5b1a.x9b0bd1d441d7040b;
		default:
			if (char.IsLetterOrDigit(x3c4da2980d043c95))
			{
				return xae43baa874aa5b1a.x9b0bd1d441d7040b;
			}
			if (char.IsWhiteSpace(x3c4da2980d043c95))
			{
				return xae43baa874aa5b1a.x3e1feffd8ca6feb2;
			}
			return xae43baa874aa5b1a.x43604484a3deae4f;
		}
	}

	private bool x9a155718b08c5041()
	{
		switch (xc0f30b33b4e98ad1)
		{
		case xae43baa874aa5b1a.x9b0bd1d441d7040b:
			return x331df821a883a75a != xae43baa874aa5b1a.x9b0bd1d441d7040b;
		case xae43baa874aa5b1a.x3e1feffd8ca6feb2:
			return x331df821a883a75a != xae43baa874aa5b1a.x3e1feffd8ca6feb2;
		case xae43baa874aa5b1a.x43604484a3deae4f:
		case xae43baa874aa5b1a.xad455511c416e678:
			return true;
		case xae43baa874aa5b1a.x236cb0a4295bc034:
			return false;
		default:
			return false;
		}
	}

	private void x0f7bcd7d85e3201c(Node xda5bf54deb817e37)
	{
		switch (xda5bf54deb817e37.NodeType)
		{
		case NodeType.FieldStart:
			xafc4b914f07c2d11++;
			break;
		case NodeType.FieldSeparator:
			xafc4b914f07c2d11--;
			OnFieldResultBoundary();
			break;
		case NodeType.FieldEnd:
			if (!((FieldEnd)xda5bf54deb817e37).HasSeparator)
			{
				xafc4b914f07c2d11--;
			}
			OnFieldResultBoundary();
			break;
		}
	}

	private bool x2228607caffd00ef()
	{
		if (x991897f13cf6aadc)
		{
			return false;
		}
		return x8385ef52c4ad91bc.NodeType switch
		{
			NodeType.Run => x2bc1e8c44eb8a932 < x8385ef52c4ad91bc.GetText().Length, 
			NodeType.Paragraph => true, 
			_ => false, 
		};
	}

	protected virtual void OnNextNode()
	{
	}

	protected virtual void OnFieldResultBoundary()
	{
	}

	protected virtual void OnChar(char c)
	{
	}

	protected virtual void OnNextChar(char c)
	{
	}

	protected virtual void ApplyNext()
	{
	}
}
