using System.IO;

namespace ns71;

internal abstract class Class3527
{
	private string string_0;

	public abstract string Key { get; }

	public string Value
	{
		get
		{
			return string_0;
		}
		set
		{
			string_0 = value;
		}
	}

	public Class3527(string value)
	{
		string_0 = value;
	}

	public void method_0(StringWriter writer)
	{
		writer.Write(Key);
		writer.Write("=");
		writer.Write(Value);
		writer.Write("\r\n");
	}
}
