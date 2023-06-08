using System.Collections;
using System.Drawing;
using ns18;

namespace ns17;

internal class Class1091
{
	private ArrayList arrayList_0;

	public float float_0;

	public float float_1;

	public Class1091()
	{
		arrayList_0 = new ArrayList();
	}

	public void method_0(Class1088 class1088_0)
	{
		arrayList_0.Add(class1088_0);
		float_1 += class1088_0.float_1;
		if (float_0 < class1088_0.float_0)
		{
			float_0 = class1088_0.float_0;
		}
	}

	public void method_1(ref Class454 class454_0, PointF pointF_0)
	{
		float num = pointF_0.X;
		float num2 = 0f;
		foreach (Class1088 item in arrayList_0)
		{
			num2 = pointF_0.Y + float_0;
			item.vmethod_0(ref class454_0, new PointF(num, num2));
			num += item.float_1;
		}
	}
}
