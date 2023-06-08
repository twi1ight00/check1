using System;
using System.IO;
using System.Text;
using ns60;

namespace ns63;

internal class Class2987 : Interface40
{
	private ushort ushort_0;

	private readonly Class2974 class2974_0;

	private readonly Class2971 class2971_0;

	public ushort Level
	{
		get
		{
			return ushort_0;
		}
		set
		{
			if (value >= 5)
			{
				throw new ArgumentOutOfRangeException("2.9.36 TextMasterStyleLevel.level can't be more than 0x5.");
			}
			ushort_0 = value;
		}
	}

	public Class2974 ParagraphFormat => class2974_0;

	public Class2971 CharFormat => class2971_0;

	public Class2987()
	{
		Level = 0;
		class2974_0 = new Class2974();
		class2971_0 = new Class2971();
	}

	public Class2987(ushort level)
		: this()
	{
		Level = level;
	}

	public override string ToString()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.AppendLine("TextMasterStyleLevel: ");
		stringBuilder.AppendLine(class2974_0.ToString());
		stringBuilder.Append(class2971_0);
		return stringBuilder.ToString().Replace("\n", "\n  ");
	}

	public void method_0(Class2987 textMasterStyleLevel)
	{
		class2974_0.vmethod_0(textMasterStyleLevel.class2974_0);
		class2971_0.method_3(textMasterStyleLevel.class2971_0);
	}

	public void method_1(Class2987 textMasterStyleLevel)
	{
		class2974_0.vmethod_1(textMasterStyleLevel.class2974_0);
		class2971_0.vmethod_0(textMasterStyleLevel.class2971_0);
	}

	internal void method_2(BinaryReader reader, short parentInstance)
	{
		if (parentInstance >= 5)
		{
			ushort_0 = reader.ReadUInt16();
		}
		class2974_0.method_0(reader);
		class2971_0.method_0(reader);
	}

	internal void method_3(BinaryWriter writer, int level, short parentInstance)
	{
		if (parentInstance >= 5)
		{
			writer.Write(ushort_0);
		}
		class2974_0.method_1(writer);
		class2971_0.method_1(writer);
	}

	internal int method_4(short parentInstance)
	{
		int num = ((parentInstance >= 5) ? 2 : 0);
		num += class2974_0.method_2();
		return num + class2971_0.method_2();
	}
}
