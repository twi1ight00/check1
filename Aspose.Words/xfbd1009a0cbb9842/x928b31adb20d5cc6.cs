using System.Text;
using Aspose.Words;
using Aspose.Words.Fields;
using x28925c9b27b37a46;

namespace xfbd1009a0cbb9842;

internal struct x928b31adb20d5cc6
{
	private FieldStart x212ae880d15d2ed1;

	private FieldSeparator x8298d7f8d08be8ed;

	private FieldEnd xb664a8c25c0c85cc;

	internal FieldChar xb29355c4bafca5da
	{
		get
		{
			if (x43604484a3deae4f == null)
			{
				return x9fd888e65466818c;
			}
			return x43604484a3deae4f;
		}
	}

	internal FieldType xc96d173d58dd8a20 => x12cb12b5d2cad53d.FieldType;

	internal FieldStart x12cb12b5d2cad53d
	{
		get
		{
			return x212ae880d15d2ed1;
		}
		set
		{
			x212ae880d15d2ed1 = value;
		}
	}

	internal FieldSeparator x43604484a3deae4f
	{
		get
		{
			return x8298d7f8d08be8ed;
		}
		set
		{
			x8298d7f8d08be8ed = value;
		}
	}

	internal FieldEnd x9fd888e65466818c
	{
		get
		{
			return xb664a8c25c0c85cc;
		}
		set
		{
			xb664a8c25c0c85cc = value;
		}
	}

	internal x928b31adb20d5cc6(FieldStart start, FieldSeparator separator, FieldEnd end)
	{
		x212ae880d15d2ed1 = start;
		x8298d7f8d08be8ed = separator;
		xb664a8c25c0c85cc = end;
	}

	internal string x071b5fbe719eaec7()
	{
		return x9f265cdf86e37e15.x633d57e35b6715a4(x12cb12b5d2cad53d, x579197826ce035a3: false, xb29355c4bafca5da, x230d76aa903b832a: false);
	}

	internal string x29815ca66d57cfae()
	{
		StringBuilder stringBuilder = new StringBuilder();
		Node nextSibling = x12cb12b5d2cad53d.NextSibling;
		Node node = xb29355c4bafca5da;
		while (nextSibling != null && nextSibling != node)
		{
			if (nextSibling.NodeType == NodeType.Run)
			{
				stringBuilder.Append(nextSibling.GetText());
			}
			nextSibling = nextSibling.NextSibling;
			if (nextSibling != null && nextSibling.NodeType == NodeType.FieldStart)
			{
				break;
			}
		}
		return stringBuilder.ToString();
	}

	internal void x8fdbe5468986594f(FieldType x77ce91e5324df734)
	{
		x12cb12b5d2cad53d.x8fdbe5468986594f(x77ce91e5324df734);
		x9fd888e65466818c.x8fdbe5468986594f(x77ce91e5324df734);
		if (x43604484a3deae4f != null)
		{
			x43604484a3deae4f.x8fdbe5468986594f(x77ce91e5324df734);
		}
	}

	internal void x45aed43ab4f2045c()
	{
		if (x12cb12b5d2cad53d != null)
		{
			x12cb12b5d2cad53d.Remove();
		}
		if (x43604484a3deae4f != null)
		{
			x43604484a3deae4f.Remove();
		}
		if (x9fd888e65466818c != null)
		{
			x9fd888e65466818c.Remove();
		}
	}

	internal void x6e0f5b69ee5c3db9()
	{
		bool flag = x12cb12b5d2cad53d.x6e94079169d5a06e || x9fd888e65466818c.x6e94079169d5a06e || (x43604484a3deae4f != null && x43604484a3deae4f.x6e94079169d5a06e);
		x12cb12b5d2cad53d.x6e94079169d5a06e = flag;
		x9fd888e65466818c.x6e94079169d5a06e = flag;
		if (x43604484a3deae4f != null && flag)
		{
			x43604484a3deae4f.x6e94079169d5a06e = flag;
		}
		bool flag2 = x12cb12b5d2cad53d.IsLocked || x9fd888e65466818c.IsLocked || (x43604484a3deae4f != null && x43604484a3deae4f.IsLocked);
		x12cb12b5d2cad53d.IsLocked = flag2;
		x9fd888e65466818c.IsLocked = flag2;
		if (x43604484a3deae4f != null && flag2)
		{
			x43604484a3deae4f.IsLocked = flag2;
		}
	}

	private static bool x5522893703a59da8(FieldChar xda5bf54deb817e37)
	{
		return xda5bf54deb817e37?.IsDeleteRevision ?? false;
	}
}
