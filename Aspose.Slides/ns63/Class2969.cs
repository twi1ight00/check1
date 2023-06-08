using System;
using System.IO;
using System.Text;
using Aspose.Slides;
using ns60;

namespace ns63;

internal class Class2969 : Interface40
{
	private const Enum421 enum421_0 = (Enum421)65535;

	private Enum421 enum421_1;

	protected Enum422 enum422_0;

	protected ushort ushort_0 = ushort.MaxValue;

	protected ushort ushort_1 = ushort.MaxValue;

	protected ushort ushort_2 = ushort.MaxValue;

	protected ushort ushort_3 = ushort.MaxValue;

	protected short short_0;

	protected Class2966 class2966_0;

	protected short short_1;

	protected byte byte_0;

	protected Enum422[] enum422_1 = new Enum422[7]
	{
		Enum422.flag_0,
		Enum422.flag_1,
		Enum422.flag_2,
		Enum422.flag_4,
		Enum422.flag_5,
		Enum422.flag_7,
		Enum422.flag_9
	};

	public bool IsEmpty
	{
		get
		{
			return enum421_1 == (Enum421)0;
		}
		set
		{
			if (value)
			{
				enum421_1 = (Enum421)0;
				class2966_0 = null;
			}
		}
	}

	public void method_0(BinaryReader reader)
	{
		enum421_1 = (Enum421)reader.ReadUInt32();
		if (method_6((Enum421)15728639))
		{
			if (method_6((Enum421)65535))
			{
				enum422_0 = (Enum422)reader.ReadUInt16();
			}
			if (method_6(Enum421.flag_12))
			{
				ushort_0 = reader.ReadUInt16();
			}
			if (method_6(Enum421.flag_17))
			{
				ushort_1 = reader.ReadUInt16();
			}
			if (method_6(Enum421.flag_18))
			{
				ushort_2 = reader.ReadUInt16();
			}
			if (method_6(Enum421.flag_19))
			{
				ushort_3 = reader.ReadUInt16();
			}
			if (method_6(Enum421.flag_13))
			{
				short_0 = reader.ReadInt16();
			}
			if (method_6(Enum421.flag_14))
			{
				class2966_0 = new Class2966(reader.ReadUInt32());
			}
			if (method_6(Enum421.flag_15))
			{
				short_1 = reader.ReadInt16();
			}
		}
		if (method_6(Enum421.flag_16))
		{
			byte_0 = (byte)(reader.ReadUInt32() & 0xFu);
		}
	}

	public void method_1(BinaryWriter writer)
	{
		writer.Write((uint)enum421_1);
		if (method_6((Enum421)15728639))
		{
			if (method_6((Enum421)65535))
			{
				writer.Write((ushort)enum422_0);
			}
			if (method_6(Enum421.flag_12))
			{
				writer.Write(ushort_0);
			}
			if (method_6(Enum421.flag_17))
			{
				writer.Write(ushort_1);
			}
			if (method_6(Enum421.flag_18))
			{
				writer.Write(ushort_2);
			}
			if (method_6(Enum421.flag_19))
			{
				writer.Write(ushort_3);
			}
			if (method_6(Enum421.flag_13))
			{
				writer.Write(short_0);
			}
			if (method_6(Enum421.flag_14))
			{
				writer.Write(class2966_0.Struct);
			}
			if (method_6(Enum421.flag_15))
			{
				writer.Write(short_1);
			}
		}
		if (method_6(Enum421.flag_16))
		{
			writer.Write((uint)byte_0);
		}
	}

	public int method_2()
	{
		int num = 4;
		if (method_6((Enum421)15728639))
		{
			if (method_6((Enum421)65535))
			{
				num += 2;
			}
			if (method_6(Enum421.flag_12))
			{
				num += 2;
			}
			if (method_6(Enum421.flag_17))
			{
				num += 2;
			}
			if (method_6(Enum421.flag_18))
			{
				num += 2;
			}
			if (method_6(Enum421.flag_19))
			{
				num += 2;
			}
			if (method_6(Enum421.flag_13))
			{
				num += 2;
			}
			if (method_6(Enum421.flag_14))
			{
				num += 4;
			}
			if (method_6(Enum421.flag_15))
			{
				num += 2;
			}
		}
		if (method_6(Enum421.flag_16))
		{
			num += 4;
		}
		return num;
	}

