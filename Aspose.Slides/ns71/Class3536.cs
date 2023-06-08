using System.IO;
using System.Text;

namespace ns71;

internal class Class3536
{
	private Class3537 class3537_0;

	private string string_0;

	internal Class3536()
	{
		class3537_0 = new Class3537();
	}

	internal void method_0(StringReader reader)
	{
		class3537_0.method_0(reader);
		string_0 = reader.ReadToEnd();
	}

	internal void method_1(StringWriter writer)
	{
		class3537_0.method_1(writer);
		writer.Write(string_0);
	}

	internal void method_2(string projectName)
	{
		class3537_0.method_2(projectName);
		method_5();
	}

	public void method_3(string name)
	{
		class3537_0.method_3(name);
	}

	public void method_4(string name)
	{
		class3537_0.method_4(name);
	}

	private void method_5()
	{
		StringBuilder stringBuilder = new StringBuilder(string_0);
		stringBuilder.Append("[Host Extender Info]");
	}
}
