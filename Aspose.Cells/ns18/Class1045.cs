using System.Drawing;

namespace ns18;

internal class Class1045 : Class1043
{
	private long long_0;

	private long long_1;

	private long long_2;

	private Class1426 class1426_0;

	internal Class1045(Class1420 class1420_0, Class1426 class1426_1)
	{
		long_0 = class1420_0.ReadUInt32();
		long_1 = class1420_0.ReadUInt32();
		long_2 = class1420_0.ReadUInt32();
		class1426_0 = class1426_1;
	}

	internal override void vmethod_0(Class1046[] class1046_0)
	{
		PointF pointF_ = new PointF(class1046_0[(int)long_0].int_0, class1046_0[(int)long_0].int_1);
		PointF pointF_2 = new PointF(class1046_0[(int)long_1].int_0, class1046_0[(int)long_1].int_1);
		PointF pointF_3 = new PointF(class1046_0[(int)long_2].int_0, class1046_0[(int)long_2].int_1);
		Class458 @class = Class458.smethod_0(pointF_, pointF_2, pointF_3);
		@class.method_3(new SolidBrush(Color.FromArgb(255, class1046_0[(int)long_0].color_0)));
		@class.vmethod_1(class1426_0.method_0().method_29());
		class1426_0.class454_0.Add(@class);
	}
}
