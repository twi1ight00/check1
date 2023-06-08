using System.Collections;
using System.Drawing;

namespace ns18;

internal class Class467 : Class452
{
	private readonly ArrayList arrayList_0 = new ArrayList();

	public ArrayList Points => arrayList_0;

	public Class467()
	{
	}

	public Class467(float[] float_0)
	{
		int num = float_0.Length / 2;
		for (int i = 0; i < num; i++)
		{
			arrayList_0.Add(new PointF(float_0[i * 2], float_0[i * 2 + 1]));
		}
	}

	public override void vmethod_0(Class468 class468_0)
	{
		class468_0.vmethod_10(this);
	}
}
