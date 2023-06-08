using System.Collections.Generic;
using ns83;

namespace ns88;

internal abstract class Class4255
{
	private class Class4256 : Class4255
	{
		private List<int> list_0;

		public Class4256(params int[] types)
		{
			list_0 = new List<int>(types);
		}

		public override bool vmethod_0(Interface105 node)
		{
			return list_0.IndexOf(node.Type) != -1;
		}
	}

	public abstract bool vmethod_0(Interface105 node);

	public static Class4255 smethod_0(params int[] types)
	{
		return new Class4256(types);
	}
}
