using System.Collections;
using System.Runtime.CompilerServices;

namespace ns18;

internal class Class466 : Class452
{
	private ArrayList arrayList_0 = new ArrayList();

	public void method_1(Struct89 struct89_0)
	{
		arrayList_0.Add(struct89_0);
	}

	[SpecialName]
	public ArrayList method_2()
	{
		return arrayList_0;
	}

	public override void vmethod_0(Class468 class468_0)
	{
		class468_0.vmethod_11(this);
	}
}
