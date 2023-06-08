using System;
using System.IO;
using ns60;

namespace ns63;

internal class Class2984 : Interface40
{
	private uint uint_0;

	private ushort ushort_0;

	private Class2974 class2974_0 = new Class2974();

	public uint Count
	{
		get
		{
			return uint_0;
		}
		set
		{
			uint_0 = value;
		}
	}

	public ushort IndentLevel
	{
		get
		{
			return ushort_0;
		}
		set
		{
			ushort_0 = value;
			if (ushort_0 > 4)
			{
				ushort_0 = 4;
			}
		}
	}

	public Class2974 ParagraphFormat
	{
		get
		{
			return class2974_0;
		}
		set
		{
			class2974_0 = value;
		}
	}

	internal void method_0(BinaryReader reader)
	{
		uint_0 = reader.ReadUInt32();
		ushort_0 = reader.ReadUInt16();
		class2974_0 = new Class2974();
		class2974_0.method_0(reader);
	}

	internal void method_1(BinaryWriter writer)
	{
		if (class2974_0.HaveTabAndMargin)
		{
			throw new Exception("Wrong serialized data!!!\nTextPFException within TextPFRun can't have LeftMargin, Indent, DefaultTabSize or TabStops!!!");
		}
		writer.Write(uint_0);
		writer.Write(ushort_0);
		class2974_0.method_1(writer);
	}

	internal int method_2()
	{
		return 6 + class2974_0.method_2();
	}

	internal bool method_3(Class2984 textPFRun)
	{
		if (ushort_0 == textPFRun.ushort_0)
		{
			return class2974_0.method_4(textPFRun.class2974_0);
		}
		return false;
	}
}
