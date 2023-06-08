using Aspose.Words;

namespace x28925c9b27b37a46;

internal class x8e28d0731c3bcab3 : xdbbc00f1636b87bc
{
	private readonly NodeType xf263b01e2956834c;

	private readonly NodeType[] xe3573dd7c09b5ec9;

	private bool x56066b4aa985992a;

	internal override bool xd8a4d30a54634d09 => x56066b4aa985992a;

	public x8e28d0731c3bcab3(NodeType type)
	{
		xf263b01e2956834c = type;
		x26cf5c34323be25a();
	}

	private void x26cf5c34323be25a()
	{
		if (xe3573dd7c09b5ec9 != null && xe3573dd7c09b5ec9.Length > 0)
		{
			for (int i = 0; i < xe3573dd7c09b5ec9.Length; i++)
			{
				if (!x2b1ee3a87b36a988.xd601422bf435ea8c(xe3573dd7c09b5ec9[i]))
				{
					x56066b4aa985992a = false;
					return;
				}
			}
			x56066b4aa985992a = true;
		}
		else
		{
			x56066b4aa985992a = x2b1ee3a87b36a988.xd601422bf435ea8c(xf263b01e2956834c);
		}
	}

	public x8e28d0731c3bcab3(NodeType[] types)
	{
		xe3573dd7c09b5ec9 = types;
		x26cf5c34323be25a();
	}

	internal override bool xc313ef0c9ca8870d(Node xda5bf54deb817e37)
	{
		if (xe3573dd7c09b5ec9 != null)
		{
			NodeType[] array = xe3573dd7c09b5ec9;
			foreach (NodeType nodeType in array)
			{
				if (xda5bf54deb817e37.NodeType == nodeType)
				{
					return true;
				}
			}
			return false;
		}
		if (xda5bf54deb817e37.NodeType != xf263b01e2956834c)
		{
			return xf263b01e2956834c == NodeType.Any;
		}
		return true;
	}
}
