using System;
using System.Collections;
using x28925c9b27b37a46;
using x6c95d9cf46ff5f25;

namespace Aspose.Words;

public class Revision
{
	private RevisionType xf263b01e2956834c;

	private xbe47717e2fd4172a xd54ab82fabd05414;

	private readonly Node x8a08cc7cfe65e03b;

	private readonly Style xdd00c5827ed18497;

	private readonly bool x7068cc579f49d2c0;

	private readonly RevisionCollection x74a1277606c51af8;

	public string Author
	{
		get
		{
			return xd54ab82fabd05414.xb063bbfcfeade526;
		}
		set
		{
			if (!x0d299f323d241756.x5959bccb67bbf051(value))
			{
				throw new ArgumentException(value);
			}
			xd54ab82fabd05414.xb063bbfcfeade526 = value;
		}
	}

	public DateTime DateTime
	{
		get
		{
			return xd54ab82fabd05414.x242851e6278ed355;
		}
		set
		{
			xd54ab82fabd05414.x242851e6278ed355 = value;
		}
	}

	public RevisionType RevisionType => xf263b01e2956834c;

	public Node ParentNode
	{
		get
		{
			if (x8a08cc7cfe65e03b == null)
			{
				throw new InvalidOperationException("Can not access ParentNode for a style revision. Use ParentStyle instead.");
			}
			return x8a08cc7cfe65e03b;
		}
	}

	public Style ParentStyle
	{
		get
		{
			if (xdd00c5827ed18497 == null)
			{
				throw new InvalidOperationException("Can not access ParentStyle for a node revision. Use ParentNode instead.");
			}
			return xdd00c5827ed18497;
		}
	}

	internal bool xc5bb70cfaaae4a20
	{
		get
		{
			if (xf263b01e2956834c != RevisionType.StyleDefinitionChange)
			{
				return x7068cc579f49d2c0;
			}
			return false;
		}
	}

	internal Revision(Node parentNode, RevisionCollection parentCollection)
	{
		x8a08cc7cfe65e03b = parentNode;
		x74a1277606c51af8 = parentCollection;
		x7f77ea92be0d9042 x72e03ac29430dcbc = xdd8aa62f92df1485.x67e96301bb4dca85(parentNode);
		x7068cc579f49d2c0 = parentNode is xcf3b0f04424de818;
		x35acb7ac1cbb328d(x72e03ac29430dcbc);
		if (parentNode is Paragraph)
		{
			Paragraph paragraph = (Paragraph)parentNode;
			if (paragraph.x1a78664fa10a3755.x054fe39eb479f67e)
			{
				xf263b01e2956834c = RevisionType.FormatChange;
				xd54ab82fabd05414 = paragraph.x1a78664fa10a3755.x978620a99b6d5014;
			}
			if (xd54ab82fabd05414 == null && paragraph.x344511c4e4ce09da.xcb78713836fcc98a)
			{
				x35acb7ac1cbb328d(paragraph.x344511c4e4ce09da);
			}
		}
	}

	internal Revision(Style parentStyle, RevisionCollection parentCollection)
	{
		xdd00c5827ed18497 = parentStyle;
		x74a1277606c51af8 = parentCollection;
		xf263b01e2956834c = RevisionType.StyleDefinitionChange;
		if (xdd00c5827ed18497.xeedad81aaed42a76.x0f53f53f15b61ef5)
		{
			xd54ab82fabd05414 = xdd00c5827ed18497.xeedad81aaed42a76.x5fb16e270c21db2e;
			return;
		}
		if (xdd00c5827ed18497.x1a78664fa10a3755.x0f53f53f15b61ef5)
		{
			xd54ab82fabd05414 = xdd00c5827ed18497.x1a78664fa10a3755.x5fb16e270c21db2e;
			return;
		}
		throw new InvalidOperationException("Please report exception.");
	}

	private void x35acb7ac1cbb328d(x7f77ea92be0d9042 x72e03ac29430dcbc)
	{
		if (x72e03ac29430dcbc.xba4e1d8a3e3316c8)
		{
			xf263b01e2956834c = RevisionType.Insertion;
			xd54ab82fabd05414 = x72e03ac29430dcbc.x18bb4aa7903ffced;
		}
		else if (x72e03ac29430dcbc.x0392c0938d22c790)
		{
			xf263b01e2956834c = RevisionType.Deletion;
			xd54ab82fabd05414 = x72e03ac29430dcbc.x83da691dd3d974a6;
		}
		else if (x72e03ac29430dcbc.x0f53f53f15b61ef5)
		{
			xf263b01e2956834c = RevisionType.FormatChange;
			xd54ab82fabd05414 = x72e03ac29430dcbc.x5fb16e270c21db2e;
		}
	}

	public void Accept()
	{
		xb30fd80dd933c5a8(x510619ea70954ab6: true, xaf009d95451d3630: true, null);
	}

	public void Reject()
	{
		xb30fd80dd933c5a8(x510619ea70954ab6: false, xaf009d95451d3630: true, null);
	}

	internal void xb30fd80dd933c5a8(bool x510619ea70954ab6, bool xaf009d95451d3630, ArrayList x51e539cc77490bdc)
	{
		if (x8a08cc7cfe65e03b != null)
		{
			xdd8aa62f92df1485.xbbf84cd4316306d6(x8a08cc7cfe65e03b, x510619ea70954ab6, x51e539cc77490bdc);
		}
		else if (x510619ea70954ab6)
		{
			xdd00c5827ed18497.xeedad81aaed42a76.xcb395027497bc067();
			xdd00c5827ed18497.x1a78664fa10a3755.xcb395027497bc067();
		}
		else
		{
			xdd00c5827ed18497.xeedad81aaed42a76.x097e4f3c708bd29c();
			xdd00c5827ed18497.x1a78664fa10a3755.x097e4f3c708bd29c();
		}
		if (xaf009d95451d3630)
		{
			x74a1277606c51af8.xe88ab84767e8fb69(this);
		}
	}
}
