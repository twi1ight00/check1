using System;

namespace ns305;

internal class Class7048 : Class6976
{
	public override string NodeName => base.OwnerDocument.string_2;

	public override Enum969 NodeType => Enum969.const_10;

	protected internal Class7048(Class7046 ownerDocument)
	{
		if (ownerDocument == null)
		{
			throw new ArgumentException();
		}
		base.vmethod_4(ownerDocument);
	}

	public override Class6976 vmethod_2(bool deep)
	{
		return base.OwnerDocument.method_20();
	}
}
