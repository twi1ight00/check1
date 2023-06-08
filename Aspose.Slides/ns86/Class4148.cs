using System.Collections.Generic;
using ns305;
using ns84;

namespace ns86;

internal class Class4148 : Class4147
{
	private List<Enum633> list_0;

	public Class4148(params Enum633[] position)
	{
		list_0 = new List<Enum633>(position);
	}

	public override bool imethod_0(Class6981 candidate)
	{
		Class4347 @class = Class4347.smethod_1(candidate);
		return list_0.Contains(@class.Position);
	}
}
