using System;
using System.Drawing;

namespace ns243;

internal class Class6251
{
	private readonly Enum800 enum800_0;

	private readonly Enum799 enum799_0;

	public Class6251(Enum799 paperSize, Enum800 dpi)
	{
		enum799_0 = paperSize;
		enum800_0 = dpi;
	}

	public SizeF method_0()
	{
		if (enum799_0 == Enum799.const_0)
		{
			return enum800_0 switch
			{
				Enum800.const_0 => new SizeF(595f, 842f), 
				Enum800.const_1 => new SizeF(2480f, 3508f), 
				Enum800.const_2 => new SizeF(4960f, 7016f), 
				_ => throw new NotImplementedException(), 
			};
		}
		throw new NotImplementedException();
	}
}
