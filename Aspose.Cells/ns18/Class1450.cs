using System.Collections.Specialized;

namespace ns18;

internal class Class1450 : StringCollection
{
	internal void method_0(Class1446 class1446_0)
	{
		class1446_0.Write("[");
		for (int i = 0; i < base.Count; i++)
		{
			class1446_0.Write(base[i]);
			class1446_0.Write(" ");
		}
		class1446_0.Write("]");
	}
}