	public void method_3(Class2969 textCFExceptionBase)
	{
		if (textCFExceptionBase == null)
		{
			return;
		}
		Enum421 @enum = textCFExceptionBase.enum421_1 ^ (textCFExceptionBase.enum421_1 & enum421_1);
		if ((@enum & Enum421.flag_24) != 0)
		{
			if ((@enum & (Enum421)65535) != 0)
			{
				enum422_0 |= textCFExceptionBase.enum422_0;
			}
			if ((@enum & Enum421.flag_12) != 0)
			{
				ushort_0 = textCFExceptionBase.ushort_0;
			}
			if ((@enum & Enum421.flag_17) != 0)
			{
				ushort_1 = textCFExceptionBase.ushort_1;
			}
			if ((@enum & Enum421.flag_18) != 0)
			{
				ushort_2 = textCFExceptionBase.ushort_2;
			}
			if ((@enum & Enum421.flag_19) != 0)
			{
				ushort_3 = textCFExceptionBase.ushort_3;
			}
			if ((@enum & Enum421.flag_13) != 0)
			{
				short_0 = textCFExceptionBase.short_0;
			}
			if ((@enum & Enum421.flag_14) != 0)
			{
				class2966_0 = (Class2966)textCFExceptionBase.class2966_0.Clone();
			}
			if ((@enum & Enum421.flag_15) != 0)
			{
				short_1 = textCFExceptionBase.short_1;
			}
		}
		if ((@enum & Enum421.flag_16) != 0)
		{
			byte_0 = textCFExceptionBase.byte_0;
		}
		enum421_1 |= textCFExceptionBase.enum421_1;
	}

	public virtual void vmethod_0(Class2969 textCFExceptionBase)
	{
		if (textCFExceptionBase == null)
		{
			return;
		}
		Enum421 @enum = textCFExceptionBase.enum421_1 & enum421_1;
		if ((@enum & Enum421.flag_24) == 0)
		{
			return;
		}
		if ((@enum & Enum421.flag_23) != 0)
		{
			if (enum422_0 == textCFExceptionBase.enum422_0)
			{
				method_7(Enum421.flag_23, condition: false);
			}
			else
			{
				for (int i = 0; i < enum422_1.Length; i++)
				{
					NullableBool nullableBool = method_8(enum422_1[i]);
					NullableBool nullableBool2 = textCFExceptionBase.method_8(enum422_1[i]);
					if (nullableBool != NullableBool.NotDefined && nullableBool == nullableBool2)
					{
						method_9(enum422_1[i], NullableBool.NotDefined);
					}
				}
			}
		}
		if ((@enum & Enum421.flag_12) != 0 && ushort_0 == textCFExceptionBase.ushort_0)
		{
			method_7(Enum421.flag_12, condition: false);
		}
		if ((@enum & Enum421.flag_17) != 0 && ushort_1 == textCFExceptionBase.ushort_1)
		{
			method_7(Enum421.flag_17, condition: false);
		}
		if ((@enum & Enum421.flag_18) != 0 && ushort_2 == textCFExceptionBase.ushort_2)
		{
			method_7(Enum421.flag_18, condition: false);
		}
		if ((@enum & Enum421.flag_19) != 0 && ushort_3 == textCFExceptionBase.ushort_3)
		{
			method_7(Enum421.flag_19, condition: false);
		}
		if ((@enum & Enum421.flag_13) != 0 && short_0 == textCFExceptionBase.short_0)
		{
			method_7(Enum421.flag_13, condition: false);
		}
		if ((@enum & Enum421.flag_14) != 0 && class2966_0.Struct == textCFExceptionBase.class2966_0.Struct)
		{
			method_7(Enum421.flag_14, condition: false);
		}
		if ((@enum & Enum421.flag_15) != 0 && short_1 == textCFExceptionBase.short_1)
		{
			method_7(Enum421.flag_15, condition: false);
		}
	}

