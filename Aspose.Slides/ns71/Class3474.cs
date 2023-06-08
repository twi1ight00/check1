using System.IO;

namespace ns71;

internal class Class3474 : Class3473
{
	private Class3476 class3476_0;

	private Class3475 class3475_0;

	public Class3476 CompressedHeader
	{
		get
		{
			return class3476_0;
		}
		set
		{
			class3476_0 = value;
		}
	}

	public Class3475 CompressedData
	{
		get
		{
			return class3475_0;
		}
		set
		{
			class3475_0 = value;
		}
	}

	internal override void vmethod_0(BinaryReader reader)
	{
		class3476_0 = new Class3476();
		class3476_0.vmethod_0(reader);
		class3475_0 = new Class3475(class3476_0.CompressedChunkSize + 3, class3476_0.CompressedChunkFlag == 1);
		class3475_0.vmethod_0(reader);
	}

	internal override void vmethod_1(BinaryWriter writer)
	{
		class3476_0.vmethod_1(writer);
		class3475_0.vmethod_1(writer);
	}
}
