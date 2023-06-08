using System.Drawing;
using ns234;

namespace ns237;

internal class Class6673
{
	private readonly string string_0;

	private PointF pointF_0 = PointF.Empty;

	internal Class6673(string pageReference, PointF location)
	{
		string_0 = pageReference;
		pointF_0 = location;
	}

	internal void method_0(Class6678 writer)
	{
		string arg = Class6159.smethod_24((int)pointF_0.X);
		string arg2 = Class6159.smethod_24((int)pointF_0.Y);
		writer.Write("[{0} /XYZ {1} {2} 0]", string_0, arg, arg2);
	}
}