	public override string ToString()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.AppendLine($"  CFMask: 0x{(uint)enum421_1:X}, {enum421_1}");
		if (method_6(Enum421.flag_24))
		{
			if (method_6(Enum421.flag_23))
			{
				stringBuilder.AppendLine($"  FontStyleMask   : 0x{(uint)enum422_0:X}, {enum422_0}");
				if (method_6(Enum421.flag_0))
				{
					stringBuilder.AppendLine($"  Bold     : {method_8(Enum422.flag_0) == NullableBool.True}");
				}
				if (method_6(Enum421.flag_1))
				{
					stringBuilder.AppendLine($"  Italic   : {method_8(Enum422.flag_1) == NullableBool.True}");
				}
				if (method_6(Enum421.flag_2))
				{
					stringBuilder.AppendLine($"  Underline: {method_8(Enum422.flag_2) == NullableBool.True}");
				}
				if (method_6(Enum421.flag_4))
				{
					stringBuilder.AppendLine($"  Shadow   : {method_8(Enum422.flag_4) == NullableBool.True}");
				}
				if (method_6(Enum421.flag_5))
				{
					stringBuilder.AppendLine($"  Fehint   : {method_8(Enum422.flag_5) == NullableBool.True}");
				}
				if (method_6(Enum421.flag_7))
				{
					stringBuilder.AppendLine($"  Kumi     : {method_8(Enum422.flag_7) == NullableBool.True}");
				}
				if (method_6(Enum421.flag_9))
				{
					stringBuilder.AppendLine($"  Emboss   : {method_8(Enum422.flag_9) == NullableBool.True}");
				}
				if (method_6(Enum421.flag_10))
				{
					stringBuilder.AppendLine($"  PP9RT    : 0x{(uint)(enum422_0 & Enum422.flag_10) >> 10:X}");
				}
			}
			if (method_6(Enum421.flag_12))
			{
				stringBuilder.AppendLine($"  FontRef: {ushort_0}");
			}
			if (method_6(Enum421.flag_17))
			{
				stringBuilder.AppendLine($"  OldEaFontRef: {ushort_1}");
			}
			if (method_6(Enum421.flag_18))
			{
				stringBuilder.AppendLine($"  AnsiFontRef: {ushort_2}");
			}
			if (method_6(Enum421.flag_19))
			{
				stringBuilder.AppendLine($"  SymbolFontRef: {ushort_3}");
			}
			if (method_6(Enum421.flag_13))
			{
				stringBuilder.AppendLine($"  FontSize: {short_0}");
			}
			if (method_6(Enum421.flag_14))
			{
				stringBuilder.AppendLine($"  Color: {class2966_0}");
			}
			if (method_6(Enum421.flag_15))
			{
				stringBuilder.Append($"  Position: {short_1}");
			}
		}
		if (method_6(Enum421.flag_16))
		{
			stringBuilder.Append($"  PP10RunID: {byte_0}");
		}
		return stringBuilder.ToString();
	}

	internal void method_4(uint testMask)
	{
	}

	internal bool method_5(Class2969 textCFException)
	{
		if (enum421_1 != textCFException.enum421_1)
		{
			return false;
		}
		if (enum421_1 == (Enum421)0)
		{
			return true;
		}
		if (method_6(Enum421.flag_10))
		{
			return false;
		}
		if (method_6((Enum421)65535) && enum422_0 != textCFException.enum422_0)
		{
			return false;
		}
		if (method_6(Enum421.flag_12) && ushort_0 != textCFException.ushort_0)
		{
			return false;
		}
		if (method_6(Enum421.flag_17) && ushort_1 != textCFException.ushort_1)
		{
			return false;
		}
		if (method_6(Enum421.flag_18) && ushort_2 != textCFException.ushort_2)
		{
			return false;
		}
		if (method_6(Enum421.flag_19) && ushort_3 != textCFException.ushort_3)
		{
			return false;
		}
		if (method_6(Enum421.flag_13) && short_0 != textCFException.short_0)
		{
			return false;
		}
		if (method_6(Enum421.flag_14) && class2966_0.Struct != textCFException.class2966_0.Struct)
		{
			return false;
		}
		if (method_6(Enum421.flag_15) && short_1 != textCFException.short_1)
		{
			return false;
		}
		if (method_6(Enum421.flag_16) && byte_0 != textCFException.byte_0)
		{
			return false;
		}
		return true;
	}

	protected bool method_6(Enum421 mask)
	{
		return (enum421_1 & mask) != 0;
	}

	protected void method_7(Enum421 mask, bool condition)
	{
		enum421_1 |= mask;
		if (!condition)
		{
			enum421_1 ^= mask;
		}
	}

	protected NullableBool method_8(Enum422 flag)
	{
		if (!method_6(method_10(flag)))
		{
			return NullableBool.NotDefined;
		}
		if ((enum422_0 & flag) == 0)
		{
			return NullableBool.False;
		}
		return NullableBool.True;
	}

	protected void method_9(Enum422 flag, NullableBool value)
	{
		Enum421 @enum = method_10(flag);
		if (value == NullableBool.NotDefined)
		{
			enum421_1 = (enum421_1 | @enum) ^ @enum;
			return;
		}
		enum421_1 |= @enum;
		enum422_0 |= flag;
		if (value == NullableBool.False)
		{
			enum422_0 ^= flag;
		}
	}

	private Enum421 method_10(Enum422 flag)
	{
		Enum421 @enum = (Enum421)(flag & (Enum422)32439);
		if (@enum == (Enum421)0)
		{
			throw new InvalidOperationException();
		}
		return @enum;
	}
}
