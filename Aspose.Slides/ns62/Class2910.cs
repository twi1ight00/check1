using System.IO;
using ns60;

namespace ns62;

internal abstract class Class2910 : Interface40
{
	private Enum426 enum426_0;

	private bool bool_0;

	public Enum426 Id => enum426_0;

	internal bool IsBid => bool_0;

	internal Class2910(Enum426 id, bool isBid)
	{
		enum426_0 = id;
		bool_0 = isBid;
	}

	internal abstract void Write(BinaryWriter writer);

	internal abstract int vmethod_0();
}
