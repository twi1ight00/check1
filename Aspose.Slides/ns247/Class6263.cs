using System.Collections;
using ns218;

namespace ns247;

internal class Class6263 : IEnumerable
{
	private readonly string string_0;

	private readonly Class5968 class5968_0;

	private readonly Class5968 class5968_1;

	private int int_0 = 1;

	public int Count => class5968_0.Count;

	public string PartName => string_0;

	public Class6263(string partName)
	{
		string_0 = partName;
		class5968_0 = new Class5968(isCaseSensitive: true);
		class5968_1 = new Class5968(isCaseSensitive: false);
	}

	public string Add(string relType, string absoluteTarget, bool isExternal)
	{
		if (isExternal)
		{
			if (Class5973.smethod_7(absoluteTarget))
			{
				absoluteTarget = "file:///" + absoluteTarget;
				absoluteTarget = Class5973.smethod_16(absoluteTarget);
			}
		}
		else
		{
			absoluteTarget = Class6254.smethod_1(string_0, absoluteTarget);
		}
		Class6262 @class = (Class6262)class5968_1[absoluteTarget];
		if (@class != null)
		{
			return @class.Id;
		}
		string text = $"rId{int_0}";
		int_0++;
		Add(text, relType, absoluteTarget, isExternal);
		return text;
	}

	public void Add(string relId, string relType, string absoluteTarget, bool isExternal)
	{
		Class6262 value = new Class6262(relId, relType, absoluteTarget, isExternal);
		class5968_0[relId] = value;
		class5968_1[absoluteTarget] = value;
	}

	public Class6262 method_0(string id)
	{
		return (Class6262)class5968_0[id];
	}

	public Class6262 method_1(string type)
	{
		foreach (Class6262 value in class5968_0.GetValueList())
		{
			if (value.Type == type)
			{
				return value;
			}
		}
		return null;
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return class5968_0.GetValueList().GetEnumerator();
	}
}
