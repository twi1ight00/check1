using System.IO;
using ns101;
using ns144;
using ns146;
using ns149;

namespace ns147;

internal class Class4659 : Class4655
{
	public const string string_0 = "fpgm";

	internal const string string_1 = "fpgm";

	internal byte[] byte_0;

	private object object_1 = new object();

	private volatile bool bool_2;

	private Class4645 class4645_0 = new Class4645();

	internal byte[] Program
	{
		get
		{
			method_0();
			return byte_0;
		}
	}

	internal Class4645 Subroutines
	{
		get
		{
			method_2();
			return class4645_0;
		}
	}

	internal Class4659(Class4681 ttfTables, Class4411 font)
		: base(ttfTables, font)
	{
	}

	internal Class4659(Class4651 context, uint checkSum, uint offset, uint length)
		: base(context, checkSum, offset, length)
	{
	}

	internal override void vmethod_2(Class4689 ttfReader)
	{
		base.vmethod_2(ttfReader);
	}

	internal override void vmethod_0(Class4689 ttfReader)
	{
		base.vmethod_0(ttfReader);
		ttfReader.Seek(base.Offset);
		byte_0 = ttfReader.method_1((int)base.Length);
	}

	internal override void Save(out byte[] tableBytes, out uint length, out uint checksum)
	{
		if (base.IsNewFont)
		{
			using (MemoryStream stream = new MemoryStream())
			{
				using Class4685 @class = new Class4685(stream, closeStreamOnDispose: true);
				if (byte_0 != null)
				{
					@class.method_1(byte_0);
				}
				method_1(@class, stream, out tableBytes, out length, out checksum);
				return;
			}
		}
		base.Save(out tableBytes, out length, out checksum);
	}

	private void method_2()
	{
		if (bool_2)
		{
			return;
		}
		lock (object_1)
		{
			if (!bool_2)
			{
				Class4641 @class = new Class4641(Program, base.Context);
				@class.method_0();
				class4645_0 = @class.Subroutines;
				bool_2 = true;
			}
		}
	}
}
