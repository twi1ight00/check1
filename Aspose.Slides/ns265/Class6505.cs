using System.Collections;
using ns237;

namespace ns265;

internal abstract class Class6505 : Class6504
{
	protected Class6673 class6673_0;

	internal abstract void vmethod_1(IDictionary destinations);

	public override void vmethod_0(Class6678 writer)
	{
		if (class6673_0 != null)
		{
			writer.Write("/Dest");
			class6673_0.method_0(writer);
		}
	}
}
