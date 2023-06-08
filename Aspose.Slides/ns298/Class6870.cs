using System.IO;
using ns292;
using ns299;

namespace ns298;

internal class Class6870 : Class6869
{
	public Class6870(Stream stream, Class6868 cssWriter, Class6794 bundle, string cssLocation)
		: base(stream, cssWriter, bundle, cssLocation)
	{
	}

	protected override string vmethod_0(Class6875 tagInfo)
	{
		return tagInfo.Name.ToLowerInvariant();
	}

	protected override string vmethod_1(Class6865 attribute)
	{
		return attribute.Name.ToLowerInvariant();
	}
}
