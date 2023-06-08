using System.Text;
using ns16;

namespace ns46;

internal class Class1008
{
	internal Stream6 stream6_0;

	internal string string_0 = "";

	internal Class1008(Stream6 stream6_1)
	{
		stream6_0 = stream6_1;
	}

	internal void method_0(string string_1)
	{
		byte[] bytes = Encoding.UTF8.GetBytes(string_1);
		stream6_0.Write(bytes, 0, bytes.Length);
		stream6_0.Flush();
	}
}
