using System.IO;
using System.Text;
using ns60;

namespace ns63;

internal class Class2976 : Interface40
{
	private Enum442 enum442_0;

	protected Class2967 class2967_0;

	protected ushort ushort_0;

	protected ushort ushort_1;

	protected bool bool_0;

	protected byte byte_0;

	protected bool bool_1;

	protected uint[] uint_0;

	public bool IsEmpty
	{
		get
		{
			return enum442_0 == (Enum442)0;
		}
		set
		{
			if (value)
			{
				enum442_0 = (Enum442)0;
				uint_0 = null;
			}
		}
	}

	internal void method_0(BinaryReader reader)
	{
		enum442_0 = (Enum442)reader.ReadUInt32();
		if (method_5(Enum442.flag_0))
		{
			class2967_0 = new Class2967(reader);
		}
		if (method_5(Enum442.flag_1))
		{
			ushort_0 = reader.ReadUInt16();
		}
		if (method_5(Enum442.flag_2))
		{
			ushort_1 = reader.ReadUInt16();
		}
		if (method_5(Enum442.flag_4))
		{
			bool_0 = reader.ReadInt16() != 0;
		}
		if (method_5(Enum442.flag_3))
		{
			uint num = reader.ReadUInt32();
			byte_0 = (byte)(num & 0xFu);
			bool_1 = (num & 0x80000000u) != 0;
		}
		if (method_5(Enum442.flag_6))
		{
			int num2 = reader.ReadInt32();
			uint_0 = new uint[num2];
			for (int i = 0; i < num2; i++)
			{
				uint_0[i] = reader.ReadUInt32();
			}
		}
	}

	internal void method_1(BinaryWriter writer)
	{
		writer.Write((uint)enum442_0);
		if (method_5(Enum442.flag_0))
		{
			class2967_0.method_1(writer);
		}
		if (method_5(Enum442.flag_1))
		{
			writer.Write(ushort_0);
		}
		if (method_5(Enum442.flag_2))
		{
			writer.Write(ushort_1);
		}
		if (method_5(Enum442.flag_4))
		{
			writer.Write((ushort)(bool_0 ? 1u : 0u));
		}
		if (method_5(Enum442.flag_3))
		{
			writer.Write((uint)(byte_0 + (bool_1 ? int.MinValue : 0)));
		}
		if (method_5(Enum442.flag_6))
		{
			writer.Write((uint)uint_0.Length);
			for (int i = 0; i < uint_0.Length; i++)
			{
				writer.Write(uint_0[i]);
			}
		}
	}

	internal int method_2()
	{
		int num = 4;
		if (method_5(Enum442.flag_0))
		{
			num += class2967_0.method_2();
		}
		if (method_5(Enum442.flag_1))
		{
			num += 2;
		}
		if (method_5(Enum442.flag_2))
		{
			num += 2;
		}
		if (method_5(Enum442.flag_4))
		{
			num += 2;
		}
		if (method_5(Enum442.flag_3))
		{
			num += 4;
		}
		if (method_5(Enum442.flag_6))
		{
			num += 4 + uint_0.Length * 4;
		}
		return num;
	}

	public override string ToString()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.AppendLine($"  SIMask: 0x{(uint)enum442_0:X}, {enum442_0}");
		if (method_5(Enum442.flag_0))
		{
			stringBuilder.AppendLine($"  SpellInfo: {class2967_0}");
		}
		if (method_5(Enum442.flag_1))
		{
			stringBuilder.AppendLine($"  Language: {ushort_0}");
		}
		if (method_5(Enum442.flag_2))
		{
			stringBuilder.AppendLine($"  AltLanguage: {ushort_1}");
		}
		if (method_5(Enum442.flag_4))
		{
			stringBuilder.AppendLine($"  Bidirectional: {bool_0}");
		}
		if (method_5(Enum442.flag_3))
		{
			stringBuilder.AppendLine($"  PP10RunID: 0x{byte_0:X}");
			stringBuilder.AppendLine($"  GrammarError: {bool_1}");
		}
		if (method_5(Enum442.flag_6))
		{
			stringBuilder.Append($"  SmartTags: {uint_0.Length:X} item(s) [");
			for (int i = 0; i < uint_0.Length; i++)
			{
				if (i > 0)
				{
					stringBuilder.Append($", 0x{uint_0[i]}");
				}
				else
				{
					stringBuilder.Append($"0x{uint_0[i]}");
				}
			}
			stringBuilder.AppendLine("]");
		}
		return stringBuilder.ToString();
	}

	internal void method_3(uint testMask)
	{
	}

	internal bool method_4(Class2976 textSIException)
	{
		if (enum442_0 != textSIException.enum442_0)
		{
			return false;
		}
		if (enum442_0 == (Enum442)0)
		{
			return true;
		}
		if (method_5(Enum442.flag_0) && !class2967_0.method_3(textSIException.class2967_0))
		{
			return false;
		}
		if (method_5(Enum442.flag_1) && ushort_0 != textSIException.ushort_0)
		{
			return false;
		}
		if (method_5(Enum442.flag_2) && ushort_1 != textSIException.ushort_1)
		{
			return false;
		}
		if (method_5(Enum442.flag_4) && bool_0 != textSIException.bool_0)
		{
			return false;
		}
		if (method_5(Enum442.flag_3) && (byte_0 != textSIException.byte_0 || bool_1 != textSIException.bool_1))
		{
			return false;
		}
		if (method_5(Enum442.flag_6))
		{
			if (uint_0.Length != textSIException.uint_0.Length)
			{
				return false;
			}
			for (int i = 0; i < uint_0.Length; i++)
			{
				if (uint_0[i] != textSIException.uint_0[i])
				{
					return false;
				}
			}
		}
		return true;
	}

	protected bool method_5(Enum442 mask)
	{
		return (enum442_0 & mask) != 0;
	}

	protected void method_6(Enum442 mask, bool condition)
	{
		enum442_0 |= mask;
		if (!condition)
		{
			enum442_0 ^= mask;
		}
	}
}
