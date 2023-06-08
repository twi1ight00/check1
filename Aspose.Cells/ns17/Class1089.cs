using System.Drawing;
using System.IO;
using ns18;

namespace ns17;

internal class Class1089 : Class1088
{
	private MemoryStream memoryStream_0;

	private SizeF sizeF_0;

	public Class1089(MemoryStream memoryStream_1, SizeF sizeF_1)
	{
		float_0 = sizeF_1.Height;
		float_1 = sizeF_1.Width;
		memoryStream_0 = memoryStream_1;
		sizeF_0 = sizeF_1;
	}

	public override void vmethod_0(ref Class454 class454_0, PointF pointF_0)
	{
		PointF pointF_ = new PointF(pointF_0.X, pointF_0.Y - sizeF_0.Height);
		Class465 class452_ = Class465.smethod_0(pointF_, sizeF_0, memoryStream_0);
		class454_0.Add(class452_);
	}
}
