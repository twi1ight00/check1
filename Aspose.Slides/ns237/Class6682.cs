using System.Collections.Generic;

namespace ns237;

internal class Class6682 : List<string>
{
	internal void method_0(Class6678 writer)
	{
		writer.Write("[");
		for (int i = 0; i < base.Count; i++)
		{
			writer.Write(base[i]);
			writer.Write(" ");
		}
		writer.Write("]");
	}
}
