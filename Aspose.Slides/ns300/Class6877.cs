using System.Collections;
using ns164;

namespace ns300;

internal class Class6877
{
	private Enum669 enum669_0;

	private string string_0;

	private Hashtable hashtable_0 = new Hashtable();

	public Enum669 Type => enum669_0;

	public string Name => string_0;

	public Hashtable LevelFormats => hashtable_0;

	public Class6877(Enum669 type, string name)
	{
		enum669_0 = type;
		string_0 = name;
	}

	public void method_0(Class6878 format)
	{
		hashtable_0[format.Level] = format;
	}
}
