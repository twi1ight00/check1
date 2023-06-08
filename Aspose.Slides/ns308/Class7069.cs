using ns305;
using ns307;

namespace ns308;

internal class Class7069 : Interface370
{
	private string string_0;

	public Class7069(string id)
	{
		string_0 = id;
	}

	public short imethod_0(Class6976 n)
	{
		foreach (Class7045 attribute in n.Attributes)
		{
			if (attribute.IsId && attribute.Value.Equals(string_0))
			{
				return 1;
			}
		}
		return 2;
	}
}
