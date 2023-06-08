using System.IO;
using ns4;

namespace ns59;

internal struct Struct135
{
	public ushort ushort_0;

	public ushort ushort_1;

	public static Struct135 smethod_0(Stream stream)
	{
		Struct135 result = default(Struct135);
		result.ushort_0 = (ushort)Class1162.smethod_22(stream);
		result.ushort_1 = (ushort)Class1162.smethod_22(stream);
		return result;
	}

	public void method_0(BinaryWriter writer)
	{
		writer.Write(ushort_0);
		writer.Write(ushort_1);
	}
}
