using System;
using System.IO;

namespace ns71;

internal class Class3482 : Class3473
{
	private readonly int int_0;

	private Class3487 class3487_0;

	private Class3488 class3488_0;

	private Class3492 class3492_0;

	private Class3485 class3485_0;

	private Class3489 class3489_0 = new Class3489();

	private Class3486 class3486_0 = new Class3486();

	private Class3484 class3484_0 = new Class3484();

	private Class3493 class3493_0 = new Class3493();

	private Class3491 class3491_0;

	private Class3490 class3490_0;

	private ushort ushort_0;

	internal Class3492 StreamName => class3492_0;

	internal Class3489 Offset => class3489_0;

	public Class3493 Type => class3493_0;

	public Class3482(int codePage, string name)
	{
		int_0 = codePage;
		class3487_0 = new Class3487(int_0);
		class3487_0.ModuleName = name;
		class3488_0 = new Class3488(int_0);
		class3488_0.ModuleNameUnicode = name;
		class3492_0 = new Class3492(int_0, name);
		class3492_0.StreamName = name;
		class3485_0 = new Class3485(int_0, "");
		class3493_0.IsProceduralModule = true;
	}

	public Class3482(int codePage)
	{
		int_0 = codePage;
		class3487_0 = new Class3487(int_0);
		class3492_0 = new Class3492(int_0);
		class3485_0 = new Class3485(int_0);
	}

	internal override void vmethod_0(BinaryReader reader)
	{
		class3487_0.vmethod_0(reader);
		if (Class3522.smethod_0(reader) == 71)
		{
			class3488_0 = new Class3488(int_0);
			class3488_0.vmethod_0(reader);
		}
		class3492_0.vmethod_0(reader);
		class3485_0.vmethod_0(reader);
		class3489_0.vmethod_0(reader);
		class3486_0.vmethod_0(reader);
		class3484_0.vmethod_0(reader);
		class3493_0.vmethod_0(reader);
		if (Class3522.smethod_0(reader) == 37)
		{
			class3491_0 = new Class3491();
			class3491_0.vmethod_0(reader);
		}
		if (Class3522.smethod_0(reader) == 40)
		{
			class3490_0 = new Class3490();
			class3490_0.vmethod_0(reader);
		}
		ushort_0 = reader.ReadUInt16();
		if (ushort_0 != 43)
		{
			throw new InvalidOperationException();
		}
		reader.ReadUInt32();
	}

	internal override void vmethod_1(BinaryWriter writer)
	{
		class3487_0.vmethod_1(writer);
		if (class3488_0 != null)
		{
			class3488_0.vmethod_1(writer);
		}
		class3492_0.vmethod_1(writer);
		class3485_0.vmethod_1(writer);
		class3489_0.vmethod_1(writer);
		class3486_0.vmethod_1(writer);
		class3484_0.vmethod_1(writer);
		class3493_0.vmethod_1(writer);
		if (class3491_0 != null)
		{
			class3491_0.vmethod_1(writer);
		}
		if (class3490_0 != null)
		{
			class3490_0.vmethod_1(writer);
		}
		writer.Write((ushort)43);
		writer.Write(0u);
	}
}
